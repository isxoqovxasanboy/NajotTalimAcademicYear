public class Servise
{
    public static List<ProgrammingLanguage> ModelProgram()
    {
        var Programming = new List<ProgrammingLanguage>
        {
            new ProgrammingLanguage { Id = 1, Name_p = "C#" },
            new ProgrammingLanguage { Id = 2, Name_p = "Java" },
            new ProgrammingLanguage { Id = 3, Name_p = "C" },
            new ProgrammingLanguage { Id = 4, Name_p = "C#" },
            new ProgrammingLanguage { Id = 5, Name_p = "Go" },
            new ProgrammingLanguage { Id = 6, Name_p = "C#" },
            new ProgrammingLanguage { Id = 7, Name_p = "Python" },
            new ProgrammingLanguage { Id = 8, Name_p = "Java" },
            new ProgrammingLanguage { Id = 9, Name_p = "C#" },
            new ProgrammingLanguage { Id = 10, Name_p = "C" }


        };
        return Programming;
    }

    public static List<Bugalters> BugalterModel()
    {
        var Buxgalter = new List<Bugalters>
        {
            new Bugalters { Id = 1, Name_b = "Akromjon", Programming_id = 7},
            new Bugalters { Id = 2, Name_b = "Tohirjon", Programming_id = 4},
            new Bugalters { Id = 3, Name_b = "MuhammadAbdulloh", Programming_id = 8},
            new Bugalters { Id = 4, Name_b = "Ozodbek", Programming_id = 3},
            new Bugalters { Id = 5, Name_b = "Elyor", Programming_id = 5},
            new Bugalters { Id = 6, Name_b = "Mahsud", Programming_id = 1},
            new Bugalters { Id = 7, Name_b = "Xusan", Programming_id = 2},
            new Bugalters { Id = 8, Name_b = "Xasan", Programming_id = 9},
            new Bugalters { Id = 9, Name_b = "Abdulloh", Programming_id = 10},
            new Bugalters { Id = 10, Name_b = "Abduxoliq", Programming_id = 6},
        };

        return Buxgalter;
    }

    public static void Task1()
    {
        var result = ModelProgram().Join(BugalterModel(), p => p.Id, b => b.Programming_id, (p, b)
            => new { p.Name_p, b.Name_b });

        foreach (var item in result)
        {
            Console.WriteLine(item.Name_b + " " + "->" + " " + item.Name_p);
        }
        Console.WriteLine();
    }

      
    public static void Task2(string Program_Name)
    {
        var result = ModelProgram().Join(BugalterModel(), p => p.Id, b => b.Programming_id, (p, b)
            => new { p.Name_p, b.Name_b }).Where(p => p.Name_p == Program_Name);

        foreach (var item in result)
        {
            Console.WriteLine(item.Name_b + " " + "->" + " " + item.Name_p);
        }
    }
}