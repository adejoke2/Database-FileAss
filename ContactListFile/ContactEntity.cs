using System;

namespace ContactListFile
{
    public class ContactEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string OfficeAddress { get; set; }

        public ContactEntity(int id, string name, string phonenumber, string  email, string officeAddress)
        {
            Id = id;

            Name = name;
            
            PhoneNumber = phonenumber;

            Email = email;

            OfficeAddress = officeAddress;
        }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{PhoneNumber}\t{Email}\t{OfficeAddress} ";
        }

        internal static ContactEntity StringToStudentEntity(string contactString)
        {
            var props = contactString.Split("\t");

            int id = int.Parse(props[0]);

            return new ContactEntity(id, props[1], props[2], props[3], props[4]);
        }
        
    }
}