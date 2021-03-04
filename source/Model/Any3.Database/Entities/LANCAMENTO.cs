using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Any3.Model.Database.Entities
{
   /// <summary>
   /// Classe DAO da entidade LANCAMENTO
   /// </summary>
   public class LANCAMENTO
   {
      [Key]
      public int ID_LANCAMENTO { get; set; }

      public DateTime DATA { get; set; }

      public string DEBITO_CREDITO { get; set; }

      public decimal VALOR { get; set; }

      public int ID_CONTA_CONTABIL { get; set; }
   }
}
