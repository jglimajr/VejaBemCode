using FluentValidator;
using FluentValidator.Validation;

namespace InteliSystem.Util.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string endereco)
        {
            Endereco = endereco;
            AddNotifications(new ValidationContract().Requires()
                .IsEmail(Endereco, "Email", "Ôps! E-Mail inválido"));
        }
        public string Endereco { get; private set; }
    }
}