using System.Globalization;
using VetPetcare.Models;

var inventory = new List<Patient>();

//Controller of cycle
var control = true;

//Main function
do
{
    Console.WriteLine("==========================");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1 Register of patient.");
    Console.WriteLine("2 Show patients.");
    Console.WriteLine("3 Find patient.");
    Console.WriteLine("4 Leave.");
    var options=Console.ReadLine();
    Console.WriteLine("==========================");
    switch (options)
    {
        case "1":
        {
            try
            {
                ServicePatient.CreatePatient(inventory);
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
            if (inventory.Count == 0)
            {
                Console.WriteLine("Doesn't have any patients.");
                break;
            }
            else
            {   
                ServicePatient.ShowList(inventory);
                break;
            }
        }

        case "3":
        {
            try
            {
                if (inventory.Count == 0)
                {
                    Console.WriteLine("Doesn't have any patients.");
                }
                else
                {
                    string name = Console.ReadLine();
                    ServicePatient.FindPatient(name,inventory);
                    if (ServicePatient.FindPatient(name,inventory) == null)
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
