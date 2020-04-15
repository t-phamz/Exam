//20183732_Tommy_Pham
using System;
using System.Text.RegularExpressions;

namespace _20183732_Tommy_Pham
{
	public class Product
    {
		//tjek hvordan ID fungere med csv filen
		private int _id;
		private string _name;
		private decimal _price;
		private bool _canBeBoughtOnCredit;
		private bool _active;

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
				//Måske brug Regex?
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
		//det er 10 fordi at når den bliver læst ind i en liste sker dette to gange.
		public decimal price
		{
			get { return _price; }
			set { _price = value/10; }
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
