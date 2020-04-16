//20183732_Tommy_Pham
using System;
using System.Text.RegularExpressions;

namespace _20183732_Tommy_Pham
{
	public class Product
    {
		private int _id;
		private string _name;
		private bool _active;
		public decimal price { get; set; }
		public bool canBeBoughtOnCredit { get; set; }

		public Product(int id, string name, decimal price, bool active, bool canBeBoughtOnCredit)
		{
			this.id = id;
			this.name = name;
			this.price = price;
			this.active = active;
			this.canBeBoughtOnCredit = canBeBoughtOnCredit;

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
		public string name
		{
			get { return _name; }
			set 
			{
					if (value != null)
					{
					string valuetrim = value.Replace("\"", "").Replace("<h1>", "").Replace("</h1>", "").Replace("</h2>", "")
					.Replace("<h2>", "").Replace("<h3>", "").Replace("</h3>", "").Replace("<b>", "").Replace("</b>", "");
						_name = valuetrim;


					}
					else
					{
						throw new CannotBeNullException("The product name can not be null");
					}
			}
			
		}

		public virtual bool active
		{
			get { return _active; }
			set { _active = value; }
		}


		public override string ToString()
		{
			return id +" " + name +" "+ price;
		}


	}
}
