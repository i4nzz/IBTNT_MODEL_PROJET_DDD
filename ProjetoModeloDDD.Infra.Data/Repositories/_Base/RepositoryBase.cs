using ProjetoModeloDDD.Domain.Interfaces._Base;
using ProjetoModeloDDD.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ProjetoModeloDDD.Infra.Data.Repositories._Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ProjetoModeloContext _context;

        public RepositoryBase(ProjetoModeloContext context)
        {
            _context = context;
        }

        //public void Add(TEntity entity)
        //{
        //    _context.Set<TEntity>().Add(entity);
        //    _context.SaveChanges();
        //}

        public void Add(TEntity entity)
        {
            Console.WriteLine("Adicionando entidade...");
            _context.Set<TEntity>().Add(entity);
            int result = _context.SaveChanges();
            Console.WriteLine($"Resultado do SaveChanges: {result}");
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        //public TEntity GetByID(int id)
        //{
        //    return _context.Set<TEntity>().Find(id);
        //}

        public TEntity GetByID(int id)
        {
            return _context.Set<TEntity>().FirstOrDefault(e => EF.Property<int>(e, "ClienteID") == id);
        }

        //public TEntity GetByID(int id)
        //{
        //    var keyName = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties
        //                    .Select(x => x.Name).FirstOrDefault();

        //    return _context.Set<TEntity>().FirstOrDefault(e => EF.Property<int>(e, keyName) == id);
        //}



        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //public void Update(TEntity entity)
        //{
        //    var entry = _context.Entry(entity);
        //    if (entry.State == EntityState.Detached)
        //    {
        //        _context.Set<TEntity>().Attach(entity);
        //    }

        //    entry.State = EntityState.Modified;
        //    _context.SaveChanges();
        //}

    }
}
