using System.Text;
using EmployerApp.HR;

namespace EmployerApp;

internal static class Utilities
{
    private const string Directory = @"X:\data\TestPhr\";
    private const string FileName = "employees.txt";

    internal static void CheckForExistingEmployeeFile()
    {
        const string path = $"{Directory}{FileName}";
        bool existingFileFound = File.Exists(path);

        if (existingFileFound) 
            Console.WriteLine("An existing file with Employee data is found");
        else
        {
            if (System.IO.Directory.Exists(Directory)) return;
            
            System.IO.Directory.CreateDirectory(Directory);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Directory is ready for saving files.");
            Console.ResetColor();
        }
    }

    internal static void RegisterEmployee(List<Employee> employees)
    {
        Console.WriteLine("Creating an employee");

        Console.WriteLine("What type of employee do you want to register?");
        Console.WriteLine("1. Manager\n2. Store manager\n3. Researcher\n4. Junior researcher\n5. Developer");
        Console.Write("Your selection: ");
        var success = int.TryParse(Console.ReadLine(), out var employeeType);

        if (!success && employeeType < 0 || !success && employeeType > 5)
        {
            Console.WriteLine("Invalid selection!");
            return;
        }

        Console.Write("Enter the first name: ");
        var firstName = Console.ReadLine();
        
        Console.Write("Enter the last name: ");
        var lastName = Console.ReadLine();
        
        Console.Write("Enter the email: ");
        var email = Console.ReadLine();
        
        Console.Write("Enter the birthday: ");
        var birthDay = DateTime.Parse(Console.ReadLine() ?? "2000/01/01");
        
        Console.Write("Enter the hourly rate: ");
        var hourlyRate = double.Parse(Console.ReadLine() ?? "12");

        string? currentProject = null!;

        if (employeeType == 5)
        {
            Console.Write("Enter the current project: ");
            currentProject = Console.ReadLine();
        }

        Employee employee = null!;

        switch (employeeType)
        {
            case 1:
                employee = new Manager(firstName, lastName, email, birthDay, hourlyRate);
                break;
            case 2:
                employee = new StoreManager(firstName, lastName, email, birthDay, hourlyRate);
                break;
            case 3:
                employee = new Researcher(firstName, lastName, email, birthDay, hourlyRate);
                break;
            case 4:
                employee = new JuniorResearcher(firstName, lastName, email, birthDay, hourlyRate);
                break;
            case 5:
                employee = new Developer(firstName, lastName, email, birthDay, currentProject, hourlyRate);
                break;
        }
        
        employees.Add(employee);

        Console.WriteLine("Employee created!\n\n");
    }
    
    internal static void ViewAllEmployees(List<Employee> employees)
    {
        for (int i = 0; i < employees.Count; i++)
        {
            employees[i].DisplayEmployeeInfo();
        }
    }
    
    internal static void SaveEmployees(List<Employee> employees)
    {
        string path = $"{Directory}{FileName}";
        StringBuilder sb = new StringBuilder();
        foreach (var employee in employees)
        {
            string type = GetEmployeeType(employee);
                
            sb.Append($"firstName:{employee.FirstName};");
            sb.Append($"lastName:{employee.LastName};");
            sb.Append($"email:{employee.Email};");
            sb.Append($"birthDay:{employee.BirthDay};");
            sb.Append($"hourlyRate:{employee.HourlyRate};");
            if (type == "5")
            {
                sb.Append($"currentProject:{employee.CurrentProject};");
            }
            sb.Append($"type:{type};");

            sb.Append(Environment.NewLine);
        }
        
        File.WriteAllText(path, sb.ToString());
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Saved employees successfully");
        Console.ResetColor();
    }
    
    private static string GetEmployeeType(Employee employee)
    {
        string type = employee switch
        {
            Manager => "1", StoreManager => "2", JuniorResearcher => "4", Researcher => "3", Developer => "5"
        };

        return type;
    }
    
    internal static void LoadEmployees(List<Employee> employees)
    {
        string path = $"{Directory}{FileName}";
        if (File.Exists(path))
        {
            employees.Clear();

            string[] employeesStrings = File.ReadAllLines(path);
            string currentProject = null!;
            for (int i = 0; i < employeesStrings.Length; i++)
            {
                string[] employeeSplits = employeesStrings[i].Split(';');
                string firstName = employeeSplits[0].Substring(employeeSplits[0].IndexOf(':') + 1);
                string lastName = employeeSplits[1].Substring(employeeSplits[1].IndexOf(':') + 1);
                string email = employeeSplits[2].Substring(employeeSplits[2].IndexOf(':') + 1);
                DateTime birthDay = DateTime.Parse(employeeSplits[3].Substring(employeeSplits[3].IndexOf(':') + 1));
                double hourlyRate = double.Parse(employeeSplits[4].Substring(employeeSplits[4].IndexOf(':') + 1));
                string employeeType;
                if (employeeSplits.Length == 8)
                {
                    currentProject = employeeSplits[5].Substring(employeeSplits[5].IndexOf(':') + 1);
                    employeeType = employeeSplits[6].Substring(employeeSplits[6].IndexOf(':') + 1);
                }
                else
                {
                    employeeType = employeeSplits[5].Substring(employeeSplits[5].IndexOf(':') + 1);
                }

                Employee employee = null!;

                switch (employeeType)
                {
                    case "1":
                        employee = new Manager(firstName, lastName, email, birthDay, hourlyRate);
                        break;
                    case "2":
                        employee = new StoreManager(firstName, lastName, email, birthDay, hourlyRate);
                        break;
                    case "3":
                        employee = new Researcher(firstName, lastName, email, birthDay, hourlyRate);
                        break;
                    case "4":
                        employee = new JuniorResearcher(firstName, lastName, email, birthDay, hourlyRate);
                        break;
                    case "5":
                        employee = new Developer(firstName, lastName, email, birthDay, currentProject, hourlyRate);
                        break;
                }
                
                employees.Add(employee);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {employees.Count} employees!\n\n");
            Console.WriteLine(employees[0]);
            Console.ResetColor();

        }
    }
}