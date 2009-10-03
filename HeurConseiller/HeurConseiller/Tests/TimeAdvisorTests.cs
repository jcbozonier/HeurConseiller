using System;
using HeurConseiller.TimeAdvisor;
using HeurConseiller.TimeAdvisor.AlarmClock;
using HeurConseiller.TimeAdvisor.SoundLookup;
using HeurConseiller.TimeAdvisor.Time;
using HeurConseiller.TimeAdvisor.Translation;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Impl;

namespace HeurConseiller.Tests
{
    [TestFixture]
    public class TimeAdvisorTests
    {
        [Test]
        public void assert_that_a_stopped_advisor_does_NOT_speak_into_microphone()
        {
            //Arrange
            var alarmStrategy = MockRepository.GenerateStub<IAlarmSettingStrategy>();
            var microphone = MockRepository.GenerateStub<ICommunicationDevice>();
            var alarmClock = MockRepository.GenerateStub<IAlarmClock>();

            var timeTranslation = MockRepository.GenerateStub<ITimeTranslation>();
            var soundsToBeLookedUp = new Sound[0];
            timeTranslation.Expect(x => x.HowDoISay(null)).IgnoreArguments().Return(soundsToBeLookedUp);
            var timeAdvisor = new TimeAdvisor.TimeAdvisor(microphone, timeTranslation, alarmClock, alarmStrategy);

            //Act
            timeAdvisor.Start();
            var eventRaiser = EventRaiser.Create(alarmClock, "OnAlarm");
            eventRaiser.Raise(alarmClock, new AlarmClockEventArgs(new Time(DateTime.Now)));

            timeAdvisor.Stop();
            eventRaiser.Raise(alarmClock, new AlarmClockEventArgs(new Time(DateTime.Now)));

            //Assert
            var callCount = microphone.GetArgumentsForCallsMadeOn(x => x.SpeakInto(null)).Count;
            Assert.AreEqual(1,callCount);
        }

        [Test]
        public void assert_that_a_started_advisor_speaks_into_microphone()
        {
            //Arrange
            var alarmStrategy = MockRepository.GenerateStub<IAlarmSettingStrategy>();
            var microphone = MockRepository.GenerateStub<ICommunicationDevice>();
            var alarmClock = MockRepository.GenerateStub<IAlarmClock>();

            var timeTranslation = MockRepository.GenerateStub<ITimeTranslation>();
            var soundsToBeLookedUp = new Sound[0];
            timeTranslation.Expect(x => x.HowDoISay(null)).IgnoreArguments().Return(soundsToBeLookedUp);
            var timeAdvisor = new TimeAdvisor.TimeAdvisor(microphone, timeTranslation, alarmClock, alarmStrategy);

            //Act
            timeAdvisor.Start();
            var eventRaiser = EventRaiser.Create(alarmClock, "OnAlarm");
            eventRaiser.Raise(alarmClock, new AlarmClockEventArgs(new Time(DateTime.Now)));

            //Assert
            var thingSaid = microphone.GetArgumentsForCallsMadeOn(x => x.SpeakInto(null))[0][0] as Sound[];
            Assert.AreSame(soundsToBeLookedUp, thingSaid);
        }
    }
}
