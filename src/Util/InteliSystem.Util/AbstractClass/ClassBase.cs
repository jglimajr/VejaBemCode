using System;

namespace InteliSystem.Util.AbstractClass
{
    public abstract class ClassBase : GuidBase
    {
        public virtual DateTime DataHoraCadastro { get; set; }
        public virtual DateTime DataHoraAlteracao { get; set; }
    }
}