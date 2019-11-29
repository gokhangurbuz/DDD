using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Campaigns.Logic.SystemInfo;
using Campaigns.App.Campaings.Command;

namespace Campaigns.App.SystemInfo.Command
{
    public class GetSystemTimeCommandQueryHandler : IRequestHandler<GetSystemTimeCommandQuery, DateTime>
    {
        private readonly ISystemInfo _systemInfo;

        public GetSystemTimeCommandQueryHandler(ISystemInfo systemInfo)
        {
            _systemInfo = systemInfo;
        }

        public async Task<DateTime> Handle(GetSystemTimeCommandQuery request, CancellationToken cancellationToken)
        {
           return _systemInfo.GetSystemTime();
        }
    }
}
