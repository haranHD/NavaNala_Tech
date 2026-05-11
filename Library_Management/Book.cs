
class Book
{
    public string? ISBN { private set; get; }
    public string? Title { set; get; }
    public string? Author { set; get; }
    public string? Genre { set; get; }
    public int TotalCopies { set; get; }
    public int AvailableCopies { set; get; }
    public Book(string isbn, string title, string author, string genre, int totCop, int avaCop)
    {
        ISBN = isbn;
        Author = author;
        Title = title;
        Genre = genre;
        TotalCopies = totCop;
        AvailableCopies = avaCop;
    }

}
