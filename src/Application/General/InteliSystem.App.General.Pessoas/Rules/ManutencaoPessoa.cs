using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InteliSystem.Util.Extentions;
using InteliSystem.Util.Interfaces;

namespace InteliSystem.App.General.Pessoas
{
    public class ManutencaoPessoa : IManutencaoPessoa
    {
        #region Membros
        private readonly IRepositorioPessoa _repositorio;
        #endregion
        #region Construtores
        public ManutencaoPessoa(IRepositorioPessoa repositorio)
        {
            this._repositorio = repositorio;
        }
        #endregion
        public Task Add(Pessoa pessoa)
        {
            if (pessoa == null){
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
            return this._repositorio.GetAll();
        }

        public Task<Pessoa> GetByCpf(string cpf)
        {
            if (cpf.IsEmpty()) {
                throw new NullReferenceException();
            }

            var retorno = this._repositorio.GetById(cpf);
            retorno.Wait();
            if (!(retorno.Result is Pessoa)){
                return Task<Pessoa>.Run(() => new Pessoa());
            }

            return Task<Pessoa>.Run(() => retorno);
        }

        public Task<Pessoa> GetById(object id)
        {
            if (id == null) {
                throw new NullReferenceException();
            }

            var retorno = this._repositorio.GetById(id);
            retorno.Wait();
            if (!(retorno.Result is Pessoa)){
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