using System;
using InteliSystem.Util.AbstractClass;
using InteliSystem.Util.Encryptions;
using InteliSystem.Util.ValueObjects;

namespace InteliSystem.Domain.Management
{
    public class Usuario : ClassBase
    {
        private Criptografia _cript;
        public Usuario(string nome, string senha, Email email)
        {
            this.Nome = nome;
            this.Senha = senha;
            this.Email = email;
            this.Senha = MontarSenha(this.Nome, this.Senha);
        }

        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public Email Email { get; private set; }

        public override string ToString()
        {
            return $"{Nome}";
        }

        private string MontarSenha(string nome, string senha)
        {
            _cript = new Criptografia();
            _cript.Chave = Criptografia.GerarChave(nome);
            return _cript.EncriptarHexadecimal(senha);
        }

    }
}
