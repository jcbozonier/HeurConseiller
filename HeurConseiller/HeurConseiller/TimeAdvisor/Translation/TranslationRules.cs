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

            if (hours > 12)
            {
                hours = hours - 12;
            }

            return new ConceptualTime(hours, minutes, seconds);
        }
    }
}
