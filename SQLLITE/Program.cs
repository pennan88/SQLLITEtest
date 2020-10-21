using System;
using Microsoft.Data.Sqlite;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SQLLITE
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using (var connection = new SqliteConnection(@"Data Source= ..\..\..\VideoGameList.db"))
            {
               

                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                    SELECT Title, Publishers, Year, Sales, Review_Score, Console
                    FROM video_games ORDER by Sales DESC LIMIT 10
                    ";



                using (var reader = command.ExecuteReader())

                {
                    while (reader.Read())
                    {


                        var Title = reader.GetString(0);
                        var Publisher = reader.IsDBNull(1) ? "No info" : reader.GetString(1);
                        var year = reader.IsDBNull(1) ? "No info" : reader.GetString(2);
                        var sales = reader.IsDBNull(1) ? "0" : reader.GetString(3);
                        var score = reader.IsDBNull(1) ? "0" : reader.GetString(4);
                        var console = reader.IsDBNull(1) ? "Unknow Console" : reader.GetString(5);

                        Console.WriteLine($"Game Title: {Title} \nPublisher: {Publisher}\nYear: {year} \nSales: {sales} Millions \nScore: {score}/100 \nConsole: {console}\n");
                    }
                }
            }
        }

    }
}
