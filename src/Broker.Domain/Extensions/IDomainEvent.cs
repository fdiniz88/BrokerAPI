using System;
using MediatR;

namespace Broker.Domain.Extensions
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}