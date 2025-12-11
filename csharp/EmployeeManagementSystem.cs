using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

public class EmployeeManagementSystem
{
    private List<Employee> employeeList = new();
    private readonly object lockObj = new();

    public void SaveDataToFile(string fileName)
    {
        Thread saveThread = new(() =>
        {
            lock (lockObj)
            {
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        IncludeFields = true,
                        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve // handles circular references
                    };
                    string json = JsonSerializer.Serialize(employeeList, options);
                    File.WriteAllText(fileName, json);
                    Console.WriteLine($"Data saved successfully in thread: {Thread.CurrentThread.ManagedThreadId}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error saving file: {e.Message}");
                }
            }
        });
        saveThread.Start();
    }

    public void LoadDataFromFile(string fileName)
    {
        Thread loadThread = new(() =>
        {
            lock (lockObj)
            {
                try
                {
                    string json = File.ReadAllText(fileName);
                    var options = new JsonSerializerOptions
                    {
                        IncludeFields = true,
                        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
                    };
                    employeeList = JsonSerializer.Deserialize<List<Employee>>(json, options) ?? new List<Employee>();
                    Console.WriteLine($"Data loaded successfully in thread: {Thread.CurrentThread.ManagedThreadId}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error loading file: {e.Message}");
                }
            }
        });
        loadThread.Start();
    }

    public void LoadDataFromList(List<Employee> list)
    {
        lock (lockObj)
        {
            employeeList = new List<Employee>(list);
        }
    }

    public void AddEmployee(Employee e)
    {
        lock (lockObj)
        {
            employeeList.Add(e);
            Console.WriteLine($"Added employee: {e.GetFullName()}");
        }
    }

    public void RemoveEmployee(Employee e)
    {
        lock (lockObj)
        {
            if (employeeList.Remove(e))
                Console.WriteLine($"Removed employee: {e.GetFullName()}");
            else
                Console.WriteLine($"Employee not found: {e.GetFullName()}");
        }
    }

    public List<Employee> GetEmployeeList()
    {
        lock (lockObj)
        {
            return new List<Employee>(employeeList);
        }
    }
}
