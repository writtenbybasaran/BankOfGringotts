using System;
using System.Net;
using BankOfGringotts.Common.Exceptions;
using BankOfGringotts.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BankOfGringotts.Api.Filter
{
    public class GeneralExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GeneralExceptionFilter> _logger;

        public GeneralExceptionFilter(ILogger<GeneralExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var basicErrorResponse = new BasicErrorHttpResponse();

            string traceId = context.HttpContext.TraceIdentifier;

            Exception ex = context.Exception;
            HttpStatusCode httpStatusCode;
            basicErrorResponse.Message = context.Exception.Message;

            if (ex is NotFoundException)
            {
                _logger.LogWarning(ex, $"TraceId: {traceId} - {basicErrorResponse.Message}", null);
                httpStatusCode = HttpStatusCode.NotFound;
            }
            else if (ex is ValidationException)
            {
                _logger.LogWarning(ex, $"TraceId: {traceId} - {basicErrorResponse.Message}", null);
                httpStatusCode = HttpStatusCode.BadRequest;
            }
            else if (ex is AuthenticationException)
            {
                _logger.LogError(ex, $"TraceId: {traceId} - {basicErrorResponse.Message}", null);
                httpStatusCode = HttpStatusCode.Unauthorized;
            }
            else
            {
                _logger.LogError(ex, $"TraceId: {traceId} - {basicErrorResponse.Message}", null);
                httpStatusCode = HttpStatusCode.InternalServerError;
                basicErrorResponse.Message = "Bilinmeyen bir hata oluştu.";
            }

            context.Result = new ObjectResult(basicErrorResponse)
            {
                StatusCode = (int)httpStatusCode
            };
        }
    }
}
