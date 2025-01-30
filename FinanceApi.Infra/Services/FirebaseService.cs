using FinanceApi.Domain.Shared.Interfaces;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Infra.Services
{
    public class FirebaseService : IFirebase
    {
        public FirebaseService()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("secrets/firebase-adminsdk.json")
            });
        }


        public async Task<string> VerifyGoogleTokenAsync(string idToken)
        {
            try
            {
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
                string uid = decodedToken.Uid;
                return uid;
            }
            catch (Exception ex)
            {                Console.WriteLine($"Erro ao verificar o token: {ex.Message}");
                return null;
            }
        }
    }  
}
