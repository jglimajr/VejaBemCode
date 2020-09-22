using FluentValidator;
using FluentValidator.Validation;
using InteliSystem.Util.Extentions;

namespace InteliSystem.Util.ValueObjects
{
    public class Cpf : Notifiable
    {
        public Cpf(string valor)
        {
            Valor = valor;
            AddNotifications(new ValidationContract().Requires()
                .IsTrue(IsCpf(Valor), "Cpf", "Ôps! Cpf informado não é Válido"));
        }
        public string Valor { get; private set; }

        private bool IsCpf(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;

			cpf = cpf.OnlyNumber();

			if (cpf.IsEmpty()) {
				return false;
			}

			if (cpf.Equals(new string('0', 11)) || cpf.Equals(new string('1', 11)) || cpf.Equals(new string('2', 11)) || cpf.Equals(new string('3', 11)) || cpf.Equals(new string('4', 11)) ||
				cpf.Equals(new string('5', 11)) || cpf.Equals(new string('6', 11)) || cpf.Equals(new string('7', 11)) || cpf.Equals(new string('8', 11)) || cpf.Equals(new string('9', 11))) {
				return false;
			}

			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}
    }
}