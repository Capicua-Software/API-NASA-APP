using DATA_L.Models.Users;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DATA_L.User
{
    public class UserD:FirebaseCore
    {
        public async Task<UserModel> GetUserInfo(string Email, string Key)
        {
            OpenFirestoreConnection();

            UserModel model = new UserModel();

            docRef = db.Collection("users").Document(Email);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                Dictionary<string, object> user = snapshot.ToDictionary();
                model.Email = (string)user["Email"];
                model.Name = (string)user["Name"];
                model.LastName = (string)user["LastName"];
                model.FaceId = (string)user["FaceId"];
                model.Sign = (string)user["Sign"];

            }

            return model;
        }

    }
}
