using System;

namespace InteliSystem.App.Management.Logins.Exceptions
{
    public class LoginException : Exception
    {
        private const string MsgPadrao = "Usuário e/ou Senha inválido(s)";
        public LoginException()
            : base(MsgPadrao){}
        public LoginException(string message)
            : base(message){}
        public LoginException(string message, Exception exception)
            :base(message, exception){}

        
    }
}