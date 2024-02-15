namespace Library_Management;
//- kutubxona boshqaruvi uchun LibraryManagement tipini yarating
public class LibraryManagement
{
    //- unda kitoblarni va ulardan nechta nusxa borligini key-value qilib saqlovchi kolleksiya Books nomli bo'lsin
    private Dictionary<Book, int> _books = new();
    
    /*
     *
    -LibraryManagement da Checkout methodini yarating - bu kitoblarni olib turish vazifasini bajaradi.
    - methodda bookId nomli kitob Id sini bildirovchi parameter bo'lsin
   - method boolean qiymat qaytaradi
   - methodda ushbu kitoblar orasidan o'sha kitob qidirilsin
   - agar kitob topilsa va nusxalar soni 0 dan katta bo'lsa, nusxalar soni birga kamaytirilib, 
     true qaytarilsin, aks holda false qaytsin
     * 
     */
    
   

    public bool Checkout(Guid bookId)
    {
        foreach (var book in _books)
        {
            if (book.Key.Id == bookId && book.Value > 0)
            {
                _books[book.Key]--;
                return true;
            }
        }
        return false;
    }

    public void CheckIn(Book book)
    {
        if (_books.ContainsKey(book))
        {
            _books[book]++;
        }
        else
        {
            _books.Add(book, 1);
        }
    }

    public void Print()
    {
        foreach (var book in _books)
        {
            Console.WriteLine($"{book.Key}   - Copies: {book.Value}");
        }
    }
    
    
}