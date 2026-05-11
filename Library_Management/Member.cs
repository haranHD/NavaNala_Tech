class Member
{
    private static int id { set; get; } = 1;
    public string? MemberId { get; }
    public string? Name
    { set; get; }
    public string? Phone { set; get; }
    public DateTime RegistratioDate { set; get; }
    public int borrowCount { set; get; } = 0;
    // public Dictionary<string, int> borrow = new();
    public Member(string name, string phone, DateTime dateTime)
    {
        MemberId = "M00" + id;
        id++;
        Name = name;
        Phone = phone;
        RegistratioDate = dateTime;
    }
    // public Member(string memberId, int count)
    // {
    //     borrowCount = count;
    //     borrow.Add(memberId, borrowCount);
    // }

}
