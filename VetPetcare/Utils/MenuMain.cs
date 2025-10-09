namespace VetPetcare.Utils;

public static class MenuMain
{
    public static void MainMenu()
    {
        bool exit = false;
        do
        {
            Console.WriteLine("Welcome to the Vet Petcare!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Menu client");
            Console.WriteLine("2. Menu pet");
            Console.WriteLine("3. Menu Veterinary");
            Console.WriteLine("4. Menu date");
            Console.WriteLine("5. Menu query");
            Console.WriteLine("6. Leave");
            int initial = Convert.ToInt32(Console.ReadLine());
            switch (initial)
            {
                case 1:
                {
                    MenuClient.ShowClient();
                    break;
                }
                case 2:
                {
                    MenuPet.ShowPet();
                    break;
                }
                case 3:
                {
                    MenuClient.ShowClient();
                    break;
                }
                case 4:
                {
                    MenuClient.ShowClient();
                    break;
                }
                case 5:
                {
                    MenuClient.ShowClient();
                    break;
                }
                case 6:
                {
                    exit = true;
                    break;
                }
                default:
                {
                    Console.WriteLine("Sorry, you did not enter a valid option.");
                    break;
                }
            }
        } while (!exit);
    }
}