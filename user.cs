//20183732_Tommy_Pham
using System;
using System.Text.RegularExpressions;

namespace _20183732_Tommy_Pham
{
	public class User : IComparable<User>
    {
		private int _id;
		private string _firstName;
		private string _lastName;
		private string _userName;
		private string _email;
		private decimal _balance;
		private static int _userID = 0;
		public delegate void UserBalanceNotification(User user, decimal balance);

		public User(int id, string firstName, string lastName, string userName, decimal balance, string email)
		{
			this.id = id;
			this.firstName = firstName;
			this.lastName = lastName;
			this.username = userName;
			this.email = email;
			this.balance = balance; 
		}

		public decimal balance
		{
			get { return _balance; }
			set { _balance = value; }
		}

		public int id
		{
			get { return _id; }
			set 
			{
				if (value <= 0)
				{
					value = 1;
				}
				_id = value;
			}
		}
		public string firstName
		{
			get { return _firstName; }
			set {
					if (value != null)
					{
						_firstName = value;
					}
					else
					{
						throw new CannotBeNullException("The product name can not be null");
					}
				}
		}
		public string lastName
		{
			get { return _lastName; }
			set {
					if (value != null)
					{
						_lastName = value;
					}
					else
					{
						throw new ArgumentException("The last name can not be null", "value");
					}
				}
		}

		public string username
		{
			get { return _userName; }
			private set 
				{
					string userNamePattern = @"^[a-zA-Z0-9_]+$";

					if (Regex.IsMatch(value, userNamePattern))
					{
						_userName = value;
					}
					else
					{
					throw new InvalidCharactersException("username contains invalid characters");
					}
				}
		}
		public string email
		{
			get { return _email; }
			set {
				string emailpattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
					if (Regex.IsMatch(value, emailpattern))
					{
						_email = value;
					}
					else
					{
					throw new InvalidEmailException("Invalid Email or invalid characters were detected");
					}
					
				}
		}
		public override string ToString()
		{
			return $"Username: {username} name: {firstName} {lastName} ({email}) Balance: {balance}";
		}

		public bool Equals(User other)
		{
			return this.firstName.Equals(other.firstName) && this.lastName.Equals(other.lastName);

		}

		public override int GetHashCode()
		{
			return HashCode.Combine(firstName, lastName);
		}

		public int CompareTo(User other)
		{
			return id.CompareTo(other.id);
		}
	}
}
