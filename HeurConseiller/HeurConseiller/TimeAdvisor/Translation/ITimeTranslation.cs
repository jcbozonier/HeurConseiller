using HeurConseiller.TimeAdvisor.SoundLookup;

namespace HeurConseiller.TimeAdvisor.Translation
{
    public interface ITimeTranslation
    {
        Sound[] HowDoISay(Time.Time time);
    }
}
