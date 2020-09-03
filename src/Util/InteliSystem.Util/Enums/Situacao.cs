using System.ComponentModel;

namespace InteliSystem.Util.Enums
{
    public enum Situacao
    {
        [Description("ATIVO")]Ativo = 1,
		[Description("BLOQUEADO")]Bloqueado,
		[Description("CANCELADO")]Cancelado,
		[Description("EXCLUIDO")]Excluido = 99
    }
}