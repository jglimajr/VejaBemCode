using System;
using Microsoft.AspNetCore.Mvc;
using InteliSystem.App.Management.Pessoas;
using System.Threading.Tasks;

namespace InteliSystem.VejaBem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private IManutencaoPessoa _manutencao;

        public PessoaController(IManutencaoPessoa manutencao)
        {
            this._manutencao = manutencao;
        } 

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retorno = await this._manutencao.GetAll();
            return Ok(retorno);
        }
    }
}