using _20221118_NeptunoMVC.Dal;
using System;

namespace _20221118_NeptunoMVC.Models
{
	public class SupportModel
	{

		public string AddSupport(string nombre,string email,string phone,string tema, string mensaje)
		{
			string message="";
			Support s = new Support()
			{
				Nombre = nombre,
				Email = email,
				Telefono =phone,
				Tema =tema,
				Mensaje =mensaje,
				Fecha= DateTime.Now
			};
			try
			{
				var dbContet = new cifo_OGSContext();
				dbContet.Add(s);
				dbContet.SaveChanges();
				message = "OK";
			}catch(Exception err)
			{
				message = err.Message;
			}
			return message;
		}
	}
}
