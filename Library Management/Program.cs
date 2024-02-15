namespace Library_Management;

internal class Program
{
    public static void Main(string[] args)
    {
        // Book[] books = new Book[]
        // {
        //     new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams"),
        //     new Book("To Kill a Mockingbird", "Harper Lee"),
        //     new Book("1984", "George Orwell"),
        //     new Book("The Great Gatsby", "F. Scott Fitzgerald"),
        //     new Book("The Catcher in the Rye", "J.D. Salinger")
        // };
        
        Book hitchhikersGuide = new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams");
        Book toKillAMockingbird = new Book("To Kill a Mockingbird", "Harper Lee");
        Book nineteenEightyFour = new Book("1984", "George Orwell");
        Book greatGatsby = new Book("The Great Gatsby", "F. Scott Fitzgerald");
        Book catcherInTheRye = new Book("The Catcher in the Rye", "J.D. Salinger");

        LibraryManagement library = new();
        
        library.CheckIn(hitchhikersGuide);
        library.CheckIn(hitchhikersGuide);
        library.CheckIn(hitchhikersGuide);

        library.Checkout(hitchhikersGuide.Id);

        library.Print();

    }
}