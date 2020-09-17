using System;
using System.Data;

namespace InteliSystem.App.Management.Secoes.Exceptions
{
    public class SecaoNotFoundException : Exception
    {
        private const string MsgPadrao = "Ôps! Seção não Encontrada";
        public SecaoNotFoundException()
            :base(MsgPadrao){}
    }
}