using System;
using Autofac;


namespace InteliSystem.Infra.CrossCuttinInitialize
{
    public class ModuloIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIOC.Load(builder);
        }
    }
}
