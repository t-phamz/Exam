//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
	public class SeasonalProduct : Product
	{
		private DateTime _seasonStartDate;
		private DateTime _seasonEndDate;
		private bool _active;

		public SeasonalProduct(string name, decimal price, bool canBeBoughtOnCredit, string seasonStartDate, string seasonEndDate) :base(name, price, canBeBoughtOnCredit)
		{
			id = System.Threading.Interlocked.Increment(ref _productID);
			this.name = name;
			this.price = price;
			this.canBeBoughtOnCredit = canBeBoughtOnCredit;
			this.seasonStartDate = DateTime.Parse(seasonStartDate);
			this.seasonEndDate = DateTime.Parse(seasonEndDate);
			active = active;
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

		public override bool active
		{
			get { return _active; }
			set
			{
				if (DateTime.Now >= seasonStartDate && DateTime.Now < seasonEndDate)
				{
					_active = true;
				}
				else
				{
					_active = false;
				}
			}
		}

	}
	
}
