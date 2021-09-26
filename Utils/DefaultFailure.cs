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
            if (!operation.Responses.ContainsKey("403"))
            {
                operation.Responses.Add("403", new OpenApiResponse
                {
                    Description = "Problem response",
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