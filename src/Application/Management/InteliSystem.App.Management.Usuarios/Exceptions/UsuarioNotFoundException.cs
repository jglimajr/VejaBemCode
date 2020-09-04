using System;

namespace InteliSystem.App.Management.Usuarios
{
    public class UsuarioNotFoundException : Exception
    {
        private const string Msg = "Usuário não encontrado!";
        public UsuarioNotFoundException()
            :base(Msg){}
    }
}