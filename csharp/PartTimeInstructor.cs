using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

[Serializable]
public class PartTimeInstructor : PartTimeEmployee
{
    [JsonInclude]
    private string? Rank { get; set; }
    [JsonInclude]
    private List<string>? CoursesTaught { get; set; }

    public PartTimeInstructor() : base() { }

    public PartTimeInstructor(string id, string firstName, string lastName, DateTime dob,
        string position, string department, double hourlyRate, int hoursPerWeek, string rank, List<string> courses)
        : base(id, firstName, lastName, dob, position, department, hourlyRate, hoursPerWeek)
    {
        if (department != "Staff")
            throw new InvalidDataException("PartTimeInstructor must belong to the Staff department.");
        if (position != "Adjunct Instructor")
            throw new InvalidDataException("Only 'Adjunct Instructor' can be part-time in Staff department.");

        Rank = rank;
        CoursesTaught = courses;
    }

    public override void ReportToManager()
    {
        if (Manager != null)
            Console.WriteLine($"{GetFullName()} ({Rank}, Part-Time Instructor) reports to manager {Manager.GetFullName()}");
        else
            Console.WriteLine($"{GetFullName()} ({Rank}, Part-Time Instructor) has no assigned manager.");
    }

    public void SubmitGrades() => Console.WriteLine($"{GetFullName()} ({Rank}) submits grades.");
    public void GiveOfficeHours() => Console.WriteLine($"{GetFullName()} ({Rank}) gives office hours.");
    public void ShowCoursesTaught()
    {
        Console.WriteLine($"{GetFullName()} ({Rank}) teaches:");
        if (CoursesTaught == null || CoursesTaught.Count == 0)
            Console.WriteLine("  No courses assigned.");
        else
            CoursesTaught.ForEach(c => Console.WriteLine($"  - {c}"));
    }
}
