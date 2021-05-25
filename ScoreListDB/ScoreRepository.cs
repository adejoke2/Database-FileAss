using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ScoreListDB
{
    public class ScoreRepository
    {
        MySqlConnection conn;
        public static List<ScoreEntity> Scores = new List<ScoreEntity>();
        public ScoreRepository(MySqlConnection connection)
        {
            conn = connection;
        }
        public bool AddScores(string studentname, int englishscore, int mathscore, int economicscore)
        {
            try
            {
                conn.Open();
                string addScore = "Insert into scoreInformation (studentname, englishscore, mathscore, economicscore)values ('" + studentname + "', '" + englishscore + "', '" + mathscore + "', '" + economicscore + "')";
                MySqlCommand command = new MySqlCommand(addScore, conn);
                Console.WriteLine("Score Added Sucessfully!");
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
        public ScoreEntity FindStudentScore(string studentname)
        {
            ScoreEntity score = null;
            try
            {
                conn.Open();
                string studentQuery = "Select studentname, englishscore, mathscore, economicscore from scoreInformation where studentname = '" + studentname + "'";
                MySqlCommand command = new MySqlCommand(studentQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    {
                        int englishscore = reader.GetInt32(1);
                        int mathscore = reader.GetInt32(2);
                        int economicscore = reader.GetInt32(3);
                        student = new ScoreEntity(studentname, englishscore, mathscore, economicscore);
                    }
                    Console.WriteLine($"StudentName: {reader[0]}, EnglishScore: {reader[1]}, MathsScore: {reader[2]}, EconomicsScore: {reader[3]}");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return score;
        }
        public bool UpdateStudentScore(string studentname, int englishscore, int mathscore, int economicscore)
        {
            var student = FindStudentScore(studentname);
            if (student == null)
            {
                Console.WriteLine($"Student with the Name: {studentname} does not exist");
            }
            try
            {
                conn.Open();
                string updateScoreQuery = "update scoreInformation set englishscore ='" + englishscore + "', mathscore = '" + mathscore + "' , economicscore = '" + economicscore + "' where studentname = '" + studentname + "'";
                MySqlCommand command = new MySqlCommand(updateScoreQuery, conn);
                int Count = command.ExecuteNonQuery();
                Console.WriteLine("Student Score Updated Sucessfully!!!");
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
        public bool DeleteStudentRecord(string studentname)
        {
            if (studentname == null)
            {
                Console.WriteLine($"Student with the Name: {studentname} does not exist");
            }
            try
            {
                conn.Open();
                string deleteStudentQuery = "delete from scoreInformation where studentname = '" + studentname + "'";
                MySqlCommand command = new MySqlCommand(deleteStudentQuery, conn);
                Console.WriteLine("Student Record Deleted Sucessfully!");
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
        public void ListAllRecords()
        {
            List<ScoreEntity> Scores = new List<ScoreEntity>();
            try
            {
                conn.Open();
                string scoreQuery = "Select studentname, englishscore, mathscore, economicscore from scoreInformation";
                MySqlCommand command = new MySqlCommand(scoreQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"StudentName: {reader[0]}, EnglishScore: {reader[1]}, MathsScore: {reader[2]}, EconomicsScore: {reader[3]}");
                }
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void StudentsAboveAverage()
        {
            List<ScoreEntity> Scores = new List<ScoreEntity>();
            try
            {
                int average =0;
                conn.Open();
                string scoreQuery = "Select studentname, englishscore, mathscore, economicscore from scoreInformation where englishscore+mathScore+economicscore > '" + 150 + "'";
                MySqlCommand command = new MySqlCommand(scoreQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    average++;
                }
                Console.WriteLine($"The total number of Students above average is: {average}");
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}