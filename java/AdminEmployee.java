import java.util.Date;

public class AdminEmployee extends FullTimeEmployee {
    private String clearance;

    public AdminEmployee(String id, String firstName, String lastName, Date dob,
            String position, String department, double baseSalary, String benefits,
            String clearance) throws InvalidDataException {
        super(id, firstName, lastName, dob, position, department, baseSalary, benefits);

        // Subclass-specific validation
        if (!"Administration".equals(department)) {
            throw new InvalidDataException("AdminEmployee must belong to the Administration department.");
        }

        this.clearance = clearance;
    }

    @Override
    public void reportToManager() {
        if (manager != null) {
            System.out.println(getFullName() + " (Admin Employee, clearance: " + clearance + ") reports to manager "
                    + manager.getFullName());
        } else {
            System.out.println(
                    getFullName() + " (Admin Employee, clearance: " + clearance + ") has no assigned manager.");
        }
    }

    public void showClearance() {
        System.out.println(getFullName() + "'s clearance level: " + clearance);
    }
}