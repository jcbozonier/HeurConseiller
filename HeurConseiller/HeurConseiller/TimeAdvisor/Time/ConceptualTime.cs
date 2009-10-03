namespace HeurConseiller.TimeAdvisor.Time
{
    public class ConceptualTime
    {
        public readonly int Seconds;
        public readonly int Hours;
        public readonly int Minutes;

        public ConceptualTime(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
    }
}