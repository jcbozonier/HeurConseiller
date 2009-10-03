using HeurConseiller.TimeAdvisor.SoundLookup;

namespace HeurConseiller.TimeAdvisor.Translation
{
    public class TimeTranslation : ITimeTranslation
    {
        public Sound[] HowDoISay(Time.Time time)
        {
            var translationRules = new TranslationRules();
            var conceptualizedTime = translationRules.Conceptualize(time);
            var soundRepo = new SoundRepository();

            var hours = conceptualizedTime.Hours;
            var minutes = conceptualizedTime.Minutes;
            var seconds = conceptualizedTime.Seconds;

            var hourSound = soundRepo.Get(hours);
            var hourWordSound = soundRepo.Get("hours");
            var minutesSound = soundRepo.Get(minutes);
            var secondsSound = soundRepo.Get(seconds);

            return new []
                    {
                        hourSound,
                        hourWordSound, 
                        minutesSound
                    };
        }
    }
}
