using System;
using System.Diagnostics;
using System.IO;

namespace Server.Misc
{
    public class ExceptionLogging
    {

        public static void WriteLine(Exception e, StackTrace catcher)
        {
            WriteLine(e, catcher, "");
        }

        public static void WriteLine(Exception e, StackTrace catcher, string infos)
        {
            string path = Directories.AppendPath(Directories.errors, "Exceptions");
            string filepath = Path.Combine(path, String.Format("{0}.log", Directories.Today));

            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, true))
                {
                    sw.WriteLine("====================================");
                    sw.WriteLine("EXCEPTION caught at {0} : line {1}", catcher.GetFrame(0).GetFileName(), catcher.GetFrame(0).GetFileLineNumber());
                    if (infos != "")
                        sw.WriteLine("Additional infos: {0}", infos);
                    sw.WriteLine(e);
                    sw.WriteLine();
                    sw.WriteLine(catcher.ToString());
                    sw.WriteLine();
                }
            }
            catch { }
        }
    }
}
