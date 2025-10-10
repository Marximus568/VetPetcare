using VetPetcare.Repository;

namespace VetPetcare.Models;

public static class ServicePet
{
    private static readonly PetRepository _repository = new PetRepository();
    private static readonly ClientRepository _clientRepository = new ClientRepository();

    public static Pet CreatePet()
    {
        try
        {
            string name;
            do
            {
                Console.WriteLine("Enter the pet's name:");
                name = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(name))
                    Console.WriteLine("Pet name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(name));

            string breed;
            do
            {
                Console.WriteLine("Enter the pet's breed:");
                breed = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(breed))
                    Console.WriteLine("Breed cannot be empty.");
            } while (string.IsNullOrWhiteSpace(breed));

            string species;
            do
            {
                Console.WriteLine("Enter the pet's species (e.g., Dog, Cat):");
                species = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(species))
                    Console.WriteLine("Species cannot be empty.");
            } while (string.IsNullOrWhiteSpace(species));

            string gender;
            do
            {
                Console.WriteLine("Enter the pet's gender (M/F):");
                gender = Console.ReadLine()?.Trim().ToUpper();
                if (gender != "M" && gender != "F")
                    Console.WriteLine("Please enter 'M' for male or 'F' for female.");
            } while (gender != "M" && gender != "F");

            DateTime dateOfBirth;
            int currentYear = DateTime.Now.Year;

            while (true)
            {
                Console.WriteLine("Enter date of birth (yyyy-mm-dd):");
                string input = Console.ReadLine()?.Trim() ?? "";

                if (!DateTime.TryParse(input, out dateOfBirth))
                {
                    Console.WriteLine("Invalid date format. Please use yyyy-mm-dd.");
                    continue;
                }

                int age = currentYear - dateOfBirth.Year;

                if (dateOfBirth > DateTime.Now)
                {
                    Console.WriteLine("Date of birth cannot be in the future.");
                }
                else if (age > 100)
                {
                    Console.WriteLine("Age cannot be greater than 100 years.");
                }
                else
                {
                    // Valid date
                    break;
                }
            }

            string symptoms;
            do
            {
                Console.WriteLine("Enter the pet's symptoms:");
                symptoms = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(symptoms))
                    Console.WriteLine("Symptoms cannot be empty.");
            } while (string.IsNullOrWhiteSpace(symptoms));

            var newPet = new Pet(name, breed, species, gender, dateOfBirth);
            _repository.Create(newPet);

            Console.WriteLine("\nPet has been created successfully.");
            Console.WriteLine($"Pet ID: {newPet.PetId}");

            Console.WriteLine("Does this pet have an owner? (yes/no)");
            string hasOwner = Console.ReadLine()?.Trim().ToLower();

            if (hasOwner == "yes" || hasOwner == "y")
            {
                Console.WriteLine("Enter the owner's ID:");
                if (int.TryParse(Console.ReadLine(), out int ownerId))
                {
                    var owner = _clientRepository.GetById(ownerId);
                    if (owner != null)
                    {
                        owner.Pets ??= new List<Pet>();
                        owner.Pets.Add(newPet);
                        Console.WriteLine("Pet successfully assigned to the owner.");
                    }
                    else
                    {
                        Console.WriteLine("Owner not found. Pet will remain without an owner.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID. Pet will remain without an owner.");
                }
            }

            return newPet;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while creating the pet.");
            Console.WriteLine(e.Message);
        }

        return null;
    }

    public static void GetAllPets()
    {
        IEnumerable<Pet> pets = _repository.GetAll();

        if (pets == null)
        {
            Console.WriteLine("No pets found.");
            return;
        }

        foreach (var pet in pets)
        {
            Console.WriteLine(
                $"ID: {pet.PetId}, Name: {pet.Name}, Species: {pet.Species}, Breed: {pet.Breed}, Gender: {pet.Gender}, BirthDay: {pet.BirthDay}");
        }
    }

    public static void GetPetById(int id)
    {
        if (id <= 0)
        {
            Console.WriteLine("Error: invalid pet ID.");
            return;
        }

        var pet = _repository.GetById(id);

        if (pet == null)
        {
            Console.WriteLine("Pet not found.");
            return;
        }

        Console.WriteLine(
            $"ID: {pet.PetId}, Name: {pet.Name}, Species: {pet.Species}, Breed: {pet.Breed}, Gender: {pet.Gender}, BirthDay: {pet.BirthDay}");
    }

    public static void UpdatePet(int id)
    {
        try
        {
            string name;
            do
            {
                Console.WriteLine("Enter the pet's name:");
                name = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(name))
                    Console.WriteLine("Pet name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(name));

            string breed;
            do
            {
                Console.WriteLine("Enter the pet's breed:");
                breed = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(breed))
                    Console.WriteLine("Breed cannot be empty.");
            } while (string.IsNullOrWhiteSpace(breed));

            string species;
            do
            {
                Console.WriteLine("Enter the pet's species (e.g., Dog, Cat):");
                species = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(species))
                    Console.WriteLine("Species cannot be empty.");
            } while (string.IsNullOrWhiteSpace(species));

            string gender;
            do
            {
                Console.WriteLine("Enter the pet's gender (M/F):");
                gender = Console.ReadLine()?.Trim().ToUpper();
                if (gender != "M" && gender != "F")
                    Console.WriteLine("Please enter 'M' for male or 'F' for female.");
            } while (gender != "M" && gender != "F");

            DateOnly dateOfBirth;
            while (true)
            {
                Console.WriteLine("Enter the pet's date of birth (yyyy-mm-dd):");
                if (DateOnly.TryParse(Console.ReadLine(), out dateOfBirth))
                    break;
                Console.WriteLine("Invalid date format. Please use yyyy-mm-dd.");
            }
            
            var updatedPet = new Pet(name, breed, species, gender, dateOfBirth);
            var success = _repository.Update(updatedPet, id);

            if (success)
                Console.WriteLine("Pet updated successfully.");
            else
                Console.WriteLine("Error: pet not found or could not be updated.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong. Try again.");
            Console.WriteLine($"Error Type: {e.GetType().Name}");
            Console.WriteLine($"Details: {e.Message}");
            Console.WriteLine($"StackTrace: {e.StackTrace}");
        }
    }


    public static void DeletePet(int id)
    {
        if (id <= 0)
        {
            Console.WriteLine("Error: invalid pet ID.");
            return;
        }

        bool success = _repository.DeleteById(id);

        if (success)
            Console.WriteLine("Pet deleted successfully.");
        else
            Console.WriteLine("Error: pet not found or could not be deleted.");
    }
}