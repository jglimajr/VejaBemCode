using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InteliSystem.DbConnection;

namespace InteliSystem.App.Management.Secoes
{
    public class RepositorioSecao : RepositoryBase, IRepositorioSecao
    {
        private readonly IConnection _conn;
        private const string SelectBase = "Select Se.Id, Se.UsuarioId, Se.DataHoraAcesso, Se.DataHoraUltimoAcesso, Se.Ip, Se.Browser, Se.SistemaOperacaional, Se.Situacao, Se.Hash From Sesao Se";
        public RepositorioSecao(IConnection conn)
            : base(conn)
        {
            this._conn = conn;
        }

        public Task<int> Add(Secao secao)
        {
            var sSql = "Insert Into Secao (Id, UsuarioId, DataHoraAcesso, DataHoraUltimoAcesso, Ip, Browser, SistemaOperacaional, Situacao, Hash) Values (" +
                        "@Id, @UsuarioId, @DataHoraAcesso, @DataHoraUltimoAcesso, @Ip, @Browser, @SistemaOperacaional, @Situacao, @Hash)";
            var param = new
            {
                Id = secao.Id,
                UsuarioId = secao.Usuario.Id,
                DataHoraAcesso = secao.DataHoraAcesso,
                DataHoraUltimoAcesso = secao.DataHoraUltimoAcesso,
                Ip = secao.Ip,
                Browser = secao.Browser,
                SistemaOperacaional = secao.SistemaOperacional,
                Situacao = secao.Situacao,
                Hash = secao.Hash
            };

            var retorno = this._conn.ExecuteAsync(comando: sSql, param: param);
            return retorno;
        }
        public Task<int> AddHis(Secao secao)
        {
            var sSql = "Insert Into Secao (Id, UsuarioId, DataHoraAcesso, Ip, Browser, SistemaOperacaional, Situacao, Hash) Values (" +
                        "@Id, @UsuarioId, @DataHoraAcesso, @Ip, @Browser, @SistemaOperacaional, @Situacao, @Hash)";
            var param = new
            {
                Id = secao.Id,
                UsuarioId = secao.Usuario.Id,
                DataHoraAcesso = secao.DataHoraAcesso,
                Ip = secao.Ip,
                Browser = secao.Browser,
                SistemaOperacaional = secao.SistemaOperacional,
                Situacao = secao.Situacao,
                Hash = secao.Hash
            };

            var retorno = this._conn.ExecuteAsync(comando: sSql, param: param);
            return retorno;
        }
        [Obsolete]
        public Task<int> Update(Secao secao)
        {
            throw new System.NotImplementedException();
        }
        public Task<int> Excluir(object id)
        {
            var sSql = "Delete From Secao Where Id = @Id";
            var retorno = this._conn.ExecuteAsync(comando: sSql, new { Id = id });
            return retorno;
        }
        public Task<IEnumerable<Secao>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Secao> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Secao> GetByUsuario(string username)
        {
            var sSq = $"{SelectBase} Inner Join Usuario Us On Us.Id = Se.UsuarioId Where Se.UserName = @UserName";
            var retorno = this._conn.GetObjectAsync<Secao>(comando: sSq, param: new { UserName = username });

            return retorno;
        }

        public bool Exists(string id)
        {
            // var sSql = "Select Coalesce((Select 1 From Secao Where Id = @Id), 0)";
            // var retorno = 
            throw new System.NotImplementedException();
        }
    }
}