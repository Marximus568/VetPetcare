using VetPetcare.Models;

namespace VetPetcare.Database;

public static class Database
{
    public static List<Client> Patients = new List<Client>();

    public static List<Pet> Pets= new List<Pet>();

    public static Dictionary<object, object> ClientAndPets= new Dictionary<object, object>();
}