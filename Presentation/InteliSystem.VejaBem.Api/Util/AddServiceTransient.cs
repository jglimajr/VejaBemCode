using System.Runtime.CompilerServices;
using InteliSystem.App.Management.Enderecos;
using InteliSystem.App.Management.Logins;
using InteliSystem.App.Management.Pessoas;
using InteliSystem.App.Management.Secoes;
using InteliSystem.App.Management.Usuarios;
using InteliSystem.DbConnection;
using Microsoft.Extensions.DependencyInjection;

namespace InteliSystem.VejaBem.Api.Util
{
    public static class AddServiceTransient
    {
        public static void AddTransients(this IServiceCollection services)
        {
            services.AddScoped<IConnection, Connection>();
            //Manutencao
            services.AddTransient<IManutencaoPessoa, ManutencaoPessoa>();
            services.AddTransient<IManutencaoEndereco, ManutencaoEndereco>();
            services.AddTransient<IManutencaoUsuario, ManutencaoUsuario>();
            services.AddTransient<IManutencaoLogin, ManutencaoLogin>();
            services.AddTransient<IManutencaoSecao, ManutencaoSecao>();
            //
            //Repositorio
            services.AddTransient<IRepositorioPessoa, RepositorioPessoa>();
            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
            services.AddTransient<IRepositorioEndereco, RepositorioEndereco>();
            services.AddTransient<IRepositorioSecao, RepositorioSecao>();
        }
    }
}