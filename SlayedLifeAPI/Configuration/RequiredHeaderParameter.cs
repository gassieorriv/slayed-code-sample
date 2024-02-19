using Microsoft.OpenApi.Models;
using SlayedLifeCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace SlayedLifeAPI.Configuration
{
    public class RequiredHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            // parameters for stripe

            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = $"{HeaderKeys.AuthenticationType}",
                Description = "Authentication Type Parameter",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema() { Type = "Int",  },
                  
            });
            
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = $"{HeaderKeys.accessToken}",
                Description = "Client Access Token",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema() { Type = "String" },
            });


            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = $"{HeaderKeys.userId}",
                Description = "Client User ID",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema() { Type = "Boolean" },
            });


           /* operation.Parameters.Add(new OpenApiParameter()
            {
                Name = $"{HeaderKeys.apiAccessToken}",
                Description = "Client User ID",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema() { Type = "Boolean" },
            });*/
        }
    }
}
