using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace ContactListDB
{
    public class ContactRepository
    {
        MySqlConnection conn;

        public static List<ContactEntity> Contacts = new List<ContactEntity>();

        public ContactRepository(MySqlConnection connection)
        {
            conn = connection;
        }
        
        public bool AddContactInfo(int id, string name, string phonenumber, string email, string officeAddress)
        {
            try
            {
                conn.Open();
                string addStudentInfo = "Insert into ContactInformation (id, name, phonenumber, email, officeAddress)values ('" + id + "', '" + name + "', '" + phonenumber + "', '" + email + "', '" + officeAddress + "')";
                MySqlCommand command = new MySqlCommand(addStudentInfo, conn);

                Console.WriteLine("Contact Information Added Sucessfully!");
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }
        public void GetContactInfo()
        {
            foreach (var contact in Contacts)
            {
                Console.WriteLine($"Contact Id: {contact.Id}, Contact Name: {contact.Name}, Contact Phone-Number: {contact.PhoneNumber}, Contact E-mail: {contact.Email},Contact Office Address: {contact.OfficeAddress} ");
            }
        }
        public ContactEntity FindContact(string name)
        {
            ContactEntity contact = null;
            try
            {
                conn.Open();
                string contactQuery = "Select id, name, phonenumber, email, officeAddress from ContactInformation where phonenumber = '" + name + "'";
                MySqlCommand command = new MySqlCommand(contactQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    {
                        int id = reader.GetInt32(0);

                        string phonenumber = reader.GetString(3);

                        string email = reader.GetString(4);

                        string officeAddress = reader.GetString(5);

                        contact = new ContactEntity(id, name, phonenumber, email, officeAddress);
                    }
                    Console.WriteLine($"Contact Name: {reader[1]}");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return contact;
        }
        public void ListAllEmails()
        {
            List<ContactEntity> contacts = new List<ContactEntity>();
            try
            {
                conn.Open();
                string studentQuery = "Select id, name, phonenumber, phonenumber, officeAddress, class from studentInformation";
                MySqlCommand command = new MySqlCommand(studentQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[4]);
                }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public bool UpdateContactInfo(string id, string email, int officeAddress)
        {
            var contact = FindContact(email);
            if (contact == null)
            {
                Console.WriteLine($"Contact with {email} does not exist");
            }
            try
            {
                conn.Open();
                string updateContactQuery = "update contactInformation set id ='" + id + "', officeAddress = '" + officeAddress + "' where phonenumber = '" + email + "'";
                MySqlCommand command = new MySqlCommand(updateContactQuery, conn);
                Console.WriteLine("Contact Updated Sucessful!");
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }
        public bool DeleteContact(string email)
        {
            if (email == null)
            {
                Console.WriteLine($"Contact with the Email: {email} does not exist");
            }
            try
            {
                conn.Open();
                string deleteContactQuery = "delete from ContactInformation where name = '" + email + "'";
                Console.WriteLine("Contact Information Deleted Sucessfully!");
                MySqlCommand command = new MySqlCommand(deleteContactQuery, conn);
                int Count = command.ExecuteNonQuery();
                if (Count > 0)
                {
                    conn.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return false;
        }

        public ContactEntity FindContactByEmail(string email)
        {
            return Contacts.Find(s => s.Email == email);
        }

        public ContactEntity FindContactByName(string name)
        {
            return Contacts.Find(s => s.Name == name);
        }        
    }
}