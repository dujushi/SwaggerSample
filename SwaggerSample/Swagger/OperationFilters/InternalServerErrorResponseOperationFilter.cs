using System.Net;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerSample.Swagger.OperationFilters
{
    /// <summary>
    /// This operation filter adds internal server error response.
    /// </summary>
    public class InternalServerErrorResponseOperationFilter : IOperationFilter
    {
        /// <inheritdoc />
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Responses.Add(((int)HttpStatusCode.InternalServerError).ToString(), new OpenApiResponse { Description = HttpStatusCode.InternalServerError.ToString() });
        }
    }
}
