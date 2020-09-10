using System;
using Microsoft.AspNetCore.Mvc;
using InteliSystem.App.Management.Pessoas;
using System.Threading.Tasks;
using InteliSystem.Util.Extentions;

namespace InteliSystem.VejaBem.Api.Controllers.V1
{
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IManutencaoPessoa _manutencao;

        public PessoaController(IManutencaoPessoa manutencao)
        {
            this._manutencao = manutencao;
        } 
        [Route("api/v1/[controller]/")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retorno = await this._manutencao.GetAll();
            return Ok(retorno);
        }
         
         [Route("api/v1/[controller]/Obter/{id?}")]
         [HttpGet("id")]
         public async Task<IActionResult> GetPessoa(string id)
         {
             if (id == null){
                 return NotFound();
             }
             var pessoa = await this._manutencao.GetById(id);
             if (pessoa == null) {
                 return NotFound();
             }
             return Ok(pessoa);
         }
         [Route("api/v1/[controller]/Cpf/{cpf?}")]
         [HttpGet("cpf")]
         public async Task<IActionResult> GetPessoaByCpf(string cpf)
         {
             if (cpf.IsEmpty()){
                 return NotFound();
             }
             var pessoa = await this._manutencao.GetByCpf(cpf);
             if (pessoa == null) {
                 return NotFound();
             }
             return Ok(pessoa);
         }
    }
}