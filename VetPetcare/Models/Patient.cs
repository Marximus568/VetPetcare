public class Patient
{
    public Guid id { get; set; }
    public string name { get; set; }
    public int age { get; set; }
    public string symptoms { get; set; }
    public Patient(string name, int age, string symptoms)
    {
        this.name = name;
        this.age = age;
        this.symptoms = symptoms;
    }
    //Functionality of class
}

