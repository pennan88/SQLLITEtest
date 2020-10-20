using System;
using Microsoft.Data.Sqlite;

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
                    SELECT Title, Publishers, Year, Sales, Review_Score
                    FROM video_games
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

                        Console.WriteLine($"Game Title: {Title} \n Publisher: {Publisher}\n Year: {year} \n Sales:{sales} Millions \n Score: {score}/100\n");
                    }
                }
            }
        }
    }
}
