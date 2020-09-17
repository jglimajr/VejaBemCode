
using Autofac;
using InteliSystem.DbConnection;
using InteliSystem.App.Management.Pessoas;
using InteliSystem.App.Management.Usuarios;
using InteliSystem.App.Management.Enderecos;
using InteliSystem.App.Management.Logins;
using InteliSystem.App.Management.Secoes;

namespace InteliSystem.Infra.CrossCuttinInitialize
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
           #region Conexão
            builder.RegisterType<Connection>().As<IConnection>();
           #endregion
           #region Rules
            builder.RegisterType<ManutencaoPessoa>().As<IManutencaoPessoa>();
            builder.RegisterType<ManutencaoUsuario>().As<IManutencaoUsuario>();
            builder.RegisterType<ManutencaoEndereco>().As<IManutencaoEndereco>();
            builder.RegisterType<ManutencaoSecao>().As<IManutencaoSecao>();
            builder.RegisterType<ManutencaoLogin>().As<IManutencaoLogin>();
           #endregion
           
           #region Repositories
            builder.RegisterType<RepositorioPessoa>().As<IRepositorioPessoa>();
            builder.RegisterType<RepositorioUsuario>().As<IRepositorioUsuario>();
            builder.RegisterType<RepositorioEndereco>().As<IRepositorioEndereco>();
            builder.RegisterType<RepositorioSecao>().As<IRepositorioSecao>();
           #endregion
        }
    }
}