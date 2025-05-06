using ProjetoModeloDDD.Domain.Interfaces._Base;
using ProjetoModeloDDD.Domain.Interfaces.Services._Base;

namespace ProjetoModeloDDD.Domain.Services._Base
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void Dispose()
        {
           _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _repository.GetAll();
        }

        public TEntity GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
