﻿using Microsoft.AspNetCore.Mvc;

namespace QuestSystem.API.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await ConvertExceptionAsync(context, exception);
            }
        }

        private async Task ConvertExceptionAsync(HttpContext context, Exception exception)
        {
            var problemDetails = new ProblemDetails();
            problemDetails.Status = exception switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                NotImplementedException => StatusCodes.Status501NotImplemented,
                _ => StatusCodes.Status500InternalServerError
            };

            problemDetails.Detail = exception.Message;
            context.Response.StatusCode = (int)problemDetails.Status;
            _logger.LogError(exception, "Exception occured.");
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
