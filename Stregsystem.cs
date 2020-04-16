//20183732_Tommy_Pham
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _20183732_Tommy_Pham
{
	public class Stregsystem : IStregsystem
	{
		public readonly List<User> userList = new List<User>();
		public readonly List<Product> productList = new List<Product>();
		public event User.UserBalanceNotification UserBalanceWarning;

		public IEnumerable<Product> products { get { return productList; } }

		public Stregsystem()
		{
			FillUserAndProductList();
			UserBalanceWarning += NotifyUser;
		}


		public void FillUserAndProductList()
		{
			IO io = new IO();
			List<User> uList = io.ReadUsercsv(@"C:\Users\T-Phamz\OneDrive - Aalborg Universitet\Skole\Objectorienteret_prog\users.csv");
			List<Product> pList = io.ReadProductcsv(@"C:\Users\T-Phamz\OneDrive - Aalborg Universitet\Skole\Objectorienteret_prog\products.csv");
			foreach (Product p in pList)
			{
				productList.Add(new Product(p.id, p.name, p.price, p.active, p.canBeBoughtOnCredit));
			}

			foreach (User u in uList)
			{
				userList.Add(new User(u.id, u.firstName, u.lastName, u.username, u.balance, u.email));
			}
		}

		public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
		{

			InsertCashTransaction insertCredit = new InsertCashTransaction(user, amount);
			insertCredit.Execute(user, amount);

			return new InsertCashTransaction(user, amount);
		}

		public BuyTransaction BuyProduct(User user, Product product)
		{
			BuyTransaction buyProduct = new BuyTransaction(user, product);
			buyProduct.Execute(user, product.price);
			return new BuyTransaction(user, product);
		}

		public void OnUserBalanceWarning(User user)
		{
			User.UserBalanceNotification localCopy = UserBalanceWarning;
			if (user.balance < 50 && localCopy != null)
			{
				UserBalanceWarning(user, user.balance);
			}
		}

		public void NotifyUser(User user, decimal balance)
		{
			IStregsystemUI ui = new StregsystemCLI(this);
			ui.DisplayGeneralError($"You have under 50 credits ({balance}) left on account ({user.username})");
		}

		public Product GetProductByID(int id)
		{
			return productList.First(p => p.id == id);
		}

		public IEnumerable<Transaction> GetTransactions(User user, int count)
		{
			IO io = new IO();
			List<Transaction> list = io.ReadTransactiontxt(@"C:\Users\T-Phamz\Desktop\test.txt");
			List<Transaction> transactionList = list.Where(u => u.user.username == user.username).OrderByDescending(s => s.id)
								.Take(count).ToList();

			return transactionList;
		}

		public User GetUserByUsername(string userName)
		{
			User desiredUser = userList.First(u => u.username == userName);
			return desiredUser;
		}

		public List<User> GetUsers(Func<User, bool> predicate)
		{

			List<User> result = new List<User>();
			foreach (User item in userList)
			{
				if (predicate(item))
				{
					result.Add(item);
				}
			}
			return result;
		}
		public void LogTransaction(Transaction t, string filePath)
		{
			if (!File.Exists(filePath))
			{
				File.Create(filePath).Dispose();
				var st = new StreamWriter(filePath, true);
				st.WriteLine(t.ToStringFile());
				st.Close();
			}
			else if (File.Exists(filePath))
			{
				var st = new StreamWriter(filePath, true);
				st.WriteLine(t.ToStringFile());
				st.Close();
			}
		}
	}
}
