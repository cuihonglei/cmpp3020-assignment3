import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class EmployeeManagementSystem {
    private List<Employee> employeeList = new ArrayList<>();

    // Object for synchronization
    private final Object lock = new Object();

    // Save data in a separate thread
    public void saveDataToFile(String fileName) {
        Runnable saveTask = () -> {
            synchronized (lock) {
                try (ObjectOutputStream oos = new ObjectOutputStream(new FileOutputStream(fileName))) {
                    oos.writeObject(employeeList);
                    System.out.println("Data saved successfully in thread: " + Thread.currentThread().getName());
                } catch (IOException e) {
                    System.out.println("Error saving file: " + e.getMessage());
                }
            }
        };
        new Thread(saveTask).start();
    }

    // Load data in a separate thread
    public void loadDataFromFile(String fileName) {
        @SuppressWarnings("unchecked")
        Runnable loadTask = () -> {
            synchronized (lock) {
                try (ObjectInputStream ois = new ObjectInputStream(new FileInputStream(fileName))) {
                    employeeList = (List<Employee>) ois.readObject();
                    System.out.println("Data loaded successfully in thread: " + Thread.currentThread().getName());
                } catch (IOException | ClassNotFoundException e) {
                    System.out.println("Error loading file: " + e.getMessage());
                }
            }
        };
        new Thread(loadTask).start();
    }

    // Load data from a provided list
    public void loadDataFromList(List<Employee> list) {
        synchronized (lock) {
            this.employeeList = new ArrayList<>(list);
        }
    }

    // Add employee
    public void addEmployee(Employee e) {
        synchronized (lock) {
            employeeList.add(e);
            System.out.println("Added employee: " + e.getFullName());
        }
    }

    // Remove employee
    public void removeEmployee(Employee e) {
        synchronized (lock) {
            if (employeeList.remove(e)) {
                System.out.println("Removed employee: " + e.getFullName());
            } else {
                System.out.println("Employee not found: " + e.getFullName());
            }
        }
    }

    // Get a snapshot of employee list
    public List<Employee> getEmployeeList() {
        synchronized (lock) {
            return new ArrayList<>(employeeList);
        }
    }
}
