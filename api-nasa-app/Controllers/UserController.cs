using DATA_L.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_nasa_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        [HttpPost]
        public async Task<ContentResult> GetUserInfo(string Email, string key)
        {
            if (key == "amc")
            {
                UserD UserDataL = new UserD();
                var data = await UserDataL.GetUserInfo(Email, key);

                string JsonData = JsonConvert.SerializeObject(data);

                JsonData.Replace(@"\", " ");

                return new ContentResult { Content = JsonData, ContentType = "application/json" };
            } else {

                return null;
            }
        }



    }
}
