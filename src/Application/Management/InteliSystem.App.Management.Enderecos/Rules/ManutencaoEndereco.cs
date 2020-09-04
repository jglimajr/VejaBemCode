using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteliSystem.App.Management.Enderecos
{
    public class ManutencaoEndereco : IManutencaoEndereco
    {
        private readonly IRepositorioEndereco _repositorio;
        public ManutencaoEndereco(IRepositorioEndereco repositorio)
        {
            this._repositorio = repositorio;
        }
        public Task Add(Endereco obj)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            this._repositorio.Dispose();
        }

        public Task Excluir(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Endereco>> GetAll()
        {
            return this._repositorio.GetAll();
        }

        public Task<Endereco> GetById(object id)
        {
            var retorno = this._repositorio.GetById(id);
            return retorno;
        }

        public Task Update(Endereco obj)
        {
            throw new System.NotImplementedException();
        }
    }
}