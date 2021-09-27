using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using ROP;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiWithROP.Utils
{
    internal class DefaultFailureResponseOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // we can override the 403 swagger documentation by decorating the endpoint with a
            // ProducesResponseType(typeof([OTHER_TYPE]), StatusCodes.Status403Forbidden)]
            // in such case Responses will contain a 403 key and the following code will skip the endpoint
            if (!operation.Responses.ContainsKey("403"))
            {
                operation.Responses.Add("403", new OpenApiResponse
                {
                    Description = "Forbidden",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = context.SchemaGenerator.GenerateSchema(typeof(Failure), context.SchemaRepository)
                        }
                    }
                });
            }
        }
    }
}