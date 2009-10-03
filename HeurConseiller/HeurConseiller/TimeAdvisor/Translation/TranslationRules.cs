using HeurConseiller.TimeAdvisor.Time;

namespace HeurConseiller.TimeAdvisor.Translation
{
    internal class TranslationRules
    {
        public ConceptualTime Conceptualize(Time.Time time)
        {

            var hours = time.GetHours();
            var minutes = time.GetMinutes();
            var seconds = time.GetSeconds();

            var timeOfDay = hours < 5
                                ? TimeOfDay.EarlyMorning
                                : hours < 12
                                      ? TimeOfDay.Morning
                                      : hours == 12
                                            ? TimeOfDay.Noon
                                            : hours < 17
                                                  ? TimeOfDay.Afternoon
                                                  : hours < 20
                                                        ? TimeOfDay.Evening
                                                        : hours >= 20
                                                              ? TimeOfDay.Night
                                                              : TimeOfDay.EarlyMorning;

            if (hours > 12)
            {
                hours = hours - 12;
            }

            return new ConceptualTime(hours, minutes, seconds, timeOfDay);
        }
    }
}
