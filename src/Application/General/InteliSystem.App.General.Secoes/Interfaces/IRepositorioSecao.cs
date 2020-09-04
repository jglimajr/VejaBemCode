using System.Threading.Tasks;
using InteliSystem.Util.Interfaces;

namespace InteliSystem.App.General.Secoes
{
    public interface IRepositorioSecao : IRepositorioBase<Secao>
    {
        Task<int> AddHis(Secao secao);
        Task<Secao> GetByUsuario(string username);
        bool Exists(string id);
    }
}