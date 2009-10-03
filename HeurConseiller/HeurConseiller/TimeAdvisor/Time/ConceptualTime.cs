using HeurConseiller.Tests;

namespace HeurConseiller.TimeAdvisor.Time
{
    public class ConceptualTime
    {
        public readonly int Seconds;
        public readonly int Hours;
        public readonly int Minutes;
        public readonly TimeOfDay TimeOfDay;

        public ConceptualTime(int hours, int minutes, int seconds, TimeOfDay timeOfDay)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            TimeOfDay = timeOfDay;
        }
    }
}