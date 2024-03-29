﻿using MediatR;

namespace Campaigns.Logic.Utils
{
    public interface INotifierMediatorService
    {
        void Notify(string notifyText);
    }

    public class NotifierMediatorService : INotifierMediatorService
    {
        private readonly IMediator _mediator;

        public NotifierMediatorService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Notify(string notifyText)
        {
            _mediator.Publish(new NotificationMessage { NotifyText = notifyText });
        }
    }

    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }
}
