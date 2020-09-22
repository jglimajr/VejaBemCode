using System;
using FluentValidator;

namespace InteliSystem.Util.ValueObjects
{
    public class Filiacao : Notifiable
    {
        public Filiacao(Nome nomeMae, Nome nomePai = null)
        {
            NomeMae = nomeMae;
            NomePai = nomePai;
            if (NomeMae.Invalid)
                AddNotification("NomeMae", "Nome da mãe é obrigatório");
        }
        public Nome NomeMae { get; private set; }
        public Nome NomePai { get; private set; }

        public override string ToString()
        {
            return $"Mãe: {NomeMae}{(NomePai == null ? "" : $", Pai: {NomePai}")}";
        }
    }
}