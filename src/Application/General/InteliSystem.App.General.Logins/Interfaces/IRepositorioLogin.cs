using System.Threading.Tasks;
using InteliSystem.Util.Interfaces;

namespace InteliSystem.App.General.Logins
{
    public interface IRepositorioLogin : IRepositorioBase<Login>
    {   
        /// <summary>
        /// Responsável por recuperar a Secao pelo
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
         Task<Login> GetByUsuario(string username);
    }
}