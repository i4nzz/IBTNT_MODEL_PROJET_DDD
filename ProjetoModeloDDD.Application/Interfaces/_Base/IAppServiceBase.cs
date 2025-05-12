namespace ProjetoModeloDDD.Application.Interfaces._Base
{
    public interface IAppServiceBase<TEntity> where TEntity : class
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
