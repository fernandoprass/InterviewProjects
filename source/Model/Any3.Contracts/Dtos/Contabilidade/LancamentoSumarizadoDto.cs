using Any3.Common.Constants;
using System;

namespace Any3.Model.Contracts.Dtos
{
   /// <summary>
   /// Lista os lançamento sumarizados por Conta Contábil e Data
   /// </summary>
   public class LancamentoSumarizadoDto
   {
      public int IdContaContabil { get; set; }

      /// <summary> Codigo da Conta Contabil </summary>
      public string Codigo { get; set; }

      /// <summary> Descricao da Conta Contabil </summary>
      public string Descricao { get; set; }

      /// <summary> Sinal (Débito ou Crédito) da Conta Contabil </summary>
      public string DebitoCredito { get; set; }

      /// <summary> Valor Total a Débito no dia </summary>
      public decimal ValorTotalDebito { get; set; }

      /// <summary> Valor Total a Crébito no dia </summary>
      public decimal ValorTotalCredito { get; set; }

      /// <summary> Valor do Saldo no dia. 
      /// Se a conta for a Débito então = Saldo = Total Débito - Total Crédito
      /// Se a conta for a Crédito então = Saldo = Total Crédito - Total Débito
      /// </summary>
      public decimal ValorSaldo => DebitoCredito == Contabilidade.DEBITO ? ValorTotalDebito - ValorTotalCredito : ValorTotalCredito - ValorTotalDebito;
   }
}
