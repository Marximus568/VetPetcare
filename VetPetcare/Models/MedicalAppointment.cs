namespace VetPetcare.Models;

public class MedicalAppointment
{
    private static int _lastId = 1;

    public int AppointmentId { get; internal set; } = _lastId++;
    public DateOnly Date { get; set; }
    public List<Veterinary> Veterinaries { get; set; } = new List<Veterinary>();
    public List<Client> Clients { get; set; } = new List<Client>();
    public string Reason { get; set; }
    public string Symptoms { get; set; }

    public MedicalAppointment(DateOnly date, List<Veterinary> veterinaries, List<Client> clients, string reason, string symptoms)
    {
        Date = date;
        Veterinaries = veterinaries ?? new List<Veterinary>();
        Clients = clients ?? new List<Client>();
        Reason = reason;
        Symptoms = symptoms;
    }
}