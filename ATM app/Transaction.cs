using System;
namespace ATM_app
{
	public class Transaction
	{

		private DateTime performedOn;
		private string action;
		private decimal cost;

		public Transaction(string action, decimal cost)
		{
			this.action = action;
			this.cost = cost;
			performedOn = DateTime.Now;
		}

		public override string ToString()
		{
			return $"{action} {cost} at {performedOn}";
		}
	}
}

