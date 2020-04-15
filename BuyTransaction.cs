//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
	//hvorfor er der en amount her og en i transaction????
	public class BuyTransaction : Transaction
	{
		private Product _product;

		public BuyTransaction(User user, Product product) : base(user)
		{
			id = System.Threading.Interlocked.Increment(ref _transactionID);
			this.user = user;
			this.product = product;
			date = DateTime.Now;
		}

		public Product product
		{
			get { return _product; }
			set { _product = value; }
		}

		public override void Execute(User user, decimal amount)
		{
			if (user.balance - product.price < 0 && product.canBeBoughtOnCredit == false)
			{
				throw new InsufficientCreditsException($"{user.username} did not have sufficient credits for purchase of {product.name}");
			}
			else if (product.active == false)
			{
				throw new ProductNotActiveException($"{user.username} tried to buy inactive {product.name}. " +
												$"{Environment.NewLine}Can not buy product which is inactive");
			}
			else
			{
				user.balance -= product.price;
			}

		}

		public override void LogTransaction(Transaction t)
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return "Buy Transaction ID: " + id + "user: " + user + "price of product(s) " + amount
		+ "this transaction transpired: " + date;
		}
	}
}
