using Any3.Model.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Any3.Domain.Repositories.Contracts
{
   /// <summary>The ContaContabil repository interface</summary>
   public interface IContaContabilRepository
   {
      /// <summary>
      /// Obtem uma lista de conta contábeis
      /// </summary>
      /// <param name="descricao"></param>
      /// <returns></returns>
      Task<IEnumerable<ContaContabilDto>> GetContaContabil(string descricao);
   }
}
