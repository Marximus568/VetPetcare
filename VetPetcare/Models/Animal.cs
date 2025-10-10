namespace VetPetcare.Models;


public abstract class Animal(string Name, string Species, string Breed, string Gender)
{
    private static int _lastId = 1;

    public int Id { get; protected set; } = _lastId++;
    public string Name { get; protected set; } = string.IsNullOrWhiteSpace(Name) ? "Unknown" : Name.Trim();
    public string Species { get; protected set; } = string.IsNullOrWhiteSpace(Species) ? "Unknown" : Species.Trim();
    public string Breed { get; protected set; } = string.IsNullOrWhiteSpace(Breed) ? "Unknown" : Breed.Trim();
    public string Gender { get; protected set; } = string.IsNullOrWhiteSpace(Gender) ? "Unknown" : Gender.Trim();

    // Constructor opcional con menos parámetros
    protected Animal(string Name, string Species, string Gender)
        : this(Name, Species, "Unknown", Gender) { }
    
    
}
