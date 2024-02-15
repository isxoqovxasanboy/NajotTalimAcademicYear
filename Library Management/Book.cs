namespace Library_Management;

public class Book
{
    public Guid Id  = Guid.NewGuid();
    private string _title;
    private string _author;

    public Book(string title, string author)
    {
        _title = title;
        _author = author;
    }

    public override string ToString()
    {
        return $" Author {_author} Title {_title}";
    }
}