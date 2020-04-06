//20183732_Tommy_Pham
namespace _20183732_Tommy_Pham
{

	public class BuyTransaction : Transaction
	{
		private Product _product;
		private decimal _amount;

		public decimal amount
		{
			get { return _amount; }
			set { _amount = value; }
		}

		public Product product
		{
			get { return _product; }
			set { _product = value; }
		}

		public override void Execute()
		{
			throw new System.NotImplementedException();
		}

		public override void ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}
