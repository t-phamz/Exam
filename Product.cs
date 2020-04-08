//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
    public class Product
    {
		private int _id;
		private string _name;
		private decimal _price;
		private bool _canBeBoughtOnCredit;
		private bool _active;

		protected static int _productID = 0;

		public Product(string name, decimal price, bool active, bool canBeBoughtOnCredit)
		{
			id = System.Threading.Interlocked.Increment(ref _productID);
			this.name = name;
			this.price = price;
			this.active = active;
			this.canBeBoughtOnCredit = canBeBoughtOnCredit;
		}
		public Product(string name, decimal price, bool canBeBoughtOnCredit)
		{
			this.id = System.Threading.Interlocked.Increment(ref _productID);
			this.name = name;
			this.price = price;
			this.canBeBoughtOnCredit = canBeBoughtOnCredit;
		}

		public int id
		{
			get { return _id; }
			set { _id = value; }
		}
		public string name
		{
			get { return _name; }
			set {
					if (value != null)
					{
						_name = value;
					}
					else
					{
						throw new CannotBeNullException("The product name can not be null");
					}
			}
			
		}
		public decimal price
		{
			get { return _price; }
			set { _price = value; }
		}
		public virtual bool active
		{
			get { return _active; }
			set { _active = value; }
		}
		public bool canBeBoughtOnCredit
		{
			get { return _canBeBoughtOnCredit; }
			set { _canBeBoughtOnCredit = value; }
		}

		public override string ToString()
		{
			return id +" " + name +" "+ price;
		}


	}
}
