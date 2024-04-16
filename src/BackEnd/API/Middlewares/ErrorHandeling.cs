using Application.Contracts.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Middlewares
{
    public class ErrorHandeling(ILogger<ErrorHandeling> _logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				_logger.LogInformation($"Calling Path: {context.Request.Path}", DateTime.UtcNow);
				await next.Invoke(context);

			}
			catch(ValidationException valex)
			{
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
				_logger.LogWarning(400, $"BadRequest: {valex.Message}");

				await context.Response.WriteAsync(valex.Message);
			}	
			catch (NotFoundException nfex)
			{
				context.Response.StatusCode = StatusCodes.Status404NotFound;
                _logger.LogWarning(404, $"NotFound: {nfex.Message}");

                await context.Response.WriteAsync(nfex.Message);
			}
			catch (Exception ex)
			{
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                _logger.LogError(500, $"InternalServerError: {ex.Message}");

                await context.Response.WriteAsync($"Global Error: {ex.Message}");
			}
        }
    }
}
