using System;

namespace Campaigns.Logic.SystemInfo
{
    public interface ISystemInfo
    {
        void IncreaseSystemTime(int time);

        DateTime GetSystemTime();

        void ResetSystemTime();
    }
}
