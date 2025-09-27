namespace VetPetcare.Models;

public static class ServicePatient
{
        //Find a patient
        public static string FindPatient(string name, List<Patient> item)
        {
            var patient = item.FirstOrDefault(p => p.Name == name);

            if (patient != null)
            {
                Console.WriteLine("Patient found");
                Console.WriteLine($"name: {patient.Name}, age: {patient.Age}, symptoms: {patient.Symptoms}");
            }
            else
            {
                Console.WriteLine("Patient not found");
            }

            return "Operation terminated";
        }

        // Create new patient
        public static void CreatePatient(List<Patient> item)
        {
            try
            {
                Console.WriteLine("Enter your name:");
                string name = Console.ReadLine();
                if (name.Length < 2)
                {
                    Console.WriteLine("Name is too short.");
                    return;
                }

                Console.WriteLine("Enter your age");
                int age = Convert.ToInt32(Console.ReadLine());
                if (age <= 0 || age >= 110)
                {
                    Console.WriteLine("Yours information is invalid.");
                    return;
                }

                Console.WriteLine("Enter your symptoms");
                string symptoms = Console.ReadLine();
                Console.WriteLine($"Yours id is {Patient.Id} ");
                item.Add(new Patient(name, age, symptoms));
                Console.WriteLine("Patient created.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong. Try again.");
                Console.WriteLine(e);
                throw;
            }
        }

        //Read the list
        public static void ShowList(List<Patient> item)
        {
            Console.WriteLine("The following patients are available:");
            foreach (var p in item)
            {
                Console.WriteLine($"ID: {p.PatientId} NAME:{p.Name}, AGE:{p.Age}, SYMPTOMS{p.Symptoms}");
            }
        }
}