using MediatR;
using System;

namespace Campaigns.Logic.Common
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}