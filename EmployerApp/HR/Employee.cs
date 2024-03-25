using EmployerApp.Data;

namespace EmployerApp.HR;

public abstract class Employee: IEmployee
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string EmployeeType { get; init; }
    public Address Address { get; set; }
    public DateTime BirthDay { get; }
    public double HourlyRate { get; }
    public double Wage { get; protected set; }
    public double TotalWage { get; private set; }
    public int HoursOfWork { get; protected set; }
    public double Bonus { get; protected set; } 
    private const double TaxRate = 0.13;
    public double ExtraBonus { get; protected set; }
    public string? CurrentProject { get; protected set; }

    protected Employee(string? firstName, string? lastName, string employeeType, string? email, DateTime birthDay, double hourlyRate = 12)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        EmployeeType = employeeType;
        BirthDay = birthDay;
        HourlyRate = hourlyRate;
    }

    protected Employee(string? firstName, string? lastName, string employeeType, string? email, DateTime birthDay, string country, string city, string street, string zip, double hourlyRate = 12)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        EmployeeType = employeeType;
        BirthDay = birthDay;
        Address = new Address(country, city, street, zip);
        HourlyRate = hourlyRate;
    }

    public void DisplayEmployeeInfo()
    {
        Console.WriteLine($"First name:\t{FirstName}\nLast name:\t{LastName}\nEmployee type:\t{EmployeeType}\nEmail:\t{Email}\nDate of Birth:\t{BirthDay.ToShortDateString()}\nHourly rate:\t{HourlyRate}\nTotal wage:\t{TotalWage}");
    }

    public void PerformWork()
    {
        const int hours = 1;
        PerformWork(hours);
    }

    public virtual void PerformWork(int hours)
    {
        Console.WriteLine($"{FirstName} {LastName} has worked for {hours} hours!");
        HoursOfWork += hours;
        GetBonus(hours, HourlyRate);
    }

    public virtual void GetBonus(int hoursOfWork, double hourlyRate)
    {
        var bonusRate = 0.15;
        if (hoursOfWork > 12)
        {
          Bonus += (hourlyRate * hoursOfWork) * bonusRate;
        }
    }

    public void ReceiveWage()
    {
        var tax = (HourlyRate * HoursOfWork) * TaxRate;
        Wage = (HourlyRate * HoursOfWork + Bonus + ExtraBonus) - tax;
        TotalWage += Wage;

        Console.WriteLine($"{FirstName} {LastName} received a wage in the amount of {Wage}");
        
        Wage = 0;
        ExtraBonus = 0;
    }
}