using System;
using System.Diagnostics;
using System.IO;
using Server.Commands;
using Server.Targeting;

namespace Server.Misc
{
    public class ExceptionLogging
    {

        public static void Initialize()
        {
            CommandSystem.Register("CreationFrame", AccessLevel.Owner, new CommandEventHandler(CreationFrame_OnCommand));
        }

        public static void CreationFrame_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            from.SendMessage("Veuillez choisir l'item.");
            from.Target = new CreationFrameTarget();
        }

        public class CreationFrameTarget : Target
        {
            public CreationFrameTarget() : base(20, false, TargetFlags.None) { }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Item)
                {
                    Item item = targeted as Item;
                    from.SendMessage(item.CreationFrame);
                }
            }
        }

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
            string filepath = Path.Combine(Directories.exceptions, String.Format("{0}.log", Directories.Today));
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
