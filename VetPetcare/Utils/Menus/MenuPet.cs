using System.Runtime.InteropServices;
using VetPetcare.Models;

namespace VetPetcare.Utils;

public static class MenuPet
{
    public static void ShowPet()
    {
        var control = true;

        do
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Register a pet.");
            Console.WriteLine("2. Show all pets.");
            Console.WriteLine("3. Find a pet.");
            Console.WriteLine("4. Update a pet.");
            Console.WriteLine("5. Delete a pet.");
            Console.WriteLine("6. Leave.");
            Console.WriteLine("==========================");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                {
                    ServicePet.CreatePet();
                    break;
                }

                case "2":
                {
                    ServicePet.GetAllPets();
                    break;
                }

                case "3":
                {
                    Console.WriteLine("Enter pet ID:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        ServicePet.GetPetById(id);
                    else
                        Console.WriteLine("Invalid ID.");
                    break;
                }

                case "4":
                {
                    Console.WriteLine("Enter pet ID to update:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        ServicePet.UpdatePet(id);
                    else
                        Console.WriteLine("Invalid ID.");
                    break;
                }

                case "5":
                {
                    Console.WriteLine("Enter pet ID to delete:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        ServicePet.DeletePet(id);
                    else
                        Console.WriteLine("Invalid ID.");
                    break;
                }

                case "6":
                {
                    Console.WriteLine("Returning to previous menu...");
                    control = false;
                    return;
                }

                default:
                {
                    Console.WriteLine("Invalid option. Try again.");
                    break;
                }
            }
        } while (control);
    }
}
