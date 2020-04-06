//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
	public class User : IComparable
    {
		private int _id;
		private int _firstName;
		private string _lastName;
		private string _userName;
		private decimal _balance;

		public User()
		{

		}

		public decimal balance
		{
			get { return _balance; }
			set { _balance = value; }
		}

		public int id
		{
			get { return _id; }
			set { _id = value; }
		}
		public int firstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}
		public string lastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}
		public string username
		{
			get { return _userName; }
			set { _userName = value; }
		}

		public void ToString()
		{
			throw new NotImplementedException();
		}
		public void Equals()
		{
			throw new NotImplementedException();

		}

		public int CompareTo(object obj)
		{
			throw new NotImplementedException();
		}
	}
}
