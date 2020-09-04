using System;
using InteliSystem.Util.Enums;

namespace InteliSystem.Util.AbstractClass
{
    public abstract class GuidBase
    {
        public GuidBase()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public virtual string Id 
        { 
            get; set;
        }
        public virtual Situacao Situacao 
        { 
            get; set; 
        }
        public string Hash { get; set; }
    }
}