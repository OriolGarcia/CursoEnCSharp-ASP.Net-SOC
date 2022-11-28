using _20221118_NeptunoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _20221118_NeptunoMVC.Controllers
{
	public class CustomerController : Controller
	{
		public IActionResult Detail(string customerId="")
		{

			CustomerModel cm = new CustomerModel();
			var customer = cm.GetCustomer(customerId);
			return View(customer);
		}
	}
}
