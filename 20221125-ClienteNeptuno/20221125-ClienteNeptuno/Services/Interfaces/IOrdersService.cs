using _20221125_ClienteNeptuno.Models;
using APINeptuno.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _20221125_ClienteNeptuno.Services.Interfaces
{
	public interface IOrdersService
	{
       
            public Task<List<PedidoExtended>> GetPedidos();
            public Task<ListPedidoExtended> GetPedidos(int skip, int pageSize, string sortColumn, string sortColumnDir, string search);
            public Task<OrderExtended> GetDetails(int orderId);
            public Task<OrderDocument> GetExcel(int orderId);
        
    }
}
