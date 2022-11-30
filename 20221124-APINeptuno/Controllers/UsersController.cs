using _20221124_APINeptuno.Dal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace _20221124_APINeptuno.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public  User Login(string login,string password)
        {
            User user = null;
            var dbContext = new cifo_OGSContext();
            try
            {
                //password = GetMD5(password);
                user=dbContext.Users.Single(u=> u.Login==login&&u.Password==password);
                
            }
            catch { }

            return user;
        }
    /*    public static string GetMD5(string str)
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
    */
    }
}
