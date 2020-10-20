using System;
using Microsoft.Data.Sqlite;

namespace SQLLITE
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection(@"DateSource=..\..\..\video_games_v02.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT Title FROM video_games";

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var title = reader.GetString(0);

                        Console.WriteLine(@"Game name: {title}");
                    }
                }
            }
        }
    }
}
