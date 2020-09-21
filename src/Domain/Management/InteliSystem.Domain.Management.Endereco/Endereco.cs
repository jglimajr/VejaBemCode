using System;
using FluentValidator.Validation;

namespace InteliSystem.Domain.Management
{
    public class Endereco : Util.AbstractClass.GuidBase
    {
        public Endereco(string logradouro, string numero, string complemento, string bairro, string cidade, string uf, string cep)
            : base()
        {
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Uf = uf;
            this.Cep = cep;
            AddNotifications(new ValidationContract().Requires()
                .IsNullOrEmpty(Logradouro, "Logradouro", "Logradouro não informado")
                .HasMaxLen(Logradouro, 100, "Logradouro", "Logradouro deve conter, no máximo, 100 Caracteres")
                .IsNullOrEmpty(Bairro, "Bairro", "Bairro não informado")
                .HasMaxLen(Bairro, 100, "Bairro", "Bairro deve conter, no máximo, 100 Caracteres")
                .IsNullOrEmpty(Cidade, "Cidade", "Cidade não informado")
                .HasMaxLen(Cidade, 100, "Cidade", "Cidade deve conter, no máximo, 100 Caracteres")
                .IsNullOrEmpty(Uf, "Uf", "Uf não informado")
                .HasMaxLen(Uf, 2, "Uf", "Uf deve conter, no máximo, 2 Caracteres")
                .IsNullOrEmpty(Cep, "Bairro", "Bairro não informado")
                .HasMaxLen(Cep, 10, "Bairro", "Bairro deve conter, no máximo, 10 Caracteres"));
        }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public string Cep { get; private set; }

        public override string ToString()
        {
            return $"{Logradouro}, {Numero}";
        }
    }
}
