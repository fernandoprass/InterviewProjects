using System;
using System.Threading.Tasks;

namespace Any3.Domain.Repositories.Contracts
{
   /// <summary>The BaseRepository interface</summary>
   /// <typeparam name="T">The entity</typeparam>
   public interface IBaseRepository<T>
   {
      /// <summary>Get one record by Id (primary key)</summary>
      /// <param name="id">The identifier</param>
      /// <returns></returns>
      Task<T> GetById(Guid id);

      /// <summary>Delete a record</summary>
      /// <param name="id">The identifier</param>
      /// <returns>True if success</returns>
      Task<bool> Delete(Guid id);

      /// <summary>Insert a new record</summary>
      /// <param name="entity">The entity</param>
      /// <returns>True if success</returns>
      Task<bool> Insert(T entity);

      /// <summary>Update a record</summary>
      /// <param name="entity">The entity</param>
      /// <returns>True if success</returns>
      Task<bool> Update(T entity);
   }
}