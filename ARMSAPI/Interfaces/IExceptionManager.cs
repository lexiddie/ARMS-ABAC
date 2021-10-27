using System;
namespace ARMSAPI.Interfaces
{
    public interface IExceptionManager
    {
        bool IsDuplicatedEntityCode(Exception e);
    }
}