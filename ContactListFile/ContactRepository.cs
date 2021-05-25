using System;
using System.Collections.Generic;
using System.IO;
namespace ContactListFile
{
    public class ContactRepository
    {
        public List<ContactEntity> Contacts = new List<ContactEntity>();

        public ContactRepository()
        {
            FetchContactInfoFromFile();
        }

        public void FetchContactInfoFromFile()
        {
            try
            {
                var contactInfoLines = File.ReadAllLines("MyContactList.txt");
                foreach (var contactInfoLine in contactInfoLines)
                {
                    var contact = ContactEntity.StringToStudentEntity(contactInfoLine);
                    Contacts.Add(contact);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // public void GetContactInfo(ContactEntity contact)
        // {
        //     Console.WriteLine($"Contact Id: {contact.Id}, Contact Name: {contact.Name}, Contact Phone-Number: {contact.PhoneNumber}, Contact E-mail: {contact.Email},Contact Office Address: {contact.OfficeAddress} ");
        // }

        public void GetContactInfo()
        {
            foreach (var contact in Contacts)
            {
                Console.WriteLine($"Contact Id: {contact.Id}, Contact Name: {contact.Name}, Contact Phone-Number: {contact.PhoneNumber}, Contact E-mail: {contact.Email},Contact Office Address: {contact.OfficeAddress} ");
            }
        }

        // public List<ContactEntity> ListContactInfo()
        // {
        //     return Contacts;
        // }

        public void AddContactInfo(int id, string name, string phonenumber, string email, string officeAddress)
        {
            var contactExist = FindContactByEmail(phonenumber);

            if (contactExist != null)
            {
                Console.WriteLine($"Contact with No:{phonenumber} already exist");
            }
            ContactEntity contact = new ContactEntity(id, name, phonenumber, email, officeAddress);

            Contacts.Add(contact);

            TextWriter writer = new StreamWriter("MyContactList.txt", true);
            writer.WriteLine(contact.ToString());
            Console.WriteLine("Contact added successfully!");
            writer.Close();
        }
        public void RefreshFile()
        {
            TextWriter writer = new StreamWriter("MyContactList.txt");
            foreach (var contact in Contacts)
            {
                writer.WriteLine(contact);
            }
            writer.Flush();
            writer.Close();
        }

        public void DeleteContact(string email)
        {
            Contacts.RemoveAll(student => student.Email == email);
            Console.WriteLine("Contact Deleted Sucessfully!!");
            RefreshFile();
        }

        public ContactEntity FindContactByEmail(string email)
        {
            return Contacts.Find(s => s.Email == email);
        }

        public ContactEntity FindContactByName(string name)
        {
            return Contacts.Find(s => s.Name == name);
        }

        public void FindContact()
        {
            Console.Write("Enter the name of Contact you want to find: ");
            string name = Console.ReadLine().ToLower();

            var contact = FindContactByName(name);

            if (contact == null)
            {
                Console.WriteLine($"Contact: {name} does not exist! ");
            }

            else
            {
                Console.WriteLine($"Contact Id: {contact.Id}, Contact Name: {contact.Name}, Phone-Number: {contact.PhoneNumber}, Email: {contact.Email}, Office Address: {contact.OfficeAddress} ");
            }
        }
        public void ListAllEmails()
        {
            foreach (var contact in Contacts)
            {
                Console.WriteLine($"Email: {contact.Email} ");
            }
        }
        public void UpdateContact(int id, string name, string phonenumber, string email, string officeAddress)
        {
            var contact = FindContactByEmail(email);

            if (contact == null)
            {
                Console.WriteLine($"Contact with E-mail: {email} does not exist");
            }
            else
            {
                contact.Id = id;
                contact.Name = name;
                contact.PhoneNumber = phonenumber;
                contact.OfficeAddress = officeAddress;
                Console.WriteLine("Contact Updated Sucessfully!!");
            }
        }
        
    }
}