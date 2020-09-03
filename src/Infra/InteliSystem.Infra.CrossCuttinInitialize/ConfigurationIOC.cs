
using Autofac;
using InteliSystem.DbConnection;
using InteliSystem.App.General.Pessoas;
using InteliSystem.App.General.Usuarios;
using InteliSystem.App.General.Enderecos;

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
           #endregion
           
           #region Repositories
            builder.RegisterType<RepositorioPessoa>().As<IRepositorioPessoa>();
            builder.RegisterType<RepositorioUsuario>().As<RepositorioUsuario>();
            builder.RegisterType<RepositorioEndereco>().As<RepositorioEndereco>();
           #endregion
        }
    }
}