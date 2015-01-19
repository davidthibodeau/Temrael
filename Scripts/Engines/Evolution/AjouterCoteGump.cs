using System;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Engines.Evolution
{
    public class AjouterCoteGump : Gump
    {
        PlayerMobile mobile;

        public AjouterCoteGump(PlayerMobile pm) : base(50, 50)
        {
            mobile = pm;

            Closable=true;
            Disposable=true;
            Dragable=true;
            Resizable=false;

            AddPage(0);
            AddBackground(31, 48, 416, 432, 9250);
            AddBackground(39, 56, 400, 417, 3500);
            AddLabel(174, 78, 1301, @"Donner une cote ou fiole à " + pm.Name);

            Cotes cotes = pm.Experience.Cotes;

            
        }
    }
}

