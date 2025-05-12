using Microsoft.Extensions.DependencyInjection;
using ProjetoModeloDDD.Application.Interfaces._Base;
using ProjetoModeloDDD.Application.Interfaces.Services;
using ProjetoModeloDDD.Application.Services;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using ProjetoModeloDDD.Infra.Data.Repositories;
using ProjetoModeloDDD.Application.Interfaces._Base;
using ProjetoModeloDDD.Domain.Services._Base;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using ProjetoModeloDDD.Domain.Services;

namespace ProjetoModeloDDD.IoC
{
    public static class DependencyInjection
    {
            public static void RegisterServices(this IServiceCollection services)
            {
            // Repositorios
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            // Serviços de Domínio
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            // Services de Aplicação
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();


        }
        
    }
}
