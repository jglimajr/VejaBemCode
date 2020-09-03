using System;

namespace InteliSystem.App.General.Usuarios
{
    public class UsuarioException : Exception
    {
        private const string Msg = "";
        public UsuarioException()
            : base(Msg){}
        
        public UsuarioException(string message)
            : base(message: message){}
        
        public UsuarioException(string message, Exception exception)
            : base(message, exception){}
    }
}