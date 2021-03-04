using Any3.Model.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Any3.Services.Contracts
{
   /// <summary>The Contabilidade service interface</summary>
   public interface IContabilidadeService
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
      /// <param name="data">Data do saldo</param>
      /// <returns></returns>
      Task<IEnumerable<ContaContabilSaldoDto>> GetSaldoContasContabeis(IEnumerable<int> idsContaContabil, DateTime data);
   }
}
