using ProjetoModeloDDD.Application.Interfaces._Base;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interfaces.Services
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarProdutos(string nome);
    }
}
