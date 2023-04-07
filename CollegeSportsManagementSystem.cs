using Microsoft.Data.SqlClient;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Assessment3Apr7
{
    internal class CollegeSportsManagementSystem
    {
        public static string connString = "Data Source=5CG7324TYL;Initial Catalog = AssessmentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);
            sqlConnection.Open();

            Console.WriteLine("Welcome!");

            int choice = 0;
            do
            {
                Console.WriteLine("Your Choice: ");
                Console.WriteLine("1. Add Tournament");
                Console.WriteLine("2. Add Sports");
                Console.WriteLine("3. Add Score");
                Console.WriteLine("4. Edit Score");
                Console.WriteLine("5. Remove Players");
                Console.WriteLine("6. Remove Tournament");
                Console.WriteLine("7. Remove Sports");
                Console.WriteLine("8. Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTournament(sqlConnection);
                        break;
                    case 2:
                        AddSports(sqlConnection);
                        break;
                    case 3:
                        AddScore(sqlConnection);
                        break;
                    case 4:
                        EditScore(sqlConnection);
                        break;
                    case 5:
                        RemovePlayers(sqlConnection);
                        break;
                    case 6:
                        RemoveTournament(sqlConnection);
                        break;
                    case 7:
                        RemoveSports(sqlConnection);
                        break;
                    case 8:
                        sqlConnection.Close();
                        Console.WriteLine("Thank You !");
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }
            } while (choice != 8);
            //AddTournament();
            //AddSports();
            //AddScore();
            //EditScore();
            //RemovePlayers();
            //RemoveTournament();
            //RemoveSports();
            
        }

        public static void AddTournament(SqlConnection sqlConnection)
        {
            string query = "SELECT * FROM SportsTournament";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            //Inserting
            try
            {
                Console.Write("Tournament Number: ");
                int tn = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nTournament Name: ");
                string Tname = Console.ReadLine();
                Console.Write("\nSport1: ");
                string Sport1 = Console.ReadLine();
                Console.Write("\nSport2: ");
                string Sport2 = Console.ReadLine();

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"insert into SportsTournament values({tn},'{Tname}','{Sport1}','{Sport2}')" +
                                  $"select * from SportsTournament";
                    cmd.ExecuteReader().Close();
                    SqlDataReader rd = cmd.ExecuteReader();
                }
                else
                {
                    Console.WriteLine("the number doesnot exist");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("Tournament Added Successfully!");

        }

        public static void AddSports(SqlConnection sqlConnection)
        {
            string query = "SELECT * FROM Sports";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            //Inserting
            try
            {
                Console.Write("Tournament Number: ");
                int tn = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nSport Id: ");
                int sportId = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nSport Name: ");
                string SportName = Console.ReadLine();
                Console.Write("\nCategory: ");
                string Category = Console.ReadLine();

                Console.WriteLine("TournamentNumber\t\tSportID\t\tSportName\t\tCategory");

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"insert into Sports values({tn},{sportId},'{SportName}','{Category}')" +
                                  $"select * from Sports";
                    cmd.ExecuteReader().Close();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Console.WriteLine($"{rd.GetInt32(0)}\t\t{rd.GetString(1)}\t\t{rd.GetString(2)}\t\t{rd.GetString(3)}");
                    }
                }
                else
                {
                    Console.WriteLine("the number doesnot exist");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.WriteLine("Successfully Added!");
        }

       public static void AddScore(SqlConnection sqlConnection)
        {
            string query = "SELECT * FROM ScoreCard";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);


            //Removing
            try
            {
                Console.Write("Athlete Id: ");
                int Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nAthlete Name: ");
                string Name = Console.ReadLine();
                Console.Write("\nSport Id: ");
                int sportId = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nAge: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nScore: ");
                int score = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("AtheteId\t\tAthleteName\t\tSportId\t\tAge\t\tScore");

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"insert into ScoreCard values({Id},'{Name}',{sportId},{age},{score})" +
                                  $"select * from ScoreCard";
                    cmd.ExecuteReader().Close();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Console.WriteLine($"{rd.GetInt32(0)}\t\t{rd.GetString(1)}\t\t{rd.GetInt32(2)}\t\t{rd.GetInt32(3)}\t\t{rd.GetInt32(4)}");
                    }
                }
                else
                {
                    Console.WriteLine("the number doesnot exist");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.WriteLine("Score Added!");
        }

        public static void EditScore(SqlConnection sqlConnection)
        {
            string query = "SELECT * FROM ScoreCard";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            //Removing
            try
            {
                Console.Write("Athlete Id: ");
                int Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nScore: ");
                int score = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("AtheteId\t\tAthleteName\t\tSportId\t\tAge\t\tScore");

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"UPDATE ScoreCard set score ={score} WHERE AthleteId = {Id}" +
                                  $"select * from ScoreCard";
                    cmd.ExecuteReader().Close();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Console.WriteLine($"{rd.GetInt32(0)}\t\t{rd.GetString(1)}\t\t{rd.GetInt32(2)}\t\t{rd.GetInt32(3)}\t\t{rd.GetInt32(4)}");
                    }
                }
                else
                {
                    Console.WriteLine("the number doesnot exist");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.WriteLine("Score Updated!");
        }

        public static void RemovePlayers(SqlConnection sqlConnection)
        {
            string query = "SELECT * FROM ScoreCard";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            Console.Write("Player Name: ");
            string playerName = Console.ReadLine();

            //Removing
            try
            {
                Console.WriteLine("AtheteId\t\tAthleteName\t\tSportId\t\tAge\t\tScore");

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"DELETE FROM ScoreCard WHERE Athletename = '{playerName}'" +
                                  $"select * from ScoreCard";
                    cmd.ExecuteReader().Close();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Console.WriteLine($"{rd.GetInt32(0)}\t\t{rd.GetString(1)}\t\t{rd.GetInt32(2)}\t\t{rd.GetInt32(3)}\t\t{rd.GetInt32(4)}");
                    }
                }
                else
                {
                    Console.WriteLine("the number doesnot exist");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.WriteLine("Removed!!");
        }
        public static void RemoveTournament(SqlConnection sqlConnection)
        {
            string query = "SELECT * FROM SportsTournament";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            Console.Write("Tournament Number: ");
            int tn = Convert.ToInt32(Console.ReadLine());

            //Removing
            try
            {
                Console.WriteLine("TournamentNumber\t\tTournamentName\t\tSport1\t\tSport2");

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"DELETE FROM SportsTournament WHERE TournamentNumber = {tn}" +
                                  $"select * from SportsTournament";
                    cmd.ExecuteReader().Close();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Console.WriteLine($"{rd.GetInt32(0)}\t\t{rd.GetString(1)}\t\t{rd.GetString(2)}\t\t{rd.GetString(3)}");
                    }
                }
                else
                {
                    Console.WriteLine("the number doesnot exist");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.WriteLine("Tournament Removed!");
        }

        public static void RemoveSports(SqlConnection sqlConnection)
        {
            string query = "SELECT * FROM Sports";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            Console.Write("SportId: ");
            int sportId = Convert.ToInt32(Console.ReadLine());

            //Removing
            try
            {
                Console.WriteLine("TournamentNumber\t\tSportID\t\tSportName\t\tCategory");

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"DELETE FROM Sports WHERE SportId = {sportId}" +
                                  $"select * from Sports";
                    cmd.ExecuteReader().Close();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Console.WriteLine($"{rd.GetInt32(0)}\t\t{rd.GetInt32(1)}\t\t{rd.GetString(2)}\t\t{rd.GetString(3)}");
                    }
                }
                else
                {
                    Console.WriteLine("the number doesnot exist");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.WriteLine("Sport Removed!");
        }
    }
}

