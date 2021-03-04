using Any3.Model.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Any3.API
{
   /// <summary>
   /// The Database connection configuration class
   /// </summary>
   public static class DBConnection
   {
      /// <summary>
      /// Configure the database connection
      /// </summary>
      /// <param name="services"></param>
      /// <param name="configuration"></param>
      public static void Configure(IServiceCollection services, IConfiguration configuration)
      {
         string connection = configuration.GetConnectionString("Any3");
         services.AddDbContext<DBContext>(options => options.UseSqlServer(connection));
      }
   }
}
