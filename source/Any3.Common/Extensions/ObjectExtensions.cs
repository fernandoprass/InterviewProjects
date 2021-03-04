using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Any3.Common.Extensions
{
   public static class ObjectExtensions
   {
      /// <summary>
      /// Return TRUE if the object is null
      /// </summary>
      /// <param name="obj"></param>
      /// <returns></returns>
      public static bool IsNull(this object obj)
      {
         return obj == null;
      }

      /// <summary>
      /// Return TRUE if the object is NOT null
      /// </summary>
      /// <param name="collection"></param>
      /// <returns></returns>
      public static bool IsNotNull(this object obj)
      {
         return obj != null;
      }
   }
}
