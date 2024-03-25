namespace EmployerApp.Data;

public struct Address(string country, string city, string street, string zip)
{
    public string Country { get; set; } = country;
    public string City { get; set; } = city;
    public string Street { get; set; } = street;
    public string Zip { get; set; } = zip;
}