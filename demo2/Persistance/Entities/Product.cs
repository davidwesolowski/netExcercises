using System;

namespace demo2.Persistance.Entities
{
	public class Product
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Parameters { get; set; }

		public Decimal Price { get; set; }
	}
}