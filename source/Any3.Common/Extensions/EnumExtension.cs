﻿using System.Collections;
using System.ComponentModel;

namespace Any3.Common.Extensions
{
   public static class EnumExtension
   {
      /// <summary>
      /// Return the enumerator description string
      /// </summary>
      /// <param name="value"></param>
      /// <returns></returns>
      public static string GetDescription(this IEnumerator value)
      {
         DescriptionAttribute[] attributes = (DescriptionAttribute[])value
            .GetType()
            .GetField(value.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false);
         return attributes.Length > 0 ? attributes[0].Description : string.Empty;
      }
   }
}
