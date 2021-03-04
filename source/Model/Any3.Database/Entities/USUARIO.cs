using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Any3.Model.Database.Entities
{
   /// <summary>
   /// Classe DAO da entidade USUARIO
   /// </summary>
   public class USUARIO
   {
      [Key]
      public int ID_USUARIO { get; set; }
      
      public string NOME { get; set; }

      /// <summary> Relation 1:N with Paper entity </summary>
      //public virtual ICollection<CONTA_CONTABIL> CONTA_CONTABIL { get; set; }
   }
}