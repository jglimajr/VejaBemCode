using System;
using FluentValidator.Validation;
using InteliSystem.Util.AbstractClass;
using InteliSystem.Util.Encryptions;
using InteliSystem.Util.ValueObjects;

namespace InteliSystem.Dominio.Gestao
{
    public class Usuario : ClassBase
    {
        private Criptografia _cript;
        public Usuario(string nome, string senha, Email email)
        {
            this.Nome = nome;
            this.Senha = senha;
            this.Email = email;
            AddNotifications(new ValidationContract()
                .IsNullOrEmpty(Nome, "Usuario", "Usuário não informado")
                .HasMinLen(Nome, 5, "Usuario", "O Usuário deve conter, no mínimo, 5 Caracteres")
                .HasMaxLen(Nome, 30, "Usuario", "O Usuário deve conter, no máximo, 30 Caracteres")
                .IsNullOrEmpty(Senha, "Senha", "Senha não informada")
                .HasMinLen(Senha, 8, "Senha", "Sua Senha deve conter, no mínino, 8 Caracteres")
                .HasMaxLen(Senha, 30, "Senha", "Sua Senha deve conter, no máximo, 30 Caractres")
                .Matchs(Senha, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,30}$", "Senha", "Ôps! Formato inválido"));
            this.Senha = MontarSenha(Senha);
        }

        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public Email Email { get; private set; }

        public override string ToString()
        {
            return $"{Nome}";
        }

        private string MontarSenha(string senha)
        {
            _cript = new Criptografia();
            return _cript.ToHash(senha);
        }

        public bool UsuarioExistente()
        {
            return false;
        }

        public bool EmailExistente()
        {
            return false;
        }

    }
}
