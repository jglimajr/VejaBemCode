using System;
using FluentValidator;
using FluentValidator.Validation;

namespace InteliSystem.Util.ValueObjects
{
    public class Nome : Notifiable
    {
        public Nome(string firstName, string lastName)
        {
            PrimeiroNome = firstName.Trim().ToUpper();
            UltimoNome = lastName.Trim().ToUpper();
            
            AddNotifications(new ValidationContract().Requires()
                .IsNullOrEmpty(PrimeiroNome, "PrimeiroNome", "Seu Nome não foi informado")
                .IsNullOrEmpty(UltimoNome, "UltimoNome", "SobreNome não informado")
                .HasMinLen(PrimeiroNome, 5, "PrimeiroNome", "Seu Nome de conter, no mínimo 5 Caracteres")
                .HasMaxLen(PrimeiroNome, 50, "PrimeiroNome", "Seu Nome de conter, no máximo, 50 Caracteres")
                .HasMinLen(UltimoNome, 5, "UltimoNome", "Seu SobreNome de conter, no mínimo 5 Caracteres")
                .HasMaxLen(UltimoNome, 50, "UltimoNome", "Seu SobreNome de conter, no máximo, 50 Caracteres"));
        }
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }

        public override string ToString()
        {
            return $"{UltimoNome}, {PrimeiroNome}";
        }

    }
}