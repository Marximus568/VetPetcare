using System.Globalization;

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
                CreatePatient();
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
                ShowList();
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
                    Console.WriteLine("Enter the name of the patient:");
                    var name = Console.ReadLine();
                    FindPatient(name);
                    if (FindPatient(name) == null)
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

//Read the list
void ShowList()
{
    Console.WriteLine("The following patients are available:");
    foreach (var p in inventory)
    {
        Console.WriteLine($"{p.name}, {p.age} años, {p.symptoms} symptoms");

    }
}
//Creat patient
void CreatePatient()
{
    try
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter your age");
        int age= Convert.ToInt32(Console.ReadLine());
        if (age <= 0 || age >= 110)
        {
            Console.WriteLine("Yours information is invalid.");
            return;
        }
        Console.WriteLine("Enter your symptoms");
        string symptoms = Console.ReadLine();
        inventory.Add(new Patient(name,age,symptoms));
        Console.WriteLine("Patient created.");
    }
    catch (Exception e)
    {
        Console.WriteLine("Something went wrong. Try again.");
        Console.WriteLine(e);
        throw;
    }
}

//Finder patient
string FindPatient(string name)
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
