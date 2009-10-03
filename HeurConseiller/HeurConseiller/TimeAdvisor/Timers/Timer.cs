using System;
using System.Timers;

namespace HeurConseiller.TimeAdvisor.Timers
{
    internal class StandardTimer : ITimer
    {
        private Timer _Timer;

        public void SetTimer(double timeInterval)
        {
            _Timer = new Timer(timeInterval);
            _Timer.Elapsed += (sndr, e) =>
                                  {
                                      _Timer.Stop();
                                      var onTimer = OnTimer;
                                      if (onTimer != null)
                                          onTimer(this, EventArgs.Empty);
                                  };
            _Timer.Start();
        }

        public event EventHandler OnTimer;
    }
}
