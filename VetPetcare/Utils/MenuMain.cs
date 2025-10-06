namespace VetPetcare.Utils;

public static class MenuMain
{
    public static void MainMenu()
    {
        Console.WriteLine("Welcome to the Vet Petcare!");
        Console.WriteLine("What would you like to do?");
        int initial = Convert.ToInt32(Console.ReadLine());
        switch (initial)
        {
            case 1:
            {
                MenuClient.ShowMenu();
                break;
            }
            case 2:
            {
                MenuClient.ShowMenu();
                break;
            }
            case 3:
            {
                MenuClient.ShowMenu();
                break;
            }
            default:
            {
                break;
            }
        }
        
    }
}