using VetPetcare.Repository;

namespace VetPetcare.Models
{
    public static class ServiceClient
    {
        private static readonly ClientRepository _repository = new ClientRepository();

        // Method for created new client
        public static void CreateClient()
        {
            try
            {
                string firstName;
                do
                {
                    Console.WriteLine("Enter your first name:");
                    firstName = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(firstName)) Console.WriteLine("First name cannot be empty.");
                } while (string.IsNullOrWhiteSpace(firstName));

                string lastName;
                do
                {
                    Console.WriteLine("Enter your last name:");
                    lastName = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(lastName)) Console.WriteLine("Last name cannot be empty.");
                } while (string.IsNullOrWhiteSpace(lastName));

                DateTime dateOfBirth;
                while (true)
                {
                    Console.WriteLine("Enter your date of birth (yyyy-mm-dd):");
                    if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth)) break;
                    Console.WriteLine("Invalid date format. Please use yyyy-mm-dd.");
                }

                string gender;
                do
                {
                    Console.WriteLine("Enter your gender (M/F):");
                    gender = Console.ReadLine()?.Trim().ToUpper();
                    if (gender != "M" && gender != "F")
                        Console.WriteLine("Please enter 'M' for male or 'F' for female.");
                } while (gender != "M" && gender != "F");

                string email;
                do
                {
                    Console.WriteLine("Enter your email:");
                    email = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                        Console.WriteLine("Invalid email. Please include '@'.");
                } while (string.IsNullOrWhiteSpace(email) || !email.Contains("@"));

                string address;
                do
                {
                    Console.WriteLine("Enter your address:");
                    address = Console.ReadLine()?.Trim();
                    if (string.IsNullOrWhiteSpace(address)) Console.WriteLine("Address cannot be empty.");
                } while
                    (string.IsNullOrWhiteSpace(address)); // Crear y guardar cliente

                var newClient = new Client(firstName, lastName, dateOfBirth, gender, email, address);
                _repository.Create(newClient);
                Console.WriteLine("\n Your client has been created successfully!");
                Console.WriteLine($"Your ID is: {newClient.ClientId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(" Something went wrong. Try again.");
                Console.WriteLine(e.Message);
            }
        }

        //Method for search by ID
        public static string FindClient(int id)
        {
            var client = _repository.GetById(id);
            if (client == null)
            {
                Console.WriteLine("Client not found.");
                return "Not found";
            }

            Console.WriteLine("Client found:\n");
            Console.WriteLine(client.GetInfo());
            return "Found...";
        }

        // Method for show all client
        public static void ShowList()
        {
            var clients = _repository.GetAll().ToList();

            if (clients.Count == 0)
            {
                Console.WriteLine("No clients registered.");
                return;
            }

            foreach (var client in clients)
            {
                Console.WriteLine(client.GetInfo());
                Console.WriteLine($"Pets: {client.Pets.Count}");
                Console.WriteLine(new string('-', 40));
            }
        }

        public static void UpdateUser(Client newClient, int id)
        {
            if (newClient == null)
            {
                Console.WriteLine("Error: client cannot be null.");
                return;
            }

            if (id <= 0)
            {
                Console.WriteLine("Error: ID must be greater than 0.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newClient.FirstName) ||
                string.IsNullOrWhiteSpace(newClient.LastName))
            {
                Console.WriteLine("Error: first name and last name are required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newClient.Email) ||
                !newClient.Email.Contains("@"))
            {
                Console.WriteLine("Error: invalid email address.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newClient.Gender))
            {
                Console.WriteLine("Error: gender is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newClient.Address))
            {
                Console.WriteLine("Error: address is required.");
                return;
            }

            if (newClient.DateOfBirth == default)
            {
                Console.WriteLine("Error: date of birth is required.");
                return;
            }

            if (newClient.DateOfBirth.Year > DateTime.Now.Year)
            {
                Console.WriteLine("Error: year of birth cannot be greater than the current year.");
                return;
            }

            if (newClient.DateOfBirth > DateTime.Now)
            {
                Console.WriteLine("Error: date of birth cannot be in the future.");
                return;
            }

            var success = _repository.Update(newClient, id);

            if (success != true)
                Console.WriteLine("Client updated successfully.");
            else
                Console.WriteLine("Error: client not found or could not be updated.");
        }


        // Method for delete client by ID
        public static void DeleteClient(int id)
        {
            var deleted = _repository.DeleteById(id);
            if (deleted == false)
            {
                Console.WriteLine("Client not found. Nothing was deleted.");
                return;
            }

            Console.WriteLine($"Client was successfully deleted.");
        }
    }
}