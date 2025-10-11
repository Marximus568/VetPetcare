namespace VetPetcare.Models;

public static class ClientPetQueries
{
    // -----------------------------
    // 1. Search pets by breed
    // -----------------------------
    public static void SearchPetsByBreed(string breed)
    {
        var clients = Database.Database.Clients;

        var breedResults = clients
            .SelectMany(client => client.Pets, (client, pet) => new { Client = client, Pet = pet })
            .Where(x => !string.IsNullOrWhiteSpace(x.Pet.Breed) &&
                        x.Pet.Breed.Equals(breed, StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("---- Pets found by breed ----");
        foreach (var r in breedResults)
        {
            Console.WriteLine(
                $"Client: {r.Client.FirstName} {r.Client.LastName}, Pet: {r.Pet.Name}, Breed: {r.Pet.Breed}");
        }
        Console.WriteLine();
    }

    // -----------------------------
    // 2. Display all client names
    // -----------------------------
    public static void DisplayAllClientNames()
    {
        var clients = Database.Database.Clients;

        var clientNames = clients.Select(c => $"{c.FirstName} {c.LastName}");

        Console.WriteLine("---- All Client Names ----");
        foreach (var name in clientNames)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();
    }

    // -----------------------------
    // 3. Order clients by age (ascending)
    // -----------------------------
    public static void OrderClientsByAge()
    {
        var clients = Database.Database.Clients;

        var orderedByAge = clients
            .OrderBy(c => c.Age)
            .Select(c => new { c.FirstName, c.LastName, c.Age });

        Console.WriteLine("---- Clients Ordered by Age ----");
        foreach (var c in orderedByAge)
        {
            Console.WriteLine($"{c.FirstName} {c.LastName} - {c.Age} years");
        }
        Console.WriteLine();
    }

    // -----------------------------
    // 4. Order clients by name (descending)
    // -----------------------------
    public static void OrderClientsByNameDesc()
    {
        var clients = Database.Database.Clients;

        var orderedByNameDesc = clients
            .OrderByDescending(c => c.FirstName)
            .Select(c => c.FirstName);

        Console.WriteLine("---- Clients Ordered by Name (Descending) ----");
        foreach (var name in orderedByNameDesc)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();
    }

    // -----------------------------
    // 5. Group pets by breed
    // -----------------------------
    public static void GroupPetsByBreed()
    {
        var clients = Database.Database.Clients;

        var groupedByBreed = clients
            .SelectMany(c => c.Pets, (c, pet) => new { Owner = c, Pet = pet })
            .GroupBy(x => x.Pet.Breed);

        Console.WriteLine("---- Pets Grouped by Breed ----");
        foreach (var group in groupedByBreed)
        {
            Console.WriteLine($"Breed: {group.Key}");
            foreach (var item in group)
            {
                Console.WriteLine($"  Owner: {item.Owner.FirstName} {item.Owner.LastName}, Pet: {item.Pet.Name}");
            }
        }
        Console.WriteLine();
    }

    // -----------------------------
    // 6. Find youngest and oldest clients
    // -----------------------------
    public static void FindYoungestAndOldestClients()
    {
        var clients = Database.Database.Clients;

        var youngest = clients.OrderBy(c => c.Age).FirstOrDefault();
        var oldest = clients.OrderByDescending(c => c.Age).FirstOrDefault();

        Console.WriteLine("---- Youngest and Oldest Clients ----");
        if (youngest != null)
            Console.WriteLine($"Youngest: {youngest.FirstName} - {youngest.Age} years");
        if (oldest != null)
            Console.WriteLine($"Oldest: {oldest.FirstName} - {oldest.Age} years");
        Console.WriteLine();
    }

    // -----------------------------
    // 7. Count pets by species
    // -----------------------------
    public static void CountPetsBySpecies()
    {
        var clients = Database.Database.Clients;

        var speciesCount = clients
            .SelectMany(c => c.Pets)
            .GroupBy(p => p.Species)
            .Select(g => new { Species = g.Key, Count = g.Count() });

        Console.WriteLine("---- Pets by Species ----");
        foreach (var s in speciesCount)
        {
            Console.WriteLine($"{s.Species}: {s.Count}");
        }
        Console.WriteLine();
    }

    // -----------------------------
    // 8. Check for pets without defined breed
    // -----------------------------
    public static void CheckPetsWithoutBreed()
    {
        var clients = Database.Database.Clients;

        bool hasNoBreed = clients
            .SelectMany(c => c.Pets)
            .Any(p => string.IsNullOrWhiteSpace(p.Breed)
                      || p.Breed.Equals("undefined", StringComparison.OrdinalIgnoreCase)
                      || p.Breed.Equals("none", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("---- Pets without defined breed ----");
        Console.WriteLine(hasNoBreed
            ? "There is at least one pet without a defined breed."
            : "All pets have a defined breed.");
        Console.WriteLine();
    }

    // -----------------------------
    // 9. List all client names uppercase and sorted
    // -----------------------------
    public static void ListClientNamesUppercase()
    {
        var clients = Database.Database.Clients;

        var orderedNames = clients
            .Select(c => c.FirstName.ToUpper())
            .OrderBy(n => n);

        Console.WriteLine("---- Client Names (Uppercase & Sorted) ----");
        foreach (var name in orderedNames)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();
    }
}
