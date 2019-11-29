using MediatR;
using Campaigns.Logic.Campaign;
using System;

namespace Campaigns.App.Campaings.Command
{
    public class GetSystemTimeCommandQuery : IRequest<DateTime>
    {
        public GetSystemTimeCommandQuery()
        {
        }
    }
}
