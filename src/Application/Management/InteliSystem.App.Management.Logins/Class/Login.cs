using System;
using InteliSystem.App.Management.Usuarios;
using InteliSystem.Util.AbstractClass;
using InteliSystem.Util.Enums;

namespace InteliSystem.App.Management.Logins
{
    public class Login : GuidBase
    {
        public string UsuarioId { get; internal set; }
        public Usuario Usuario { get; internal set; }
        public DateTime DataHoraAcesso { get; internal set; }
        public DateTime DataHoraUltimoAcesso { get; internal set; }
        public string Ip { get; internal set; }
        public string Browser { get; internal set; }
        public string SistemaOperacional { get; internal set; }
    }
}