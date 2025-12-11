using System;

[Serializable]
public class PayrollEmployee : FullTimeEmployee
{

    public PayrollEmployee() : base() { }

    public PayrollEmployee(string id, string firstName, string lastName, DateTime dob,
        string position, string department, double baseSalary, string benefits)
        : base(id, firstName, lastName, dob, position, department, baseSalary, benefits)
    {
        if (department != "Payroll")
            throw new InvalidDataException("PayrollEmployee must belong to the Payroll department.");
    }

    public override void ReportToManager()
    {
        if (Manager != null)
            Console.WriteLine($"{GetFullName()} (Payroll Employee) reports to manager {Manager.GetFullName()}");
        else
            Console.WriteLine($"{GetFullName()} (Payroll Employee) has no assigned manager.");
    }

    public double CalculateDeductions(double salary)
    {
        if (salary < 0)
            throw new MathOperationException("Error: Salary cannot be negative.");
        if (salary == 0)
            throw new MathOperationException("Error: Salary cannot be zero for deduction calculation.");

        double deduction = salary * 0.2;
        if (double.IsInfinity(deduction) || double.IsNaN(deduction))
            throw new MathOperationException("Error: Invalid deduction calculation.");

        Console.WriteLine($"Calculating deductions for salary ${salary}: ${deduction}");
        return deduction;
    }
}
