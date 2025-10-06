using VetPetcare.Repository;

namespace VetPetcare.Models
{
    public static class ServiceClient
    {
        private static readonly ClientRepository _repository = new ClientRepository();

        // Crear nuevo cliente
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
                    (string.IsNullOrWhiteSpace(
                         address)); // Crear y guardar cliente

                var newClient = new Client(firstName, lastName, dateOfBirth, gender, email, address);
                _repository.Create(newClient);
                Console.WriteLine("\n Your client has been created successfully!");
                Console.WriteLine($"Your ID is: {newClient.Id}");
            }
            catch (Exception e)
            {
                Console.WriteLine(" Something went wrong. Try again.");
                Console.WriteLine(e.Message);
            } }

            // Buscar cliente por ID
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

            // Mostrar todos los clientes
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

            // Eliminar cliente por ID
            public static void DeleteClient(int id)
            {
                var deleted = _repository.DeleteById(id);
                if (deleted == null)
                {
                    Console.WriteLine("Client not found. Nothing was deleted.");
                    return;
                }

                Console.WriteLine($"Client with ID {deleted.Id} was successfully deleted.");
            }
        }
    }