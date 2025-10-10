    Vet Petcare System
Description

Vet Petcare is a console-based application designed to manage veterinary clinic operations, including clients, pets, veterinarians, and medical appointments. The system allows scheduling, viewing, updating, and deleting records, as well as performing queries for better management of veterinary services.

Features

Client Management

Register, view, update, and delete clients.

Pet Management

Register, view, update, and delete pets for each client.

Veterinary Management

Register, view, update, and delete veterinarians with specialties.

Medical Appointment Management

Schedule appointments with predefined time slots.

Assign a veterinarian and a client to an appointment.

Specify appointment type (Consultation, Bath, Vaccination) and symptoms.

View, update, and delete appointments.

Queries

Search pets by breed or name.

Order clients or pets by age or name.

Group pets by breed.

Project Structure
VetPetcare/
├── Models/
│   ├── Client.cs
│   ├── Pet.cs
│   ├── Veterinary.cs
│   ├── MedicalAppointment.cs
│   └── ...
├── Repository/
│   ├── ClientRepository.cs
│   ├── PetRepository.cs
│   ├── VeterinaryRepository.cs
│   ├── MedicalAppointmentRepository.cs
│   └── IMedicalAppointment.cs
├── Services/
│   ├── ServiceClient.cs
│   ├── ServicePet.cs
│   ├── ServiceVeterinary.cs
│   └── ServiceMedicalAppointment.cs
├── Utils/
│   ├── MenuClient.cs
│   ├── MenuPet.cs
│   ├── MenuVeterinary.cs
│   ├── MenuMedicalAppointment.cs
│   └── MenuMain.cs
└── Database/
└── Database.cs

Technologies

C# 11

.NET 7

Console Application

Object-Oriented Programming (OOP)

In-memory storage using Dictionary and List

DateOnly and TimeOnly for handling dates and time slots

LINQ for queries and data manipulation

Getting Started
Prerequisites

.NET 7 SDK installed on your system.

IDE such as Visual Studio or Visual Studio Code.

How to Run

Clone the repository:

git clone https://github.com/your-username/vet-petcare.git


Open the project in Visual Studio or VS Code.

Build the project.

Run the application:

dotnet run


Navigate through the main menu to manage clients, pets, veterinarians, or appointments.

Usage
Main Menu

Menu Client – Manage clients.

Menu Pet – Manage pets.

Menu Veterinary – Manage veterinarians.

Menu Date – Schedule and manage appointments.

Menu Query – Perform queries on clients or pets.

Exit – Close the application.

Appointment Scheduling

Select a date for the appointment.

Choose a time slot (e.g., 12:00 PM - 2:00 PM).

Enter veterinary ID.

Enter client ID.

Select appointment type: Consultation, Bath, or Vaccination.

Appointment is saved to the in-memory database.

Notes

All data is stored in-memory using static dictionaries and lists.

The application uses a layered architecture: Models → Repository → Services → Menus.

Input validation is performed for dates, IDs, emails, and other fields.

Designed to be easily extended to a database-backed system in the future.