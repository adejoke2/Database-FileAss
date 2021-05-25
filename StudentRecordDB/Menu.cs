using System;
using MySql.Data.MySqlClient;

namespace StudentRecord
{
    public class Menu
    {
        static string connectionString = "server=localhost;user=root;database=studentmanagement;port=3306;password=Adejoke#19?";
        static MySqlConnection conn = new MySqlConnection(connectionString);
        StudentRepository studentRepo = new StudentRepository(conn);
        private void StudentMenu()
        {
            Console.WriteLine("0. Exit");

            Console.WriteLine("1. Add Student Information");

            Console.WriteLine("2. Find Student Information By Email");

            Console.WriteLine("3. List all Emails");

            Console.WriteLine("4. Update Student Information");

            Console.WriteLine("5. Delete Student Information");

            Console.WriteLine("6. Number of Student greater than 18");

            Console.WriteLine("7. Information of Students in Jss1");
        }
        private void AddStudentInfo()
        {
            Console.Write("Enter Student First Name: ");
            string firstname = Console.ReadLine();

            Console.Write("Enter Student last Name: ");
            string lastname = Console.ReadLine();

            Console.Write("Enter Student E-Mail: ");
            string email = Console.ReadLine();

            Console.Write("Enter Student Phone-No: ");
            string phonenumber = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Class: ");
            string studentclass = Console.ReadLine().ToLower();

            studentRepo.AddStudentInfo(firstname, lastname, email, phonenumber, age, studentclass);
        }
        private void UpdateStudent()
        {
            Console.Write("Enter E-Mail of student you want to update: ");
            string email = Console.ReadLine();

            Console.Write("Update Student First Name: ");
            string firstname = Console.ReadLine();

            Console.Write("Update Student Age: ");
            int age = int.Parse(Console.ReadLine());

            studentRepo.UpdateStudentInfo(firstname, email,  age);
        }
        private void DeleteStudent()
        {
            Console.Write("Enter Last Name of Student you want to Delete: ");
            string lastname = Console.ReadLine();
            studentRepo.DeleteStudent(lastname);
        }
        public void MainMenu()
        {
            StudentMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddStudentInfo();
                    MainMenu();
                    break;
                case "2":
                    Console.Write("Enter E-mail of the Student you want to Find: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("");
                    studentRepo.FindStudent(email);
                    MainMenu();
                    break;
                case "3":
                    studentRepo.ListAllEmails();
                    MainMenu();
                    break;
                case "4":
                    UpdateStudent();
                    MainMenu();
                    break;
                case "5":
                    DeleteStudent();
                    MainMenu();
                    break;
                case "6":
                    studentRepo.Above18Years();
                    MainMenu();
                    break;
                case "7":
                    studentRepo.ListOfJss1Students();
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}