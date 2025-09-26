namespace VetPetcare.Models;

public static class ServicePatient
{
        //Find a patient
        public static string FindPatient(string name, List<Patient> item)
        {
            foreach (var p in item)
            {
                if (name == p.Name)
                {
                    Console.WriteLine("Patient found");
                    Console.WriteLine($"name: {p.Name}, age: {p.Age}, syphtoms: {p.Symptoms}");
                }
            }

            return "Don't found";
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
                item.Add(new Patient(name, age, symptoms));
                Console.WriteLine($"Yours id is {} ");
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
                Console.WriteLine($"ID: {p.Id} NAME:{p.Name}, AGE:{p.Age}, SYMPTOMS{p.Symptoms}");
            }
        }
}