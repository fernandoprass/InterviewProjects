using Any3.Common.Constants;
using Any3.Model.Contracts.Enums;
using System;

namespace Any3.Model.Contracts.Dtos
{
   /// <summary>
   /// Lista os lançamento sumarizados por Conta Contábil e Data
   /// </summary>
   public class ContasPagarReceberSumarizadoDto
   {
      public int IdContaContabil { get; set; }

      /// <summary> Tipo de Conta (receita ou despesa) </summary>
      public ContaTipo Tipo { get; set; }

      /// <summary> Codigo da Conta Contabil </summary>
      public string Codigo { get; set; }

      /// <summary> Descricao da Conta Contabil </summary>
      public string Descricao { get; set; }

      /// <summary> Data de Vencimento </summary>
      public DateTime DataVencimento { get; set; }

      /// <summary> Valor Total a Débito no dia </summary>
      public decimal Valor { get; set; }
   }
}
