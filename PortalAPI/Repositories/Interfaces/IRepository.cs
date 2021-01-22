using System;
using System.Collections.Generic;

namespace PortalAPI.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        void Register(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
