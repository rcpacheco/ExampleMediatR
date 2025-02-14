﻿using FluentValidation;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ExampleMediatR.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseFluentValidationExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;
                    string errorText;

                    if (exception is ValidationException validationException)
                    {
                        var errors = validationException.Errors.Select(err => new
                        {
                            err.PropertyName,
                            err.ErrorMessage,
                        });
                        errorText = JsonSerializer.Serialize(errors);
                        context.Response.StatusCode = 400;
                    }
                    else
                    {
                        errorText = JsonSerializer.Serialize(new { isSuccess = false, error = exception.Message });
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }

                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorText, Encoding.UTF8).ConfigureAwait(false);
                });
            });
        }
    }
}
