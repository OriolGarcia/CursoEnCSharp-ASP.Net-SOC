using _20221125_ClienteNeptuno.Services.Intefaces;
using APINeptuno.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using System.Text.Json;

namespace _20221125_ClienteNeptuno.Services
{
	public class OrdersService : IOrdersService
	{
		public async Task<List<PedidoExtended>> GetPedidos()
		{
            //https://localhost:44348/api/orders/pedidos
            string url = "api/orders/pedidos";
			//Conexion con el WEBAPI
			HttpClient client= new HttpClient();
			client.BaseAddress = new Uri("https://localhost:44348");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			List<PedidoExtended> pedidos = null;
			try { 
				
				HttpResponseMessage response = await client.GetAsync(url);

				if (response.IsSuccessStatusCode)
				{
					//Deserializacion
					string data=await response.Content.ReadAsStringAsync();
					var options = new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true,
					};
					pedidos= JsonSerializer.Deserialize<List<PedidoExtended>>(data,options);
				}
			
			}
			catch { 
			
			
			
			}
            return pedidos; 
		}
        public async Task<OrderExtended> GetDetails(int orderId)
        {
            //https://localhost:44348/api/orders/pedido?orderId=XXX
            string url = "api/orders/pedido?orderId="+orderId;
            //Conexion con el WEBAPI
            HttpClient client=GetClient();
            OrderExtended oe = null;
            try
            {

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //Deserializacion
                    string data = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    oe = JsonSerializer.Deserialize<OrderExtended>(data, options);
                }

            }
            catch
            {



            }
            return oe;
        }
        private HttpClient GetClient()
        {
            
            //Conexion con el WEBAPI
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44348");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
