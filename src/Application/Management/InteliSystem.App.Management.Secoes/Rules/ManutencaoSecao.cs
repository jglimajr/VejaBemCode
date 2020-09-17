using System.Collections.Generic;
using System.Threading.Tasks;
using InteliSystem.App.Management.Secoes.Exceptions;
using InteliSystem.Util.Extentions;

namespace InteliSystem.App.Management.Secoes
{
    public class ManutencaoSecao : IManutencaoSecao
    {
        private readonly IRepositorioSecao _repositorio;

        public ManutencaoSecao(IRepositorioSecao repositorio)
        {
            this._repositorio = repositorio;   
        }

        public void Dispose()
        {
            this._repositorio.Dispose();
        }
        public Task Add(Secao secao)
        {
            if (secao == null)
            {
                throw new SecaoNotFoundException();
            }

            var secaoasync = this._repositorio.GetByUsuario(secao.UsuarioId);
            secaoasync.Wait();
            var secaoAux = secaoasync.Result;
            if (secaoAux != null)
            {
                this._repositorio.AddHis(secaoAux);
                this._repositorio.Excluir(secaoAux.Id);
            }

            secao.ToUpper();
            return this._repositorio.Add(secao);
        }

        public Task Excluir(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Secao>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Secao> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Secao secao)
        {
            throw new System.NotImplementedException();
        }
    }
}