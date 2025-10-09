namespace VetPetcare.Models;

public class Pet(string name, string breed, string species, string gender, DateOnly dateOfBirth, string symptoms) 
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

    public DateOnly BirthDay { get; set; } = dateOfBirth;
    public string Symptoms { get; set; } = symptoms;
    
}
