using Any3.Model.Contracts.Dtos;
using Any3.Model.Database.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Any3.Model.Helpers
{
   public static class Contabilidade
   {
      public static ContaContabilDto ToDto(this CONTA_CONTABIL contaContabil)
      {
         return new ContaContabilDto
         {
            IdContaContabil = contaContabil.ID_CONTA_CONTABIL,
            Descricao = contaContabil.DESCRICAO
         };
      }

      public static IEnumerable<ContaContabilDto> ToDto(this IEnumerable<CONTA_CONTABIL> contaContabil)
      {
         return contaContabil.Select(x => ToDto(x));
      }
   }

}
