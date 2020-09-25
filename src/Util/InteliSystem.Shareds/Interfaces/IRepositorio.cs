using System;

namespace InteliSystem.Shareds.Interfaces
{
    public interface IRepositorio<TClass> : IDisposable where TClass : class
    {
        void Add(TClass objeto);
        void Update(TClass objeto);
        void Excluir(object id);
    }
}