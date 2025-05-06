namespace ProjetoModeloDDD.Domain.Interfaces.Services._Base
{
    public interface IServiceBase<TEntity> where TEntity : class
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
