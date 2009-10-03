using System;

namespace HeurConseiller.TimeAdvisor.Timers
{
    internal class ManualTimer : ITimer
    {
        public double IntervalSet{ get; private set;}

        public void SetTimer(double timeInterval)
        {
            IntervalSet = timeInterval;
        }

        public event EventHandler OnTimer;

        public void FireTimerAlert()
        {
            var onTimer = OnTimer;
            if (onTimer != null)
                onTimer(this, EventArgs.Empty);
        }
    }
}