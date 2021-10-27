using System;
using System.Threading.Tasks;

namespace ARMSAPI.Interfaces
{
    public interface IFirebaseProvider
    {
        void IsComputing();
        void IsError(string message);
        void IsProcessing();
        void IsRetrieving();
        void IsUpdating();
        void Finish();
        Task<Boolean> IsDissolving();
        Task<Boolean> FinishDissolving();
        void IsAutomate();
    }
}