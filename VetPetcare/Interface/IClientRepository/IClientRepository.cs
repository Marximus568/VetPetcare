
public interface IClientRepository
{
    Client Create(Client client);
    Client GetById(int id);
    IEnumerable<Client> GetAll();
    bool Update(Client client, int id);
    bool DeleteById(int id);
}