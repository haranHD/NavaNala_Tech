// namespace Library_Management
// {
class Program
{
    public static void Main(string[] agrs)
    {
        Library library = new();
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("            Library Management                  ");
            Console.WriteLine("================================================");
            menu();
            Console.Write("Enter the option number : ");
            int op;

            if (!int.TryParse(Console.ReadLine(), out op))
            {
                Console.WriteLine("Invalid Input! Enter Numbers Only.");
                continue;
            }
            switch (op)
            {
                case 1:
                    library.AddBook();
                    break;
                case 2:
                    library.viewAll();
                    break;
                case 3:
                    library.searchBook();
                    break;
                case 4:
                    library.RegisterMember();
                    break;
                case 5:
                    library.viewMember();
                    break;
                case 6:
                    library.IssueBook();
                    break;
                case 7:
                    library.returnBook();
                    break;
                case 8:
                    library.viewIssue();
                    break;
                case 9:
                    library.showOverDue();
                    break;
                case 10:
                    library.borrowHistory();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid Input!.....");
                    break;
            }
        }

    }
    static void menu()
    {
        Console.WriteLine("******************************************");
        Console.WriteLine("1 . Add Book");
        Console.WriteLine("2 . View All Books");
        Console.WriteLine("3 . Search Book");
        Console.WriteLine("4 . Register Member");
        Console.WriteLine("5 . View All Members");
        Console.WriteLine("6 . Issue Book");
        Console.WriteLine("7 . Return Book");
        Console.WriteLine("8 . View Issued Books");
        Console.WriteLine("9 . View Overdue Books");
        Console.WriteLine("10 . Member History");
        Console.WriteLine("0 . Exit");
        Console.WriteLine("******************************************");
    }
}

// }