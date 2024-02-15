using System.Security.Cryptography;
using System.Text;
using Npgsql;

internal class Program
{
    private const string Salt = $"SHA_512";

    private static void Main()
    {
        while (true)
        {
            Console.Write("username kiriting:");
            string username = Console.ReadLine()!;
            Console.Write("password kiriting:");
            string password = Console.ReadLine()! + Salt;
            byte[] encode = Encoding.UTF8.GetBytes(password!);
            var hash = SHA512.HashData(encode);

            password = Convert.ToHexString(hash)!;
            if (CheckUserFromDb(username, password))
            {
                ReadAllChatMessages(username);
                while (true)
                    MessageToUser(username, password);
            }
            else
            {
                AddUserToDb(username, password);
                while (true)
                    MessageToUser(username, password);
            }
        }
    }

    static void MessageToUser(string username, string password)
    {
        List<User> users = ReadAllUsers(username, password);
        Console.WriteLine("\n Userlar ro'yxati: ");
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].username != username && users[i].password != password)
                Console.WriteLine($"{i + 1}) {users[i].username}");
        }

        Console.Write("Qaysi userga message yubormoqchisiz(raqamini tanlang):");
        string idString = Console.ReadLine()!;
        if (idString == "<-")
        {
            Main();
        }

        int id = Convert.ToInt32(idString);
        Console.Write("Message yozing:");
        string comment = Console.ReadLine()!;
        if (comment == "<-")
        {
            Main();
        }

        AddRowToChat(username, users[id - 1].username, comment);
    }

    static void ReadAllChatMessages(string username)
    {
        string connectionString = "Server=127.0.0.1;Port=5432;Database=YourDataBase;username=postgres;Password=YourPassword;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        using NpgsqlCommand cmd = new NpgsqlCommand(
            $"select * from chat where toUser='{username}'", connection);
        NpgsqlDataReader result = cmd.ExecuteReader();
        while (result.Read())
        {
            Console.WriteLine($"{result["fromUser"]} userdan --> {result["comment"]}");
        }

        connection.Close();
    }

    static bool CheckUserFromDb(string username, string password)
    {
        string connectionString = "Server=127.0.0.1;Port=5432;Database=YourDataBase;username=postgres;Password=YourPassword;";
        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        string query = $"select * from users where username='{username}' and password='{password}'";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
        NpgsqlDataReader result = cmd.ExecuteReader();
        if (result.FieldCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    static void AddUserToDb(string username, string password)
    {
        string connectionString = "Server=127.0.0.1;Port=5432;Database=YourDataBase;username=postgres;Password=YourPassword;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        using NpgsqlCommand cmd = new NpgsqlCommand(
            $"""insert into users(username,password) values('{username}','{password}')""", connection);

        cmd.ExecuteNonQuery();

        connection.Close();
    }

    static List<User> ReadAllUsers(string username, string password)
    {
        string connectionString = "Server=127.0.0.1;Port=5432;Database=YourDataBase;username=postgres;Password=YourPassword;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        using NpgsqlCommand cmd = new NpgsqlCommand(
            $"select * from users", connection);


        NpgsqlDataReader result = cmd.ExecuteReader();
        List<User> users = new List<User>();
        while (result.Read())
        {
            users.Add(new User()
                { username = Convert.ToString(result["username"]), password = Convert.ToString(result["password"]) });
        }

        return users;
        connection.Close();
    }

    static void AddRowToChat(string fromUser, string toUser, string comment)
    {
        string connectionString = "Server=127.0.0.1;Port=5432;Database=YourDataBase;username=postgres;Password=YourPassword;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        using NpgsqlCommand cmd = new NpgsqlCommand(
            $"""insert into chat(fromUser,toUser,comment) values('{fromUser}','{toUser}','{comment}')""", connection);

        cmd.ExecuteNonQuery();

        connection.Close();
    }

    class User
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}


