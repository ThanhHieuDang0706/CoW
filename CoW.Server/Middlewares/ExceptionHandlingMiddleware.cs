using CoW.Application.Exceptions;
using CoW.Models.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FinLog.Server.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            logger.LogError(ex, "");

            var code = StatusCodes.Status500InternalServerError;
            var errors = new List<string> { ex.Message };

            code = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => code
            };

            var result = JsonConvert.SerializeObject(ApiResponse<string>.Failure(errors), new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(result);
        }
    }
}
