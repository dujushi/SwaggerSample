using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerSample.Swagger.OperationFilters
{
    /// <summary>
    /// This operation filter adds forbidden response.
    /// </summary>
    public class ForbiddenResponseOperationFilter : IOperationFilter
    {
        /// <inheritdoc />
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var policies = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Where(attribute => attribute.Policy != null)
                .Select(attribute => attribute.Policy);

            if (policies.Any())
                operation.Responses.Add(((int)HttpStatusCode.Forbidden).ToString(), new OpenApiResponse { Description = HttpStatusCode.Forbidden.ToString() });
        }
    }
}
