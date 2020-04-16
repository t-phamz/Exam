//20183732_Tommy_Pham
using System;
using System.IO;

namespace _20183732_Tommy_Pham
{
	public abstract class Transaction
    {
		private User _user;
		public decimal amount { get; set; }
		public DateTime date { get; set; }
		public int id { get; set; }

		public Transaction(User user)
		{
			this.id = LastIDUsed(@"C:\Users\T-Phamz\Desktop\test.txt");
			this.user= user;
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
					throw new ArgumentException("User can not be null");
				}
			}
		}


		public abstract override string ToString();
		public abstract string ToStringFile();
		public abstract void Execute(User user, decimal amount);

		public int LastIDUsed(string filePath)
		{
			int lastID = 0;
			try
			{
				foreach (string line in File.ReadLines(filePath))
				{
					string[] newList = line.Split(",");
					lastID = int.Parse(newList[0]);
				}
				lastID += 1;
				return lastID;
			}
			catch (Exception)
			{
				File.Create(filePath).Dispose();
				return 1;
			}
			

		}





	}
}
