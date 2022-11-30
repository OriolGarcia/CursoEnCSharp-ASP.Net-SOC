using APINeptuno.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _20221125_ClienteNeptuno.Services.Interfaces
{
	public interface IOrdersService
	{
		public Task<List<PedidoExtended>> GetPedidos();
		public Task<OrderExtended> GetDetails(int orderId);
	}
}
