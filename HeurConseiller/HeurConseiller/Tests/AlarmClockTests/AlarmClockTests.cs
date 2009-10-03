using HeurConseiller.TimeAdvisor.AlarmClock;
using HeurConseiller.TimeAdvisor.Time;
using HeurConseiller.TimeAdvisor.Timers;
using NUnit.Framework;

namespace HeurConseiller.Tests.AlarmClockTests
{
    [TestFixture]
    public class When_alarm_is_set
    {
        [Test]
        public void It_should_alert_its_observers()
        {
            Assert.IsTrue(AlarmWentOff);
        }

        [Test]
        public void It_should_say_the_current_time()
        {
            Assert.IsNotNull(CurrentTime);
        }

        [Test]
        public void It_should_set_its_timer_to_the_interval_given()
        {
            Assert.AreEqual(GivenInterval, ManualTestingTimer.IntervalSet);
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Context();
            Because();
        }

        private void Because()
        {
            ManualTestingTimer.FireTimerAlert();
        }

        private void Context()
        {
            ManualTestingTimer = new ManualTimer();
            AdvisorAlarmClock = new AlarmClock(ManualTestingTimer);
            AdvisorAlarmClock.OnAlarm += (sndr, e) =>
                                             {
                                                 AlarmWentOff = true;
                                                 CurrentTime = e.Time;
                                             };
            GivenInterval = 100;
            AdvisorAlarmClock.SetFor(GivenInterval);
        }

        private AlarmClock AdvisorAlarmClock;
        private bool AlarmWentOff;
        private ManualTimer ManualTestingTimer;
        private Time CurrentTime = null;
        private int GivenInterval;
    }
}
