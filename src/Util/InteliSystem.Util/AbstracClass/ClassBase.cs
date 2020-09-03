using System;

namespace InteliSystem.Util.AbstracClass
{
    public abstract class ClassBase : GuidBase
    {
        public virtual DateTime DataHoraCadastro { get; set; }
        public virtual DateTime DataHoraAlteracao { get; set; }
        
    }
}