using System;
using Service;

namespace MyBackupCandidate
{
    public class CandidateFactory
    {
        public static Candidate Create(Config config, string name, DateTime fileDateTime, long size)
        {
            return new Candidate(config, fileDateTime, name, "processName", size);
        }
    }
}