using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace DATA_L
{
    public class FirebaseCore
    {
        public static string ApiKey = "AIzaSyC-GHDp3bQ1pqK0dWjl6SXG-Az5G3KL20E";
        public static string Bucket = "nasa-75384.appspot.com";

        public static string SecretKey = "6fcd512cde09ca04a89cc118ee408e6409277d86";
        //public static string BasePath = "https://jobsy-e4cf0-default-rtdb.firebaseio.com/";

        //FIRESTORE
        public static string path = AppDomain.CurrentDomain.BaseDirectory + @"nasa-75384-firebase-adminsdk-so2ym-6fcd512cde.json";
        public static FirestoreDb db;
        public void OpenFirestoreConnection()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            db = FirestoreDb.Create("nasa-75384");
        }

        public static DocumentReference docRef;
    }
}
