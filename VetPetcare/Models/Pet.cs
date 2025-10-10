namespace VetPetcare.Models;

public class Pet(string name, string breed, string species, string gender, DateTime dateOfBirth) 
    : Animal(name, species, gender)
{
    public int PetId
    {
        get => base.Id;
        internal set => base.Id = value;
    }
    public string Name { get; set; } = name;
    public string Breed { get; set; } = breed;
    public string Species { get; set; } = species;
    public string Gender { get; set; } = gender;

    public DateTime BirthDay { get; set; } = dateOfBirth;
    
}
