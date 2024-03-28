using System;
namespace ATM_app
{
	public class Card
	{
        
        private string pin = string.Empty;
        private decimal balance = 0;
        public string Number { get; set; }
        public bool IsBlocked { get; set; }

        public List<Bill> Bills { get; } = new();
        public List<Transaction> Transactions { get; } = new();
       

		public Card(string n)
		{
            Number = n;
            while (pin == string.Empty)
            {
                Console.Write("Set a PIN: ");
                SetPin(Console.ReadLine());
            }
            Bills.Add(new Bill("Internet", 300));
            Bills.Add(new Bill("Cellphone", 100));
            Bills.Add(new Bill("Mortgage", 2500));
            Bills.Add(new Bill("Water", 400));
        }

        private void SetPin(string value)
        {
            if (value.Length == 4 && int.TryParse(value, out int result))
                pin = value;
            else
                Console.WriteLine("invalid pin. Pin must only contain 4 digits");
        }

        public bool PinIsRight(string v)
        {
            return v == pin;
        }

        public void DepositMoney(decimal amt)
        {
            balance += amt;
            Transactions.Add(new Transaction("Deposited", amt));
            Console.WriteLine($"Deposited {amt}");
        }

        public void WithdrawMoney(decimal amt)
        {
            if (balance >= amt)
            {
                balance -= amt;
                Transactions.Add(new Transaction("Withdrew", amt));
                Console.WriteLine($"Withdrew {amt}. Current balance: {balance}");
            }
            else
                Console.WriteLine("You don't have this much money.");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Current balance: {balance}");
            Console.WriteLine("Transactions done since ATM started:");
            foreach (var t in Transactions)
                Console.WriteLine(t);
        }

        public void ShowBills()
        {
            for(int i = 0; i<Bills.Count; i++)
            {
                Console.WriteLine($"{i+1}) {Bills[i].Name} -- {Bills[i].Cost}");
            }
        }

        public void PayBills(int billId)
        {

            billId -= 1;
            int cost = Bills[billId].Cost;

            if (balance >= cost)
            {
                balance -= cost;
                Transactions.Add(new Transaction($"Paid for {Bills[billId].Name}", cost));
                Console.WriteLine($"Paid {cost} for {Bills[billId].Name}");
                Bills.RemoveAt(billId);
            }
            else
                Console.WriteLine("You don't have this much money");

        }
    }
}

