
using MediatR;

namespace B.Core.Messages;

public class CommandWithResponse<T> : IRequest<CommandResponse<T>>
{
    public DateTime Timestamp { get; private set; }

    protected CommandWithResponse()
    {
        Timestamp = DateTime.Now;
    }
}