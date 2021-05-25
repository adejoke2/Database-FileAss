namespace ContactListDB
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
        
    }
}