using FluentValidation.Results;

namespace B.Core.Messages;

public class CommandResponse<T>
{
    public CommandResponse(T? response, ValidationResult? validationResult, bool alternativeError = false)
    {
        ValidationResult = validationResult;
        Response = response;
        AlternativeError = alternativeError;
    }

    public ValidationResult? ValidationResult { get; set; }
    public T? Response { get; set; }
    public bool IsValid => ValidationResult?.IsValid ?? false;
    public bool AlternativeError { get; set; }


    public static CommandResponse<T> Create(T? response, ValidationResult? validationResult = null, bool alternativeError = false)
    {
        return new CommandResponse<T>(response, validationResult, alternativeError);
    }
}