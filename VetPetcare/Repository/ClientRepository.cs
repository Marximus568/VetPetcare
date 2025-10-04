using VetPetcare.Interface.ClientRepository;

namespace VetPetcare.Repository;

public class ClientRepository : IClientRepository
{
    public Client Create(Client client)
    {
        Database.Clients.Add(client);
        return client;
    }

    public Client GetById(Guid id)
    {
        return Database.Clients.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Client> GetAll()
    {
        return Database.Clients;
    }
}