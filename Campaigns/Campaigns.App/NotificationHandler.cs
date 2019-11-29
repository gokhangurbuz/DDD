using Campaigns.Logic.Utils;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Campaigns.App
{
    public class NotificationHandler : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            Console.Write(Environment.NewLine);

            Console.Write(notification.NotifyText);

            return Task.CompletedTask;
        }
    }
}
