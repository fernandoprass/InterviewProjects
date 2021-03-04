using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Any3.API
{
   public static class Swagger
   {
      public static void Configure(IServiceCollection services)
      {
         services.AddSwaggerGen(options =>
         {
            options.DescribeAllParametersInCamelCase();
            options.SwaggerDoc("v1", new OpenApiInfo
            {
               Title = "Any3API ",
               Version = "v1",
               Description = "The Catalog Microservice HTTP API. This is a Data-Driven/CRUD microservice sample"
            });
         });
      }

      public static void SetEndpoint(IApplicationBuilder app)
      {
         app.UseSwagger()
                     .UseSwaggerUI(c =>
                     {
                        c.SwaggerEndpoint("../swagger/v1/swagger.json", "Any3 API V1");
                     });
      }
   }
}
