using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Auth;
using Google.Cloud.Firestore;

namespace DATA_L.Models.Users
{
    public class UserModel
    {
        public string Email { get; set; }
        public string FaceId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Sign { get; set; }

        public FirebaseAuthProvider auth { get; set; }
        public FirebaseAuthLink a { get; set; }



    }
}
