using ProjetoModeloDDD.Application.Interfaces._Base;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interfaces.Services
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
    }
}
