using System.Threading.Tasks;
using InteliSystem.App.Management.Logins;
using Microsoft.AspNetCore.Mvc;

namespace InteliSystem.VejaBem.Api.Controllers.V1
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IManutencaoLogin _manutencao;
        public LoginController(IManutencaoLogin manutencao)
        {
            this._manutencao = manutencao;
        }

        public async Task<IActionResult> GetLogin(string username, string password)
        {
            
            try
            {
                this._manutencao.
                    
            }
            catch (System.Exception e)
            {
                
                throw;
            }
        }
    }
}