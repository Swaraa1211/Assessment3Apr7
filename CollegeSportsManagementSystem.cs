﻿using Microsoft.Data.SqlClient;

namespace Assessment3Apr7
{
    internal class CollegeSportsManagementSystem
    {
        public static string connString = "Data Source=5CG7324TYL;Initial Catalog = AssessmentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        static void Main(string[] args)
        {
            //AddTournament();
            AddSports();
            
            //SqlConnection connection = new SqlConnection(connString);
            //connection.Open();

            //SqlCommand command = connection.CreateCommand();
            //command.CommandText = "SELECT * FROM SportsTournament";
            //SqlDataReader reader = command.ExecuteReader();

            ///*Console.WriteLine("TounamentNum         Name");
            //while (reader.Read())
            //{
            //    Console.WriteLine($"{reader.GetInt32(0)}      {reader.GetString(1)}");
            //}*/

            ////SqlDataReader reader = cmd.ExecuteReader();
            ////cmd.CommandText = "SELECT * FROM orderDetails";
            //Console.WriteLine("Number       Name     Sport1  Sport2");
            //while (reader.Read())
            //{
            //    Console.WriteLine($"{reader.GetInt32(0)}      {reader.GetString(1)}          {reader.GetString(2)}      {reader.GetString(3)}");
            //}

            //reader.Close();

            //connection.Close();
        }

        public static void AddTournament()
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM SportsTournament";
            //SqlDataReader reader = cmd.ExecuteReader();


            //Inserting
            try
            {
                int tn = Convert.ToInt32(Console.ReadLine());
                string Tname = Console.ReadLine();
                string Sport1 = Console.ReadLine();
                string Sport2 = Console.ReadLine();

                //SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("TournamentNumber\t\tTournamentName\t\tSport1\t\tSport2");

                //int tn1 = Convert.ToInt32(Console.ReadLine());
                //cmd.CommandText = $"select count(*) from SportsTournament where TournamentNumber={tn1}";
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"insert into SportsTournament values({tn},'{Tname}','{Sport1}','{Sport2}')" +
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


            //Updation
            //try
            //{
            //    int tn1 = Convert.ToInt32(Console.ReadLine());
            //    cmd.CommandText = $"select count(*) from SportsTournament where TournamentNumber={tn1}";
            //    int count = (int)cmd.ExecuteScalar();
            //    if (count > 0)
            //    {
            //        cmd.CommandText = $"UPDATE SportsTournament set TournamentName = 'VCETIntraCollege' where TournamentNumber = {tn1}" +
            //            $"Select * from SportsTournament where TournamentNumber = {tn1}";
            //        cmd.ExecuteReader().Close();
            //        SqlDataReader rd = cmd.ExecuteReader();
            //        while (rd.Read())
            //        {
            //            Console.WriteLine($"{rd.GetInt32(0)}\t\t{rd.GetString(1)}\t\t{rd.GetString(2)}\t\t{rd.GetString(3)}");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("the number doesnot exist");
            //    }
            //}
            //catch (SqlException e)
            //{
            //    Console.WriteLine($"Error: {e.Message}");
            //}


            //reader.Close();
            connection.Close();

        }

        public static void AddSports()
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Sports";
            //SqlDataReader reader = cmd.ExecuteReader();

            //Inserting
            try
            {
                int tn = Convert.ToInt32(Console.ReadLine());
                int sportId = Convert.ToInt32(Console.ReadLine());
                string SportName = Console.ReadLine();
                string Category = Console.ReadLine();

                //SqlDataReader reader = cmd.ExecuteReader();
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

            //reader.Close();
            connection.Close();
        }

       public static void AddScore()
        {

        }

        public static void EditScore()
        {

        }

        public static void RemovePlayers()
        {

        }
        public static void RemoveTournament()
        {
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM SportsTournament";
            //SqlDataReader reader = cmd.ExecuteReader();

            int tn = Convert.ToInt32(Console.ReadLine());

            //Inserting
            try
            {
                //SqlDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("TournamentNumber\t\tTournamentName\t\tSport1\t\tSport2");

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"DELETE FROM SportsTournament WHERE TournamentName = {tn}')" +
                                  $"select * from SportsTournament";
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

            //reader.Close();
            connection.Close();

        }

        public static void RemoveSports()
        {

        }
    }
}