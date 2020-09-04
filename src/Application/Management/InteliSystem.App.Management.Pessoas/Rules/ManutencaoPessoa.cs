using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteliSystem.App.Management.Enderecos;
using InteliSystem.Util.Extentions;
using InteliSystem.Util.Interfaces;

namespace InteliSystem.App.Management.Pessoas
{
    public class ManutencaoPessoa : IManutencaoPessoa
    {
        #region Membros
        private readonly IRepositorioPessoa _repositorio;
        private readonly IManutencaoEndereco _manuEndereco;
        #endregion
        #region Construtores
        public ManutencaoPessoa(IRepositorioPessoa repositorio, IManutencaoEndereco manuEndereco)
        {
            this._repositorio = repositorio;
            this._manuEndereco = manuEndereco;
        }
        #endregion
        public Task Add(Pessoa pessoa)
        {
            if (pessoa == null)
            {
                throw new NullReferenceException("Ops! Favor verificar com seu desenvolvimento");
            }

            var retorno = this._repositorio.Add(pessoa);
            retorno.Wait();
            return Task.Run(() => retorno.Result == 1);
        }

        public void Dispose()
        {
            this._repositorio.Dispose();
        }

        public Task Excluir(object id)
        {
            var retorno = this._repositorio.Excluir(id);
            retorno.Wait();

            return Task.Run(() => retorno.Result == 1);
        }

        public Task<IEnumerable<Pessoa>> GetAll()
        {
            var retorno = this._repositorio.GetAll();
            retorno.Wait();
            retorno.Result.ToList().ForEach(pessoa =>
            {
                if (!pessoa.EnderecoId.IsEmpty()) {
                    var endereco = this._manuEndereco.GetById(pessoa.EnderecoId);
                    endereco.Wait();
                    pessoa.Endereco = endereco.Result;
                }
            });

            return retorno;
        }

        public Task<Pessoa> GetByCpf(string cpf)
        {
            if (cpf.IsEmpty())
            {
                throw new NullReferenceException();
            }

            var retorno = this._repositorio.GetById(cpf);
            retorno.Wait();
            if (!(retorno.Result is Pessoa))
            {
                return Task<Pessoa>.Run(() => new Pessoa());
            }

            return Task<Pessoa>.Run(() => retorno);
        }

        public Task<Pessoa> GetById(object id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }

            var retorno = this._repositorio.GetById(id);
            retorno.Wait();
            if (!(retorno.Result is Pessoa))
            {
                return Task<Pessoa>.Run(() => new Pessoa());
            }

            return Task<Pessoa>.Run(() => retorno);
        }

        public Task Update(Pessoa pessoa)
        {
            var retorno = this._repositorio.Update(pessoa);
            retorno.Wait();

            return Task.Run(() => retorno.Result == 1);
        }
    }
}