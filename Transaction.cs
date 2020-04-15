﻿//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
    public abstract class Transaction
    {
		private int _id;
		private User _user;
		private DateTime _date;
		private decimal _amount;

		protected static int _transactionID = 0;

		public Transaction(User user)
		{
			id = System.Threading.Interlocked.Increment(ref _transactionID);
			this.user= user;
			DateTime date = DateTime.Now;
		}

		public decimal amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		public int id
		{
			get { return _id; }
			set { _id = value; }
		}
		public User user
		{
			get { return _user; }
			set
			{
				if (value != null)
				{
					_user = value;
				}
				else
				{
					throw new ArgumentException("User can not be null", "value");
				}
			}
		}
		public DateTime date
		{
			get { return _date; }
			set { _date = DateTime.Now; }
		}

		public abstract override string ToString();

		public abstract void Execute(User user, decimal amount);

		public abstract void LogTransaction(Transaction t);



	}
}
