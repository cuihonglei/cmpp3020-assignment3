using System;
using System.Collections.Generic;

[Serializable]
public class FullTimeInstructor : FullTimeEmployee
{
    private string Rank { get; set; }
    private List<string> CoursesTaught { get; set; }

    public FullTimeInstructor() : base() { }

    public FullTimeInstructor(string id, string firstName, string lastName, DateTime dob,
        string position, string department, double baseSalary, string benefits,
        string rank, List<string> courses)
        : base(id, firstName, lastName, dob, position, department, baseSalary, benefits)
    {
        if (department != "Staff")
            throw new InvalidDataException("FullTimeInstructor must belong to the Staff department.");
        if (position == "Adjunct Instructor")
            throw new InvalidDataException("Adjunct Instructor cannot be full-time; use PartTimeInstructor instead.");

        Rank = rank;
        CoursesTaught = courses;
    }

    public override void ReportToManager()
    {
        if (Manager != null)
            Console.WriteLine($"{GetFullName()} ({Rank}, Full-Time Instructor) reports to manager {Manager.GetFullName()}");
        else
            Console.WriteLine($"{GetFullName()} ({Rank}, Full-Time Instructor) has no assigned manager.");
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
