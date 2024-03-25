using EmployerApp;
using EmployerApp.HR;

List<Employee> employees = new List<Employee>();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("***************************");
Console.WriteLine("*Employee registration app*");
Console.WriteLine("***************************");
Console.ForegroundColor = ConsoleColor.White;
int userSelection;
Console.ForegroundColor = ConsoleColor.Blue;

Utilities.CheckForExistingEmployeeFile();

do
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Loaded {employees.Count} employee(s)\n\n");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("******************");
    Console.WriteLine("*Select an action*");
    Console.WriteLine("******************");

    Console.WriteLine("1: Register employee");
    Console.WriteLine("2: View all employees");
    Console.WriteLine("3: Save data");
    Console.WriteLine("4: Load data");
    Console.WriteLine("9: Quiet application");
    Console.Write("Your selection: ");

    int.TryParse(Console.ReadLine(), out userSelection);
    switch (userSelection)
    {
        case 1:
            Utilities.RegisterEmployee(employees);
            break;
        case 2:
            Utilities.ViewAllEmployees(employees);
            break;
        case 3:
            Utilities.SaveEmployees(employees);
            break;
        case 4:
            Utilities.LoadEmployees(employees);
            break;
        case 9: break;
        default:
            Console.WriteLine($"Invalid selection. Please try again.");
            break;
    }

} while (userSelection != 9);