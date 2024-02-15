using System.Data;
using MongoDbLearning.Data;
using Npgsql;

// AppDataContext appDataContext = new AppDataContext();
        // var s = appDataContext.GetDatabaseByName("Lesson");
internal class Program
{
    public static void Main(string[] args)
    {
        const string connectionString =
            "Server=127.0.0.1;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        var npgsqlConnection = new NpgsqlConnection(connectionString);

        var s = npgsqlConnection;
        npgsqlConnection.Open();
        var query = $"Create table TestTable(id int, name varchar(255), start_date date)";


        // var command = new NpgsqlCommand(query, npgsqlConnection);

        // var result = command.ExecuteNonQuery();
        
        Console.WriteLine("O'xshadi");
        
        npgsqlConnection.Close();

    }
}

