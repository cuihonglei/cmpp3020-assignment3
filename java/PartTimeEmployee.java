import java.util.Date;

public abstract class PartTimeEmployee extends Employee {
    private double hourlyRate;
    private int hoursPerWeek;

    public PartTimeEmployee(String id, String firstName, String lastName, Date dob,
            String position, String department, double hourlyRate, int hours) throws InvalidDataException {
        super(id, firstName, lastName, dob, position, department);
        this.hourlyRate = hourlyRate;
        this.hoursPerWeek = hours;
    }

    @Override
    public double getAnnualSalary() {
        return hourlyRate * hoursPerWeek * 52;
    }

    @Override
    public void reportToManager() {
        if (manager != null) {
            System.out.println(getFullName() + " (Part-Time) reports to manager " + manager.getFullName());
        } else {
            System.out.println(getFullName() + " (Part-Time) has no assigned manager.");
        }
    }
}