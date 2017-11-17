using System.IO;
using MyBackupCandidate;

namespace Service.Handler
{
    public class DirectoryHandler : AbstractHandler
    {
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = target;

            base.Perform(candidate, target);

            if (target != null)
            {
                // write file thru FileHandler
                HandlerFactory.Create("file").Perform(candidate, target);

                // copy the file to destination
                CopyToDirectory(candidate, target);
            }

            return target;
        }

        private void CopyToDirectory(Candidate candidate, byte[] target)
        {
            File.Copy(Path.Combine(candidate.Config.Location, candidate.Name), Path.Combine(candidate.Config.Dir, candidate.Name), true);
        }
    }
}