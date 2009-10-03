namespace HeurConseiller.TimeAdvisor.AlarmClock
{
    public class ConstantIntervalStrategy : IAlarmSettingStrategy
    {
        private readonly double _Interval;

        public ConstantIntervalStrategy(double intervalToWait)
        {
            _Interval = intervalToWait;
        }
        public double GetNextInterval()
        {
            return _Interval;
        }
    }
}
