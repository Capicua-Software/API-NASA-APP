using DATA_L.Models.Users;
using Firebase.Auth;

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


        public async Task RegisterAsync(UserModel model)
        {
            model.auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            model.a = await model.auth.CreateUserWithEmailAndPasswordAsync(model.Email, model.Password, model.Name, true);
            await SendUserInfoToFirestore(model);
            //return model;
        }


        public async Task SendUserInfoToFirestore(UserModel model)  // Metodo para guardar un empleo en Firestore
        {
          
            try
            {
                OpenFirestoreConnection(); // Establece la conexión
                docRef = db.Collection("users").Document(model.Email); // Creamos el documento para obtener el id


                Dictionary<string, object> user = new Dictionary<string, object> //Diccionario de datos con los campos y sus respectivos valores
                {
                { "Email", model.Email },
                { "FaceId", model.FaceId },
                { "Name", model.Name },
                { "LastName", model.LastName },
                { "Sign", model.Sign },
                };


                await docRef.SetAsync(user); // Guardar en la colección de Jobs el diccionario

             
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message); // En caso de una excepción imprime más información en la consola
             
                throw;
            }

        }

    }
}
