using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteliSystem.App.General.Secoes.Rules
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
            throw new System.NotImplementedException();
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