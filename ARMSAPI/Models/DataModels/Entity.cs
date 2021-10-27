using System;

namespace ARMSAPI.Models.DataModels
{
    public abstract class Entity
    {
        public virtual void OnBeforeInsert(string by) { }
        public virtual void OnBeforeUpdate(string by) { }
    }
}
