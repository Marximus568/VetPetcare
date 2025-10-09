using VetPetcare.Models;

namespace VetPetcare.Interface.IPetRepository;

public interface IPetRepository
{
    Pet Create(Pet pet);
    Pet GetById(int id);
    IEnumerable<Pet> GetAll();
    bool Update(Pet pet, int id);
    bool DeleteById(int id);
}
