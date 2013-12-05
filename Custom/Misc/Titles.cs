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
            TMobile pm = beheld as TMobile;

            string customTitle = beheld.Title;
            StringBuilder title = new StringBuilder();

            //TROUVER NOM
            if (beheld is TMobile)
            {
                string name;
                name = ((TMobile)beheld).GetNameUseBy(((TMobile)beholder));
                //if (name == "-1") { if (beholder.Female) { name = "Inconnue"; } else { name = "Inconnu"; } }

                //title.Append(((RacePlayerMobile)beheld).PlayerName);

                if (customTitle != null && (customTitle = customTitle.Trim()).Length > 0 && ((TMobile)beheld).RevealTitle == true)
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
                Console.WriteLine("Result : " + ((TMobile)beheld).GetNameUseBy(((TMobile)beholder)));*/

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