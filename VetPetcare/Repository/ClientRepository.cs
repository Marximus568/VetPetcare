using VetPetcare.Interface.ClientRepository;
using VetPetcare.Models;

namespace VetPetcare.Repository;

public class ClientRepository : IClientRepository
{
    public Client Create(Client client)
    {
        Database.Database.Clients.Add(client);
        return client;
    }

    public Client GetById(int id)
    {
        return Database.Database.Clients.FirstOrDefault(c => c.Id == id);
    }

    public IEnumerable<Client> GetAll()
    {
        return Database.Database.Clients;
    }

    public Client DeleteById(int id)
    {
        var client = Database.Database.Clients.FirstOrDefault(c => c.Id == id);
        if (client != null)
        {
            Database.Database.Clients.Remove(client);
        }

        return client;
    }
}