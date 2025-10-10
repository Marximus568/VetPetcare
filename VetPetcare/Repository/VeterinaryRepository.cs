using VetPetcare.Interface.IVeterinaryRepository;
using VetPetcare.Models;

namespace VetPetcare.Repository;

public class VeterinaryRepository : IVeterinaryRepository
{
    public Veterinary Create(Veterinary veterinary)
    {
        Database.Database.Veterinaries.Add(veterinary);
        return veterinary;
    }

    public Veterinary GetById(int id)
    {
        return Database.Database.Veterinaries.First(v => v.VeterinaryId == id);
    }

    public IEnumerable<Veterinary> GetAll()
    {
        return Database.Database.Veterinaries;
    }

    public bool Update(Veterinary veterinary, int id)
    {
        int index = Database.Database.Veterinaries.FindIndex(v => v.VeterinaryId == id);

        if (index == -1)
        {
            Console.WriteLine("Veterinary not found.");
            return false;
        }

        veterinary.VeterinaryId = id;
        Database.Database.Veterinaries[index] = veterinary;

        return true;
    }

    public bool DeleteById(int id)
    {
        var veterinary = Database.Database.Veterinaries.FirstOrDefault(v => v.VeterinaryId == id);

        if (veterinary == null)
        {
            Console.WriteLine("Veterinary not found.");
            return false;
        }

        Database.Database.Veterinaries.Remove(veterinary);
        return true;
    }
}
