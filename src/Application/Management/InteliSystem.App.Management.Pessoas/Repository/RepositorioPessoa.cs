using InteliSystem.DbConnection;
using InteliSystem.Util.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace InteliSystem.App.Management.Pessoas
{
    public class RepositorioPessoa : IRepositorioPessoa
    {
        #region Membros
        private readonly IConnection _conn;
        private const string SelectBase = "Select Id, EnderecoId, Cpf, Nome, NomeCurto, DataNascimento, Sexo, EstadoCivil, DataHoraCadastro, DataHoraAlteracao, Situacao From Pessoa";
        #endregion
        internal RepositorioPessoa(IConnection conn)
        {
            this._conn = conn;
        }

        public void Dispose()
        {
            this._conn.Dispose();
        }

        public Task<int> Add(Pessoa pessoa)
        {
            var sSql = "Insert Into Pessoa (Id, EnderecoId, Cpf, Nome, NomeCurto, DataNascimento, Sexo, EstadoCivil, DataHoraCadastro) " +
					  "Values(@Id, @EnderecoId, @Cpf, @Nome, @NomeCurto, @DataNascimento, @Sexo, @EstadoCivil, @DataHoraCadastro)";
			var param = new {
				Id = pessoa.Id,
				EnderecoId = pessoa.EnderecoId,
				Cpf = pessoa.Cpf,
				Nome = pessoa.Nome,
				NomeCurto = pessoa.NomeCurto,
				DataNascimento = pessoa.DataNascimento,
				Sexo = pessoa.Sexo,
				EstadoCivil = pessoa.EstadoCivil,
				DataHoraCadastro = pessoa.DataHoraCadastro
			};
			var retorno = this._conn.ExecuteAsync(sSql, param);
			return retorno;
        }

        public Task<int> Update(Pessoa pessoa)
        {
            var sSql = "Update Pessoa Set EnderecoId = @EnderecoId, Cpf = @Cpf, Nome = @Nome, NomeCurto = @NomeCurto, DataNascimento = @DataNascimento, Sexo = @Sexo, EstadoCivil = @EstadoCivil, DataHoraAlteracao = @DataHoraAlteracao \n" +
						"Where Id = @Id";
			var param = new {
				Id = pessoa.Id,
				EnderecoId = pessoa.EnderecoId,
				Cpf = pessoa.Cpf,
				Nome = pessoa.Nome,
				NomeCurto = pessoa.NomeCurto,
				DataNascimento = pessoa.DataNascimento,
				Sexo = pessoa.Sexo,
				EstadoCivil = pessoa.EstadoCivil,
				DataHoraAlteracao = DateTime.Now
			};

            var retorno = this._conn.ExecuteAsync(sSql, param: param);
            return retorno;
        }

        public Task<int> Excluir(object id)
        {
            var sSql = "Update Pessoa Set Situacao = @Situacao Where Id = @Id";
			var param = new {
				Id = id,
                Situacao = Situacao.Excluido
			};

			var retorno = this._conn.ExecuteAsync(sSql, param);
			return retorno;
        }

        public Task<IEnumerable<Pessoa>> GetAll()
        {
            var sSql = $"{SelectBase}";
            var retorno = this._conn.GetListAsync<Pessoa>(comando: sSql);
            return retorno;
        }

        public Task<Pessoa> GetById(object id)
        {
            var sSql = $"{SelectBase} Where Id = @Id";
            var param = new {
                Id = id
            };

            var retorno = this._conn.GetObjectAsync<Pessoa>(comando: sSql, param: param);
            return retorno;
        }

        public Task<Pessoa> GetByCpf(string cpf)
        {
            var sSql = $"{SelectBase} Where Cpf = @Cpf";
            var param = new {
                Cpf = cpf
            };

            var retorno = this._conn.GetObjectAsync<Pessoa>(comando: sSql, param: param);
            return retorno;
        }
    }
}