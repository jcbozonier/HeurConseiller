namespace HeurConseiller.TimeAdvisor.SoundLookup
{
    public class Sound
    {
        private readonly string _FilePath;

        public Sound(string fileName)
        {
            _FilePath = fileName;
        }

        public void PlayWith(ICanPlay play)
        {
            play.PlaySound(_FilePath);
        }
    }
}
