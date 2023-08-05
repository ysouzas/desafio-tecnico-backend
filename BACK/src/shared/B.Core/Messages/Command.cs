﻿using System.ComponentModel.DataAnnotations;
using MediatR;

namespace B.Core.Messages;

public abstract class Command : IRequest<ValidationResult>
{
    public DateTime Timestamp { get; private set; }
    public ValidationResult? ValidationResult { get; set; }

    protected Command()
    {
        Timestamp = DateTime.Now;
    }

    public virtual bool IsValid()
    {
        throw new NotImplementedException();
    }
}