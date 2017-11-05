﻿using System.IO;
using System.IO.Compression;

namespace Service.Handler
{
    public class ZipHandler : AbstractHandler
    {
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = base.Perform(candidate, target);

            MemoryStream output = new MemoryStream();

            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(result, 0, result.Length);
            }

            return output.ToArray();
        }
    }
}