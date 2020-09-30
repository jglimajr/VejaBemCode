using System;
using FluentValidator.Validation;
using InteliSystem.Util.AbstractClass;
using InteliSystem.Util.Enums;

namespace InteliSystem.Dominio.Gestao.Secoes
{
    public class Secao : GuidBase
    {

        public Secao(Usuario usuario, string ip, DateTime dataHoraAcesso, string browser, string so, Situacao situacao, DateTime? dataHoraUltimoAcesso = null)
            : base()
        {
            this.Usuario = usuario;
            this.Ip = ip;
            this.DataHoraAcesso = dataHoraAcesso;
            this.DataHoraUltimoAcesso = dataHoraUltimoAcesso;
            this.Browser = browser;
            this.SO = so;
            this.Situacao = situacao;
            AddNotifications(new ValidationContract()
                .IsNullOrEmpty(Ip, "IP", "IP Não informado"));
        }

        public Usuario Usuario { get; private set; }
        public string Ip { get; private set; }
        public DateTime DataHoraAcesso { get; private set; }
        public DateTime? DataHoraUltimoAcesso { get; private set; }
        public string Browser { get; private set; }
        public string SO { get; private set; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}