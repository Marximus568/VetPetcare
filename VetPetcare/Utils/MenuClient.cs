using VetPetcare.Models;


public static class MenuClient
{
    public static void ShowMenu()
    {
        var control = true;
        do
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 Register for patient.");
            Console.WriteLine("2 Show patients.");
            Console.WriteLine("3 Find patient.");
            Console.WriteLine("4. Leave.");
            var options = Console.ReadLine();
            Console.WriteLine("==========================");

            switch (options)
            {
                case "1":
                {
                    ServiceClient.CreateClient();
                    return;
                }
                case "2":
                {
                    ServiceClient.ShowList();
                    return;
                }

                case "3":
                {
                    {
                        Console.WriteLine("Write a id");
                        int id = int.Parse(Console.ReadLine());
                        ServiceClient.FindClient(id);
                        return;
                    }
                }

                case "4":
                {
                    Console.WriteLine("You will return page past.");
                    control = false;
                    return;
                }
                default:
                {
                    Console.WriteLine("Invalid option. Try again.");
                    return;
                }
            } while (control);
        }
    }