namespace VetPetcare.Models;

public class Pet
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public string Symptoms { get; set; }

    public Pet(string name, string breed, string gender, int age, string symptoms)
    {
        this.Name = name;
        this.Breed = breed;
        this.Gender = gender;
        this.Age = age;
        this.Symptoms = symptoms;
    }
}