using Any3.Model.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Any3.Domain.Contexts.Contracts
{
   /// <summary>The Contabilidade context interface</summary>
   public interface IContabilidadeContext
   {
      /// <summary>
      /// Obtem uma lista de conta contábeis ativas
      /// </summary>
      /// <returns></returns>
      Task<IEnumerable<ContaContabilDto>> GetContasCorrentes();

      /// <summary>
      /// Retorna a lista de contas contábeis com os seus respectivos saldos em uma determinada data 
      /// </summary>
      /// <param name="idsContaContabil">Lista de Contas Contábeis</param>
      /// <param name="anoMes">Ano/Mês de referência</param>
      /// <returns></returns>
      Task<IEnumerable<ContaContabilSaldoDto>> GetSaldoHistContasContabeis(IEnumerable<int> idsContaContabil, string anoMes);


      /// <summary>
      /// Retorna a lista de lançamentos sumarizados por conta contábil para um determinado período
      /// </summary>
      /// <param name="idsContaContabil">Lista de Contas Contábeis</param>
      /// <param name="dataInicial">Data Inicial</param>
      /// <param name="dataFinal">Data Final</param>
      /// <returns></returns>
      Task<IEnumerable<LancamentoSumarizadoDto>> GetLancamentoSumarizadosByConta(IEnumerable<int> idsContaContabil, DateTime dataInicial, DateTime dataFinal);
   }
}
