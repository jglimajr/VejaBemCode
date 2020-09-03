namespace InteliSystem.Util.Extentions
{
    public static class GenericStringsManipulations
    {
        public static string OnlyNumber(this string value)
		{
			if (string.IsNullOrEmpty(value)) {
				return "";
			}
			var retorno = "";
			foreach (var item in value.ToCharArray()) {
				if (!char.IsDigit(item)) {
					continue;
				}
				retorno += $"{item}";
			}
			return retorno;
		}
		public static bool IsEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}
    }
}