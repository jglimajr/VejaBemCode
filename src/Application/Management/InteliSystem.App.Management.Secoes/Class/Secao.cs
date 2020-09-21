using System;
using InteliSystem.Util;
using InteliSystem.Util.Enums;
using InteliSystem.Util.AbstractClass;
using InteliSystem.App.Management.Usuarios;

namespace InteliSystem.App.Management.Secoes
{
    public class Secao : GuidBase
    {
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataHoraAcesso { get; set; } = DateTime.Now;
        public DateTime? DataHoraUltimoAcesso { get; set; }
        public string Ip { get; set; }
        public string Browser { get; set; }
        public string SistemaOperacional { get; set; }

        public override string ToString()
        {
            return $"{this.Id}-{Usuario.UserName}";
        }
    }
}