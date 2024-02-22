using Domain.Errors;
using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace WebApi.Extensions
{

    public static class ExceptionMiddlewares
    {
        public static void UseGlobalExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            ValidationException =>
                            StatusCodes.Status422UnprocessableEntity,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        if (contextFeature.Error is ValidationException exception)
                        {
                            await context.Response
                           .WriteAsync(JsonSerializer.Serialize(new
                           {
                               exception.Errors
                           }));
                        }
                        else
                        {
                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message,
                            }.ToString());
                        }
                    }
                });
            });
        }
    }

}
