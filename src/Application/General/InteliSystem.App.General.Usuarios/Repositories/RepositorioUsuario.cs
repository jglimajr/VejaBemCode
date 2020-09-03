using System.Collections.Generic;
using System.Threading.Tasks;
using InteliSystem.DbConnection;

namespace InteliSystem.App.General.Usuarios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        #region Membros
        private readonly IConnection _conn;
        private const string SelectBase = "Select Id, PessoaId, UserName, PassWord, SenhaProvisoria, Email, AcessoErro, SocialToken, DataHoraCadastro, DataHoraAlteracao, Situacao From Usuario";
        #endregion
        #region Construtores
        public RepositorioUsuario(IConnection conn)
        {
            this._conn = conn;
        }
        #endregion
        public void Dispose()
        {
            this._conn.Dispose();
        }
        public Task<int> Add(Usuario usuario)
        {
            var sSql = @"Insert into Usuario(Id, PessoaId, UserName, PassWord, SenhaProvisoria, Email, AcessoErro, SocialToken, DataHoraCadastro, Situacao) Values (" +
                        "@Id, @PessoaId, @UserName, @PassWord, @SenhaProvisoria, @EMail, @AcessoErro, @SocialToken, @DataHoraCadastro, @Situacao)";
            
            var param = new {
                Id = usuario.Id, 
                PessoaId = usuario.PessoaId, 
                UserName = usuario.UserName, 
                PassWord = usuario.PassWord, 
                SenhaProvisoria = usuario.SenhaProvisoria, 
                EMail = usuario.Email, 
                AcessoErro = usuario.AcessoErro, 
                SocialToken = usuario.SocialToken, 
                DataHoraCadastro = usuario.DataHoraCadastro,
                Situacao = usuario.Situacao
            };

            var retorno = this._conn.ExecuteAsync(comando: sSql, param: param);
            return retorno;
        }
        public Task<int> Update(Usuario usuario)
        {
            var sSql = @"Update Usuario Set UserName = @UserName, PassWord = @PassWord, EMail = @EMail, SocialToken = @SocialToken, " +
                        "DataHoraAlteracao = @DataHoraAlteracao, Situacao = @Situacao Where Id = @Id";
            
            var param = new {
                Id = usuario.Id, 
                UserName = usuario.UserName, 
                PassWord = usuario.PassWord, 
                EMail = usuario.Email, 
                SocialToken = usuario.SocialToken, 
                DataHoraAlteracao = usuario.DataHoraAlteracao,
                Situacao = usuario.Situacao
            };

            var retorno = this._conn.ExecuteAsync(comando: sSql, param: param);
            return retorno;
        }
        public Task<int> Excluir(object id)
        {
            var sSql = "Delete From Usuario Where Id = @Id";
            var param = new { Id = id };

            var retorno = this._conn.ExecuteAsync(comando: sSql, param: param);
            return retorno;
        }
        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new System.NotImplementedException();
        }
        public Task<Usuario> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Usuario> GetByPassWordAsync(string username, string password)
        {
            var sSql = $"{SelectBase} Where UserName = @UserName And PassWord = PassWord";
            var param = new {
                UserName = username,
                PassWord = password
            };

            var retorno = this._conn.GetObjectAsync<Usuario>(comando: sSql, param: param);
            return retorno;
        }
    }
}