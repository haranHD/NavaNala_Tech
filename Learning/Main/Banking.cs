namespace Learning.Main
{
    class Banking
    {
        public string accountNo { set; get; }
        public string accHolder { set; get; }
        public int Pin { set; get; }
        private double balances;
        public Banking(string accNo, string acHolder, int pin, double initailbalance)
        {
            accountNo = accNo;
            accHolder = acHolder;
            Pin = pin;
            balances = initailbalance;
            Console.WriteLine($"Account Created Successfully for {accHolder}");
        }
        public void deposite(double amount)
        {
            balances += amount;
            Console.WriteLine($"{amount} added to your account");
        }
        public void withdraw(double amount)
        {
            if (balances >= amount)
            {
                balances -= amount;
                Console.WriteLine($"Have your amount {amount}");
            }
            else
            {
                Console.WriteLine("Insufficient Balances");
            }
        }
        public void balanceChk()
        {
            Console.WriteLine($"Your Total Balance : {balances}");
        }


    }

}
