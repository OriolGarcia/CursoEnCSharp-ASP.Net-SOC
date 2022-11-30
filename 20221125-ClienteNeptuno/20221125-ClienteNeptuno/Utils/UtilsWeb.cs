using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
	public static class UtilsWeb
	{
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }
        public static string Encode(string text)
        {
            byte[] mybyte = System.Text.Encoding.UTF8.GetBytes(text);
            string returntext = System.Convert.ToBase64String(mybyte);
            return returntext;
        }

        public static string Decode(string text)
        {
            byte[] mybyte = System.Convert.FromBase64String(text);
            string returntext = System.Text.Encoding.UTF8.GetString(mybyte);
            return returntext;
        }
        public  static HttpClient GetClient(string urlBase)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
