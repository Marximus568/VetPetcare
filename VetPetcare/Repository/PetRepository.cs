using VetPetcare.Interface;
using VetPetcare.Interface.IPetRepository;
using VetPetcare.Models;

namespace VetPetcare.Repository;

public class PetRepository : IPetRepository
{
    public Pet Create(Pet pet)
    {
        Database.Database.Pets.Add(pet);
        return pet;
    }

    public Pet GetById(int id)
    {
        return Database.Database.Pets.First(p => p.PetId == id);
    }

    public IEnumerable<Pet> GetAll()
    {
        return Database.Database.Pets;
    }

    public bool Update(Pet pet, int id)
    {
        int index = Database.Database.Pets.FindIndex(p => p.PetId == id);

        if (index == -1)
        {
            Console.WriteLine("Pet not found.");
            return false;
        }

        pet.PetId = id;
        Database.Database.Pets[index] = pet;

        return true;
    }

    public bool DeleteById(int id)
    {
        var pet = Database.Database.Pets.FirstOrDefault(p => p.PetId == id);

        if (pet == null)
        {
            Console.WriteLine("Pet not found.");
            return false;
        }

        Database.Database.Pets.Remove(pet);
        return true;
    }
}