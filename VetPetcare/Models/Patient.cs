
public class Patient
{
    public static int Id = 1;
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Symptoms { get; set; }
    
    public Patient(string Name, int Age, string Symptoms)
    {
        PatientId = Id++;
        this.Name = Name.ToLower();
        this.Age = Age;
        this.Symptoms = Symptoms;
       
    }
  
}

