//20183732_Tommy_Pham
using System;

namespace _20183732_Tommy_Pham
{
	public class SeasonalProduct : Product
	{
		private bool _active;
		public DateTime seasonStartDate { get; set; }
		public DateTime seasonEndDate { get; set; }

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
