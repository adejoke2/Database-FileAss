using System;
using MySql.Data.MySqlClient;

namespace ScoreListDB
{
    public class Menu
    {
        static string connectionString = "server=localhost;user=root;database=scoremanagement;port=3306;password=Adejoke#19?";
        static MySqlConnection conn = new MySqlConnection(connectionString);
        ScoreRepository scoreRepo = new ScoreRepository(conn);
        private void ScoreMenu()
        {
            Console.WriteLine("0. Back");

            Console.WriteLine("1. Add Student Score");

            Console.WriteLine("2. List all Scores");

            Console.WriteLine("3. Find Student Record");

            Console.WriteLine("4. Update Score");

            Console.WriteLine("5. Delete Student Record");

            Console.WriteLine("6. Total Number above Average");
        }
        private void AddStudentRecord()
        {
            Console.Write("Enter Student Full Name: ");
            string studentname = Console.ReadLine().ToLower().Trim();

            Console.Write("English Score: ");
            int englishscore = Convert.ToInt32((Console.ReadLine().Trim()));

            Console.Write("Math Score: ");
            int mathscore = int.Parse(Console.ReadLine().Trim());

            Console.Write("English Score: ");
            int economicscore = int.Parse(Console.ReadLine().Trim());

            scoreRepo.Addscores(studentname, englishscore, mathscore, economicscore);
        }
        private void UpdateStudentScore()
        {
            Console.Write("Enter the FullName of the Student you want to Update: ");
            string studentname = Console.ReadLine().ToLower().Trim();

            Console.Write("Update English Score: ");
            int englishscore = Convert.ToInt32((Console.ReadLine().Trim()));

            Console.Write("Update Math Score: ");
            int mathscore = int.Parse(Console.ReadLine().Trim());

            Console.Write("Update English Score: ");
            int economicscore = Convert.ToInt32((Console.ReadLine().Trim()));

            scoreRepo.UpdateStudentScore(studentname, englishscore, mathscore, economicscore);
        }
        private void DeleteStudentScore()
        {
            Console.Write("Enter the name of Student you want to Delete: ");
            string studentname = Console.ReadLine().ToLower().Trim();

            scoreRepo.DeleteStudentRecord(studentname);
        }
        public void MainMenu()
        {
            ScoreMenu();
            Console.Write("Option: ");
            string option = Console.ReadLine().Trim();

            switch (option)
            {
                case "0":
                    break;
                case "1":
                    AddStudentRecord();
                    MainMenu();
                    break;
                case "2":
                    scoreRepo.ListAllRecords();
                    MainMenu();
                    break;
                case "3":
                    Console.Write("Enter Full Name of the Student you want to Find: ");
                    string studentname  = Console.ReadLine().ToLower().Trim();
                    Console.WriteLine("");
                    scoreRepo.FindStudentScore(studentname);
                    MainMenu();
                    break;
                case "4":
                    UpdateStudentScore();
                    MainMenu();
                    break;
                case "5":
                    DeleteStudentScore();
                    MainMenu();
                    break;
                case "6":
                    scoreRepo.StudentsAboveAverage();
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }
        }
    }
}