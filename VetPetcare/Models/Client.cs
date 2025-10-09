using System.ComponentModel.DataAnnotations;
using VetPetcare.Models;

public class Client(
    string firstName,
    string lastName,
    DateTime dateOfBirth,
    string gender,
    string email,
    string address)
    : People(firstName, lastName, dateOfBirth, gender, email, address)
{
    public int ClientId
    {
        get => base.Id;
        internal set => base.Id = value;
    }

    public List<Pet> Pets { get; set; } = new();
}