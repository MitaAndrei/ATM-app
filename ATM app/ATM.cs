using System;
namespace ATM_app
{
	public class ATM
	{
		private List<Card> cards = new();

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

			if (currentCard.IsBlocked)
			{
				Console.WriteLine("Card is blocked.");
				WithdrawCard();
				return;
			}

			OperateWithCard();
		}

		private void OperateWithCard()
		{
			do
			{
				Console.WriteLine();
				Console.WriteLine("What would you want to do?");
				Console.WriteLine("Withdraw money (type 1)");
				Console.WriteLine("Deposit money (type 2)");
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
						Console.Write("How much would you like to deposit? ");
						amt = Convert.ToDecimal(Console.ReadLine());
						currentCard.DepositMoney(amt);
						break;

					case "3":
						if (currentCard.Bills.Count == 0)
							Console.WriteLine("You have paid all bills");
						else
						{
							Console.WriteLine("Which one do you want to pay? (type index)");
							currentCard.ShowBills();
							var ans = Console.ReadLine();
							if (int.TryParse(ans, out int result) && result > 0 && result <= currentCard.Bills.Count)
								currentCard.PayBills(result);
							else
								Console.WriteLine("invalid index");
						}
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
						Console.WriteLine("Invalid option");
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
			currentCard.IsBlocked = true;
			Console.WriteLine("Blocked card.");
			WithdrawCard();
		}
	}
}

