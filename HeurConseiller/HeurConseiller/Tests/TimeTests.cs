using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeurConseiller.TimeAdvisor.Time;
using NUnit.Framework;

namespace HeurConseiller.Tests
{
    [TestFixture]
    public class TimeTests
    {
        [Test]
        public void hours_are_translated_correctly()
        {
            var dateTime = new DateTime(2000, 1, 1, 23, 12, 09);
            var time = new Time(dateTime);

            Assert.AreEqual(23, time.GetHours());
        }

        [Test]
        public void minutes_are_translated_correctly()
        {
            var dateTime = new DateTime(2000, 1, 1, 23, 12, 09);
            var time = new Time(dateTime);

            Assert.AreEqual(12, time.GetMinutes());
        }

        [Test]
        public void seconds_are_translated_correctly()
        {
            var dateTime = new DateTime(2000, 1, 1, 23, 12, 09);
            var time = new Time(dateTime);

            Assert.AreEqual(09, time.GetSeconds());
        }
    }
}
