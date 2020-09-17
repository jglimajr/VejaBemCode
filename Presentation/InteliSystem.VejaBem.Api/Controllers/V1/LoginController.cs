using System.Threading.Tasks;
using InteliSystem.App.Management.Logins;
using InteliSystem.App.Management.Logins.Exceptions;
using InteliSystem.VejaBem.Api.Util;
using Microsoft.AspNetCore.Http;
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
        [Route("api/V1/[Controller]/")]
        [HttpPut()]
        public async Task<IActionResult> PutLogin([FromHeader]string username, [FromHeader] string password)
        {
            try
            {
                var retorno = await this._manutencao.GetLogin(username: username, password: password);
                return Ok(retorno);
            }
            catch (LoginException le)
            {
                return ValidationControllers.ValidationMessages(statusCode: StatusCodes.Status412PreconditionFailed, title: "Falha no Login", exception: le);
            }
            catch (System.Exception e)
            {
                return ValidationControllers.ValidationMessages(statusCode: StatusCodes.Status500InternalServerError, title: "Problema(s) Interno(s)", exception: e);
            }
        }
    }
}