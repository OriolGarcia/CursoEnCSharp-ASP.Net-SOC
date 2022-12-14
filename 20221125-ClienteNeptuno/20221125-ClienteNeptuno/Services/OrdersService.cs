using _20221125_ClienteNeptuno.Services.Interfaces;
using APINeptuno.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using Utils;
using _20221125_ClienteNeptuno.Models;

namespace _20221125_ClienteNeptuno.Services
{
	public class OrdersService : IOrdersService
	{
		public async Task<OrderExtended> GetDetails(int orderId)
		{
            //Conexión con el WEBAPI
            //https://localhost:44348/api/orders/pedido?orderId=XXXXX
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
        public async Task<OrderDocument> GetExcel(int orderId)
        {
            //Conexión con el WEBAPI
            //https://localhost:44348/api/orders/excel?orderId=XXXXX
            string url = "api/orders/excel?orderId=" + orderId;

            HttpClient client = Utils.UtilsWeb.GetClient();

            OrderDocument od = null;
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
                    od = JsonSerializer.Deserialize<OrderDocument>(data, options);
                }
            }
            catch (Exception err)
            {
            }

            return od;
        }


        public async Task<List<PedidoExtended>> GetPedidos()
        {
            //Conexión con el WEBAPI
            //https://localhost:44348/api/orders/pedidos
            string url = "api/orders/pedidos";

            HttpClient client = Utils.UtilsWeb.GetClient();

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
        public async Task<ListPedidoExtended> GetPedidos(int skip, int pageSize, string sortColumn, string sortColumnDir, string search)
		{
            //Conexión con el WEBAPI
            //https://localhost:44348/api/orders/pedidos
            string url = "api/orders/pedidoss?skip="+skip+"&pageSize="+pageSize+"&sortColum="+sortColumn+"&sortColumnDir="+sortColumnDir+"&search="+search;

            HttpClient client = UtilsWeb.GetClient();

            ListPedidoExtended pedidos = null;

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
                    pedidos = JsonSerializer.Deserialize<ListPedidoExtended>(data, options);
                }
            }
            catch { }

            return pedidos;
        }
	}
}
