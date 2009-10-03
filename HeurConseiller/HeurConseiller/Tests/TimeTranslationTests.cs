using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeurConseiller.TimeAdvisor.Time;
using HeurConseiller.TimeAdvisor.Translation;
using NUnit.Framework;

namespace HeurConseiller.Tests
{
    [TestFixture]
    public class TimeTranslationTests
    {
        [Test]
        public void When_given_an_afternoon_time_it_should_be_translated_to_non_24_hour_time()
        {
            var hour = 16;
            var minute = 20;
            var second = 31;

            var dateTime = new DateTime(2009, 10, 2, hour, minute, second);
            var time = new Time(dateTime);
            var translationRules = new TranslationRules();

            var languageNeutralTranslation = translationRules.Conceptualize(time);

            Assert.AreEqual(4, languageNeutralTranslation.Hours);
            Assert.AreEqual(minute, languageNeutralTranslation.Minutes);
            Assert.AreEqual(second, languageNeutralTranslation.Seconds);
        }
    }

    
}
