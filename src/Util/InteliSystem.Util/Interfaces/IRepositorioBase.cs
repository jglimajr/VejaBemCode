using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteliSystem.Util.Interfaces
{
    public interface IRepositorioBase<TObject> : IDisposable where TObject : class
    {
         Task<int> Add(TObject obj);
         Task<int> Update(TObject obj);
         Task<int> Excluir(object id);
         Task<TObject> GetById(object id);
         Task<IEnumerable<TObject>> GetAll();
    }
}