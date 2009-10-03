using System.IO;
using System.Linq;

namespace HeurConseiller.TimeAdvisor.SoundLookup
{
    public class SoundRepository
    {
        public Sound Get(int soundID)
        {
            var directoryInfo = new DirectoryInfo(@"C:\Code\French121\HeurConseiller\HeurConseiller\AudioFiles\French");
            var soundFiles = directoryInfo.GetFiles("*.ogg");

            var fileInfo = soundFiles.Single(x => x.Name == soundID + ".ogg");

            return new Sound(fileInfo.FullName);
        }

        public Sound Get(string soundName)
        {
            var directoryInfo = new DirectoryInfo(@"C:\Code\French121\HeurConseiller\HeurConseiller\AudioFiles\French");
            var soundFiles = directoryInfo.GetFiles("*.ogg");

            var fileInfo = soundFiles.Single(x => x.Name == soundName + ".ogg");

            return new Sound(fileInfo.FullName);
        }
    }
}