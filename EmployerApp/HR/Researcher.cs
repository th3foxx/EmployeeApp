namespace EmployerApp.HR;

public class Researcher: Employee
{
    public Researcher(string? firstName, string? lastName, string? email, DateTime birthDay, double hourlyRate = 12) : base(firstName, lastName, "Researcher", email, birthDay, hourlyRate)
    {
    }

    public Researcher(string? firstName, string? lastName, string? email, DateTime birthDay, string country, string city, string street, string zip, double hourlyRate = 12) : base(firstName, lastName, "Researcher", email, birthDay, country, city, street, zip, hourlyRate)
    {
    }

    public void DoResearch()
    {
        HoursOfWork += 4;
        if (new Random().Next(100) > 50)
        {
            double bonus = (HourlyRate * HoursOfWork) * 0.05;
            Console.WriteLine($"Researcher {FirstName} {LastName} has discovered a new recipe and get a bonus!");
            ExtraBonus+= bonus;
        }
        else
        {
            Console.WriteLine($"Researcher {FirstName} {LastName} didn't discover anything new...");
        }
    }
}