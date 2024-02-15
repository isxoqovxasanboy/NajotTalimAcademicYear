using System.Data;
using Npgsql;
using SendMessage.Application.Models.Entities;

namespace SendMessage.Application.Data;

public class DataContext
{
    private List<UserMessage> UserMessages { get; init; }
    private static string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";
    
    
    public DataContext()
    {
        
        Initialize();
    }
    
    
    public void Initialize()
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string query = "select name from testtable;";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine(result[0]);
            }
        }
    }

    private static void EnsureDataExists()
    {
        var queryCreateReference = "Create Table if not exists user(Id uuid primary key, First_name varchar(55), LastName varchar(55),password varchar(255), BirthDate date ); " +
                                   "Create table if not exists message(sender_id uuid, body text, title text)"+
                                   "Create table if not exists user_message(id serial primary key, name varchar(55),student_id int references students(student_id))";


        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        NpgsqlDataAdapter adapter = new("select * from users", connection);
    }
    
    
    
}