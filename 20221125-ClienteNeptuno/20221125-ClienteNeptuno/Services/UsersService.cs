using _20221124_APINeptuno.Dal;
using _20221125_ClienteNeptuno.Services.Interfaces;
using APINeptuno.Models;
using System.Net.Http;
using System.Text.Json;
using System;
using System.Threading.Tasks;
using Utils;

namespace _20221125_ClienteNeptuno.Services
{
    public class UsersService : IUsersService
    {
        public async Task<User> DoLogin(string login, string password)
        {


            //Conexión con el WEBAPI
            //https://localhost:44392/api/orders/pedido?orderId=XXXXX

            password = UtilsWeb.GetMD5(password);
            string url = "api/users/login?login=" + login+"&password="+password;

            HttpClient client =UtilsWeb.GetClient("https://localhost:44348/");

           User user = null;
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
                    user = JsonSerializer.Deserialize<User>(data, options);
                }
            }
            catch (Exception err)
            {
            }

            return user;
        }
    }
}
