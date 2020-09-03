using System;

namespace InteliSystem.App.General.Usuarios
{
    public class UsuarioNotFoundException : Exception
    {
        private const string Msg = "Usuário não encontrado!";
        public UsuarioNotFoundException()
            :base(Msg){}
    }
}