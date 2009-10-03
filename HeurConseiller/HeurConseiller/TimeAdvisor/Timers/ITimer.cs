using System;

namespace HeurConseiller.TimeAdvisor.Timers
{
    internal interface ITimer
    {
        void SetTimer(double timeInterval);
        event EventHandler OnTimer;
    }
}