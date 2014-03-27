using System;
using System.Diagnostics;
using System.IO;

namespace Server.Misc
{
    public class ExceptionLogging
    {

        public static void WriteLine(Exception e)
        {
            WriteLine(e, new System.Diagnostics.StackTrace(2, true), "");
        }

        public static void WriteLine(Exception e, string infos)
        {
            WriteLine(e, new System.Diagnostics.StackTrace(2, true), infos);
        }

        public static void WriteLine(Exception e, string infos, params object[] param)
        {
            WriteLine(e, new System.Diagnostics.StackTrace(2, true), String.Format(infos, param));
        }

        private static void WriteLine(Exception e, StackTrace catcher, string infos)
        {
            string path = Directories.AppendPath(Directories.errors, "Exceptions");
            string filepath = Path.Combine(path, String.Format("{0}.log", Directories.Today));
            StackTrace testcatcher = new System.Diagnostics.StackTrace(e, true);
            StackFrame testframe = testcatcher.GetFrame(testcatcher.FrameCount - 1);

            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, true))
                {
                    sw.WriteLine("====================================");
                    sw.WriteLine("EXCEPTION caught the {0}", DateTime.Now);
                    sw.WriteLine("Catcher was {0} : line {1}", testframe.GetFileName(), testframe.GetFileLineNumber());
                    if (infos != "")
                        sw.WriteLine("Additional infos: {0}", infos);
                    sw.WriteLine(e);
                    sw.WriteLine(catcher.ToString());
                    sw.WriteLine();
                }
            }
            catch { }
        }
    }
}
