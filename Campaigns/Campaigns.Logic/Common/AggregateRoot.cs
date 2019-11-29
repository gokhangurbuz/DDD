using System;

namespace Campaigns.Logic.Common
{
    public abstract class AggregateRoot : Entity
    {
        private static DateTime? _dateTime;

        protected AggregateRoot()
        {
            _dateTime = _dateTime ?? DateTime.MinValue;
        }

        protected void IncreaseTime(int time)
        {
            _dateTime = _dateTime ?? DateTime.MinValue;
            _dateTime = _dateTime.Value.AddHours(time);
        }

        public DateTime GetTime()
        {
           return _dateTime.Value;
        }

        public void ResetTime()
        {
            _dateTime = DateTime.MinValue;
        }
    }
}
