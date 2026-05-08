namespace practice
{
    class Program
    {
        public static void Main(string[] agrs)
        {
            Console.WriteLine("=======================");
            Console.WriteLine("  STUDENT's DASHBOARD  ");
            Console.WriteLine("=======================");
            List<Students> students = new List<Students>();
            // Dictionary<string, Dictionary<string, int>> semester = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                Console.WriteLine("1 . Add New Student");
                Console.WriteLine("2 . Add Marks");
                Console.WriteLine("3 . Show all Details");
                Console.WriteLine("4 . Show Marks");
                Console.WriteLine("5 . Edit Student Details");
                Console.WriteLine("6 . Exit");
                Console.Write("Enter your Action Number : ");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        AddStudent(students);
                        break;
                    case 2:
                        AddMarks(students);
                        break;
                    case 3:
                        displayAll(students);
                        break;
                    case 4:
                        ShowMark(students);
                        break;
                    case 6:
                        Console.WriteLine("Closing.........!");
                        return;
                    default:
                        Console.WriteLine("Invalid Input!!");
                        break;
                }
            }


        }
        static void displayAll(List<Students> data)
        {
            Console.WriteLine("=======================");
            Console.WriteLine("    Students Info");
            Console.WriteLine("=======================");
            foreach (var student in data)
            {
                Console.WriteLine($"NAME : {student.Name}");
                Console.WriteLine($"Roll No : {student.rollNo}");
            }
            Console.WriteLine("=======================");
        }
        static void AddStudent(List<Students> students)
        {

            Console.Write("Enter the Roll No :");
            int rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Name :");
            string name = Console.ReadLine() ?? "";

            students.Add(new Students(rollNo, name));
        }
        static Students? FindStudent(
                List<Students> students,
                int RollNo
        )
        {
            foreach (var student in students)
            {
                if (student.rollNo == RollNo)
                {
                    return student;
                }

            }
            return null;
        }
        static bool FindSemeter(Dictionary<string, Dictionary<string, int>> semester, string sem)
        {
            return semester.ContainsKey(sem);

        }

        static void AddMarks(List<Students> student)
        {
            Console.Write("Enter the Student Roll No : ");
            int roll = Convert.ToInt32(Console.ReadLine());
            Students? foundStudent = FindStudent(student, roll);

            if (foundStudent == null)
            {
                Console.WriteLine("Student Not Found!...");
            }
            else
            {
                Console.Write("Enter the Semester : ");
                string semNo = Console.ReadLine() ?? "";
                Console.WriteLine("Enter the 5 Subject's Name and Mark :");
                Console.Write("Enter the Subject : ");
                string sub1 = Console.ReadLine() ?? "";
                Console.Write($"Enter the {sub1} Mark : ");
                int mar1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Subject : ");
                string sub2 = Console.ReadLine() ?? "";
                Console.Write($"Enter the {sub2} Mark : ");
                int mar2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Subject : ");
                string sub3 = Console.ReadLine() ?? "";
                Console.Write($"Enter the {sub3} Mark : ");
                int mar3 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Subject : ");
                string sub4 = Console.ReadLine() ?? "";
                Console.Write($"Enter the {sub4} Mark : ");
                int mar4 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Subject : ");
                string sub5 = Console.ReadLine() ?? "";
                Console.Write($"Enter the {sub5} Mark : ");
                int mar5 = Convert.ToInt32(Console.ReadLine());
                Dictionary<string, int> data = new Dictionary<string, int>();
                data.Add(sub1, mar1);
                data.Add(sub2, mar2);
                data.Add(sub3, mar3);
                data.Add(sub4, mar4);
                data.Add(sub5, mar5);
                foundStudent.semesters.Add(semNo, data);
            }

        }
        static void ShowMark(List<Students> data)
        {
            Console.Write("Enter the Roll No : ");
            int RollNo = Convert.ToInt32(Console.ReadLine());
            Students? foundStudent = FindStudent(data, RollNo);
            if (foundStudent == null)
            {
                Console.WriteLine("Student Not Found!.............");
            }
            else
            {
                Console.WriteLine($"The Semester Marks of {RollNo}");
                Console.Write("Enter the Semester : ");
                string Sem = Console.ReadLine() ?? "";
                if (!foundStudent.semesters.ContainsKey(Sem))
                {
                    Console.WriteLine($"Still the {Sem} Marks are not added!..");
                }
                else
                {
                    Console.WriteLine("=========================");
                    foreach (var Data in foundStudent.semesters[Sem])

                    {
                        Console.WriteLine($"{Data.Key} : {Data.Value}");
                    }
                    Console.WriteLine("=========================");
                }
            }
        }
    }
}