using System;
using System.Diagnostics;
using System.IO;

namespace Server.Misc
{
    public class ExceptionLogging
    {
        int lineNumber = (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber();

        public static void WriteLine(Exception e, StackFrame catcher)
        {
            string path = Directories.exceptions;
            string filepath = Path.Combine(path, Directories.Today);

            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, true))
                {
                    sw.WriteLine("====================================");
                    sw.WriteLine("EXCEPTION caught at {0} : line {1}", catcher.GetFileName(), catcher.GetFileLineNumber());
                    sw.WriteLine(e);
                    sw.WriteLine();
                }
            }
            catch { }
        }
    }
}
