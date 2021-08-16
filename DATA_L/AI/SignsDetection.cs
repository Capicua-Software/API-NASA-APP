using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using DATA_L.Models;
using System.Text.Json;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net;

namespace DATA_L.AI
{
    public class SignsDetection
    {
        private static string apiUrl = "https://nasaapp-prediction.cognitiveservices.azure.com/customvision/v3.0/Prediction/eedf237b-71eb-4d46-a128-bf813f8687ed/classify/iterations/Iteration3/url";
        public static SignsDetectionModel DetectSign(string imgUrl)
        {
            var responseBody = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers["Prediction-Key"] = "f8dbdff3d79d4ec4b4e7f9eae29c8d5b";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = "{\"Url\":\""+imgUrl+"\"}";
                    streamWriter.Write(json);
                }
                using(WebResponse response = request.GetResponse())
                {
                    using(Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using(StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                        }
                    }
                }

                SignsDetectionModel prediction = JsonConvert.DeserializeObject<SignsDetectionModel>(responseBody);
                return prediction;

            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }

          

        }


    }
}
