namespace EmployerApp.HR;

public class Manager: Employee
{
    public Manager(string? firstName, string? lastName, string? email, DateTime birthDay, double hourlyRate = 12) : base(firstName, lastName, "Manager", email, birthDay, hourlyRate)
    {
    }

    public Manager(string? firstName, string? lastName, string? email, DateTime birthDay, string country, string city, string street, string zip, double hourlyRate = 12) : base(firstName, lastName, "Manager", email, birthDay, country, city, street, zip, hourlyRate)
    {
    }

    public void MakeAMeeting()
    {
        Console.WriteLine($"Manager {FirstName} {LastName} had an 8 hour meeting!");
        HoursOfWork += 8;
    }

    public override void GetBonus(int hoursOfWork, double hourlyRate)
    {
        double bonusRate = 0.15;
        if (hoursOfWork > 8)
        {
            Bonus += (hourlyRate * hoursOfWork) * bonusRate;
        }
    }
}