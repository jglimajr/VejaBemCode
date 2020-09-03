using System;
using System.Linq;

namespace InteliSystem.Util.Extentions
{
    public static class GenericGetDescriptionEnum
	{
		public static string GetDescription(this Enum value)
		{
			var tipoEnum = value.GetType();
			var memberInfos = tipoEnum.GetMember(value.ToString());

			var descricao = value.ToString();
			if (typeof(Enum) == value.GetType()) {
				descricao = Enum.GetName(value.GetType(), value);
			}

			if (memberInfos.Length <= 0) {
				return descricao;
			}
			var attribs = memberInfos[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
			return attribs.Any() ? ((System.ComponentModel.DescriptionAttribute)attribs.ElementAt(0)).Description : descricao;
		}
	}
}