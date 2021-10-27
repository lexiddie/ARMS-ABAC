using System;
using System.Threading.Tasks;
using ARMSAPI.Interfaces;
using ARMSAPI.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace ARMSAPI.Providers
{
    public class FirebaseProvider : IFirebaseProvider
    {
        protected readonly FirebaseClient _firebase;

        public FirebaseProvider()
        {
            _firebase = new FirebaseClient(Path.BaseUrl);
        }

        public void IsComputing()
        {
            _firebase.Child(Path.IsComputing)
                     .PutAsync(true);
        }

        public void IsError(string message)
        {
            _firebase.Child(Path.IsError)
                     .PutAsync(true);

            _firebase.Child(Path.ErrorMessage)
                     .PutAsync(message);

            Finish();
        }

        public void IsProcessing()
        {
            _firebase.Child(Path.IsProcessing)
                     .PutAsync(true);
        }

        public void IsRetrieving()
        {
            _firebase.Child(Path.IsRetrieving)
                     .PutAsync(true);
        }

        public void IsUpdating()
        {
            _firebase.Child(Path.IsUpdating)
                     .PutAsync(true);
        }

        public void Finish()
        {
            var model = new FirebaseViewModel();
            
            _firebase.Child(Path.Assigning)
                     .PutAsync(JsonConvert.SerializeObject(model));
        }
        
        public async Task<Boolean> IsDissolving()
        {
            await _firebase.Child(Path.IsDissolving)
                           .PutAsync(true);

            return true;
        }

        public async Task<Boolean> FinishDissolving()
        {
            await _firebase.Child(Path.IsDissolving)
                           .PutAsync(false);

            return true;
        }

        public void IsAutomate()
        {
            _firebase.Child(Path.IsAutomate)
                     .PutAsync(true);
        }
    }
}