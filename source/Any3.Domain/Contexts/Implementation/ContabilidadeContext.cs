using Any3.Common.Constants;
using Any3.Domain.Contexts.Contracts;
using Any3.Model.Contracts.Dtos;
using Any3.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Any3.Domain.Contexts.Implementation
{
   /// <summary>The ContaContabil context class</summary>
   public class ContabilidadeContext : IContabilidadeContext
   {
      private readonly DBContext dbContext;

      public ContabilidadeContext(DBContext dbContext)
      {
         this.dbContext = dbContext;
      }
      
      ///<inheritdoc/>
      public async Task<IEnumerable<ContaContabilDto>> GetContasCorrentes()
      {
         var query = from cc in dbContext.CONTA_CONTABIL
                     where cc.CONTA_CORRENTE == Contabilidade.SIM && cc.ATIVO == Contabilidade.SIM
                     orderby cc.DESCRICAO
                     select new ContaContabilDto
                     {
                        IdContaContabil = cc.ID_CONTA_CONTABIL,
                        Codigo = cc.CODIGO,
                        Classificador = cc.CLASSIFICADOR,
                        Descricao = cc.DESCRICAO,
                        DebitoCredito = cc.CREDORA_DEVEDORA
                     };
         return query.ToList();
      }

      ///<inheritdoc/>
      public async Task<IEnumerable<LancamentoSumarizadoDto>> GetLancamentoSumarizadosByConta(IEnumerable<int> idsContaContabil, DateTime dataInicial, DateTime dataFinal)
      {
         var query = await Task.Run(() =>
                         from lanc in dbContext.LANCAMENTO
                         join cc in dbContext.CONTA_CONTABIL on lanc.ID_CONTA_CONTABIL equals cc.ID_CONTA_CONTABIL
                         where idsContaContabil.Contains(lanc.ID_CONTA_CONTABIL) &&
                               lanc.DATA >= dataInicial && lanc.DATA <= dataFinal                               
                         group lanc by new { lanc.ID_CONTA_CONTABIL, lanc.DEBITO_CREDITO, cc.CODIGO, cc.DESCRICAO } into lanc_group
                         select new LancamentoSumarizadoDto
                         {
                            IdContaContabil = lanc_group.Key.ID_CONTA_CONTABIL,
                            Codigo = lanc_group.Key.CODIGO,
                            Descricao = lanc_group.Key.DESCRICAO,
                            DebitoCredito = lanc_group.Key.DEBITO_CREDITO,
                            ValorTotalDebito = lanc_group.Where(x => x.DEBITO_CREDITO == Contabilidade.DEBITO).Sum(x => x.VALOR),
                            ValorTotalCredito = lanc_group.Where(x => x.DEBITO_CREDITO == Contabilidade.CREDITO).Sum(x => x.VALOR)
                         });
         return query.ToList();
      }

      ///<inheritdoc/>
      public async Task<IEnumerable<ContaContabilSaldoDto>> GetSaldoHistContasContabeis(IEnumerable<int> idsContaContabil, string anoMes)
      {
         var query =  await Task.Run( () =>
                        from hcc in dbContext.HIST_CONTA_CONTABIL
                        join cc in dbContext.CONTA_CONTABIL on hcc.ID_CONTA_CONTABIL_ORIGEM equals cc.ID_CONTA_CONTABIL
                        where cc.CONTA_CORRENTE == Contabilidade.SIM && cc.ATIVO == Contabilidade.SIM && hcc.ANO_MES_REFERENCIA == anoMes
                           orderby cc.DESCRICAO
                        select new ContaContabilSaldoDto
                        {
                           IdContaContabil = cc.ID_CONTA_CONTABIL,
                           Codigo = hcc.CODIGO,
                           Descricao = hcc.DESCRICAO,
                           DebitoCredito = cc.CREDORA_DEVEDORA,
                           ValorSaldo = hcc.VALOR_SALDO
                        });
         return query.ToList();
      }
   }
}
