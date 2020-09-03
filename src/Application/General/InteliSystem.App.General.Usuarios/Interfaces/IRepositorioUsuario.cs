using System.Threading.Tasks;
using InteliSystem.Util.Interfaces;

namespace InteliSystem.App.General.Usuarios
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    { 
        /// <summary>
        /// Recupera o Usuário caso sua Senha esteja correta
        /// </summary>
        /// <param name="username">Usuário</param>
        /// <param name="password">Senha</param>
        /// <returns>Objeto Usuário já Populado</returns>
        Task<Usuario> GetByPassWordAsync(string username, string password);     
    }
}