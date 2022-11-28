using _20221118_NeptunoMVC.Dal;
using System;

namespace _20221118_NeptunoMVC.Models
{
	public class CustomerModel
	{
		public Customer GetCustomer(string customerId)
		{
			var dbContext = new cifo_OGSContext();
			var customer = dbContext.Customers.Find(customerId);
			return	customer;
		}
	}
}
