namespace VetPetcare.Models;

public class Pet(string name, string breed, string species, string gender) 
    : Animal(name, species, gender)
{
    public string Name { get; set; } = name;
    public string Breed { get; set; } = breed;
    public string Species { get; set; } = species;
    public string Gender { get; set; } = gender;

    public int Age { get; set; }
    public string Symptoms { get; set; }
}
