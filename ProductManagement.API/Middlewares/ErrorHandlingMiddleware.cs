using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProductManagement.Common.Errors;
using System;
using System.Threading.Tasks;

namespace ProductManagement.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            object errors = null;

            switch (ex)
            {
                //Bắt lỗi 40x tại đây
                case ErrorBase er:
                    _logger.LogError(er.Message, "REST ERROR");
                    context.Response.StatusCode = er.Code;
                    errors = new { status = er.Status, code = er.Code, error = er.Message };
                    break;
                //Bắt lỗi 500 tại đây
                case Exception e:
                    _logger.LogError(e.Message, "SERVER ERROR");
                    errors = new { status = "Fail", code = 500, error = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message };
                    context.Response.StatusCode = 500;
                    break;
            }
            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var result = JsonConvert.SerializeObject(errors);

                await context.Response.WriteAsync(result);
            }
        }
    }
}