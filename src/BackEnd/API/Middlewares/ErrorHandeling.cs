using Application.Contracts.Exceptions;
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
			catch (NotFoundException nfex)
			{
				context.Response.StatusCode = 400;
				await context.Response.WriteAsync(nfex.Message);
			}
			catch (Exception ex)
			{
				context.Response.StatusCode = 500;
				await context.Response.WriteAsync($"Global Error: {ex.Message}");
			}
        }
    }
}
