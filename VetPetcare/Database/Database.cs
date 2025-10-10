using VetPetcare.Models;

namespace VetPetcare.Database;

public static class Database
{
    public static List<Client> Clients = new List<Client>();
    
    public static List<Veterinary> Veterinaries = new List<Veterinary>();

    public static List<Pet> Pets= new List<Pet>();
    
    public static Dictionary<object, object> MedicalAppointment = new Dictionary<object, object>();
}