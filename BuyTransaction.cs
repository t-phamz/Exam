//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{

	public class BuyTransaction : Transaction
	{
		private Product _product;
		private decimal _amount;

		public BuyTransaction(User user, decimal amount) : base(user, amount)
		{
			id = System.Threading.Interlocked.Increment(ref _transactionID);
			this.user = user;
			this.amount = amount;
		}

		public Product product
		{
			get { return _product; }
			set { _product = value; }
		}

		public override void Execute(User user, decimal price)
		{
			if (user.balance - amount > 0)
			{
				throw new InsufficientCreditsException($"{user.username} did not have sufficient credits for purchase of {product.name}");
			}
			else if (product.active == false)
			{
				throw new ProductNotActiveException($"{user.username} tried to buy inactive {product.name}. " +
												$"{Environment.NewLine} Can not buy product which is inactive");
			}
			else
			{
				user.balance -= amount;
			}
		}

		public override string ToString()
		{
			return "Buy Transaction ID: " + id + "user: " + user + "price of product(s) " + amount
		+ "this transaction transpired: " + date;
		}
	}
}
