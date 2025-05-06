using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Infra.Data.Context;
using ProjetoModeloDDD.Infra.Data.Repositories._Base;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProjetoModeloContext context)
            : base(context)
        {

        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _context.Produtos.Where(p => p.Nome == nome);
        }
    }
}
