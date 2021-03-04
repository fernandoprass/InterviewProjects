using Any3.Common.Constants;
using Any3.Common.Extensions;
using Any3.Domain.Contexts.Contracts;
using Any3.Model.Contracts.Dtos;
using Any3.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Any3.Services.Implementation
{
   /// <summary>The Contabilidade service class</summary>
   public class ContabilidadeService : IContabilidadeService
   {
      /// <summary> The ContaContabil repository </summary>
      private readonly IContabilidadeContext contaContabilContext;

      /// <summary>The Contabilidade service constructor class</summary>
      public ContabilidadeService(IContabilidadeContext contaContabilContext)
      {
         this.contaContabilContext = contaContabilContext;
      }
      
      ///<inheritdoc/>
      public async Task<IEnumerable<ContaContabilDto>> GetContasCorrentes()
      {
         var list = await contaContabilContext.GetContasCorrentes();
         return list;
      }

      ///<inheritdoc/>
      public async Task<IEnumerable<ContaContabilSaldoDto>> GetSaldoContasContabeis(IEnumerable<int> idsContaContabil, DateTime data)
      {
         //retorna o saldo da conta no último dia do mês anterior
         var anoMes = data.AddMonths(-1).ToString(Mascara.ANO_MES);
         var histCC = contaContabilContext.GetSaldoHistContasContabeis(idsContaContabil, anoMes).Result.ToList();

         //retorna o total dos lançamentos a partir do primeiro dia do mês até a data informada
         var lancamentos = await contaContabilContext.GetLancamentoSumarizadosByConta(idsContaContabil, data.FirstDayOfMonth(), data);

         //atualiza o saldo da conta => saldo do último dia do mês anterior + movimentação no mês
         foreach(var hcc in histCC)
         {
            var lanc = lancamentos.FirstOrDefault(x => x.IdContaContabil == hcc.IdContaContabil);
            hcc.ValorSaldo = lanc.IsNotNull() ? hcc.ValorSaldo + lanc.ValorSaldo : hcc.ValorSaldo;
         }

         //verifica se há uma nova conta (contas criadas no mês não possuem saldo no mês anterior)
         var novasCC = lancamentos.Where(x => !histCC.Select(cc => cc.IdContaContabil).Contains(x.IdContaContabil))
            .Select(cc => new ContaContabilSaldoDto
                  {
                     IdContaContabil = cc.IdContaContabil,
                     Codigo = cc.Codigo,
                     Descricao = cc.Descricao,
                     DebitoCredito = cc.DebitoCredito,
                     ValorSaldo = cc.ValorSaldo
                  }).ToList();
         
         //se existir algum conta nova, adiciona a lista de saldo
         novasCC.ForEach(x => histCC.Add(x));

         return histCC.OrderBy(x => x.Descricao);
      }
   }
}
