class Transaction
{
    public string? MemberId { private set; get; }

    public string? ISBN { private set; get; }
    public DateTime IssueDate;
    public DateTime ReturnDate;
    public decimal Fine { set; get; } = 10.00m;
    public Transaction(string memberID, string isbn, DateTime issuedte)
    {
        MemberId = memberID;
        ISBN = isbn;
        IssueDate = issuedte;
    }

    // public void showOverDue()
    // {

    // }
    public decimal fine(DateTime issueDate, DateTime returnDte)
    {
        TimeSpan diff = returnDte - issueDate;
        int days = diff.Days;
        if (days > 14)
        {
            Fine = days * Fine;
            return Fine;
        }
        else
        {
            Fine = 0;
            return Fine;
        }
    }

}
