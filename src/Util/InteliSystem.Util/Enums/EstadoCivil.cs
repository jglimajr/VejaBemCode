using System.ComponentModel;

namespace InteliSystem.Util.Enums
{
    public enum EstadoCivil
    {
        [Description("SOLTEIRO(A)")]Solteiro=1,
		[Description("CASADO(A)")] Casado,
		[Description("DIVORCIADO(A)")] Divorciado,
		[Description("VIÚVO(A)")] Viuvo,
		[Description("OUTROS")] Outros
    }
}