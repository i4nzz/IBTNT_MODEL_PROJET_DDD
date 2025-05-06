using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces._Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        // APENAS C.R.U.D
        void Add(TEntity entity);
        TEntity GetByID(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Dispose();
    }
}
