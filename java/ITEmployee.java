import java.util.Date;

public class ITEmployee extends FullTimeEmployee {
    private String specialization;

    public ITEmployee(String id, String firstName, String lastName, Date dob,
            String position, String department, double baseSalary, String benefits,
            String specialization) throws InvalidDataException {
        super(id, firstName, lastName, dob, position, department, baseSalary, benefits);

        // Subclass-specific validation
        if (!"IT".equals(department)) {
            throw new InvalidDataException("ITEmployee must belong to the IT department.");
        }
        
        this.specialization = specialization;
    }

    @Override
    public void reportToManager() {
        if (manager != null) {
            System.out.println(getFullName() + " (IT Employee, " + specialization + ") reports to manager "
                    + manager.getFullName());
        } else {
            System.out.println(getFullName() + " (IT Employee, " + specialization + ") has no assigned manager.");
        }
    }

    public void showSpecialization() {
        System.out.println(getFullName() + "'s specialization: " + specialization);
    }
}