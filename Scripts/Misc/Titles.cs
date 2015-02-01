using System;
using System.Collections;
using System.Text;
using Server;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Misc
{
    public class Titles
    {
        public static string ComputeTitle(Mobile beholder, Mobile beheld)
        {
            PlayerMobile pm = beheld as PlayerMobile;

            string customTitle = beheld.Title;
            StringBuilder title = new StringBuilder();

            //TROUVER NOM
            if (beheld is PlayerMobile)
            {
                string name;
                name = ((PlayerMobile)beheld).GetNameUsedBy(((PlayerMobile)beholder));
                //if (name == "-1") { if (beholder.Female) { name = "Inconnue"; } else { name = "Inconnu"; } }

                //title.Append(((RacePlayerMobile)beheld).PlayerName);

                if (customTitle != null && (customTitle = customTitle.Trim()).Length > 0)
                {
                    title.AppendFormat(name + ", {0}", customTitle);
                }
                else
                {
                    title.Append(name);
                }

                /*Console.WriteLine("*******Paperdoll********");
                Console.WriteLine("beholder : " + beholder.Name);
                Console.WriteLine("beheld : " + beheld.Name);
                Console.WriteLine("Result : " + ((PlayerMobile)beheld).GetNameUseBy(((PlayerMobile)beholder)));*/

                return title.ToString();
            }

            else
            {
                if (customTitle != null && (customTitle = customTitle.Trim()).Length > 0)
                {
                    title.AppendFormat(beheld.Name + ", {0}", customTitle);
                }
                else
                {
                    title.Append(beheld.Name);
                }

                return title.ToString();
            }
        }
    }
}