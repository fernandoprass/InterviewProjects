using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Any3.Model.Database.Entities
{
   /// <summary>
   /// Classe DAO da entidade hist.CONTA_CONTABIL
   /// </summary>
   [Table("CONTA_CONTABIL", Schema ="hist")]
   public class HIST_CONTA_CONTABIL
   {
      [Key]
      public int ID_CONTA_CONTABIL { get; set; }

      public string ANO_MES_REFERENCIA { get; set; }

      public string CODIGO { get; set; }

      public string CLASSIFICADOR { get; set; }

      public string DESCRICAO { get; set; }

      public string CONTA_CORRENTE { get; set; }

      public decimal VALOR_SALDO { get; set; }

      public int ID_CONTA_CONTABIL_ORIGEM { get; set; }
   }
}
