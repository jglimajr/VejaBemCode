using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteliSystem.App.General.Enderecos
{
    public class RepositorioEndereco : IRepositorioEndereco
    {
        public Task<int> Add(Endereco obj)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Excluir(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Endereco>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Endereco> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Endereco obj)
        {
            throw new System.NotImplementedException();
        }
    }
}