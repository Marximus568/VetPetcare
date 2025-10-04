namespace VetPetcare.Interface.ClientRepository;

public interface IClientRepository
{
    Client Create(Client client);
    Client GetById(Guid id);
    IEnumerable<Client> GetAll();
}