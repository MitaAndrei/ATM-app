using System;
namespace ATM_app
{
	public class ATM
	{
		private List<Card> cards = new();
		private List<Card> blockedCards = new();


        Card currentCard = null;
		
		public ATM()
		{
		}

		public void InsertCard()
		{
			Console.Write("Type card number: ");
			string n = Console.ReadLine();

			foreach (var c in cards)
				if (c.Number == n)
				{
					currentCard = c;
					break;
				}

			if (currentCard == null)
			{
				currentCard = new(n);
				cards.Add(currentCard);
			}

			Console.WriteLine("You have inserted a card. To continue, type in the PIN");

			while (!currentCard.PinIsRight(Console.ReadLine()))
				Console.WriteLine("Incorrect PIN. Try again");

			OperateWithCard();
		}

		private void OperateWithCard()
		{
			do
			{
				Console.WriteLine();
				Console.WriteLine("What would you want to do?");
				Console.WriteLine("Withdraw money (type 1)");
				Console.WriteLine("Deposit money (tyoe 2)");
				Console.WriteLine("Pay bills (type 3)");
				Console.WriteLine("Show balance (type 4)");
				Console.WriteLine("------------------------");
				Console.WriteLine("Withdraw card (type 5)");
				Console.WriteLine("Block card (type 6)");

				string answer = Console.ReadLine();
				decimal amt;
				switch (answer)
				{
					case "1":
						Console.Write("How much would you like to withdraw? ");
						amt = Convert.ToDecimal(Console.ReadLine());
						currentCard.WithdrawMoney(amt);
						break;
					case "2":
						Console.Write("How much would you like to deposit?");
						amt = Convert.ToDecimal(Console.ReadLine());
						currentCard.DepositMoney(amt);
						break;
					case "3":
						break;
					case "4":
						currentCard.ShowBalance();
						break;
					case "5":
						WithdrawCard();
						break;
					case "6":
						BlockCard();
						break;
					default:
						break;
				}
				if (answer == "5" || answer == "6")
					break;
			
			} while (true);

        }

        public void WithdrawCard()
		{
			if (currentCard == null)
				Console.WriteLine("No card inserted");
			else
			{
				currentCard = null;
				Console.WriteLine("Withdrew card.");
			}
		}

		public void BlockCard()
		{
			blockedCards.Add(currentCard);
			cards.Remove(currentCard);
			
			Console.WriteLine("Blocked card.");
			WithdrawCard();
		}
	}
}

