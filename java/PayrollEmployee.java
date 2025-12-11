import java.util.Date;

public class PayrollEmployee extends FullTimeEmployee {

    public PayrollEmployee(String id, String firstName, String lastName, Date dob,
            String position, String department, double baseSalary, String benefits) throws InvalidDataException {
        super(id, firstName, lastName, dob, position, department, baseSalary, benefits);

        // Subclass-specific validation
        if (!"Payroll".equals(department)) {
            throw new InvalidDataException("PayrollEmployee must belong to the Payroll department.");
        }
    }

    @Override
    public void reportToManager() {
        if (manager != null) {
            System.out.println(getFullName() + " (Payroll Employee) reports to manager "
                    + manager.getFullName());
        } else {
            System.out.println(getFullName() + " (Payroll Employee) has no assigned manager.");
        }
    }

    // Calculate and print deductions for another employee's salary
    public double calculateDeductions(double salary) throws MathOperationException {

        // Exception conditions
        if (salary < 0) {
            throw new MathOperationException("Error: Salary cannot be negative.");
        }

        if (salary == 0) {
            throw new MathOperationException("Error: Salary cannot be zero for deduction calculation.");
        }

        double deduction = salary * 0.20;

        // Validate calculation result
        if (Double.isInfinite(deduction) || Double.isNaN(deduction)) {
            throw new MathOperationException("Error: Invalid deduction calculation.");
        }

        System.out.println("Calculating deductions for salary $" + salary
                + ": $" + deduction);

        return deduction;
    }
}
