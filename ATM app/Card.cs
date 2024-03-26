using System;
namespace ATM_app
{
	public class Card
	{
        
        private string pin = string.Empty;
        private decimal balance = 0;
        public string Number { get; set; }

		public Card(string n)
		{
            Number = n;
            while (pin == string.Empty)
            {
                Console.Write("Set a PIN: ");
                SetPin(Console.ReadLine());
            }
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
            Console.WriteLine($"Deposited {amt}");
        }

        public void WithdrawMoney(decimal amt)
        {
            if (balance >= amt)
            {
                balance -= amt;
                Console.WriteLine($"Withdrew {amt}. Current balance: {balance}");
            }
            else
                Console.WriteLine("You don't have this much money.");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Current balance: {balance}");
        }

    }
}

