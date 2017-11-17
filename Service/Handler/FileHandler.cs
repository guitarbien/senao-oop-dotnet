using System.IO;
using MyBackupCandidate;

namespace Service.Handler
{
    public class FileHandler : AbstractHandler
    {
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = target;
            base.Perform(candidate, target);

            if (target == null)
            {
                result = ConvertFileToByteArray(candidate);
            }
            else
            {
                 ConvertByteArrayToFile(candidate, target);
            }

            return result;
        }

        private byte[] ConvertFileToByteArray(Candidate candidate)
        {
            return File.ReadAllBytes(candidate.Name);
        }

        private void ConvertByteArrayToFile(Candidate candidate, byte[] target)
        {
            File.WriteAllBytes(candidate.Config.Dir + candidate.Name, target);
        }
    }
}