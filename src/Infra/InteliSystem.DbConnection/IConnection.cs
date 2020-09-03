using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteliSystem.DbConnection
{
    public interface IConnection : IDisposable
    {
        /// <summary>
        /// Responsável por abrir conexão com a Base de Dados
        /// </summary>
        void Open();
        /// <summary>
        /// Responsável por Fecha a conexão com a base de Dados
        /// </summary>
        void Close();
        /// <summary>
        /// Executa comandos SQL (Insert, Update, Delete)
        /// </summary>
        /// <param name="comando">Instrução Sql</param>
        /// <param name="param">Parametros com os valores a serem persistidos no Banco</param>
        /// <param name="iniciartransacao">Indica se será iniciado uma transação específica</param>
        /// <returns>Quantidade de linhas que foram afetadas</returns>
        int Execute(string comando, object param, bool iniciartransacao = false);
        /// <summary>
        /// Executa comandos SQL (Insert, Update, Delete) de forma Assincrona
        /// </summary>
        /// <param name="comando">Instrução Sql</param>
        /// <param name="param">Parametros com os valores a serem persistidos no Banco</param>
        /// <param name="iniciartransacao">Indica se será iniciado uma transação específica</param>
        /// <returns>Quantidade de linhas que foram afetadas</returns>
        Task<int> ExecuteAsync(string comando, object param = null, bool iniciartransacao = false);
        /// <summary>
        /// Executa consulta Retornando o Tipo do Objeto Genérico informado
        /// </summary>
        /// <param name="comando">Consulta Sql</param>
        /// <param name="param">Parametros com os valores a serem persistidos no Banco</param>
        /// <typeparam name="TObject">Objeto ou Classe</typeparam>
        /// <returns>Objeto do Tipo Genérico devidamente preenchido</returns>
        TObject GetObject<TObject>(string comando, object param = null);
        /// <summary>
        /// Executa consulta Retornando o Tipo do Objeto Genérico informado de forma assincrona
        /// </summary>
        /// <param name="comando">Consulta Sql</param>
        /// <param name="param">Parametros com os valores a serem persistidos no Banco</param>
        /// <typeparam name="TObject">Objeto ou Classe</typeparam>
        /// <returns>Objeto do Tipo Genérico devidamente preenchido</returns>
        Task<TObject> GetObjectAsync<TObject>(string comando, object param = null);
        /// <summary>
        /// Executa consulta Retornando uma Lista do Tipo de Objeto Genérico informado
        /// </summary>
        /// <param name="comando">Consulta Sql</param>
        /// <param name="param">Parametros com os valores a serem persistidos no Banco</param>
        /// <typeparam name="TObject">Objeto ou Classe</typeparam>
        /// <returns>Lista do Tipo Genérico devidamente preenchido</returns>
        IEnumerable<TObject> GetList<TObject>(string comando, object param = null);
        /// <summary>
        /// Executa consulta Retornando uma Lista do Tipo de Objeto Genérico informado
        /// </summary>
        /// <param name="comando">Consulta Sql</param>
        /// <param name="param">Parametros com os valores a serem persistidos no Banco</param>
        /// <typeparam name="TObject">Objeto ou Classe</typeparam>
        /// <returns>Lista do Tipo Genérico devidamente preenchido</returns>
        Task<IEnumerable<TObject>> GetListAsync<TObject>(string comando, object param = null);

    }
}