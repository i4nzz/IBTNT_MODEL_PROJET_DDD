using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Mappers
{
    public static class ProdutoMapper
    {
        // Mapeia de Produto (entidade) para ProdutoViewModel
        public static ProdutoViewModel ToViewModel(Produto produto)
        {
            return new ProdutoViewModel
            {
                ProdutoID = produto.ProdutoID,
                Nome = produto.Nome,
                Valor = produto.Valor,
                Disponivel = produto.Disponivel,
                ClienteID = produto.ClienteID,
                
                Cliente = new ClienteViewModel
                {
                    ClienteID = produto.Cliente.ClienteID,
                    Nome = produto.Cliente.Nome
                } 
            };
        }

        // Mapeia de ProdutoViewModel para Produto (entidade)
        public static Produto ToEntity(ProdutoViewModel viewModel)
        {
            return new Produto
            {
                ProdutoID = viewModel.ProdutoID,
                Nome = viewModel.Nome,
                Valor = viewModel.Valor,
                Disponivel = viewModel.Disponivel,
                ClienteID = viewModel.ClienteID // Não precisamos preencher Cliente diretamente
            };
        }

        // Atualiza os campos de um produto existente (para edição)
        public static void UpdateEntity(ProdutoViewModel viewModel, Produto produto)
        {
            produto.Nome = viewModel.Nome;
            produto.Valor = viewModel.Valor;
            produto.Disponivel = viewModel.Disponivel;
            produto.ClienteID = viewModel.ClienteID;
        }

        //    Cliente = produto.Cliente != null ? new ClienteViewModel
        //            {
        //                ClienteID = produto.Cliente.ClienteID,
        //                Nome = produto.Cliente.Nome
        //} : null // Caso Cliente seja nulo, retorna null

    }
}
