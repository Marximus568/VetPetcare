namespace VetPetcare.Models;

public abstract class People(string FirstName,string LastName, DateTime DateOfBirth, string Gender, string Email, string Address)
{
    private static int _lastId = 0;
    protected int Id { get; private set; } = _lastId++;
    protected string FirstName { get; set; } = FirstName;
    protected string LastName { get; set; } = LastName;
    protected DateTime DateOfBirth { get; set; } = DateOfBirth;
    protected string Gender { get; set; } = Gender;
    protected string Email { get; set; } = Email;
    protected string Address { get; set; } = Address;
    
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
    public string GetInfo()
    {
        return  $"ID: {Id}\n"+ 
                $"Name: {FirstName} {LastName}\n" +
                $"Email: {Email}\n" +
                $"Address: {Address}\n" +
                $"Gender: {Gender}\n" +
                $"Birth date: {DateOfBirth:dd/MM/yyyy}";
    }
}