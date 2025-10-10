using VetPetcare.Models;

namespace VetPetcare.Database;

public static class Database
{
    public static List<Client> Clients = new List<Client>()
    {
        new Client("Alice", "Johnson", new DateTime(1990, 5, 12), "F", "alice@mail.com", "123 Main St"),
        new Client("Bob", "Smith", new DateTime(1985, 8, 23), "M", "bob@mail.com", "456 Oak Ave"),
        new Client("Carla", "Diaz", new DateTime(2000, 2, 17), "F", "carla@mail.com", "789 Pine Rd")
    };

    public static List<Veterinary> Veterinaries = new List<Veterinary>()
    {
        new Veterinary("Dr. John", "Watson", new DateTime(1980, 3, 14), "M", "johnvet@mail.com", "101 Vet St", "Surgery"),
        new Veterinary("Dr. Emily", "Stone", new DateTime(1992, 7, 8), "F", "emilyvet@mail.com", "202 Vet Ave", "Dermatology"),
        new Veterinary("Dr. Mark", "Lee", new DateTime(1988, 12, 2), "M", "markvet@mail.com", "303 Vet Blvd", "General")
    };

    public static List<Pet> Pets = new List<Pet>();

    public static Dictionary<object, object> MedicalAppointment = new Dictionary<object, object>()
    {
        {
            1, new MedicalAppointment
            {
                Date = new DateOnly(2025, 10, 15),
                StartTime = new TimeOnly(12, 0),
                EndTime = new TimeOnly(14, 0),
                Veterinaries = new List<Veterinary> { Veterinaries[0] },
                Clients = new List<Client> { Clients[0] },
                Reason = "Consultation",
                Symptoms = "Coughing"
            }
        },
        {
            2, new MedicalAppointment
            {
                Date = new DateOnly(2025, 10, 16),
                StartTime = new TimeOnly(14, 20),
                EndTime = new TimeOnly(16, 20),
                Veterinaries = new List<Veterinary> { Veterinaries[1] },
                Clients = new List<Client> { Clients[1] },
                Reason = "Vaccination",
                Symptoms = "N/A"
            }
        },
        {
            3, new MedicalAppointment
            {
                Date = new DateOnly(2025, 10, 17),
                StartTime = new TimeOnly(16, 30),
                EndTime = new TimeOnly(18, 30),
                Veterinaries = new List<Veterinary> { Veterinaries[2] },
                Clients = new List<Client> { Clients[2] },
                Reason = "Bath",
                Symptoms = "Dirty fur"
            }
        }
    };
    
}