using System;

[Serializable]
public abstract class FullTimeEmployee : Employee
{
    public double BaseSalary { get; set; }
    public string BenefitsPackage { get; set; }

    protected FullTimeEmployee() { }

    protected FullTimeEmployee(string id, string firstName, string lastName, DateTime dob,
        string position, string department, double baseSalary, string benefits)
        : base(id, firstName, lastName, dob, position, department)
    {
        BaseSalary = baseSalary;
        BenefitsPackage = benefits;
    }

    public override double GetAnnualSalary() => BaseSalary;

    public override void ReportToManager()
    {
        if (Manager != null)
            Console.WriteLine($"{GetFullName()} (Full-Time) reports to manager {Manager.GetFullName()}");
        else
            Console.WriteLine($"{GetFullName()} (Full-Time) has no assigned manager.");
    }
}
