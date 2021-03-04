using Any3.Common.Constants;
using Any3.Domain.Contexts.Contracts;
using Any3.Model.Contracts.Dtos;
using Any3.Model.Contracts.Enums;
using Any3.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Any3.Domain.Contexts.Implementation
{
   /// <summary>The Financeiro context class</summary>
   public class FinanceiroContext : IFinanceiroContext
   {
      private readonly DBContext dbContext;

      public FinanceiroContext(DBContext dbContext)
      {
         this.dbContext = dbContext;
      }
      
      ///<inheritdoc/>
      public async Task<IEnumerable<ContasPagarReceberSumarizadoDto>> GetContasPagarReceberSumarizadasByContaContabilData(IEnumerable<int> idsContaContabil, DateTime dataInicial, DateTime dataFinal)
      { 
         var query = await Task.Run(() =>
                         from nf in dbContext.NOTA_FISCAL
                         join cc in dbContext.CONTA_CONTABIL on nf.ID_CONTA_CONTABIL equals cc.ID_CONTA_CONTABIL
                         where idsContaContabil.Contains(nf.ID_CONTA_CONTABIL) && nf.ATIVO == Financeiro.ATIVO &&
                               nf.DATA_VENCIMENTO >= dataInicial && nf.DATA_VENCIMENTO <= dataFinal                               
                         group nf by new { nf.ID_CONTA_CONTABIL, cc.CODIGO, cc.DESCRICAO, nf.DATA_VENCIMENTO, nf.PRESTADO_TOMADO } into contas
                         select new ContasPagarReceberSumarizadoDto
                         {
                            IdContaContabil = contas.Key.ID_CONTA_CONTABIL,
                            Tipo = contas.Key.PRESTADO_TOMADO == Financeiro.PRESTADO ? ContaTipo.Receita : ContaTipo.Despesa,
                            Codigo = contas.Key.CODIGO,
                            Descricao = contas.Key.DESCRICAO,                            
                            DataVencimento = contas.Key.DATA_VENCIMENTO.Value,
                            Valor = contas.Sum(x => x.VALOR)
                         });
         return query;
      }
   }
}
