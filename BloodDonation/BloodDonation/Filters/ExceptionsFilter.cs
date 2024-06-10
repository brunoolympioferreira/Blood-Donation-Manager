using BloodDonation.Application.Models.ViewModels;
using BloodDonation.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BloodDonation.API.Filters;

public class ExceptionsFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BloodDonationException)
            HandleBloodDonationException(context);
        else
            ThrowUnknownError(context);
    }

    private void HandleBloodDonationException(ExceptionContext context)
    {
        if (context.Exception is ValidationErrorsException)
            HandleValidationErrorsException(context);
    }

    private void HandleValidationErrorsException(ExceptionContext context)
    {
        ValidationErrorsException? validationErrorException = context.Exception as ValidationErrorsException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        if (!string.IsNullOrEmpty(validationErrorException?.Message))
        {
            context.Result = new ObjectResult(validationErrorException.Message);
        }
        else
        {
            context.Result = new ObjectResult(new ErrorViewModel(validationErrorException.ErrorMessages));
        }
    }

    private static void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ErrorViewModel(context.Exception.Message));
    }
}
