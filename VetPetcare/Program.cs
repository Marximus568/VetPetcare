using System.Globalization;
using VetPetcare.Models;

var patients = new List<Patient>();

var patientPets = new Dictionary<int, List<Pet>>();


//Controller of cycle
var control = true;

//Main function
do
{
    Console.WriteLine("==========================");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Register for patient.");
    Console.WriteLine("2. Show patients.");
    Console.WriteLine("3. Find patient.");
    Console.WriteLine("4. Register for pet.");
    Console.WriteLine("5. Show users with pets.");
    Console.WriteLine("8. Leave.");
    var options=Console.ReadLine();
    Console.WriteLine("==========================");
    switch (options)
    {
        case "1":
        {
            try
            {
                ServicePatient.CreatePatient(patients);
               break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Something went wrong.");
                break;
            }
        }   
        case "2":
        {
            if (patients.Count == 0)
            {
                Console.WriteLine("Doesn't have any patients.");
                break;
            }
            else
            {   
                ServicePatient.ShowList(patients);
                break;
            }
        }

        case "3":
        {
            try
            {
                if (patients.Count == 0)
                {
                    Console.WriteLine("Doesn't have any patients.");
                }
                else
                {
                    Console.WriteLine("Write the name of the patient:");
                    string name = Console.ReadLine();
                    ServicePatient.FindPatient(name, patients);
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                break;
            }
        }
        case "4":
        {
            try
            {
                Console.WriteLine("Name of the patient:");
                string name = Console.ReadLine();
                //Search an user
                var patient = patients.FirstOrDefault(p => p.Name == name);
                
                if (patient == null)
                {
                    Console.WriteLine("Patient not found.");
                    break;
                }
                var newPets = new List<Pet>();
                ServicePet.CreatePet(newPets);
                //Here, for created a new user with pet
                if (patientPets.ContainsKey(patient.PatientId))
                {
                    patientPets[patient.PatientId].AddRange(newPets);
                }
                else
                {
                    patientPets[patient.PatientId] = newPets;
                }

                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Something went wrong.");
                break;
            }
        } 
        case "5":
        {
            try
            {
                //In this part of code, it is doing consult for show the inventory
                foreach (var entry in patientPets)
                {
                    Console.WriteLine($"Id of user is {entry.Key}");

                    foreach (var pet in entry.Value)
                    {
                        Console.WriteLine($"   Pet: {pet.Name}, Breed: {pet.Breed}, Gender: {pet.Gender}");
                    }
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
          
        case "8":
        {
            Console.WriteLine("Thanks for use the application.");
            control = false;
            break;
        }
        default:
        {
            Console.WriteLine("Invalid option. Try again.");
            break;
        }

    }
} while (control);
