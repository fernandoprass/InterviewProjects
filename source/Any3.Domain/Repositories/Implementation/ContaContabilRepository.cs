using Any3.Domain.Repositories.Contracts;
using Any3.Model.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Any3.Domain.Repositories.Implementation
{
   /// <summary>The ContaContabil repository class</summary>
   public class ContaContabilRepository : IContaContabilRepository
   {
      ///<inheritdoc/>
      public Task<IEnumerable<ContaContabilDto>> GetContaContabil(string descricao)
      {
         return null;
      }
   }
}
