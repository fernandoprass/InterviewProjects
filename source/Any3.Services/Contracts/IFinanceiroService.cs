using Any3.Model.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Any3.Services.Contracts
{
   /// <summary>The Financeiro service interface</summary>
   public interface IFinanceiroService
   {
      /// <summary>
      /// Lista as Contas a Pagar e receber sumarizadas por Conta Contábil e Data
      /// </summary>
      /// <param name="idsContaContabil">Lista de contas pagadoras</param>
      /// <param name="dataInicial">Data inicial</param>
      /// <param name="dataFinal">Data final</param>
      /// <returns></returns>
      Task<IEnumerable<ContasPagarReceberSumarizadoDto>> GetContasPagarReceberSumarizadasByContaContabilData(IEnumerable<int> idsContaContabil, DateTime dataInicial, DateTime dataFinal);
   }
}
