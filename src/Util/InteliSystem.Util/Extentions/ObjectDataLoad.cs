using System.Linq;

namespace InteliSystem.Util.Extentions
{
    public static class ObjectDataLoad
    {
        public static void Load(this object load, object obj)
		{
			if (load == null) {
				return;
			}
			var thisType = load.GetType();
			var objType = obj.GetType();

			var thisProp = thisType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			var objProp = objType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			thisProp.ToList().ForEach(prop => {
				objProp.ToList().ForEach(oprop => {
					if (prop.Name == oprop.Name) {
						var obase = prop.PropertyType.BaseType;
						//var oobase = oprop.PropertyType.BaseType;

						var valor = oprop.GetValue(obj);
						//var valor2 = prop.GetValue(load);


						if (valor != null) {
							if (prop.PropertyType == typeof(string)) {
								if (prop.Name.ToUpper().Contains("PASSWORD")|| prop.Name.ToUpper().Contains("SENHA")) {
									prop.SetValue(load, valor.ToString());
								} else {
									prop.SetValue(load, valor.ToString().ToUpper());
								}
								
							} else {
								if (obase.FullName.Contains("InteliSystem")) {
									var itobjload = prop.GetValue(load);
									itobjload.Load(valor);
								} else {
									prop.SetValue(load, valor);
                                }

							}
						}
					}
				});
			});
		}
    }
}