using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using FluentValidator.Validation;
using InteliSystem.Util.AbstractClass;
using InteliSystem.Util.Enums;
using InteliSystem.Util.ValueObjects;

namespace InteliSystem.Dominio.Gestao.Pessoas
{
    public class Pessoa : ClassBase
    {
        private IList<Endereco> _enderecos;
        public Pessoa(Nome nome, Sexo sexo, EstadoCivil estadoCivil, DateTime dataNascimento, Filiacao filiacao)
            : base()
        {
            Nome = nome;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
            DataNascimento = dataNascimento;
            _enderecos = new List<Endereco>();
            AddNotifications(new ValidationContract().Requires()
                .IsGreaterOrEqualsThan(DataNascimento, DateTime.Now, "DataNascimento", "A Data de Nascimento informada não é valida"));
        }
        public Nome Nome { get; private set; }
        public Sexo Sexo { get; private set; }
        public EstadoCivil EstadoCivil { get; private set; } = EstadoCivil.Solteiro;
        public DateTime DataNascimento { get; private set; }
        public Filiacao Filiacao { get; private set; }
        public IReadOnlyCollection<Endereco> Enderecos => _enderecos.ToArray<Endereco>();

        public void AddEndereco(Endereco endereco)
        {
            this._enderecos.Add(endereco);
        }

        public override string ToString()
        {
            return $"{this.Nome.PrimeiroNome} {this.Nome.UltimoNome}";
        }
    }
}