using System;
using InteliSystem.App.General.Usuarios;
using InteliSystem.Util.AbstracClass;
using InteliSystem.Util.Enums;

namespace InteliSystem.App.General.Logins
{
    public class Login : GuidBase
    {
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataHoraAcesso { get; set; }
        public DateTime DataHoraUltimoAcesso { get; set; }
        public string Ip { get; set; }
        public string Browser { get; set; }
        public string SistemaOperacional { get; set; }
        public string Hash { get; set; }
    }
}