namespace VetPetcare.Models;

public class Veterinary(string FirstName,
    string LastName,
    DateTime DateOfBirth, 
    string Gender, 
    string Email, 
    string Address) : People(FirstName,
    LastName, DateOfBirth, Gender, Email, Address)
{
    public int VeterinaryId
    {
        get => base.Id;
        internal set => base.Id = value;
    }
    public string speciality{get; private set;}

    public Veterinary(string FirstName, 
        string LastName, 
        DateTime DateOfBirth, 
        string Gender, 
        string Email,
        string Address, 
        string speciality) : this(FirstName, LastName, DateOfBirth, Gender, Email, Address)
    {
        this.speciality = speciality;
    }
}