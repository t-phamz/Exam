//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
	public class SeasonalProduct
	{
		public class Product
		{
			private int _id;
			private string _name;
			private decimal _price;
			private bool _canBeBoughtOnCredit;
			private DateTime _seasonStartDate;
			private DateTime _seasonEndDate;
			private bool _active;



			public int id
			{
				get { return _id; }
				set { _id = value; }
			}
			public string name
			{
				get { return _name; }
				set { _name = value; }
			}

			public decimal price
			{
				get { return _price; }
				set { _price = value; }
			}
			public bool canBeBoughtOnCredit
			{
				get { return _canBeBoughtOnCredit; }
				set { _canBeBoughtOnCredit = value; }
			}
			public DateTime seasonStartDate
			{
				get { return _seasonStartDate; }
				set { _seasonStartDate = value; }
			}
			public DateTime seasonEndDate
			{
				get { return _seasonEndDate; }
				set { _seasonEndDate = value; }
			}
			public bool active
			{
				get { return _active; }
				set { _active = value; }
			}
		}
	}
}
