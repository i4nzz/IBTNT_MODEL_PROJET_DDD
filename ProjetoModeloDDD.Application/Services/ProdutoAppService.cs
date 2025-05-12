using ProjetoModeloDDD.Application.Interfaces.Services;
using ProjetoModeloDDD.Application.Services._Base;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application.Services
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
            : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<Produto> BuscarProdutos(string nome)
        {
            return _produtoService.BuscarPorNome(nome);
        }

        
    }
}
