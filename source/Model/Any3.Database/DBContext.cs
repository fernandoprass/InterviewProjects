using Any3.Model.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Any3.Model.Database
{
   /// <summary> The database context class </summary>
   public class DBContext : DbContext
   {
      #region DboSchema
      /// <summary> The Author entity reference </summary>
      public DbSet<CONTA_CONTABIL> CONTA_CONTABIL { get; set; }

      public DbSet<LANCAMENTO> LANCAMENTO { get; set; }

      public DbSet<NOTA_FISCAL> NOTA_FISCAL { get; set; }
      
      public DbSet<USUARIO> USUARIO { get; set; }

      #endregion

      #region HistSchema
      public DbSet<HIST_CONTA_CONTABIL> HIST_CONTA_CONTABIL { get; set; }

      #endregion

      public DBContext(DbContextOptions<DBContext> options) : base(options)
      { 
      }

      /// <summary> Action to be execute when the model is created </summary>
      /// <param name="modelBuilder"></param>
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<HIST_CONTA_CONTABIL>().Property(p => p.VALOR_SALDO).HasPrecision(18, 2);
         modelBuilder.Entity<LANCAMENTO>().Property(p => p.VALOR).HasPrecision(18, 2);

         //modelBuilder.Entity<Blog>().Property(b => b.Url).IsRequired();
         ///https://sql2go.com/2018/12/specifying-schema-names-in-entity-framework-core-code-first-models/
         ///https://www.codeproject.com/articles/350135/entity-framework-get-mapped-table-name-from-an-ent
         /// https://www.itprotoday.com/development-techniques-and-management/working-schema-names-entity-framework-code-first-design
      }

   }
}
