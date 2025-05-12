using ProjetoModeloDDD.Application.Interfaces._Base;
using ProjetoModeloDDD.Domain.Interfaces.Services._Base;

namespace ProjetoModeloDDD.Application.Services._Base
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        public void Add(TEntity entity)
        {
            _serviceBase.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _serviceBase.Delete(entity);
        }
        public IEnumerable<TEntity> GetAll()
        {
           return _serviceBase.GetAll();
        }


        public TEntity GetByID(int id)
        {
            return _serviceBase.GetByID(id);
        }

        public void Update(TEntity entity)
        {
            _serviceBase.Update(entity);
        }
        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
