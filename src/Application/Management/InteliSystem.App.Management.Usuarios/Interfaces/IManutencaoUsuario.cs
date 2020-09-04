using System.Threading.Tasks;
using InteliSystem.Util.Interfaces;

namespace InteliSystem.App.Management.Usuarios
{
    public interface IManutencaoUsuario : IManutencaoBase<Usuario>
    {
        Task<Usuario> GetByPassWord(string username, string password);      
    }
}