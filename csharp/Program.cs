using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // ---------------------- Managers ----------------------
            Manager managerIT = new Manager("M001", "Alice", "Johnson", DateTime.Now, "Manager", "IT", 90000, "Full Benefits", new List<Employee>());
            Manager managerAdmin = new Manager("M002", "Eve", "Williams", DateTime.Now, "Manager", "Administration", 95000, "Full Benefits", new List<Employee>());

            // ---------------------- Full-Time Employees ----------------------
            FullTimeInstructor instructor = new FullTimeInstructor("I001", "Bob", "Smith", DateTime.Now, "Senior Instructor", "Staff", 70000, "Standard Benefits", "Senior", new List<string>{"CS101","CS102"});
            PayrollEmployee payroll = new PayrollEmployee("P001", "Carol", "White", DateTime.Now, "Payroll Specialist", "Payroll", 60000, "Basic Benefits");
            ITEmployee itEmployee = new ITEmployee("IT001", "Frank", "Miller", DateTime.Now, "System Administrator", "IT", 85000, "Full Benefits", "Networking");
            AdminEmployee adminEmployee = new AdminEmployee("A001", "Grace", "Lee", DateTime.Now, "Admin Assistant", "Administration", 65000, "Standard Benefits", "Top Secret");

            // ---------------------- Part-Time Employees ----------------------
            PartTimeInstructor partTimer = new PartTimeInstructor("PT001", "David", "Brown", DateTime.Now, "Adjunct Instructor", "Staff", 30, 15, "Junior", new List<string>{"CS103"});

            // ---------------------- Setup Manager Relationships ----------------------
            instructor.Manager = managerIT;
            payroll.Manager = managerIT;
            itEmployee.Manager = managerIT;
            adminEmployee.Manager = managerAdmin;
            partTimer.Manager = managerIT;

            managerIT.ManagedEmployees?.AddRange(new List<Employee>{ instructor, payroll, itEmployee, partTimer });
            managerAdmin.ManagedEmployees?.Add(adminEmployee);

            // ---------------------- Demonstrate Employee Actions ----------------------
            Console.WriteLine("---- Employee Annual Salaries ----");
            Console.WriteLine($"{instructor.GetFullName()}: ${instructor.GetAnnualSalary()}");
            Console.WriteLine($"{payroll.GetFullName()}: ${payroll.GetAnnualSalary()}");
            Console.WriteLine($"{itEmployee.GetFullName()}: ${itEmployee.GetAnnualSalary()}");
            Console.WriteLine($"{adminEmployee.GetFullName()}: ${adminEmployee.GetAnnualSalary()}");
            Console.WriteLine($"{partTimer.GetFullName()}: ${partTimer.GetAnnualSalary()}");

            Console.WriteLine("\n---- Reporting to Managers ----");
            instructor.ReportToManager();
            payroll.ReportToManager();
            itEmployee.ReportToManager();
            adminEmployee.ReportToManager();
            partTimer.ReportToManager();

            Console.WriteLine("\n---- Manager Approvals ----");
            managerIT.ApproveLeave(instructor);
            managerIT.ApproveLeave(payroll);
            managerAdmin.ApproveLeave(adminEmployee);

            Console.WriteLine("\n---- Instructor Actions ----");
            instructor.SubmitGrades();
            instructor.GiveOfficeHours();
            instructor.ShowCoursesTaught();
            partTimer.SubmitGrades();
            partTimer.GiveOfficeHours();
            partTimer.ShowCoursesTaught();

            Console.WriteLine("\n---- IT Employee and Admin Employee Details ----");
            itEmployee.ShowSpecialization();
            adminEmployee.ShowClearance();

            Console.WriteLine("\n---- Payroll Deductions ----");
            payroll.CalculateDeductions(instructor.GetAnnualSalary());
            payroll.CalculateDeductions(payroll.GetAnnualSalary());

            // ---------------------- Employee Management System ----------------------
            EmployeeManagementSystem ems = new EmployeeManagementSystem();
            List<Employee> allEmployees = new List<Employee> { managerIT, managerAdmin, instructor, payroll, itEmployee, adminEmployee, partTimer };
            ems.LoadDataFromList(allEmployees);

            Console.WriteLine("\n---- Adding and Removing Employees ----");
            FullTimeInstructor newInstructor = new FullTimeInstructor("I002", "Helen", "Taylor", DateTime.Now, "Junior Instructor", "Staff", 50000, "Standard Benefits", "Junior", new List<string>{"CS201"});
            newInstructor.Manager = managerIT;
            ems.AddEmployee(newInstructor);
            ems.RemoveEmployee(partTimer);

            Console.WriteLine("\n---- Saving and Loading Data ----");
            ems.SaveDataToFile("employees.dat");

            Thread.Sleep(1000); // Ensure threads complete before loading
            ems.LoadDataFromFile("employees.dat");
        }
        catch (InvalidDataException e)
        {
            Console.WriteLine($"Invalid data error: {e.Message}");
        }
        catch (MathOperationException e)
        {
            Console.WriteLine($"Payroll error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}
