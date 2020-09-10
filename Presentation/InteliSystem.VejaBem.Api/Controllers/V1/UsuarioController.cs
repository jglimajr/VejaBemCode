using Microsoft.AspNetCore.Mvc;
using InteliSystem.App.Management.Usuarios;
using System.Threading.Tasks;
using InteliSystem.Util.Extentions;
using InteliSystem.VejaBem.Api.Util;
using Microsoft.AspNetCore.Http;

namespace InteliSystem.VejaBem.Api.Controllers.V1
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IManutencaoUsuario _manutencao;
        public UsuarioController(IManutencaoUsuario manutencao)
        {
            this._manutencao = manutencao;
        }

        // public async Task<IActionResult> GetUsuario(string username, string password)
        // {
        //     if (username.IsEmpty() || password.IsEmpty())
        //     {
        //         ModelState.AddModelError("Usuário", "Usuário e/ou Senha não informados");
        //         return ValidationControllers.ValidationMessages(statusCode: StatusCodes.Status406NotAcceptable, "Usuário", ModelState);
        //     }
        //     try
        //     {
        //         var usuario = await this._manutencao.GetByPassWord(username: username, password: password);
        //         return Ok(usuario);
        //     }
        //     catch (System.Exception e)
        //     {
        //         return ValidationControllers.ValidationMessages(StatusCodes.Status500InternalServerError, "Erro Grave", exception: e);
        //     }

        // }
        [Route("api/V1/[Controller]/{id?}")]
        [HttpGet("id")]
        public async Task<IActionResult> GetUsuario(string id)
        {
            if (id.IsEmpty())
            {
                ModelState.AddModelError("id", "Usuário não informado ou inválido");
                return ValidationControllers.ValidationMessages(StatusCodes.Status204NoContent, title: "Usuario", modelStateDictionary: ModelState);
            }
            try
            {
                var usuario = await this._manutencao.GetById(id);
                return Ok(usuario);
        
            }
            catch (System.Exception e)
            {
                return ValidationControllers.ValidationMessages(StatusCodes.Status500InternalServerError, "Erro Grave", exception: e);
            }
        }
    }
}