using System.Collections.Generic;
using System.Threading.Tasks;
using InteliSystem.App.Management.Pessoas;
using InteliSystem.Util.Extentions;

namespace InteliSystem.App.Management.Usuarios
{
    public class ManutencaoUsuario : Usuario, IManutencaoUsuario
    {
        private readonly IRepositorioUsuario _repositorio;
        private readonly IManutencaoPessoa _manutencaoPessoa;

        public ManutencaoUsuario(IRepositorioUsuario repositorio, IManutencaoPessoa manutencao)
        {
            this._repositorio = repositorio;
            this._manutencaoPessoa = manutencao;
        }
        public void Dispose()
        {
            this._repositorio.Dispose();
            this._manutencaoPessoa.Dispose();
        }
        public Task Add(Usuario usuario)
        {
            if (usuario == null){
                throw new UsuarioNotFoundException();
            }
            if (usuario.Pessoa != null){
                this._manutencaoPessoa.Add(usuario.Pessoa);
            }
            usuario.ToUpper();
            var retorno = this._repositorio.Add(usuario);
            return Task.Run(() => retorno.Result == 1);
        }
        public Task Update(Usuario usuario)
        {
            if (usuario == null){
                throw new UsuarioNotFoundException();
            }
            if (usuario.Pessoa != null){
                try{
                    this._manutencaoPessoa.Add(usuario.Pessoa);
                } catch {
                    this._manutencaoPessoa.Update(usuario.Pessoa);
                }
            }
            usuario.ToUpper();
            var retorno = this._repositorio.Update(usuario);
            return Task.Run(() => retorno.Result == 1);
        }
        public Task Excluir(object id)
        {
            if (id == null){
                throw new UsuarioNotFoundException();
            }
            var retorno = this._repositorio.Excluir(id);
            return Task.Run(() => retorno.Result == 1);
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Usuario> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Usuario> GetByPassWord(string username, string password)
        {
            if (username.IsEmpty() || password.IsEmpty()){
                throw new UsuarioException("Usuário e/ou Senha não informado(s)");
            }

            return this._repositorio.GetByPassWordAsync(username, password);
        } 
    }
}