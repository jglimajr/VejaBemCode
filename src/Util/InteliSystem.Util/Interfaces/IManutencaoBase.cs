using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteliSystem.Util.Interfaces
{
    public interface IManutencaoBase<Tobject> : IDisposable where Tobject : class 
	{
		Task Add(Tobject obj);
		Task Update(Tobject obj);
		Task Excluir(object id);
		Task<Tobject> GetById(object id);
		Task<IEnumerable<Tobject>> GetAll();
	}
}