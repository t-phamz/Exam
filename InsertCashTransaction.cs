//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
	public class InsertCashTransaction : Transaction
	{
		public InsertCashTransaction(User user, decimal amount) : base(user)
		{
			id = id;
			this.user = user;
			this.amount = amount;
			date = DateTime.Now;
		}
		public InsertCashTransaction(int id, User user, decimal amount, DateTime Date): base(user)
		{
			this.id = id;
			this.user = user;
			this.amount = amount;
			date = Date;
		}

		public override string ToStringFile()
		{
			return $"{id},InsertCashTransaction,{user.username},{amount},0,{date}";
		}
		public override string ToString()
		{
			return $"Insert cash transaction ID: {id} username: {user.username} amount inserted {amount} date of transaction {date}";
		}

		public override void Execute(User user, decimal amount)
		{
			user.balance += amount;
		}


	}
}
