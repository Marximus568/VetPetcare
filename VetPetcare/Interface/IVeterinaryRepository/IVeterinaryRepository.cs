using VetPetcare.Models;

namespace VetPetcare.Interface.IVeterinaryRepository;

public interface IVeterinaryRepository
{
    Veterinary Create(Veterinary Veterinary);
    Veterinary GetById(int id);
    IEnumerable<Veterinary> GetAll();
    bool Update(Veterinary Veterinary, int id);
    bool DeleteById(int id);
}