namespace Any3.Model.Contracts.Dtos
{
   /// <summary>
   /// The DTO to CONTA_CONTABIL table
   /// </summary>
   public class ContaContabilDto
   {
      public int IdContaContabil { get; set; }

      public string Codigo { get; set; }

      public string Classificador { get; set; }

      public string Descricao { get; set; }

      public string DebitoCredito { get; set; }
   }
}
