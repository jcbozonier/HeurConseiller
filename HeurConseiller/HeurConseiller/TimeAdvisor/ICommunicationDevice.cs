using HeurConseiller.TimeAdvisor.SoundLookup;

namespace HeurConseiller.TimeAdvisor
{
    public interface ICommunicationDevice
    {
        void SpeakInto(Sound[] o);
    }
}
