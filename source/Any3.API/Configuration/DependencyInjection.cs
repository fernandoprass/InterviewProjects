using Any3.Domain.Contexts.Contracts;
using Any3.Domain.Contexts.Implementation;
using Any3.Services.Contracts;
using Any3.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Any3.API
{
   /// <summary>The DependencyInjection class </summary>
   public static class DependencyInjection
   {

      /// <summary>Register services </summary>
      /// <param name="services">The services collection</param>
      public static void Register(IServiceCollection services)
      {
         services.AddTransient<IContabilidadeContext, ContabilidadeContext>();
         services.AddTransient<IContabilidadeService, ContabilidadeService>();
      }
   }
}