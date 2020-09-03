using System;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteliSystem.DbConnection
{
    public class Connection : IConnection, IDisposable
    {
        #region Membros
        private readonly IDbConnection _conn;
        private IDbTransaction _trans;
        #endregion
        #region Constutores
        public Connection()
        {
            _conn = new MySql.Data.MySqlClient.MySqlConnection("Server=localhost;Port=3307;Database=dbgerencial;Uid=root;Pwd=29532561;Pooling=True;Connection Timeout=3600;default command timeout=3600;");
        }
        #endregion
        public void Open()
        {
            if (this._conn.State == ConnectionState.Open)
            {
                return;
            }
            this._conn.Open();
        }

        public Connection Requires()
        {
            return this;
        }
        public void Close()
        {
            if (this._conn.State == ConnectionState.Closed)
            {
                return;
            }
            if (this._trans != null)
            {
                this._trans.Commit();
                this._trans = null;
            }
            this._conn.Close();
        }

        public int Execute(string comando, object param, bool iniciartransacao = false)
        {
            if (iniciartransacao)
            {
                this._trans = this._conn.BeginTransaction();
            }

            return this._conn.Execute(sql: comando, param: param, transaction: _trans);
        }

        public Task<int> ExecuteAsync(string comando, object param = null, bool iniciartransacao = false)
        {
            if (iniciartransacao)
            {
                this._trans = this._conn.BeginTransaction();
            }

            return this._conn.ExecuteAsync(sql: comando, param: param, transaction: _trans);
        }

        public IEnumerable<TObject> GetList<TObject>(string comando, object param = null)
        {
            var retorno = this._conn.Query<TObject>(sql: comando, param: param);
            return retorno;
        }

        public Task<IEnumerable<TObject>> GetListAsync<TObject>(string comando, object param = null)
        {
            var retorno = this._conn.QueryAsync<TObject>(sql: comando, param: param);
            return retorno;
        }

        public TObject GetObject<TObject>(string comando, object param = null)
        {
            var retorno = this._conn.QueryFirstOrDefault<TObject>(sql: comando, param: param);
            return retorno;
        }

        public Task<TObject> GetObjectAsync<TObject>(string comando, object param = null)
        {
            var retorno = this._conn.QueryFirstOrDefaultAsync<TObject>(sql: comando, param: param);
            return retorno;
        }

        public void Dispose()
        {
            this.Close();
            this._conn.Dispose();
        }
    }
}