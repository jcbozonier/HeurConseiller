using System;

namespace HeurConseiller.TimeAdvisor.AlarmClock
{
    public interface IAlarmClock
    {
        event EventHandler<AlarmClockEventArgs> OnAlarm;
        void SetFor(double interval);
    }
}
