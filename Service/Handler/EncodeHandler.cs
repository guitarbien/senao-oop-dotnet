using MyBackupCandidate;

namespace Service.Handler
{
    public class EncodeHandler : AbstractHandler
    {
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = target;

            base.Perform(candidate, target);

            byte[] newResult = new byte[result.Length];

            if (target != null)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    newResult[i] = somethingEncode(result[i]);
                }
            }

            return newResult;
        }

        private byte somethingEncode(byte input)
        {
            return input;
        }
    }
}