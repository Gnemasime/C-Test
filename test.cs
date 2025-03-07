using System;
using System.Collections.Generic;

namespace ContactsManagementSystem
{
    // Contact class to represent each contact
    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Constructor to create a new contact
        public Contact(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }
    }

    // ContactsManager class to manage contacts
    public class ContactsManager
    {
        private List<Contact> contacts;

        // Constructor initializes an empty contacts list
        public ContactsManager()
        {
            contacts = new List<Contact>();
        }

        // Method to add a new contact
        public void AddContact(string name, string phone, string email)
        {
            contacts.Add(new Contact(name, phone, email));
            Console.WriteLine("Contact added successfully.");
        }

        // Method to view all contacts
        public void ViewContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
                return;
            }

            Console.WriteLine("\nContacts List:");
            for (int i = 0; i < contacts.Count; i++)
            {
                var contact = contacts[i];
                Console.WriteLine($"{i + 1}. Name: {contact.Name}, Phone: {contact.Phone}, Email: {contact.Email}");
            }
        }

        // Method to update a contact
        public void UpdateContact(int index, string name, string phone, string email)
        {
            if (index < 0 || index >= contacts.Count)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            var contact = contacts[index];
            contact.Name = name;
            contact.Phone = phone;
            contact.Email = email;
            Console.WriteLine("Contact updated successfully.");
        }

        // Method to delete a contact
        public void DeleteContact(int index)
        {
            if (index < 0 || index >= contacts.Count)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            contacts.RemoveAt(index);
            Console.WriteLine("Contact deleted successfully.");
        }
    }

    // Main Program class to handle user interaction
    class Program
    {
        static void Main(string[] args)
        {
            ContactsManager manager = new ContactsManager();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Contacts Management System ===");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Update Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter your choice: ");
                
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter phone number: ");
                        string phone = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();

                        manager.AddContact(name, phone, email);
                        break;

                    case "2":
                        manager.ViewContacts();
                        Console.WriteLine("\nPress any key to go back to the main menu...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Write("Enter the contact index to update: ");
                        int updateIndex = int.Parse(Console.ReadLine()) - 1; // 1-based to 0-based index
                        if (updateIndex >= 0)
                        {
                            Console.Write("Enter new name: ");
                            string newName = Console.ReadLine();
                            Console.Write("Enter new phone number: ");
                            string newPhone = Console.ReadLine();
                            Console.Write("Enter new email: ");
                            string newEmail = Console.ReadLine();

                            manager.UpdateContact(updateIndex, newName, newPhone, newEmail);
                        }
                        break;

                    case "4":
                        Console.Write("Enter the contact index to delete: ");
                        int deleteIndex = int.Parse(Console.ReadLine()) - 1; // 1-based to 0-based index
                        if (deleteIndex >= 0)
                        {
                            manager.DeleteContact(deleteIndex);
                        }
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to go back to the main menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
