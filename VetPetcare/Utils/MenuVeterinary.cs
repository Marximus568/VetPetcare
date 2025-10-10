namespace VetPetcare.Utils;

public static class MenuVeterinary
{
    public static void ShowVeterinary()
    {
        bool control = true;

        do
        {
            Console.WriteLine("==========================");
            Console.WriteLine("   Veterinary Management");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Register a veterinary.");
            Console.WriteLine("2. Show all veterinaries.");
            Console.WriteLine("3. Find a veterinary by ID.");
            Console.WriteLine("4. Update a veterinary.");
            Console.WriteLine("5. Delete a veterinary.");
            Console.WriteLine("6. Leave.");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                {
                    ServiceVeterinary.CreateVeterinary();
                    break;
                }

                case "2":
                {
                    ServiceVeterinary.ShowList();
                    break;
                }

                case "3":
                {
                    Console.Write("Enter veterinary ID: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        ServiceVeterinary.FindVeterinary(id);
                    else
                        Console.WriteLine("Invalid ID. Please enter a number.");
                    break;
                }

                case "4":
                {
                    Console.Write("Enter veterinary ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        ServiceVeterinary.UpdateVeterinary(id);
                    else
                        Console.WriteLine("Invalid ID. Please enter a number.");
                    break;
                }

                case "5":
                {
                    Console.Write("Enter veterinary ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        ServiceVeterinary.DeleteVeterinary(id);
                    else
                        Console.WriteLine("Invalid ID. Please enter a number.");
                    break;
                }

                case "6":
                {
                    Console.WriteLine("Returning to previous menu...");
                    control = false;
                    break;
                }

                default:
                {
                    Console.WriteLine("Invalid option. Try again.");
                    break;
                }
            }

            if (control)
            {
                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        } while (control);
    }
}