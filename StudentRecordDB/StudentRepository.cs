using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace StudentRecord
{
    public class StudentRepository
    {
        MySqlConnection conn;

        public static List<StudentEntities> Students = new List<StudentEntities>();

        public StudentRepository(MySqlConnection connection)
        {
            conn = connection;
        }
        public bool AddStudentInfo(string firstname, string lastname, string email, string phonenumber, int age, string studentclass)
        {
            try
            {
                conn.Open();
                string addStudentInfo = "Insert into studentInformation (firstname, lastname, email, phonenumber, age, class)values ('" + firstname + "', '" + lastname + "', '" + email + "', '" + phonenumber + "', '" + age + "', '" + studentclass + "')";
                MySqlCommand command = new MySqlCommand(addStudentInfo, conn);
                Console.WriteLine("Student Information Added Sucessfully!");
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
        public StudentEntities FindStudent(string email)
        {
            StudentEntities student = null;
            try
            {
                conn.Open();
                string studentQuery = "Select firstname, lastname, email, phonenumber, age, class from studentInformation where email = '" + email + "'";
                MySqlCommand command = new MySqlCommand(studentQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    {
                        string firstname = reader.GetString(0);

                        string lastname = reader.GetString(1);

                        string phonenumber = reader.GetString(3);

                        int age = reader.GetInt32(4);

                        string studentclass = reader.GetString(5);

                        student = new StudentEntities(firstname, lastname, email, phonenumber, age, studentclass);
                    }
                    Console.WriteLine($"Student First Name: {reader[0]}  Student Last Name: {reader[1]}");
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return student;
        }
        public void ListAllEmails()
        {
            List<StudentEntities> students = new List<StudentEntities>();
            try
            {
                conn.Open();
                string studentQuery = "Select firstname, lastname, email, phonenumber, age, class from studentInformation";
                MySqlCommand command = new MySqlCommand(studentQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[2]);
                }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public bool UpdateStudentInfo(string firstname, string email, int age)
        {
            var student = FindStudent(email);
            if (student == null)
            {
                Console.WriteLine($"Student with {email} does not exist");
            }
            try
            {
                conn.Open();
                string updateStudentQuery = "update studentInformation set firstname ='" + firstname + "', age = '" + age + "' where email = '" + email + "'";
                MySqlCommand command = new MySqlCommand(updateStudentQuery, conn);
                Console.WriteLine("Student Updated Sucessful!");
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
        public bool DeleteStudent(string lastname)
        {
            if (lastname == null)
            {
                Console.WriteLine($"student with the LastName: {lastname} does not exist");
            }
            try
            {
                conn.Open();
                string deleteCategoryQuery = "delete from studentInformation where lastname = '" + lastname + "'";
                Console.WriteLine("Student Information Deleted Sucessfully!");
                MySqlCommand command = new MySqlCommand(deleteCategoryQuery, conn);
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
        public void Above18Years()
        {
            int AgeGraterThan18 = 0;
            try
            {
                conn.Open();
                string studentQuery = "select age from studentInformation where age > 18";
                MySqlCommand command = new MySqlCommand(studentQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();  
                while (reader.Read())
                {
                    AgeGraterThan18++;
                }
                Console.WriteLine($"No. of people greater than 18years = {AgeGraterThan18}");
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
        public void ListOfJss1Students()
        {
            try
            {
                conn.Open();
                string studentQuery = "select firstname, lastname, email, phonenumber, age, class from studentInformation where class = 'jss1';";
                MySqlCommand command = new MySqlCommand(studentQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"First Name: {reader[0]}, Last Name: {reader[1]}, E-mail: {reader[2]}, Phone No.: {reader[3]}, Age: {reader[4]}, Class {reader[5]}");
                }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
        }
    }
}