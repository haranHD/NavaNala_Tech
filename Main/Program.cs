using System;
namespace Learning.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to NavaNala Banking System!");
            List<Banking> accounts = new List<Banking>();
            while (true)
            {
                Console.WriteLine("Please Enter your Processing Number");
                Console.WriteLine("1.Create an account");
                Console.WriteLine("2.Deposite");
                Console.WriteLine("3.Withdraw");
                Console.WriteLine("4.Balance");
                Console.WriteLine("5.Exit");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Write("Enter account no :");
                        string accNo = Console.ReadLine();
                        Console.Write("Enter your Name :");
                        string accHolder = Console.ReadLine();
                        Console.Write("Enter your PIN :");
                        int pin = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter your Balances :");
                        double balance = Convert.ToDouble(Console.ReadLine());
                        accounts.Add(new Banking(accNo, accHolder, pin, balance));
                        break;
                    case 2:
                        Console.Write("Enter the Account No :");
                        string acNo = Console.ReadLine();
                        var acc = accounts.Find(idx => idx.accountNo == acNo);
                        if (acc != null)
                        {
                            int count = 3;
                            while (count != 0)
                            {
                                Console.Write("Enter Your PIN :");
                                int pin1 = int.Parse(Console.ReadLine());
                                var pinNo = accounts.Find(idx => idx.Pin == pin1);
                                if (pinNo != null)
                                {
                                    Console.Write("Enter the Amount :");
                                    double amt = double.Parse(Console.ReadLine());
                                    acc.deposite(amt);
                                    break;
                                }
                                else if (count != 0)
                                {
                                    count--;
                                    Console.WriteLine($"Try again {count} Times");
                                }
                                else
                                {
                                    Console.WriteLine("Try some other again");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Account Not Found!");
                        }
                        // Console.WriteLine("Deposited Successfully!");
                        break;
                    case 3:
                        Console.Write("Enter the Account No :");
                        string acNo1 = Console.ReadLine();
                        var acc1 = accounts.Find(idx => idx.accountNo == acNo1);
                        if (acc1 != null)
                        {
                            int count = 3;
                            while (count != 0)
                            {
                                Console.Write("Enter Your PIN :");
                                int pin1 = int.Parse(Console.ReadLine());
                                var pinNo = accounts.Find(idx => idx.Pin == pin1);
                                if (pinNo != null)
                                {
                                    Console.Write("Enter the Amount :");
                                    double amt = double.Parse(Console.ReadLine());
                                    acc1.withdraw(amt);
                                    break;
                                }
                                else if (count != 0)
                                {
                                    count--;
                                    Console.WriteLine($"Try again {count} Times");
                                }
                                else
                                {
                                    Console.WriteLine("Try some other again");
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Account Not Found!");
                        }

                        // Console.WriteLine("withdraw Done!");

                        break;



                    case 4:
                        Console.Write("Enter the Account No :");
                        string acNo2 = Console.ReadLine();
                        Console.WriteLine("Checking Your Balances");
                        var acc2 = accounts.Find(idx => idx.accountNo == acNo2);
                        if (acc2 != null)
                        {
                            acc2.balanceChk();
                        }
                        else
                        {
                            Console.WriteLine("Account Not Found!");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid Input!!");
                        break;

                }
            }
        }
    }
}