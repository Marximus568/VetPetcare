using VetPetcare.Models;


public static class Menu
{
    public static void ShowMenu()
    {
        var control = true;

        Console.WriteLine("==========================");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1 Register for patient.");
        Console.WriteLine("2 Show patients.");
        Console.WriteLine("3 Find patient.");
        Console.WriteLine("4. Register for pet.");
        Console.WriteLine("5 Show pets.");
        Console.WriteLine("6. Leave.");
        var options = Console.ReadLine();
        Console.WriteLine("==========================");

        switch (options)
        {
            case "1":
            {
                try
                {
                    ServicePatient.CreatePatient(patients);
                    patientsAndPets.Add(patients, patients);
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
                        if (ServicePatient.FindPatient(name, patients) == null)
                        {
                            Console.WriteLine("Patient not found.");
                        }
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
                    ServicePet.CreatePet(pets);
                    patientsAndPets.Add(patients, pets);
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
                ServicePet.ShowList(pets);
                break;
            }
            case "6":
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

        while (control) ;
    }
}


