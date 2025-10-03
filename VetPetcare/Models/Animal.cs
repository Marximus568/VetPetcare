namespace VetPetcare.Models;


public abstract class Animal
{   
    private static int _lastId = 0;
    protected int Id { get; private set; } = ++_lastId;
    private string name;
    private string species;
    private string breed;
    private string gender;

    public string Name
    {
        get => name;
        set => name = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
    }
    
    public string Breed { get => breed; set => breed = value; }
    public string Species
    {
        get => species;
        set => species = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
    }

    public string Gender
    {
        get => gender;
        set => gender= string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
    }
}