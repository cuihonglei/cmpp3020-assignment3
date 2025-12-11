import java.util.Date;
import java.util.List;

public class Manager extends FullTimeEmployee {
    public List<Employee> managedEmployees;

    public Manager(String id, String firstName, String lastName, Date dob, String position, String department,
            double baseSalary, String benefits, List<Employee> managedEmployees) throws InvalidDataException {
        super(id, firstName, lastName, dob, position, department, baseSalary, benefits);
        this.managedEmployees = managedEmployees;
    }

    @Override
    public void reportToManager() {
        if (manager != null) {
            System.out.println(getFullName() + " (Manager) reports to manager " + manager.getFullName());
        } else {
            System.out.println(getFullName() + " (Manager) has no assigned manager.");
        }
    }

    public void approveLeave(Employee e) {
        System.out.println("Manager " + getFullName() + " approves leave for " + e.getFullName());
    }
}