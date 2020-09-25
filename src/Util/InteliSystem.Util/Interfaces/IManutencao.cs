using System;
using System.Collections.Generic;

namespace InteliSystem.Util.Interfaces
{
    public interface IManutencao<TClass> : IDisposable where TClass : class
    {
         void Add(TClass objeto);
         void Update(TClass objeto);
         void Excluir(object id);
         TClass GetById(object id);
         IEnumerator<TClass> GetAll();
    }
}