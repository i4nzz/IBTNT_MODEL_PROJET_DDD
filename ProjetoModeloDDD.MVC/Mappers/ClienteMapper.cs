using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Mappers
{
    public static class ClienteMapper
    {
        public static ClienteViewModel ToViewModel(Cliente cliente)
        {
            return new ClienteViewModel
            {
                ClienteID = cliente.ClienteID,
                Nome = cliente.Nome,
                Sobrenome = cliente.Sobrenome,  
                Email = cliente.Email,
                Ativo = cliente.Ativo,
                DataCadastro = cliente.DataCadastro
            };
        }

        public static Cliente ToEntity(ClienteViewModel viewModel)
        {
            return new Cliente
            {
                Nome = viewModel.Nome,
                Sobrenome = viewModel.Sobrenome,
                Email = viewModel.Email,
                DataCadastro = DateTime.Now,
                Ativo = viewModel.Ativo
            };
        }
    }
}
