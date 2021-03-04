using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Any3.Model.Database.Entities
{
   /// <summary>
   /// Classe DAO da entidade LANCAMENTO
   /// </summary>
   public class NOTA_FISCAL
   {
      [Key]
      public int ID_NOTA_FISCAL { get; set; }

      public string PRESTADO_TOMADO { get; set; }

      public DateTime DATA { get; set; }
      
      public decimal VALOR { get; set; }

      public decimal VALOR_LIQUIDO { get; set; }

      public string ATIVO { get; set; }

      public DateTime? DATA_VENCIMENTO { get; set; }

      public DateTime? DATA_HORA_LANCAMENTO { get; set; }

      public int ID_CONTA_CONTABIL { get; set; }
   }
}
