using System;
using System.Collections.Generic;
using System.IO;

namespace StudentRecordKeepingSystem
{
    public class StudentRepository
    {
        public List<StudentEntity> Students = new List<StudentEntity>();

        public StudentRepository()
        {
            FetchStudentInfoFromFile();
        }

        public void FetchStudentInfoFromFile()
        {
            try
            {
                var studentInfoLines = File.ReadAllLines("student.txt");
                foreach (var studentInfoLine in studentInfoLines)
                {
                    var student = StudentEntity.StringToStudentEntity(studentInfoLine);
                    Students.Add(student);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintStudentInfo(StudentEntity student)
        {
            Console.WriteLine($"First Name: {student.FirstName}, Last Name: {student.LastName}, Email: {student.Email}, Phone Number: {student.PhoneNumber}, Age: {student.Age}, Class: {student.Class} ");
        }

        public void GetStudentInfo()
        {
            foreach (StudentEntity student in Students)
            {
                PrintStudentInfo(student);
            }
        }

        public List<StudentEntity> ListStudentInfo()
        {
            return Students;
        }

        public void AddStudentInfo(string firstName, string lastName, string email, string phoneNumber, int age, string studentClass)
        {
            var stockExist = FindStudentByEmail(email);

            if (stockExist != null)
            {
                Console.WriteLine($"Student with {email} already exist");
            }

            StudentEntity student = new StudentEntity(firstName, lastName, email, phoneNumber, age, studentClass);

            Students.Add(student);

            TextWriter writer = new StreamWriter("student.txt", true);
            writer.WriteLine(student.ToString());
            Console.WriteLine("Student Info added successfully!");
            writer.Close();
        }

        public void UpdateStudent(string firstName, string lastName, string email, string phoneNumber, int age, string studentClass)
        {
            var student = FindStudentByEmail(email);
            if (student == null)
            {
                Console.WriteLine($"Student with {email} does not exist");
            }

            student.FirstName = firstName;
            RefreshFile();
        }

        public void RefreshFile()
        {
            TextWriter writer = new StreamWriter("student.txt");
            foreach (var student in Students)
            {
                writer.WriteLine(student);
            }
            writer.Flush();
            writer.Close();
        }

        public void DeleteStudentLastName(string lastName)
        {
            var student = FindStudentByLastName(lastName);
            if (student == null)
            {
                Console.WriteLine($"Student with {lastName} does not exist");
            }

            Students.RemoveAll(student => student.LastName == lastName);
            RefreshFile();
        }

        public StudentEntity FindStudentByEmail(string email)
        {
            return Students.Find(s => s.Email == email);
        }

        public List<StudentEntity> FindStudentByLastName(string lastName)
        {
           return Students.FindAll(s => s.LastName == lastName);
        }

        public void FindStudent()
        {
            Console.WriteLine("Enter the email of the Student you want to find: ");
            string email = Console.ReadLine();

            var student = FindStudentByEmail(email);

            if (student == null)
            {
                Console.WriteLine($"Student with Email \t {email} does not exist! ");
            }

            else
            {
                Console.WriteLine($"First Name: {student.FirstName} Last Name: {student.LastName} Email: {student.Email} Phone Number: {student.PhoneNumber} Age: {student.Age} Class: {student.Class} ");
            }
        }
        public void ListAllEmails()
        {
            {
                foreach (var student in Students)
                {
                    Console.WriteLine($"Email: {student.Email} ");
                }
            }
        }

        public void AgesGreaterThan18()
        {
            List<StudentEntity> Students = new List<StudentEntity>();
            {
                int count = 0;
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine($"Age: {Students[2]}");
                    count++;
                }
                
                Console.WriteLine($"Number of Students with ages greater than 18 is {count}. ");
            }
        }

        public void ListAllStudentInJss1()
        {
            List<StudentEntity> Students = new List<StudentEntity>();
            
            foreach (var student in Students)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName+ " " + student.Email + " " + student.PhoneNumber + " " + student.Age + " " + student.Class);
            }
               
        }
        public void UpdateStudent(string firstName, string email, int age)
        {
            var student = FindStudentByEmail(email);

            if (student == null)
            {
                Console.WriteLine($"Student with {email} does not exist");
            }
            else
            {
                foreach(var studente in Students)
                {
                    studente.FirstName = firstName;
                    studente.Age = age;
                }
            }
        }
    }
}