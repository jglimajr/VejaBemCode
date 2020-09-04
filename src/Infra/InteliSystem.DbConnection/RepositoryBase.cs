using System;

namespace InteliSystem.DbConnection
{
    public abstract class RepositoryBase : IDisposable
    {
        #region Membros
        private readonly IConnection _conn;
        #endregion
        public RepositoryBase(IConnection conn)
        {
            this._conn = conn;
        }

        public void Dispose()
        {
            this._conn.Dispose();
        }
    }
}