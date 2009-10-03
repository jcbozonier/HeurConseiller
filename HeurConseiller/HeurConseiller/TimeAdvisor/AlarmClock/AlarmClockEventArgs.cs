using System;

namespace HeurConseiller.TimeAdvisor.AlarmClock
{
    public class AlarmClockEventArgs : EventArgs
    {
        public readonly Time.Time Time;

        public AlarmClockEventArgs(Time.Time time)
        {
            Time = time;
        }
    }
}