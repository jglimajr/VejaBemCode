using System.Threading.Tasks;
using InteliSystem.Util.Interfaces;

namespace InteliSystem.App.General.Usuarios
{
    public interface IManutencaoUsuario : IManutencaoBase<Usuario>
    {
        Task<Usuario> GetByPassWord(string username, string password);      
    }
}