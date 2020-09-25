using InteliSystem.DbConnection;
using InteliSystem.Domain.Management.Pessoas;
using InteliSystem.Domain.Management.Pessoas.Repository;
using InteliSystem.Util.Enums;

namespace InteliSystem.Repository.Management.Pessoas
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly IConnection _conexao;
        public PessoaRepositorio(IConnection conexao)
        {
            this._conexao = conexao;
        }

        public void Add(Pessoa pessoa)
        {
            var sSql = $"Insert into Pessoa (Id, PrimeroNome, UltimoNome, Sexo, EstadoCivil, DataNascimento) Valeus (Id, @PrimeroNome, @UltimoNome, @Sexo, @EstadoCivil, @DataNascimento) ";

            var param = new
            {
                Id = pessoa.Id,
                PrimeroNome = pessoa.Nome.PrimeiroNome,
                UltimoNome = pessoa.Nome.UltimoNome,
                Sexo = pessoa.Sexo,
                EstadoCivil = pessoa.EstadoCivil,
                DataNascimento = pessoa.DataNascimento
            };
            this._conexao.Execute(sSql, param);
        }

        public void Update(Pessoa pessoa)
        {
            var sSql = "Update Pessoa Set PrimeiroNome";

            var param = new
            {
                Id = pessoa.Id,
                PrimeroNome = pessoa.Nome.PrimeiroNome,
                UltimoNome = pessoa.Nome.UltimoNome,
                Sexo = pessoa.Sexo,
                EstadoCivil = pessoa.EstadoCivil,
                DataNascimento = pessoa.DataNascimento
            };
            this._conexao.Execute(sSql, param);
        }

        public void Excluir(object id)
        {
            var sSql = "Update Pessoa Set Situacao = @Situacao Where Id = @Id";

            this._conexao.Execute(sSql, new { Id = id, Situacao = Situacao.Excluido });
        }

        public void Dispose()
        {
            _conexao.Dispose();
        }
    }
}