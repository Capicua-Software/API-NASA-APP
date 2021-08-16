using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DATA_L.AI;
using Newtonsoft.Json;

namespace api_nasa_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {
        private SignsDetection dataL = new SignsDetection();

        [HttpPost]
        public async Task<ContentResult> DetectSign(string imgUrl)
        {
            var data = await dataL.DetectSign(imgUrl);

            string JsonData = JsonConvert.SerializeObject(data);

            JsonData.Replace(@"\", " ");

            return new ContentResult { Content = JsonData, ContentType = "application/json" };

        }
    }
}
