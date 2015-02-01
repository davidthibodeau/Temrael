using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Engines.Langues
{
    class LangueCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("Langue", AccessLevel.Player, new CommandEventHandler(Langue_OnCommand));
        }

        [Usage("Langue [langue]")]
        [Description("Permet d'utiliser le système de langues. Sans arguments, présente le menu de langue." 
            + " Peut prendre un nom de langue qui va être utilisée directement sans passer par le menu.")]
        public static void Langue_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is PlayerMobile)
            {
                PlayerMobile tm = from as PlayerMobile;
                if (e.Length == 1)
                {
                    try
                    {
                        Langue langue = (Langue) Enum.Parse(typeof(Langue), e.GetString(0), true);
                        if (tm.Langues[langue])
                        {
                            tm.Langues.CurrentLangue = langue;
                            tm.SendMessage("Vous parlez maintenant la langue: " + langue);
                        }
                        else
                        {
                            tm.SendMessage("Vous ne pouvez pas parlez une langue que vous ne connaissez pas.");
                        }
                    }
                    catch
                    {
                        tm.SendMessage("La langue que que vous avez indiquée n'est pas valide.");
                    }
                    
                }
                else
                    from.SendGump(new GumpLanguage(tm, false));
            }
        }
    }

    class LangueEtude
    {
        public static void Initialize()
        {
            CommandSystem.Register("LangueEtude", AccessLevel.Player, new CommandEventHandler(LangueEtude_OnCommand));
        }

        [Usage("LangueEtude")]
        [Description("Permet d'apprendre des langues")]
        public static void LangueEtude_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is PlayerMobile)
            {
                from.SendGump(new GumpLanguage((PlayerMobile)from, true));
            }
        }
    }
}
