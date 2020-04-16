//20183732_Tommy_Pham
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
			this.id = LastIDUsed(@"C:\Users\T-Phamz\Desktop\test.txt");
			this.user= user;
		}

		public decimal amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		public int id
		{
			get { return _id; }
			set 
			{
				_id = value; 
			}
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
			set { _date = value; }
		}
		
		public abstract override string ToString();
		public abstract string ToStringFile();
		public abstract void Execute(User user, decimal amount);

		public int LastIDUsed(string filePath)
		{
			int lastID = 0;
			foreach (string line in File.ReadLines(filePath))
			{
				string[] newList = line.Split(",");
				lastID = int.Parse(newList[0]);
			}
			lastID += 1;
			return lastID;
		}





	}
}
