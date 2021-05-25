using System;
using System.Collections.Generic;

namespace ContactListFile
{
    public class Menu
    {
        static ContactRepository contactRepo = new ContactRepository();

        private void ShowMenu()
        {
            Console.WriteLine("0. Back");

            Console.WriteLine("1. Add Contact");

            Console.WriteLine("2. List all Contacts");

            Console.WriteLine("3. Find Contact Information");

            Console.WriteLine("4. Update Contact");

            Console.WriteLine("5. Delete Contact");

            Console.WriteLine("6. Search Contact");
        }

        public void AddContactDetails()
        {
            Console.Write("Contact Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Contact Name: ");
            string name = Console.ReadLine().ToLower();

            Console.Write("Phone Number: ");
            string phonenumber = Console.ReadLine();

            Console.Write("E-mail Address: ");
            string email = Console.ReadLine().ToLower();

            Console.Write("Office Address: ");
            string officeAddress = Console.ReadLine();

            contactRepo.AddContactInfo(id, name, email, phonenumber, officeAddress);
        }

        public void UpdateContactDetails()
        {
            Console.Write("Enter E-mail Address of Contact you want to Update: ");
            string email = Console.ReadLine().ToLower();

            Console.Write("Update Contact Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Update Name: ");
            string name = Console.ReadLine().ToLower();

            Console.Write("Update Phone Number: ");
            string phonenumber = Console.ReadLine();

            Console.Write("Update Office Address: ");
            string officeAddress = Console.ReadLine();

            contactRepo.UpdateContact(id, name, email, phonenumber, officeAddress);
            contactRepo.RefreshFile();
        }

        public void DeleteContacti()
        {
            Console.Write("Enter the Contat name you want to delete: ");
            string name = Console.ReadLine().ToLower();

            Console.Write("Are you sure you want to delete? (y/n) ");
            string option = Console.ReadLine().ToLower();

            if(option == "y")
            {
                contactRepo.DeleteContact(name);

                Console.WriteLine($"Contact: {name} deleted successfully! ");
            }

            else
            {
                ShowMenu();
            }
        }
        public void ShowContactMenu()
        {
            ShowMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddContactDetails();
                    ShowContactMenu();
                    break;
                case "2":
                    contactRepo.GetContactInfo();
                    ShowContactMenu();
                    break;

                case "3":
                    contactRepo.FindContact();
                    ShowContactMenu();
                    break;

                case "4":
                    UpdateContactDetails();
                    ShowContactMenu();
                    break;

                case "5":
                    DeleteContacti();
                    ShowContactMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
        
    }
}