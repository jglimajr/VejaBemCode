using System.Linq;

namespace InteliSystem.Util.Extentions
{
    public static class ObjectToUpper
	{
		public static void ToUpper(this object value)
		{
			var typeObjc = value.GetType();
			var props = typeObjc.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

			props.AsParallel().ToList().ForEach(prop => {
				var valor = prop.GetValue(value);
				if (valor != null) {
					var basetype = prop.PropertyType;
					if (basetype == typeof(string)) {
						if (prop.Name.ToUpper().Contains("PASSWORD") || prop.Name.ToUpper().Contains("SENHA")) {
							prop.SetValue(value, valor);
						} else {
							prop.SetValue(value, valor.ToString().ToUpper());
						}
					}
				}
				
			});
		}
	}
}