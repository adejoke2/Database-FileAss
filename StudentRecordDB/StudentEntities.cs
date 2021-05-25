namespace StudentRecord
{
    public class StudentEntities
    {
        public string FirstName {get; set; }

        public string LastName {get; set; }

        public string Email {get; set; }

        public string PhoneNumber {get; set; }

        public int Age {get; set; }

        public string Class {get; set; }

        public StudentEntities(string firstname, string lastname, string email, string phonenumber, int age, string studentclass)
        {
            firstname = FirstName;

            lastname = LastName;

            email = Email;

            phonenumber = PhoneNumber;

            age = Age;

            studentclass = Class;
        }
        
    }
}