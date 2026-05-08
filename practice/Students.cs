namespace practice
{
    class Students
    {
        public int rollNo { set; get; }
        public string Name { set; get; } = "";
        public Dictionary<string, Dictionary<string, int>> semesters { set; get; } = new();
        public Students(int rollno, string name)
        {
            rollNo = rollno;
            Name = name;
            Console.WriteLine($"Student {Name} Added in the Dashboard!");
        }
        // public Students(Dictionary<string, int> subject)
        // {
        //     semesters = subject;
        // }


    }
}