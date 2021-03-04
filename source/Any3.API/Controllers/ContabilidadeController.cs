using Any3.Model.Contracts.Dtos;
using Any3.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Any3API.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class ContabilidadeController : ControllerBase
   {
      /// <summary> The Contabilidade repository </summary>
      private readonly IContabilidadeService contaContabilService;

      public ContabilidadeController(IContabilidadeService contaContabilService)
      {
         this.contaContabilService = contaContabilService;
      }
      
      [HttpGet("GetContasCorrentes")]
      public async Task<IEnumerable<ContaContabilDto>> GetContasCorrentes()         
      {
         return await contaContabilService.GetContasCorrentes();
      }


      [HttpGet("GetSaldoContaContabeis")]
      /// <summary>
      /// Retorna a lista de contas contábeis com os seus respectivos saldos em uma determinada data 
      /// </summary>
      /// <param name="idsContaContabil">Lista de Contas Contábeis</param>
      /// <param name="data">Data do saldo</param>
      /// <returns></returns>
      public async Task<IEnumerable<ContaContabilSaldoDto>> GetSaldoContaContabeis([FromBody]IEnumerable<int> idsContaContabil, DateTime data)
      {
         return await contaContabilService.GetSaldoContasContabeis(idsContaContabil, data);
      }

   }
}
