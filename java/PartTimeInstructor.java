import java.util.Date;
import java.util.List;

public class PartTimeInstructor extends PartTimeEmployee {
    private String rank;
    private List<String> coursesTaught;

    public PartTimeInstructor(String id, String firstName, String lastName, Date dob,
            String position, String department,
            double hourlyRate, int hoursPerWeek, String rank, List<String> courses) throws InvalidDataException {

        super(id, firstName, lastName, dob, position, department, hourlyRate, hoursPerWeek);

        // Subclass-specific validation
        if (!"Staff".equals(department)) {
            throw new InvalidDataException("FullTimeInstructor must belong to the Staff department.");
        }

        // Only allow part-time positions
        if (!"Adjunct Instructor".equals(position)) {
            throw new InvalidDataException("Only 'Adjunct Instructor' can be part-time in Staff department.");
        }

        this.rank = rank;
        this.coursesTaught = courses;
    }

    @Override
    public void reportToManager() {
        if (manager != null) {
            System.out.println(getFullName() + " (" + rank + ", Part-Time Instructor) reports to manager "
                    + manager.getFullName());
        } else {
            System.out.println(getFullName() + " (" + rank + ", Part-Time Instructor) has no assigned manager.");
        }
    }

    public void submitGrades() {
        System.out.println(getFullName() + " (" + rank + ") submits grades.");
    }

    public void giveOfficeHours() {
        System.out.println(getFullName() + " (" + rank + ") gives office hours.");
    }

    public void showCoursesTaught() {
        System.out.println(getFullName() + " (" + rank + ") teaches:");

        if (coursesTaught == null || coursesTaught.isEmpty()) {
            System.out.println("  No courses assigned.");
            return;
        }

        for (String course : coursesTaught) {
            System.out.println("  - " + course);
        }
    }
}
