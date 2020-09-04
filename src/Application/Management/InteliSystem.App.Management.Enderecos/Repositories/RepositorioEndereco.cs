using System.Collections.Generic;
using System.Threading.Tasks;
using InteliSystem.DbConnection;

namespace InteliSystem.App.Management.Enderecos
{
    public class RepositorioEndereco : RepositoryBase, IRepositorioEndereco
    {
        private readonly IConnection _conn;
        private const string SelectBase = "Select Id, Nome, Logradouro, Numero, Complemento, Bairro, " +
                                            "Cidade, Uf, Cep, Situacao, DataHoraCadastro, DataHoraAlteracao, Hash From Endereco";
        public RepositorioEndereco(IConnection conn) : base(conn)
        {
            this._conn = conn;
        }

        public Task<int> Add(Endereco obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Excluir(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Endereco>> GetAll()
        {
            var sSql = $"{SelectBase}";
            var retorno = this._conn.GetListAsync<Endereco>(comando: sSql);

            return retorno;
        }

        public Task<Endereco> GetById(object id)
        {
            var sSql = $"{SelectBase} Where Id = @Id";
            var retorno = this._conn.GetObjectAsync<Endereco>(comando: sSql, param: new { Id = id });

            return retorno;
        }

        public Task<int> Update(Endereco obj)
        {
            throw new System.NotImplementedException();
        }
    }
}