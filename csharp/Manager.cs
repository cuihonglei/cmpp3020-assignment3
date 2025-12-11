using System;
using System.Collections.Generic;

[Serializable]
public class Manager : FullTimeEmployee
{
    public List<Employee>? ManagedEmployees { get; set; }

    public Manager() : base() { }

    public Manager(string id, string firstName, string lastName, DateTime dob, string position, string department,
        double baseSalary, string benefits, List<Employee> managedEmployees)
        : base(id, firstName, lastName, dob, position, department, baseSalary, benefits)
    {
        ManagedEmployees = managedEmployees;
    }

    public override void ReportToManager()
    {
        if (Manager != null)
            Console.WriteLine($"{GetFullName()} (Manager) reports to manager {Manager.GetFullName()}");
        else
            Console.WriteLine($"{GetFullName()} (Manager) has no assigned manager.");
    }

    public void ApproveLeave(Employee e)
    {
        Console.WriteLine($"Manager {GetFullName()} approves leave for {e.GetFullName()}");
    }
}
