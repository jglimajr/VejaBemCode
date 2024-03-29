using System;
using FluentValidator;
using InteliSystem.Util.Enums;

namespace InteliSystem.Util.AbstractClass
{
    public abstract class GuidBase : Notifiable
    {
        public GuidBase()
        {
            this.Id = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
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