//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
    public abstract class Transaction
    {
		private int _id;
		private string _user;
		private DateTime _date;
		private decimal _amount;

		public Transaction()
		{
				
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
		public string user
		{
			get { return _user; }
			set { _user = value; }
		}
		public DateTime date
		{
			get { return _date; }
			set { _date = value; }
		}

		public abstract void ToString();
		public abstract void Execute();
	}
}
