
using System.Xml;
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
        return Database.Database.Clients.First(c => c.ClientId == id);
    }

    public IEnumerable<Client> GetAll()
    {
        return Database.Database.Clients;
    }

    public bool Update(Client client, int id)
    {
        int index = Database.Database.Clients.FindIndex(c => c.ClientId == id);

        if (index == -1)
        {
            Console.WriteLine("Client not found.");
            return false;
        }
        client.ClientId = id;
        Database.Database.Clients[index] = client;

        Console.WriteLine("Client updated successfully.");

        return true;
    }

    public bool DeleteById(int id)
    {
        var client = Database.Database.Clients.First(c => c.ClientId == id);
        if (client == null) return false;
        Database.Database.Clients.Remove(client);
        return true;
    }
    
}