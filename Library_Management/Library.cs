using System.Transactions;

class Library
{
    public List<Book> Books = new();
    public List<Member> Member = new();
    public List<Transaction> Transaction = new();

    //CASE 1
    public void AddBook()
    {
        Console.Write("Enter ISBN :");
        string ISBN = Console.ReadLine() ?? "";
        var bookId = FindByISBN(ISBN);
        if (bookId != null)
        {
            Console.Write("Enter the no.of.Copies : ");
            int newCop = Convert.ToInt32(Console.ReadLine());
            bookId.TotalCopies += newCop;
            bookId.AvailableCopies += newCop;
        }
        else
        {
            Console.Write("Title : ");
            string Title = Console.ReadLine() ?? "";
            Console.Write("Author : ");
            string Author = Console.ReadLine() ?? "";
            Console.Write("Genre : ");
            string Genre = Console.ReadLine() ?? "";
            Console.Write("Total Copies : ");
            int totCop = Convert.ToInt32(Console.ReadLine());
            Console.Write("Available Copies : ");
            int avaliCop = Convert.ToInt32(Console.ReadLine());
            Books.Add(new Book(ISBN, Title, Author, Genre, totCop, avaliCop));
        }
    }
    //CASE 2
    public void viewAll()
    {
        Console.WriteLine("=====================================");
        if (Books.Count() > 0)
        {
            foreach (var book in Books)
            {
                Console.WriteLine($"Title : {book.Title}| Availability : {book.AvailableCopies}");
            }
        }
        else
        {
            Console.WriteLine("No Books are Available!..");
        }
        Console.WriteLine("=====================================");
    }
    public Book? FindByTitle(string title)
    {
        foreach (var Book in Books)
        {
            if (title == Book.Title)
            {
                return Book;
            }
        }
        return null;
    }
    public Book? FindByAuthor(string author)
    {
        foreach (var Book in Books)
        {
            if (author == Book.Author)
            {
                return Book;
            }
        }
        return null;
    }
    public Book? FindByISBN(string isbn)
    {
        foreach (var Book in Books)
        {
            if (isbn == Book.ISBN)
            {
                return Book;
            }
        }
        return null;
    }
    //CASE 3
    public void searchBook()
    {
        Console.WriteLine("1. Search by Title");
        Console.WriteLine("2. Search by Author");
        Console.WriteLine("3. Search by ISBN");
        Console.Write("Enter your Search Number : ");
        int op = Convert.ToInt32(Console.ReadLine());
        switch (op)
        {
            case 1:
                Console.Write("Enter the Title : ");
                string title = Console.ReadLine();
                var book = FindByTitle(title);
                if (book != null)
                {
                    Console.WriteLine($"{book.Title} | {book.Author} | {book.AvailableCopies}");
                }
                else
                {
                    Console.WriteLine("Book is not Found!");
                }
                break;
            case 2:
                Console.Write("Enter the Author : ");
                string author = Console.ReadLine();
                var book1 = FindByAuthor(author);
                if (book1 != null)
                {
                    Console.WriteLine($"{book1.Title} | {book1.Author} | {book1.AvailableCopies}");
                }
                else
                {
                    Console.WriteLine("Book is not Found!");
                }
                break;
            case 3:
                Console.Write("Enter the ISBN : ");
                string isbn = Console.ReadLine();
                var book2 = FindByISBN(isbn);
                if (book2 != null)
                {
                    Console.WriteLine($"{book2.Title} | {book2.Author} | {book2.AvailableCopies}");
                }
                else
                {
                    Console.WriteLine("Book is not Found!");
                }
                break;
            default:
                Console.WriteLine("Invalid Input!");
                break;
        }
    }
    //CASE 4
    public void RegisterMember()
    {
        // Console.Write("Enter the Member ID : ");
        // string memberId = Console.ReadLine();
        Console.Write("Enter Your Name : ");
        string name = Console.ReadLine();
        Console.Write("Enter Phone No : ");
        string phone = Console.ReadLine();
        if (phone.Length < 10 || phone.Length > 10)
        {
            Console.WriteLine("Invalid Phone Number!..");
            Console.Write("Please Enter it Correctly Again : ");
            string cortPhone = Console.ReadLine();
            phone = cortPhone;
        }
        DateTime date = DateTime.Now;
        // Member m =
        Member.Add(new Member(name, phone, date));
        Console.WriteLine($"Member Added Successfully and {name}your ID : {Member.Last().MemberId}");

    }

