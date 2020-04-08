//20183732_Tommy_Pham
using System;
using System.Collections.Generic;
using System.Linq;

namespace _20183732_Tommy_Pham
{
    public class StrikeSystem
	{

		List<Product> activeProducts = new List<Product>();

		public void BuyProduct(User user, Product product)
		{
			BuyTransaction buyProduct = new BuyTransaction(user);
			buyProduct.Execute(user, product.price);

		}

		public void AddCreditsToAccount(User user, decimal amount)
		{
			InsertCashTransaction insertCredit = new InsertCashTransaction(user);
			insertCredit.Execute(user, amount);
		}
		public void ExecuteTransaction(Transaction transaction)
		{
			throw new NotFiniteNumberException();
		}
		public Product GetProductByID(int ID, List<Product> list)
		{
			return list[ID-1];
		}

		public void GetUsers(Func<User, bool> predicate)
		{
			throw new NotFiniteNumberException();
		}

		public User GetUserByUsername(string userName, List<User> list)
		{
			User desiredUser = list.FirstOrDefault(u => u.username == userName);
			return desiredUser;
		}

		public List<Transaction> GetTransactions(User user, int count)
		{
			//List<Transaction> list = new List<Transaction>();
			//List<Transaction> sortedList = list.OrderByDescending(l => l.id).ToList();
			//List <Transaction> transactionList = list.Where()


			List<Transaction> list = new List<Transaction>();
			List<Transaction>  transactionList = list.Where(u => u.user.username == user.username).OrderByDescending(s => s.id)
								.Take(count).ToList();




			return transactionList;
		}



	}
}
