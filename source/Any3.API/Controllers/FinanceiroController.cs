using Any3.Model.Contracts.Dtos;
using Any3.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Any3.API.Controllers
{
   [Route("[controller]")]
   [ApiController]
   public class FinanceiroController : ControllerBase
   {
      /// <summary> The Contabilidade repository </summary>
      private readonly IFinanceiroService financeiroService;

      public FinanceiroController(IFinanceiroService financeiroService)
      {
         this.financeiroService = financeiroService;
      }

      /// <summary>
      /// Lista as Contas a Pagar e receber sumarizadas por Conta Contábil e Data
      /// </summary>
      /// <param name="idsContaContabil">Lista de contas pagadoras</param>
      /// <param name="dataInicial">Data inicial</param>
      /// <param name="dataFinal">Data final</param>
      /// <returns></returns>
      [HttpGet]
      public async Task<IEnumerable<ContasPagarReceberSumarizadoDto>> GetContasPagarReceberSumarizadasByContaContabilData(
         [FromBody] IEnumerable<int> idsContaContabil, 
         DateTime dataInicial, 
         DateTime dataFinal)
      {
         return await financeiroService.GetContasPagarReceberSumarizadasByContaContabilData(idsContaContabil, dataInicial, dataFinal);
      }

   }
}
