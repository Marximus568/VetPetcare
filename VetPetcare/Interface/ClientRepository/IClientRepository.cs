using VetPetcare.Models;

namespace VetPetcare.Interface.ClientRepository;

public interface IClientRepository
{
    Client Create(Client client);
    Client GetById(int id);
    IEnumerable<Client> GetAll();
    bool DeleteById(int id);
}