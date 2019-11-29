using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Campaigns.Logic.SystemInfo;
using Campaigns.App.Order.Command;

namespace Campaigns.App.SystemInfo.Command
{
    public class ResetSystemTimeCommandHandler : IRequestHandler<ResetSystemTimeCommand>
    {
        private readonly ISystemInfo _systemInfo;

        public ResetSystemTimeCommandHandler(ISystemInfo systemInfo)
        {
            _systemInfo = systemInfo;
        }

        public async Task<Unit> Handle(ResetSystemTimeCommand request, CancellationToken cancellationToken)
        {
            _systemInfo.ResetSystemTime();

            return Unit.Value;
        }
    }
}
