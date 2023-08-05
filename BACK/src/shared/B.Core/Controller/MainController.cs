using System.Net;
using B.Core.Communication;
using B.Core.Messages;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace B.Core.Controller;


[Route("[controller]")]
[ApiController]
public abstract class MainController : ControllerBase
{
    protected ICollection<string> Errors = new List<string>();

    protected ActionResult CustomResponse(object? result = null, int statusCodesOkAlternative = 0, int statusCodesBadRequestAlternative = 0, bool useAlternativeError = false)
    {
        if (ValidOperation())
        {
            return statusCodesOkAlternative is 0 ? Ok(result) : StatusCode(statusCodesOkAlternative, result);
        }

        var ValidationProblemDetails = new ValidationProblemDetails(new Dictionary<string, string[]> { { "Messages", Errors.ToArray() } });

        return useAlternativeError ? StatusCode(statusCodesBadRequestAlternative, ValidationProblemDetails) : BadRequest(ValidationProblemDetails);
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);
        foreach (var error in errors)
        {
            AddErrorToStack(error.ErrorMessage);
        }

        return CustomResponse();
    }

    protected ActionResult CustomResponse(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddErrorToStack(error.ErrorMessage);
        }

        return CustomResponse();
    }

    protected ActionResult CustomResponse<T>(CommandResponse<T> commandResponse, int statusCodesOkAlternative = 0, int statusCodesBadRequestAlternative = 0)
    {
        var errors = commandResponse?.ValidationResult?.Errors ?? null;

        if (errors is null)
            return CustomResponse(commandResponse.Response, statusCodesOkAlternative, statusCodesBadRequestAlternative, commandResponse.AlternativeError);


        foreach (var error in errors)
        {
            AddErrorToStack(error.ErrorMessage);
        }

        return CustomResponse(commandResponse.Response, statusCodesOkAlternative, statusCodesBadRequestAlternative, commandResponse.AlternativeError);
    }

    protected ActionResult CustomResponse(ResponseResult responseResult)
    {
        ResponseHasErrors(responseResult);

        return CustomResponse();
    }

    protected bool ResponseHasErrors(ResponseResult responseResult)
    {
        if (responseResult == null || !responseResult.Errors.Messages.Any()) return false;

        foreach (var errorMessage in responseResult.Errors.Messages)
        {
            AddErrorToStack(errorMessage);
        }

        return true;
    }

    protected bool ValidOperation()
    {
        return !Errors.Any();
    }

    protected void AddErrorToStack(string error)
    {
        Errors.Add(error);
    }

    protected void CleanErrors()
    {
        Errors.Clear();
    }
}

