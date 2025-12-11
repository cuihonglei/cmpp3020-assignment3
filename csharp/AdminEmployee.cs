using System;
using System.Text.Json.Serialization;

[Serializable]
public class AdminEmployee : FullTimeEmployee
{
    [JsonInclude]
    private string Clearance { get; set; }

    public AdminEmployee() : base() { }

    public AdminEmployee(string id, string firstName, string lastName, DateTime dob,
        string position, string department, double baseSalary, string benefits, string clearance)
        : base(id, firstName, lastName, dob, position, department, baseSalary, benefits)
    {
        if (department != "Administration")
            throw new InvalidDataException("AdminEmployee must belong to the Administration department.");
        Clearance = clearance;
    }

    public override void ReportToManager()
    {
        if (Manager != null)
            Console.WriteLine($"{GetFullName()} (Admin Employee, clearance: {Clearance}) reports to manager {Manager.GetFullName()}");
        else
            Console.WriteLine($"{GetFullName()} (Admin Employee, clearance: {Clearance}) has no assigned manager.");
    }

    public void ShowClearance() => Console.WriteLine($"{GetFullName()}'s clearance level: {Clearance}");
}
