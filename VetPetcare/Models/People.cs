namespace VetPetcare.Models;

public abstract class People(string FirstName,string LastName, DateTime DateOfBirth, string Gender, string Email, string Address)
{
    private static int _lastId = 0;
    public int Id { get; private set; } = _lastId++;
    public string FirstName { get; protected set; } = FirstName;
    public string LastName { get; protected set; } = LastName;
    public DateTime DateOfBirth { get; protected set; } = DateOfBirth;
    public string Gender { get; protected set; } = Gender;
    public string Email { get; protected set; } = Email;
    public string Address { get; protected set; } = Address;
    
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