using DATA_L.User;
using DATA_L.Models.Users;
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
            }
            else
            {

                return null;
            }

        }

            [HttpPost]
            [Route("RegisterUser")]
            public async Task RegisterUser(UserModel user)
            {

                UserD UserDataL = new UserD();               

                //user.Email = "ramosa@gmail.com";
                //user.Name = "hannah";
                //user.LastName = "ramos";
                //user.Password = "1234567";
                //user.Sign = "Tumbs Up";

                
               await UserDataL.RegisterAsync(user);

             

        }



    }
}
