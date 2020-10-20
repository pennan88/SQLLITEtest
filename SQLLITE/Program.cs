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
                        var title = reader.GetString(0);
                        var publishers = reader.GetString(1);
                        var year = reader.GetString(2);
                        var sales = reader.GetString(3);
                        var score = reader.GetString(4);


                        Console.WriteLine($"Game name: {title} \n Publishers: {publishers} \n Year: {year} \n Sales: {sales} Millions \n Score: {score}/100 ");
                    }
                }
            }
        }
    }
}
