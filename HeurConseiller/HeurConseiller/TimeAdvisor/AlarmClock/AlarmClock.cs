using System;
using HeurConseiller.TimeAdvisor.Timers;

namespace HeurConseiller.TimeAdvisor.AlarmClock
{
    internal class AlarmClock : IAlarmClock
    {
        public event EventHandler<AlarmClockEventArgs> OnAlarm;
        private readonly ITimer _Timer;

        public AlarmClock(ITimer timer)
        {
            _Timer = timer;
            _Timer.OnTimer += (sndr, e) =>
                                  {
                                      var onAlarm = OnAlarm;
                                      if (onAlarm != null)
                                          onAlarm(this, new AlarmClockEventArgs(new Time.Time(DateTime.Now)));
                                  };
        }

        public void SetFor(double interval)
        {
            _Timer.SetTimer(interval);
        }
    }
}