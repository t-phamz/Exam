//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
	public class SeasonalProduct : Product
	{
		//tjek hvordan ID fungere med csv filen
		private DateTime _seasonStartDate;
		private DateTime _seasonEndDate;
		private bool _active;

		public SeasonalProduct(int id, string name, decimal price, bool active, bool canBeBoughtOnCredit, string seasonStartDate, string seasonEndDate) :base(id, name, price, active, canBeBoughtOnCredit)
		{
			this.id = id;
			this.name = name;
			this.price = price;
			this.active = active;
			this.canBeBoughtOnCredit = canBeBoughtOnCredit;
			this.seasonStartDate = DateTime.Parse(seasonStartDate);
			this.seasonEndDate = DateTime.Parse(seasonEndDate);
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
