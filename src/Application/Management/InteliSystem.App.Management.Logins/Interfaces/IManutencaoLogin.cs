using System.Threading.Tasks;
using InteliSystem.Util.Interfaces;

namespace InteliSystem.App.Management.Logins
{
    public interface IManutencaoLogin
    {
        Task<Login> GetLogin(string username, string password);
    }

    
}