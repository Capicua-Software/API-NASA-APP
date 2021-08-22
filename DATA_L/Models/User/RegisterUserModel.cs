using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA_L.Models.User
{
    [BindProperties]
    public class RegisterUserModel
    {
        public string Email { get; set; }
        public string FaceId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Sign { get; set; }
        public string Password { get; set; }

    }
}
