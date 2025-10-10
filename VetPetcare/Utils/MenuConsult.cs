using VetPetcare.Models;

namespace VetPetcare.Utils;

public static class MenuQueries
{
    public static void ShowMenu()
    {
        bool running = true;

        do
        {
            Console.WriteLine("===============================");
            Console.WriteLine("        Client & Pet Queries  ");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Search pets by breed");
            Console.WriteLine("2. Display all client names");
            Console.WriteLine("3. Order clients by age");
            Console.WriteLine("4. Order clients by name (descending)");
            Console.WriteLine("5. Group pets by breed");
            Console.WriteLine("6. Find youngest and oldest clients");
            Console.WriteLine("7. Count pets by species");
            Console.WriteLine("8. Check pets without defined breed");
            Console.WriteLine("9. List all client names uppercase and sorted");
            Console.WriteLine("10. Exit");
            Console.WriteLine("===============================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":
                    Console.Write("Enter breed to search: ");
                    string breed = Console.ReadLine()?.Trim() ?? "";
                    ClientPetQueries.SearchPetsByBreed(breed);
                    break;

                case "2":
                    ClientPetQueries.DisplayAllClientNames();
                    break;

                case "3":
                    ClientPetQueries.OrderClientsByAge();
                    break;

                case "4":
                    ClientPetQueries.OrderClientsByNameDesc();
                    break;

                case "5":
                    ClientPetQueries.GroupPetsByBreed();
                    break;

                case "6":
                    ClientPetQueries.FindYoungestAndOldestClients();
                    break;

                case "7":
                    ClientPetQueries.CountPetsBySpecies();
                    break;

                case "8":
                    ClientPetQueries.CheckPetsWithoutBreed();
                    break;

                case "9":
                    ClientPetQueries.ListClientNamesUppercase();
                    break;

                case "10":
                    Console.WriteLine("Exiting queries menu...");
                    running = false;
                    break;

                default:
                    Console.WriteLine("=== Invalid option, please choose again ===");
                    break;
            }

        } while (running);
    }
}
