import java.util.Date;

public abstract class FullTimeEmployee extends Employee {
    private double baseSalary;
    private String benefitsPackage;

    public FullTimeEmployee(String id, String firstName, String lastName, Date dob,
            String position, String department, double baseSalary, String benefits) throws InvalidDataException {
        super(id, firstName, lastName, dob, position, department);
        this.baseSalary = baseSalary;
        this.benefitsPackage = benefits;
    }

    @Override
    public double getAnnualSalary() {
        return baseSalary;
    }

    @Override
    public void reportToManager() {
        if (manager != null) {
            System.out.println(getFullName() + " (Full-Time) reports to manager " + manager.getFullName());
        } else {
            System.out.println(getFullName() + " (Full-Time) has no assigned manager.");
        }
    }
}