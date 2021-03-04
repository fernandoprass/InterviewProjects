namespace Any3.Model.Contracts.Dtos
{
   /// <summary>
   /// The ContaContabilSaldo DTO
   /// </summary>
   public class ContaContabilSaldoDto
   {
      public int IdContaContabil { get; set; }

      public string Codigo { get; set; }

      public string Descricao { get; set; }

      public string DebitoCredito { get; set; }

      public decimal ValorSaldo { get; set; }
   }
}
