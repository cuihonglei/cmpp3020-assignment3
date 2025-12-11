using System;
using System.Text.Json.Serialization;

[Serializable]
public class ITEmployee : FullTimeEmployee
{
    [JsonInclude]
    private string? Specialization { get; set; }

    public ITEmployee() : base() { }

    public ITEmployee(string id, string firstName, string lastName, DateTime dob,
        string position, string department, double baseSalary, string benefits, string specialization)
        : base(id, firstName, lastName, dob, position, department, baseSalary, benefits)
    {
        if (department != "IT")
            throw new InvalidDataException("ITEmployee must belong to the IT department.");
        Specialization = specialization;
    }

    public override void ReportToManager()
    {
        if (Manager != null)
            Console.WriteLine($"{GetFullName()} (IT Employee, {Specialization}) reports to manager {Manager.GetFullName()}");
        else
            Console.WriteLine($"{GetFullName()} (IT Employee, {Specialization}) has no assigned manager.");
    }

    public void ShowSpecialization() => Console.WriteLine($"{GetFullName()}'s specialization: {Specialization}");
}
