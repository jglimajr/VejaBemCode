using FluentValidator;
using FluentValidator.Validation;
using InteliSystem.Util.Extentions;

namespace InteliSystem.Util.ValueObjects
{
    public class Cnpj : Notifiable
    {
        
        public Cnpj(string valor)
        {
            this.Valor = valor;
            AddNotifications(new ValidationContract()
                .IsTrue(IsCnpj(this.Valor), "Cnpj", "Ôps! Cnpj informado não é Válido"));
        }

        public string Valor { get; private set; }
        private bool IsCnpj(string value)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;

			value = value.OnlyNumber();

			if (value.Equals(new string('0', 14)) || value.Equals(new string('1', 14)) || value.Equals(new string('2', 14)) || value.Equals(new string('3', 14)) || value.Equals(new string('4', 14)) ||
				value.Equals(new string('5', 14)) || value.Equals(new string('6', 14)) || value.Equals(new string('7', 14)) || value.Equals(new string('8', 14)) || value.Equals(new string('9', 14))) {
				return false;
			}
			tempCnpj = value.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return value.EndsWith(digito);
		}
    }
}