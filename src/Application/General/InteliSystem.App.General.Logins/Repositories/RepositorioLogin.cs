using System.Collections.Generic;
using System.Threading.Tasks;
using InteliSystem.DbConnection;

namespace InteliSystem.App.General.Logins.Repositories
{
    public class RepositorioLogin : RepositoryBase, IRepositorioLogin
    {
        private readonly IConnection _conn;
        public RepositorioLogin(IConnection conn) : base(conn)
        {
            this._conn = conn;
        }

        public Task<int> Add(Login login)
        {
            throw new System.NotImplementedException();
        }
        public Task<int> Update(Login login)
        {
            throw new System.NotImplementedException();
        }
        public Task<int> Excluir(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Login>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Login> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Login> GetByUsuario(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}