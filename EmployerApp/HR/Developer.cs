namespace EmployerApp.HR;

public class Developer: Employee
{
    public Developer(string? firstName, string? lastName, string? email, DateTime birthDay, string? currentProject, double hourlyRate = 12) : base(firstName, lastName, "Developer", email, birthDay, hourlyRate)
    {
        CurrentProject = currentProject;
    }

    public Developer(string? firstName, string? lastName, string? email, DateTime birthDay, string country, string city, string street, string zip, string? currentProject, double hourlyRate = 12) : base(firstName, lastName, "Developer", email, birthDay, country, city, street, zip, hourlyRate)
    {
        CurrentProject = currentProject;
    }

    
    

    
    public override void PerformWork(int hours)
    {
        Console.WriteLine($"Developer {FirstName} {LastName} is working on an {CurrentProject} project for {hours} hours!");
        HoursOfWork += hours;
        GetBonus(hours, HourlyRate);
    }
}