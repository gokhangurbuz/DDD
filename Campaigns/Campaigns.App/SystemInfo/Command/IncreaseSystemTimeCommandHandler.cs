using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Campaigns.Logic.SystemInfo;

namespace Campaigns.App.SystemInfo.Command
{
    public class IncreaseSystemTimeCommandHandler : IRequestHandler<IncreaseSystemTimeCommand>
    {
        private readonly ISystemInfo _systemInfo;

        public IncreaseSystemTimeCommandHandler(ISystemInfo systemInfo)
        {
            _systemInfo = systemInfo;
        }

        public async Task<Unit> Handle(IncreaseSystemTimeCommand request, CancellationToken cancellationToken)
        {
            _systemInfo.IncreaseSystemTime(request.Time);

            return Unit.Value;
        }
    }
}
