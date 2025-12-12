// File: Main.java
import java.util.*;

public class Main {
    public static void main(String[] args) {
        try {
            // ---------------------- Managers ----------------------
            Manager managerIT = new Manager(
                    "M001", "Alice", "Johnson", new Date(), "Manager", "IT",
                    90000, "Full Benefits", new ArrayList<>()
            );

            Manager managerAdmin = new Manager(
                    "M002", "Eve", "Williams", new Date(), "Manager", "Administration",
                    95000, "Full Benefits", new ArrayList<>()
            );

            // ---------------------- Full-Time Employees ----------------------
            FullTimeInstructor instructor = new FullTimeInstructor(
                    "I001", "Bob", "Smith", new Date(), "Senior Instructor", "Staff",
                    70000, "Standard Benefits", "Senior", Arrays.asList("CS101", "CS102")
            );

            PayrollEmployee payroll = new PayrollEmployee(
                    "P001", "Carol", "White", new Date(), "Payroll Specialist", "Payroll",
                    60000, "Basic Benefits"
            );

            ITEmployee itEmployee = new ITEmployee(
                    "IT001", "Frank", "Miller", new Date(), "System Administrator", "IT",
                    85000, "Full Benefits", "Networking"
            );

            AdminEmployee adminEmployee = new AdminEmployee(
                    "A001", "Grace", "Lee", new Date(), "Admin Assistant", "Administration",
                    65000, "Standard Benefits", "Top Secret"
            );

            // ---------------------- Part-Time Employees ----------------------
            PartTimeInstructor partTimer = new PartTimeInstructor(
                    "PT001", "David", "Brown", new Date(), "Adjunct Instructor", "Staff",
                    30, 15, "Junior", Arrays.asList("CS103")
            );

            // ---------------------- Setup Manager Relationships ----------------------
            instructor.manager = managerIT;
            payroll.manager = managerIT;
            itEmployee.manager = managerIT;

            adminEmployee.manager = managerAdmin;
            partTimer.manager = managerIT;

            managerIT.managedEmployees.addAll(Arrays.asList(instructor, payroll, itEmployee, partTimer));
            managerAdmin.managedEmployees.add(adminEmployee);

            // ---------------------- Demonstrate Employee Actions ----------------------
            System.out.println("---- Employee Annual Salaries ----");
            System.out.println(instructor.getFullName() + ": $" + instructor.getAnnualSalary());
            System.out.println(payroll.getFullName() + ": $" + payroll.getAnnualSalary());
            System.out.println(itEmployee.getFullName() + ": $" + itEmployee.getAnnualSalary());
            System.out.println(adminEmployee.getFullName() + ": $" + adminEmployee.getAnnualSalary());
            System.out.println(partTimer.getFullName() + ": $" + partTimer.getAnnualSalary());

            System.out.println("\n---- Static Binding: Method Overloading ----");
            instructor.getPaid();       // Calls getPaid() - no parameters
            instructor.getPaid(6);      // Calls getPaid(int) - overloaded version

            System.out.println("\n---- Reporting to Managers ----");
            instructor.reportToManager();
            payroll.reportToManager();
            itEmployee.reportToManager();
            adminEmployee.reportToManager();
            partTimer.reportToManager();

            System.out.println("\n---- Manager Approvals ----");
            managerIT.approveLeave(instructor);
            managerIT.approveLeave(payroll);
            managerAdmin.approveLeave(adminEmployee);

            System.out.println("\n---- Instructor Actions ----");
            instructor.submitGrades();
            instructor.giveOfficeHours();
            instructor.showCoursesTaught();
            partTimer.submitGrades();
            partTimer.giveOfficeHours();
            partTimer.showCoursesTaught();

            System.out.println("\n---- IT Employee and Admin Employee Details ----");
            itEmployee.showSpecialization();
            adminEmployee.showClearance();

            System.out.println("\n---- Payroll Deductions ----");
            try {
                payroll.calculateDeductions(instructor.getAnnualSalary());
                payroll.calculateDeductions(payroll.getAnnualSalary());
            } catch (MathOperationException e) {
                System.out.println("Payroll error: " + e.getMessage());
            }

            // ---------------------- Employee Management System ----------------------
            EmployeeManagementSystem ems = new EmployeeManagementSystem();
            List<Employee> allEmployees = Arrays.asList(managerIT, managerAdmin, instructor,
                    payroll, itEmployee, adminEmployee, partTimer);
            ems.loadDataFromList(allEmployees);

            System.out.println("\n---- Adding and Removing Employees ----");
            FullTimeInstructor newInstructor = new FullTimeInstructor(
                    "I002", "Helen", "Taylor", new Date(), "Junior Instructor", "Staff",
                    50000, "Standard Benefits", "Junior", Arrays.asList("CS201")
            );
            newInstructor.manager = managerIT;
            ems.addEmployee(newInstructor);
            ems.removeEmployee(partTimer);

            System.out.println("\n---- Saving and Loading Data ----");
            ems.saveDataToFile("employees.dat");

            // Add a short delay to ensure threads complete before loading
            Thread.sleep(1000);

            ems.loadDataFromFile("employees.dat");

        } catch (InvalidDataException e) {
            System.out.println("Invalid data error: " + e.getMessage());
        } catch (InterruptedException e) {
            System.out.println("Thread interrupted: " + e.getMessage());
        } catch (Exception e) {
            System.out.println("Unexpected error: " + e.getMessage());
        }
    }
}
