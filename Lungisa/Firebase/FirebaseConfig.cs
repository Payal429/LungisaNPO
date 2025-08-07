using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;

namespace Lungisa.Firebase
{
    public static class FirebaseConfig
    {
        public static void InitializeFirebase()
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(AppDomain.CurrentDomain.BaseDirectory + "App_Data/lungisa-firebase-key.json")
                });
            }
        }
    }
}