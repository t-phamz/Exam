//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
	public class InsertCashTransaction : Transaction
	{
		public InsertCashTransaction(User user) : base(user)
		{
			id = System.Threading.Interlocked.Increment(ref _transactionID);
			this.user = user;
		}

		public override string ToString()
		{
			return "Insert cash transaction ID: " + id + "user: " + user + "amount inserted " + amount
					+ "this transaction transpired: " + date;
		}
		public override void Execute(User user, decimal amount)
		{
			user.balance += amount;
		}
	}
}
