namespace VetPetcare.Models;

public static class LINQ
{
    public static string consult1()
    {
        //Search by breed
        // try
        // {
        //     Console.WriteLine("Enter breed to search:");
        //     string breed = Console.ReadLine().ToLower();
        //     var results = patientPets
        //         .SelectMany(entry => entry.Value, (entry, pet) => new { PatientId = entry.Key, Pet = pet })
        //         .Where(x => x.Pet.Breed.ToLower() == breed);
        //
        //     foreach (var r in results)
        //     {
        //         Console.WriteLine($"PatientId: {r.PatientId}, Pet: {r.Pet.Name}, Breed: {r.Pet.Breed}");
        //     }
        //
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e);
        //     throw;
        // }
        
        
        
        
        //Search names
        // var patientNames = patients
        //     .Select(p => p.Name);
        //
        // foreach (var name in patientNames)
        // {
        //     Console.WriteLine(name);
        // }
        
        //Order by age
        // var orderedByAge = patients
        //     .OrderBy(p => p.Age);
        //
        // foreach (var p in orderedByAge)
        // {
        //     Console.WriteLine($"{p.Name} - {p.Age}");
        // }

        //Order descendt names
        // var orderedByNameDesc = patients
        //     .OrderByDescending(p => p.Name);
        //
        // foreach (var p in orderedByNameDesc)
        // {
        //     Console.WriteLine($"{p.Name}");
        // }

        //Group with GroupBy
        // var groupedByBreed = patientPets
        //     .SelectMany(entry => entry.Value, (entry, pet) => new { entry.Key, Pet = pet })
        //     .GroupBy(x => x.Pet.Breed);
        //
        // foreach (var group in groupedByBreed)
        // {
        //     Console.WriteLine($"Breed: {group.Key}");
        //     foreach (var item in group)
        //     {
        //         Console.WriteLine($"  PatientId: {item.Key}, Pet: {item.Pet.Name}");
        //     }
        // }

        return "Operation terminated";
    }
}