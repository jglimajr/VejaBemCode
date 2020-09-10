using System.Threading.Tasks;
using InteliSystem.App.Management.Logins.Exceptions;
using InteliSystem.App.Management.Secoes;
using InteliSystem.App.Management.Usuarios;
using InteliSystem.Util.Extentions;

namespace InteliSystem.App.Management.Logins.Rules
{
    public class ManutencaoLogin : IManutencaoLogin
    {
        private readonly IManutencaoSecao _manuSecao;
        private readonly IManutencaoUsuario _manuUsuario;
        public ManutencaoLogin(IManutencaoSecao manutencaoSecao, IManutencaoUsuario manuUsuario)
        {
            this._manuSecao = manutencaoSecao;
            this._manuUsuario = manuUsuario;
        }

        public Task<Login> GetLogin(string username, string password)
        {
            if (username.IsEmpty() || password.IsEmpty())
            {
                throw new LoginException("Usuário e/ou Senha não Informado(s)");
            }
            var usuarioAsync = this._manuUsuario.GetByPassWord(username: username, password: password);
            usuarioAsync.Wait();
            var usuario = usuarioAsync.Result;
            if (usuario == null)
            {
                throw new LoginException();
            }
            var secao = new Secao(){
                Usuario = usuario,
                UsuarioId = usuario.Id,
                Browser = "",
                Ip = "",
                SistemaOperacional = "",
            };
            this._manuSecao.Add(secao);
            var secaoAsync = this._manuSecao.GetById(secao.Id);
            secaoAsync.Wait();
            secao = secaoAsync.Result;
            Login login = new Login(){
                Id = secao.Id,
                Usuario
            }
        }
    }
}