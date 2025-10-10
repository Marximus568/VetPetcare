using VetPetcare.Models;
using VetPetcare.Repository;

public static class ServiceVeterinary
{
    private static readonly VeterinaryRepository _repository = new VeterinaryRepository();

    // ==========================
    // CREATE VETERINARY
    // ==========================
    public static Veterinary? CreateVeterinary()
    {
        try
        {
            string firstName;
            do
            {
                Console.WriteLine("Enter the veterinary's first name:");
                firstName = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(firstName))
                    Console.WriteLine("First name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(firstName));

            string lastName;
            do
            {
                Console.WriteLine("Enter the veterinary's last name:");
                lastName = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(lastName))
                    Console.WriteLine("Last name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(lastName));

            DateTime dateOfBirth;
            while (true)
            {
                Console.WriteLine("Enter the veterinary's date of birth (yyyy-mm-dd):");
                if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                    break;
                Console.WriteLine("Invalid date format. Please use yyyy-mm-dd.");
            }

            string gender;
            do
            {
                Console.WriteLine("Enter the veterinary's gender (M/F):");
                gender = Console.ReadLine()?.Trim().ToUpper();
                if (gender != "M" && gender != "F")
                    Console.WriteLine("Please enter 'M' for male or 'F' for female.");
            } while (gender != "M" && gender != "F");

            string email;
            do
            {
                Console.WriteLine("Enter the veterinary's email:");
                email = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                    Console.WriteLine("Invalid email. Please include '@'.");
            } while (string.IsNullOrWhiteSpace(email) || !email.Contains("@"));

            string address;
            do
            {
                Console.WriteLine("Enter the veterinary's address:");
                address = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(address))
                    Console.WriteLine("Address cannot be empty.");
            } while (string.IsNullOrWhiteSpace(address));

            string speciality;
            do
            {
                Console.WriteLine("Enter the veterinary's speciality:");
                speciality = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(speciality))
                    Console.WriteLine("Speciality cannot be empty.");
            } while (string.IsNullOrWhiteSpace(speciality));

            var newVeterinary = new Veterinary(firstName, lastName, dateOfBirth, gender, email, address, speciality);
            _repository.Create(newVeterinary);

            Console.WriteLine("\nVeterinary created successfully!");
            Console.WriteLine($"Veterinary ID: {newVeterinary.VeterinaryId}");

            return newVeterinary;
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while creating the veterinary.");
            Console.WriteLine(e.Message);
        }

        return null;
    }

    // ==========================
    // GET BY ID
    // ==========================
    public static void FindVeterinary(int id)
    {
        var veterinary = _repository.GetById(id);
        if (veterinary == null)
        {
            Console.WriteLine("Veterinary not found.");
            return;
        }

        Console.WriteLine("\nVeterinary found:");
        Console.WriteLine($"ID: {veterinary.VeterinaryId}");
        Console.WriteLine($"Name: {veterinary.FirstName} {veterinary.LastName}");
        Console.WriteLine($"Date of Birth: {veterinary.DateOfBirth}");
        Console.WriteLine($"Gender: {veterinary.Gender}");
        Console.WriteLine($"Email: {veterinary.Email}");
        Console.WriteLine($"Address: {veterinary.Address}");
        Console.WriteLine($"Speciality: {veterinary.speciality}");
    }

    // ==========================
    // GET ALL
    // ==========================
    public static void ShowList()
    {
        var veterinaries = _repository.GetAll().ToList();

        if (veterinaries.Count == 0)
        {
            Console.WriteLine("No veterinaries registered.");
            return;
        }

        foreach (var v in veterinaries)
        {
            Console.WriteLine(v.GetInfo());
            Console.WriteLine($"Speciality: {v.speciality}");
            Console.WriteLine(new string('-', 40));
        }
    }


    // ==========================
    // UPDATE
    // ==========================
    public static void UpdateVeterinary(int id)
    {
        try
        {
            string firstName;
            do
            {
                Console.WriteLine("Enter new first name:");
                firstName = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(firstName))
                    Console.WriteLine("First name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(firstName));

            string lastName;
            do
            {
                Console.WriteLine("Enter new last name:");
                lastName = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(lastName))
                    Console.WriteLine("Last name cannot be empty.");
            } while (string.IsNullOrWhiteSpace(lastName));

            DateTime dateOfBirth;
            while (true)
            {
                Console.WriteLine("Enter new date of birth (yyyy-mm-dd):");
                if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                    break;
                Console.WriteLine("Invalid date format. Try again.");
            }

            string gender;
            do
            {
                Console.WriteLine("Enter new gender (M/F):");
                gender = Console.ReadLine()?.Trim().ToUpper();
                if (gender != "M" && gender != "F")
                    Console.WriteLine("Please enter 'M' or 'F'.");
            } while (gender != "M" && gender != "F");

            string email;
            do
            {
                Console.WriteLine("Enter new email:");
                email = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                    Console.WriteLine("Invalid email format.");
            } while (string.IsNullOrWhiteSpace(email) || !email.Contains("@"));

            string address;
            do
            {
                Console.WriteLine("Enter new address:");
                address = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(address))
                    Console.WriteLine("Address cannot be empty.");
            } while (string.IsNullOrWhiteSpace(address));

            string speciality;
            do
            {
                Console.WriteLine("Enter new speciality:");
                speciality = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(speciality))
                    Console.WriteLine("Speciality cannot be empty.");
            } while (string.IsNullOrWhiteSpace(speciality));

            var tempVeterinary = new Veterinary(firstName, lastName, dateOfBirth, gender, email, address, speciality);
            var success = _repository.Update(tempVeterinary, id);

            if (success)
                Console.WriteLine("Veterinary updated successfully.");
            else
                Console.WriteLine("Error: veterinary not found or could not be updated.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while updating the veterinary.");
            Console.WriteLine($"Error Type: {e.GetType().Name}");
            Console.WriteLine($"Details: {e.Message}");
        }
    }

    // ==========================
    // DELETE
    // ==========================
    public static void DeleteVeterinary(int id)
    {
        var deleted = _repository.DeleteById(id);

        if (!deleted)
        {
            Console.WriteLine("Veterinary not found. Nothing was deleted.");
            return;
        }

        Console.WriteLine("Veterinary deleted successfully.");
    }
}
