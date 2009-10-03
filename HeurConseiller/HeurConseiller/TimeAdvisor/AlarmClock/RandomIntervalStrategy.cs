using System;

namespace HeurConseiller.TimeAdvisor.AlarmClock
{
    public class RandomIntervalStrategy : IAlarmSettingStrategy
    {
        private readonly Random _Random;

        public RandomIntervalStrategy()
        {
            _Random = new Random(DateTime.Now.TimeOfDay.Seconds);
        }
        public double GetNextInterval()
        {
            // Every 30 seconds to 10 minutes.
            return _Random.Next(1000*30, 10*60*1000);
        }
    }
}
