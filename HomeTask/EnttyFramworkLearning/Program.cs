using Npgsql;

internal class Program
{
    public static void Main(string[] args)
    {
        // CreatTable();
        // Insert("Hasan");
        // Insert("Husan");
        // Insert("Toxir");
        // Insert("Baxodir");
        // Update("Baxtiyor","Hasan");
        // Delete("Husan");
        // GetWithLikeOperator();

        // GetAll();
    }

    public static void CreatTable()
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            string query = "create table testtable" +
                           "(id serial primary key, name varchar(255))";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

            var result = cmd.ExecuteReader();

            Console.WriteLine(result);
        }
    }

    public static void Insert(string name)
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string query = $"insert into testtable(Name) values('{name}');";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var countRow = cmd.ExecuteNonQuery();

        Console.WriteLine(countRow + "  qator qo'shildi");
    }

    public static void Insert(params string[] names)
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        int countRow = default;
        foreach (var name in names)
        {
            string query = $"insert into testtable(Name) values('{name}');";
            using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
            countRow += cmd.ExecuteNonQuery();
        }

        Console.WriteLine(countRow + "  qator qo'shildi");
    }

    public static void GetAll()
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

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

    public static void GetById(string id)
    {
        var connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        var query = "select name from testtable where id = {id};";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var result = cmd.ExecuteReader();

        while (result.Read())
        {
            Console.WriteLine(result[0]);
        }
    }

    public static void GetWithLikeOperator()
    {
        var connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Enter one character");
        var word = Console.ReadLine();
        var query = $"select id,name from testtable where name ILIKE '{word}%';";
        using (var cmd = new NpgsqlCommand(query, connection))
        {
            var result = cmd.ExecuteReader();
            while (result.Read())
            {
                Console.WriteLine(result[1]);
            }
        }
    }

    public static void Delete(string name)
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string query = $"delete from testtable where Name='{name}'";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "  Shuncha row muvaffaqiyatli o'chirildi");
    }

    public static void Update(string newName, string oldName)
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        string query = $"update testtable set Name = '{newName}' where Name= '{oldName}' ";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        var rowCount = cmd.ExecuteNonQuery();

        Console.WriteLine(rowCount + "  Shuncha row muvaffaqiyatli o'chirildi");
    }

    public static void AddTable()
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        Console.WriteLine("Enter column name");
        var columnName = Console.ReadLine();
        var query = $"ALTER TABLE testtable ADD {columnName} VARCHAR(255);";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        cmd.ExecuteNonQuery();

        Console.WriteLine("  Created success");
    }

    public static void AddColumnWithDefaultValue()
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        Console.WriteLine("Enter column name");
        var columnName = Console.ReadLine();
        Console.WriteLine("Enter column default value");
        var defaulValue = Console.ReadLine();

        var query = $"ALTER TABLE testtable ADD {columnName} VARCHAR(255) default {defaulValue};";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        cmd.ExecuteNonQuery();
        Console.WriteLine("Created success");
    }

    public static void RenameColumnName()
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        Console.WriteLine("Enter rename column name");
        var oldColumnName = Console.ReadLine();
        Console.WriteLine("Enter new column name ");
        var newColumnName = Console.ReadLine();

        var query = $"ALTER TABLE customers RENAME COLUMN {oldColumnName} TO {newColumnName};";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        cmd.ExecuteNonQuery();
        Console.WriteLine("Created success");
    }

    public static void UpdateTableName()
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        Console.WriteLine("Enter rename table name");
        var oldTableName = Console.ReadLine();
        Console.WriteLine("Enter new table name ");
        var newTableName = Console.ReadLine();

        var query = $"ALTER TABLE {oldTableName} RENAME TO {newTableName};";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        cmd.ExecuteNonQuery();
        Console.WriteLine("Created success");
    }

    public static void CheckDatabase()
    {
        bool dbExists;
        var createDatabase = @"Host=localhost;Port=5432;User Id=postgres;Password=A321a321;";

        using var mCreatedb = new NpgsqlConnection(createDatabase);
        Console.WriteLine("Enter database name");
        var nameDb = Console.ReadLine();
        string connectionString = $"Host=localhost;Port=5432;Database={nameDb};User Id=postgres;Password=A321a321;";
        var m_createTb = new NpgsqlConnection(connectionString);
        var cmdText =
            $"CREATE DATABASE \"{nameDb}\" WITH OWNER = postgres ENCODING = 'UTF8' LOCALE_PROVIDER = 'libc' CONNECTION LIMIT = -1 IS_TEMPLATE = False;";
        mCreatedb.Open();
        var cmd = new NpgsqlCommand(cmdText, mCreatedb);
        cmd.ExecuteNonQuery();
        mCreatedb.Close();
        cmd.CommandText = "create table test1(id serial primary key ,fullname varchar(255)); " +
                          "create table test2(id serial primary key ,fullname varchar(255));" +
                          "create table test3(id serial primary key ,fullname varchar(255));";

        cmd.Connection = m_createTb;

        m_createTb.Open();
        cmd.ExecuteNonQuery();
        m_createTb.Close();
    }

    public static void TruncateTable()
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();

        Console.WriteLine("Enter truncate table name");
        var truncateTableName = Console.ReadLine();


        var query = $"TRUNCATE TABLE {truncateTableName}";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);

        cmd.ExecuteNonQuery();
        Console.WriteLine("success");
    }

    public static void JoinTwoTables()
    {
        string connectionString = "Host=localhost;Port=5432;Database=Lesson;User Id=postgres;Password=A321a321;";

        var queryCreateReference = "Create Table if not exists students(student_id serial primary key, name varchar(55)); " +
                                   "Create table if not exists university(id serial primary key, name varchar(55),student_id int references students(student_id))";

        // var mockData =
        //     "INSERT INTO students (name) VALUES ('John Doe'),('Jane Smith'),('Michael Johnson'),('Emily Brown'),('William Taylor'),('Sophia Martinez'),('Matthew Anderson'),    ('Olivia Wilson'),    ('James Moore'),    ('Emma Garcia'),    ('Daniel Jackson'),    ('Ava White'),    ('Alexander Lee'),    ('Mia Harris'),    ('David Martin'),    ('Isabella Thompson'),    ('Joseph Clark'),    ('Charlotte Rodriguez'),    ('Samuel Lewis'),    ('Madison Hall');" +
        //     "INSERT INTO university (name, student_id) VALUES    ('Harvard University', 1),    ('Stanford University', 2),    ('Massachusetts Institute of Technology', 3),    ('University of Oxford', 4),    ('California Institute of Technology', 5),    ('University of Cambridge', 6),    ('University of California, Berkeley', 7),    ('Princeton University', 8),    ('Yale University', 9),    ('University of Chicago', 10),    ('Columbia University', 11),    ('University of Michigan', 12),    ('Cornell University', 13),    ('University of Pennsylvania', 14),    ('Johns Hopkins University', 15),    ('Northwestern University', 16),    ('University of California, Los Angeles', 17),    ('Duke University', 18),    ('University of Toronto', 19),    ('University of Washington', 20);";


        using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        
        using NpgsqlCommand cmdCreateTable = new NpgsqlCommand(queryCreateReference, connection);
        cmdCreateTable.ExecuteNonQuery();
            
        // using NpgsqlCommand cmdInsertData = new NpgsqlCommand(mockData, connection);
        // cmdInsertData.ExecuteNonQuery();
            
        string query = "select university.id,university.name, university.student_id from university join students using(student_id);";
        using NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
        
        var result = cmd.ExecuteReader();
        Console.WriteLine("{0,-3} {1,-50} {2}", "id", "name","student_id\n");
        while (result.Read())
        {
            Console.WriteLine("{0,-3} {1,-50} {2}",result[0],result[1],result[2]);
        }
    }
}