using Server.Commands;
using System;
using System.Diagnostics;
using System.IO;

namespace Server.Misc
{
    public class AbuseLogging
    {
        public static void WriteLine(Mobile from, string infos)
        {
            string path = Directories.exceptions;
            string filepath = Path.Combine(path, String.Format("Abuse-{0}.log", Directories.Today));

            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, true))
                {
                    sw.WriteLine("[{0}] {1} : {2} {3}", DateTime.Now, from.NetState, CommandLogging.Format(from), infos);
                }
            }
            catch { }
        }
    }
}
