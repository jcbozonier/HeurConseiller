
using HeurConseiller.TimeAdvisor.AlarmClock;
using HeurConseiller.TimeAdvisor.SoundLookup;
using HeurConseiller.TimeAdvisor.Translation;

namespace HeurConseiller.TimeAdvisor
{
    internal class TimeAdvisor
    {
        private readonly ICommunicationDevice _CommunicationDevice;
        private readonly ITimeTranslation _TimeTranslation;
        private readonly IAlarmClock _AlarmClock;
        private readonly IAlarmSettingStrategy _AlarmSettingStrategy;

        public TimeAdvisor(
            ICommunicationDevice communicationDevice,
            ITimeTranslation timeTranslation,
            IAlarmClock alarmClock,
            IAlarmSettingStrategy alarmSettingStrategy)
        {
            _CommunicationDevice = communicationDevice;
            _TimeTranslation = timeTranslation;
            _AlarmClock = alarmClock;
            _AlarmSettingStrategy = alarmSettingStrategy;
            _AlarmClock.OnAlarm += _AlarmClock_OnAlarm;
        }

        void _AlarmClock_OnAlarm(object sender, AlarmClockEventArgs e)
        {
            var time = e.Time;
            var translation = _TimeTranslation.HowDoISay(time);
            _CommunicationDevice.SpeakInto(translation);

            Start();
        }

        public void Start()
        {
            var alarmInterval = _AlarmSettingStrategy.GetNextInterval();
            _AlarmClock.SetFor(alarmInterval);
        }

        public void Stop()
        {
            _AlarmClock.OnAlarm -= _AlarmClock_OnAlarm;
        }
    }
}
