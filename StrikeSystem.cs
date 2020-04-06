//20183732_Tommy_Pham
using System;
using System.Collections.Generic;

namespace _20183732_Tommy_Pham
{
    public class StrikeSystem
	{

		List<Product> activeProducts = new List<Product>();
		public void BuyProduct(User u, Product p)
		{
			throw new NotImplementedException();
		}

		public void AddCreditsToAccount(User u, decimal amount)
		{
			throw new NotFiniteNumberException();
		}
		public void ExecuteTransaction(Transaction t)
		{
			throw new NotFiniteNumberException();
		}
		public void GetProductByID(int ID)
		{
			throw new NotFiniteNumberException();
		}

		public void GetUsers(Func<User, bool> predicate)
		{
			throw new NotFiniteNumberException();
		}

		public void GetUserByUsername(string userName)
		{
			throw new NotFiniteNumberException();
		}

		public void GetTransactions(User u, int i)
		{
			throw new NotFiniteNumberException();
		}



	}
}
