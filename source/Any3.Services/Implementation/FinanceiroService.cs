using Any3.Model.Contracts.Dtos;
using Any3.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Any3.Services.Implementation
{
   /// <summary>The Financeiro service class</summary>
   public class FinanceiroService : IFinanceiroService
   {
      /// <summary> The ContaContabil repository </summary>
      private readonly IFinanceiroService financeiroContext;

      /// <summary>The Contabilidade service constructor class</summary>
      public FinanceiroService(IFinanceiroService financeiroContext)
      {
         this.financeiroContext = financeiroContext;
      }

      public async Task<IEnumerable<ContasPagarReceberSumarizadoDto>> GetContasPagarReceberSumarizadasByContaContabilData(IEnumerable<int> idsContaContabil, DateTime dataInicial, DateTime dataFinal)
      {
         var list = await financeiroContext.GetContasPagarReceberSumarizadasByContaContabilData(idsContaContabil, dataInicial, dataFinal);
         return list;
      }
   }
}
