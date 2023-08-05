
using FluentValidation.Results;
using MediatR;

namespace B.Core.Messages;

public class CommandWithResponse<T> : IRequest<CommandResponse<T>>
{
    public DateTime Timestamp { get; private set; }
    public ValidationResult? ValidationResult { get; set; }

    protected CommandWithResponse()
    {
        Timestamp = DateTime.Now;
    }
}