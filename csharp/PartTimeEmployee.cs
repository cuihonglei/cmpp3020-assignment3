using System;

[Serializable]
public abstract class PartTimeEmployee : Employee
{
    private double HourlyRate { get; set; }
    private int HoursPerWeek { get; set; }

    protected PartTimeEmployee() { }

    protected PartTimeEmployee(string id, string firstName, string lastName, DateTime dob,
        string position, string department, double hourlyRate, int hoursPerWeek)
        : base(id, firstName, lastName, dob, position, department)
    {
        HourlyRate = hourlyRate;
        HoursPerWeek = hoursPerWeek;
    }

    public override double GetAnnualSalary() => HourlyRate * HoursPerWeek * 52;

    public override void ReportToManager()
    {
        if (Manager != null)
            Console.WriteLine($"{GetFullName()} (Part-Time) reports to manager {Manager.GetFullName()}");
        else
            Console.WriteLine($"{GetFullName()} (Part-Time) has no assigned manager.");
    }
}
