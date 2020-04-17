//20183732_Tommy_Pham

using System;

namespace _20183732_Tommy_Pham
{
    public class StregsystemCLI : IStregsystemUI
    {
        private bool _running = true;
        private readonly IStregsystem ss;
        public delegate void StregsystemEvent(string command);
        public event StregsystemEvent CommandEntered;

        public StregsystemCLI(IStregsystem ss)
        {
            this.ss = ss;
        }

        public void Start()
        {
            Console.Clear();
            StregsystemCommandParser parser = new StregsystemCommandParser(this, ss);
            do
            {
                DrawMenu();
                parser.ParseCommand();
                Console.WriteLine("Press any button to continue");
                Console.ReadKey();
                
                
            } while (_running);
        }

        public void DrawMenu()
        {
            Console.Clear();
            foreach (Product item in ss.products)
            {
                if (item.active)
                {
                    string formattedString = string.Format("{0, 7} - {1, -35} - {2, 8} credits", item.id, item.name, item.price);
                    System.Console.WriteLine(formattedString);
                }
            }
            System.Console.WriteLine(Environment.NewLine + "For at købe, Indtast dit brugernavn og et produkt ID (adskildt med \"space\")." +
                                     " Købet vil blive registreret uden yderligere input. Under feltet vil der vises en bekræftelse af købet");
            System.Console.Write(Environment.NewLine + "Quickbuy:");
        }

        public void Close()
        {
            Console.WriteLine("You have closed the program, goodbye");
            _running = false;
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine("Admincommand \"" + adminCommand + "\" could not be found, please try again");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine(errorString);
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine(user.username + " has insufficient cash for " + product.name);
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine("Product:\"" + product + "\"" + " can not be found");
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine("input " + command + " had too many arguments");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.user.username + " bought " + transaction.product.name);
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine(transaction.user.username + " bought " + count + " number of " + transaction.product.name);
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(Environment.NewLine + user.ToString() + Environment.NewLine);
        }

        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"User: \"{username}\" was not found or does not exist");
        }

        public void DisplayTransactions(Transaction t)
        {
            Console.WriteLine(t.ToString());
        }

        protected virtual void OnCommandEntered(string command)
        {
            CommandEntered?.Invoke(command);
        }
    }

}