    //CASE 5
    public void viewMember()
    {
        if (Member.Count() > 0)
        {
            foreach (var member in Member)
            {
                Console.WriteLine($"{member.MemberId}  |  {member.Name}  | {member.RegistratioDate}");
            }
        }
        else
            Console.WriteLine("No Members are there!!.");
    }

    public Member? FindID(string id)
    {
        foreach (var member in Member)
        {
            if (id == member.MemberId)
            {
                return member;
            }
        }
        return null;
    }
    public Transaction? FindTransactionID(String id)
    {
        foreach (var member in Transaction)
        {
            if (id == member.MemberId)
            {
                return member;
            }
        }
        return null;
    }

    //CASE 6
    public void IssueBook()
    {
        Console.Write("Enter Member ID : ");
        string id = Console.ReadLine();
        var ID = FindID(id);
        // var TransID = FindTransactionID(id);
        if (ID == null)
        {
            Console.WriteLine("Member ID is not Found!!.");
        }
        else
        {
            Console.Write("Enter Book ISBN : ");
            string isbn = Console.ReadLine() ?? "";
            var BookID = FindByISBN(isbn);
            if (BookID != null)
            {
                bool alreadyBorrowed = false;
                foreach (var trans in Transaction)
                {
                    if (trans.MemberId == id && trans.ISBN == isbn)
                    {
                        alreadyBorrowed = true;
                        break;
                    }
                }
                if (alreadyBorrowed)
                {
                    Console.WriteLine("You have Already Borrow this Book!. ");
                }
                else
                {
                    if (ID.borrowCount < 3)
                    {
                        Transaction.Add(new Transaction(id, isbn, DateTime.Now));
                        ID.borrowCount++;
                        BookID.AvailableCopies--;
                        Console.WriteLine($"{ID.Name} Borrow the Book {BookID.Title} Successfully!.");
                    }
                    else
                    {
                        Console.WriteLine("Your Max Limit of Borrowing over!.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Book Not Found!.");
            }
        }
    }

    //CASE 7
    public void returnBook()
    {
        Console.Write("Enter Member ID : ");
        string id = Console.ReadLine();
        var ID = FindTransactionID(id);
        var MemID = FindID(id);
        if (ID != null && MemID != null)
        {
            Console.Write("Enter Book Title : ");
            string bookTitle = Console.ReadLine();
            var Book = FindByTitle(bookTitle);
            if (Book == null) Console.WriteLine("Book is not Found in Library!..");
            else
            {
                Book.AvailableCopies++;
                MemID.borrowCount--;
                ID.ReturnDate = DateTime.Now;

            }
        }
        else
        {
            Console.WriteLine("ID not Found!!.");
        }

    }

    //CASE 8
    public void viewIssue()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("             Issued Book's");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("*******************************************************");
        if (Transaction.Count() > 0)
        {
            foreach (var transaction in Transaction)
            {
                Console.WriteLine($"{transaction.MemberId} | {transaction.ISBN} | {transaction.IssueDate} | {transaction.ReturnDate}");
            }
        }
        else
            Console.WriteLine("No Transaction has been done yet!..");
        Console.WriteLine("*******************************************************");
    }

    //CASE 9
    public void showOverDue()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("              Over Due's");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("*******************************************************");
        if (Transaction.Count() > 0)
        {
            foreach (var transaction in Transaction)
            {
                decimal fine = transaction.fine(transaction.IssueDate, transaction.ReturnDate);
                Console.WriteLine($"{transaction.MemberId} | {transaction.IssueDate} | {transaction.ReturnDate} | {fine}");
            }
        }
        else
            Console.WriteLine("No Transaction has been done yet!..");
        Console.WriteLine("*******************************************************");
    }

    //CASE 10
    public void borrowHistory()
    {
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("             Member's Borrowing History");
        Console.WriteLine("--------------------------------------------------------");
        if (Member.Count() > 0)
        {
            foreach (var member in Member)
            {
                Console.WriteLine($"{member.MemberId} | {member.Name} | {member.Phone} | {member.borrowCount} ");
            }
        }
        else
            Console.WriteLine("No Member Has Borrowed Yet!.");
        Console.WriteLine("--------------------------------------------------------");
    }
}
