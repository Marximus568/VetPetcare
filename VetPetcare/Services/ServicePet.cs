namespace VetPetcare.Models;

// public static class ServicePet
// {
//     // Create new Pet
//     public static void CreatePet(List<Pet> item)
//     {
//         try
//         {
//             
//             Console.WriteLine("Name pet:");
//             string name = Console.ReadLine();
//             if (name.Length < 2)
//             {
//                 Console.WriteLine("Name is too short.");
//                 return;
//             }
//             Console.WriteLine("Enter its breed:");
//             string breed = Console.ReadLine();
//             if (breed.Length < 2)
//             {
//                 Console.WriteLine("Name is too short.");
//                 return;
//             }
//             Console.WriteLine("Enter its gender:");
//             string gender = Console.ReadLine();
//             if (name.Length < 2)
//             {
//                 Console.WriteLine("Name is too short.");
//                 return;
//             }
//
//             Console.WriteLine("Enter its age");
//             int age = Convert.ToInt32(Console.ReadLine());
//             if (age <= 0 || age >= 15)
//             {
//                 Console.WriteLine("These's information is invalid.");
//                 return;
//             }
//
//             Console.WriteLine("Enter its symptoms");
//             string symptoms = Console.ReadLine();
//             item.Add(new Pet(name,breed,gender,age,symptoms));
//             Console.WriteLine("Pet created.");
//             
//             
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine("Something went wrong. Try again.");
//             Console.WriteLine(e);
//             throw;
//         }
//     }
//
//     //Read the list
//     public static void ShowList(List<Pet> item)
//     {
//         Console.WriteLine("Pet are available:");
//         foreach (var p in item)
//         {
//             Console.WriteLine($"NAME:{p.Name}, AGE:{p.Age}, SYMPTOMS{p.Symptoms}, BREED:{p.Breed}, GENDER:{p.Gender}");
//         }
//     }
// }