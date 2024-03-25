namespace EmployerApp;

public interface IEmployee
{
    void DisplayEmployeeInfo();
    void PerformWork(int hours);
    void GetBonus(int hoursOfWork, double hourlyRate);
    void ReceiveWage();
}