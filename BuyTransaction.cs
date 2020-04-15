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
			this.id = id;
			this.user = user;
			this.product = product;
			date = DateTime.Now;
		}
		public BuyTransaction(int id, User user, Product product, string kindOfTransaction, DateTime Date) : base(user)
		{
			this.id = id;
			this.user = user;
			this.product = product;
			string transactionType = kindOfTransaction;
			this.date = Date;
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
				LogTransaction(@"C:\Users\T-Phamz\Desktop\test.txt");
			}

		}

		public override string ToString()
		{
			return $"Buy transaction id: {id} username: {user.username} product bought: {product.id} {product.name}  date of transaction {date}";
		}

		public override string ToStringFile()
		{
			return $"{id},BuyTransaction,{user.username},{product.price},{product.id},{date}";
		}
	}
}
