namespace VetPetcare.Models;

public static class ServicePatient
{
        //Find a patient
        public static string FindPatient(string name, List<Patient> inventory)
        {
            foreach (var p in inventory)
            {
                if (name == p.name)
                {
                    Console.WriteLine("Patient found");
                    Console.WriteLine($"name: {p.name}, age: {p.age}, syphtoms: {p.symptoms}");
                }
            }

            return name;
        }

        // Create new patient
        public static void CreatePatient(List<Patient> inventory)
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
                inventory.Add(new Patient(name, age, symptoms));
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
        public static void ShowList(List<Patient> inventory)
        {
            Console.WriteLine("The following patients are available:");
            foreach (var p in inventory)
            {
                Console.WriteLine($"{p.name}, {p.age} años, {p.symptoms} symptoms");

            }
        }
}