// <snippet_using>
using DATA_L.Models.Face;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;



namespace DATA_L.AI
{
    public class FaceDetection
    {

        public async Task<FaceVerifyModel> VerifyFace(string imgUrl1, string imgUrl2)
        {
            string apiUrl = "https://southcentralus.api.cognitive.microsoft.com/face/v1.0/verify";

            var getFaceId1 = await GetFaceId(imgUrl1);
            var getFaceId2 = await GetFaceId(imgUrl2);

            string faceId1 = getFaceId1[0].faceId.ToString();
            string faceId2 = getFaceId2[0].faceId.ToString();

            //string faceId1 = "b0d166e3-cc66-416a-abe2-29652b48b08c";
            //string faceId2 = "83ca7f48-9ec9-4146-b682-bfa34c313c4a";

            var responseBody = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers["Ocp-Apim-Subscription-Key"] = "ef3582a267e94c7eafbd1faf260f12b4";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = "{\"faceId1\":\"" +faceId1+"\",\"faceId2\":\""+faceId2+"\"}";
                    streamWriter.Write(json);
                }
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                        }
                    }
                }

                FaceVerifyModel prediction = JsonConvert.DeserializeObject<FaceVerifyModel>(responseBody);
                return prediction;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }



        }


        public async Task<List<FaceIdModel>> GetFaceId(string imgUrl)
        {
            string apiUrl = "https://southcentralus.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false&recognitionModel=recognition_04&returnRecognitionModel=false&detectionModel=detection_03&faceIdTimeToLive=86400";

            var responseBody = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers["Ocp-Apim-Subscription-Key"] = "ef3582a267e94c7eafbd1faf260f12b4";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = "{\"url\":\"" + imgUrl + "\"}";
                    streamWriter.Write(json);
                }
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                        }
                    }
                }

                List<FaceIdModel> prediction = JsonConvert.DeserializeObject<List<FaceIdModel>>(responseBody);
                return prediction;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }

            
        }

    }
}
