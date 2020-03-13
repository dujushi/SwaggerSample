using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerSample.Swagger.OperationFilters
{
    /// <summary>
    /// This operation filter adds unauthorized response.
    /// </summary>
    public class UnauthorizedResponseOperationFilter : IOperationFilter
    {
        /// <inheritdoc />
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.DeclaringType == null)
            {
                return;
            }

            var authorizeAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
                operation.Responses.Add(((int)HttpStatusCode.Unauthorized).ToString(), new OpenApiResponse { Description = HttpStatusCode.Unauthorized.ToString() });
        }
    }
}
