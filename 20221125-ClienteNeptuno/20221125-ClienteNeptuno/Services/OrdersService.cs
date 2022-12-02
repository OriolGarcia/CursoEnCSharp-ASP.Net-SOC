using _20221125_ClienteNeptuno.Services.Interfaces;
using APINeptuno.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using Utils;

namespace _20221125_ClienteNeptuno.Services
{
	public class OrdersService : IOrdersService
	{
		public async Task<OrderExtended> GetDetails(int orderId)
		{
            //Conexión con el WEBAPI
            //https://localhost:44392/api/orders/pedido?orderId=XXXXX
            string url = "api/orders/pedido?orderId=" + orderId;

            HttpClient client =UtilsWeb.GetClient();

			OrderExtended oe = null;
			try
			{
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //Deserialización de datos
                    string data = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    oe = JsonSerializer.Deserialize<OrderExtended>(data, options);
                }
            }
			catch (Exception err)
			{ 
			}

			return oe;
        }

	

        public async Task<List<PedidoExtended>> GetPedidos()
		{
            //Conexión con el WEBAPI
            //https://localhost:44392/api/orders/pedidos
            string url = "api/orders/pedidos";

			HttpClient client = UtilsWeb.GetClient();

			List<PedidoExtended> pedidos = null;

			try
			{
				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					//Deserialización de datos
					string data = await response.Content.ReadAsStringAsync();
					var options = new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true,
					};
					pedidos = JsonSerializer.Deserialize<List<PedidoExtended>>(data, options);
				}
			}
			catch { }

            return pedidos;
		}
	}
}
