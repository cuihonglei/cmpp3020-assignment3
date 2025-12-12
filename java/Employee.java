import java.util.Arrays;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.io.Serializable;

public abstract class Employee implements Serializable {
    public String id;
    public String firstName;
    public String lastName;
    public Date dateOfBirth;
    public String position;
    public String department;

    // Make manager transient to avoid circular reference issues
    public transient Employee manager;

    // Global map: department -> allowed positions
    private static final Map<String, List<String>> departmentPositions = new HashMap<>();
    static {
        departmentPositions.put("Staff", Arrays.asList(
                "Senior Instructor", "Junior Instructor", "Adjunct Instructor", "Manager"));
        departmentPositions.put("Payroll", Arrays.asList(
                "Payroll Specialist", "Payroll Manager", "Manager"));
        departmentPositions.put("IT", Arrays.asList(
                "IT Support", "System Administrator", "Network Engineer", "Manager"));
        departmentPositions.put("Administration", Arrays.asList(
                "Admin Assistant", "Office Manager", "HR Specialist", "Manager"));
    }

    public Employee(String id, String firstName, String lastName, Date dob, String position, String department)
            throws InvalidDataException {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dob;
        this.position = position;
        this.department = department;

        // Validate position against department
        if (!isValidPositionForDepartment(position, department)) {
            throw new InvalidDataException("Invalid position " + position + " for department " + department);
        }
    }

    private boolean isValidPositionForDepartment(String position, String department) {
        List<String> validPositions = departmentPositions.get(department);
        return validPositions != null && validPositions.contains(position);
    }

    public String getFullName() {
        return firstName + " " + lastName;
    }

    public double getPaid() {
        // Static binding example: print monthly pay
        double monthlyPay = getAnnualSalary() / 12;
        System.out.println(getFullName() + "'s monthly pay is: " + monthlyPay);
        return monthlyPay;
    }

    // Overloaded method - static binding example (method overloading)
    public double getPaid(int months) {
        double customPay = getAnnualSalary() / 12 * months;
        System.out.println(getFullName() + "'s pay for " + months + " months is: " + customPay);
        return customPay;
    }

    public abstract double getAnnualSalary();

    public abstract void reportToManager();
}