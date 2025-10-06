namespace VetPetcare.Models;


public abstract class Animal
{
    private static int _lastId = 0;
    protected int Id { get; private set; } = ++_lastId;
    private string name;
    private string species;
    private string breed;
    private string gender;

    protected string Name
    {
        get => name;
        set => name = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
    }

    protected string Breed
    {
        get => breed;
        set => breed = value;
    }

    protected string Species
    {
        get => species;
        set => species = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
    }

    protected string Gender
    {
        get => gender;
        set => gender = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
    }

    protected Animal(string name, string species, string breed, string gender)
    {
        this.name = name;
        this.species = species;
        this.breed = breed;
        this.gender = gender;
    }

    protected Animal(string name, string species, string gender)
    {
        this.name = name;
        this.species = species;
        this.gender = gender;
    }
}