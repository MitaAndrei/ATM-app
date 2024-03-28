using System;
namespace ATM_app
{
	public class Bill
	{
		public string Name { get; set; }
		public int Cost { get; set; }

		public Bill(string name, int cost)
		{
			Name = name;
			Cost = cost;
		}
	}
}

