using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

[Serializable]
// Add all concrete subclasses that inherit from Employee
[JsonDerivedType(typeof(AdminEmployee), typeDiscriminator: "admin")]
[JsonDerivedType(typeof(FullTimeInstructor), typeDiscriminator: "ft_instructor")]
[JsonDerivedType(typeof(ITEmployee), typeDiscriminator: "it")]
[JsonDerivedType(typeof(Manager), typeDiscriminator: "manager")]
[JsonDerivedType(typeof(PartTimeInstructor), typeDiscriminator: "pt_instructor")]
[JsonDerivedType(typeof(PayrollEmployee), typeDiscriminator: "payroll")]
public abstract class Employee
{
    public string? Id { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string? Position { get; set; }
    public string? Department { get; set; }

    // Manager reference (transient equivalent not needed in C# serialization unless using BinaryFormatter)
    public Employee? Manager { get; set; }

    // Parameterless constructor for JSON deserialization (must be protected for derived classes)
    protected Employee() { }

    private static readonly Dictionary<string, List<string>> DepartmentPositions = new()
    {
        { "Staff", new List<string>{ "Senior Instructor", "Junior Instructor", "Adjunct Instructor", "Manager" } },
        { "Payroll", new List<string>{ "Payroll Specialist", "Payroll Manager", "Manager" } },
        { "IT", new List<string>{ "IT Support", "System Administrator", "Network Engineer", "Manager" } },
        { "Administration", new List<string>{ "Admin Assistant", "Office Manager", "HR Specialist", "Manager" } }
    };

    protected Employee(string id, string firstName, string lastName, DateTime dob, string position, string department)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dob;
        Position = position;
        Department = department;

        if (!IsValidPositionForDepartment(position, department))
        {
            throw new InvalidDataException($"Invalid position {position} for department {department}");
        }
    }

    private bool IsValidPositionForDepartment(string position, string department)
    {
        return DepartmentPositions.ContainsKey(department) && DepartmentPositions[department].Contains(position);
    }

    public string GetFullName() => $"{FirstName} {LastName}";

    public double GetPaid()
    {
        double monthlyPay = GetAnnualSalary() / 12;
        Console.WriteLine($"{GetFullName()}'s monthly pay is: {monthlyPay}");
        return monthlyPay;
    }

    // Overloaded method - static binding example (method overloading)
    public double GetPaid(int months)
    {
        double customPay = GetAnnualSalary() / 12 * months;
        Console.WriteLine($"{GetFullName()}'s pay for {months} months is: {customPay}");
        return customPay;
    }

    public abstract double GetAnnualSalary();

    public abstract void ReportToManager();
}
