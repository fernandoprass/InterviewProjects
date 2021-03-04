using System.ComponentModel.DataAnnotations;

namespace Any3.Model.Database.Entities
{
   /// <summary>
   /// Classe DAO da entidade CONTA_CONTABIL
   /// </summary>
   public class CONTA_CONTABIL
   {
      [Key]
      public int ID_CONTA_CONTABIL { get; set; }

      public string CODIGO { get; set; }

      public string CLASSIFICADOR { get; set; }

      public string CLASSIFICADOR1 { get; set; }

      public string CLASSIFICADOR_NIVEL { get; set; }

      public string DESCRICAO { get; set; }

      public string CREDORA_DEVEDORA { get; set; }

      public string CONTA_CORRENTE { get; set; }

      public string PERMITE_LANCAMENTO { get; set; }

      public string ATIVO { get; set; }

      public int ID_USUARIO_CADASTRO { get; set; }
   }
}
