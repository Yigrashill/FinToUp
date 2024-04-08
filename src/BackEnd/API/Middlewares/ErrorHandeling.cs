using Application.Contracts.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Middlewares
{
    public class ErrorHandeling : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch(ValidationException valex)
			{
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
				await context.Response.WriteAsync(valex.Message);
			}	
			catch (NotFoundException nfex)
			{
				context.Response.StatusCode = StatusCodes.Status400BadRequest;
				await context.Response.WriteAsync(nfex.Message);
			}
			catch (Exception ex)
			{
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
				await context.Response.WriteAsync($"Global Error: {ex.Message}");
			}
        }
    }
}
