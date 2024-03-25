namespace EmployerApp.HR;

public class StoreManager: Employee
{
    public StoreManager(string? firstName, string? lastName, string? email, DateTime birthDay, double hourlyRate = 12) : base(firstName, lastName, "Store manager", email, birthDay, hourlyRate)
    {
    }

    public StoreManager(string? firstName, string? lastName, string? email, DateTime birthDay, string country, string city, string street, string zip, double hourlyRate = 12) : base(firstName, lastName, "Store manager", email, birthDay, country, city, street, zip, hourlyRate)
    {
    }
}