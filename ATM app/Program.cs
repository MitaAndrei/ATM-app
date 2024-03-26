namespace ATM_app;

class Program
{
    static void Main(string[] args)
    {
        ATM atm = new();
        do
        {

            Console.WriteLine("Select an action to perform on the ATM:");
            Console.WriteLine("Insert card (type insert)");
            Console.WriteLine("Withdraw card (type withdraw)");
            Console.WriteLine("Block card (type block)");

            string ans = Console.ReadLine();

            switch (ans)
            {
                case "insert":
                    atm.InsertCard();
                    break;
                case "withdraw":
                    atm.WithdrawCard();
                    break;
                case "block":
                    atm.BlockCard();
                    break;
                default:
                    break;
            }
        } while (true);
    }
}

