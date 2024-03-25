namespace EmployerApp.HR;

public class JuniorResearcher: Researcher
{
    public JuniorResearcher(string? firstName, string? lastName, string? email, DateTime birthDay, double hourlyRate = 12) : base(firstName, lastName, email, birthDay, hourlyRate)
    {
        EmployeeType = "Junior Researcher";
    }

    public JuniorResearcher(string? firstName, string? lastName, string? email, DateTime birthDay, string country, string city, string street, string zip, double hourlyRate = 12) : base(firstName, lastName, email, birthDay, country, city, street, zip, hourlyRate)
    {
        EmployeeType = "Junior Researcher";
    }

}