using MediatR;

namespace Campaigns.App.SystemInfo.Command
{
    public class IncreaseSystemTimeCommand : IRequest
    {
        public int Time { get; private set; }

        public IncreaseSystemTimeCommand(int time)
        {
            Time = time;
        }
    }
}
