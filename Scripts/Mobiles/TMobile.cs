using Server.Commands;
using Server.ContextMenus;
using Server.Engines.Equitation;
using Server.Engines.Identities;
using Server.Engines.Langues;
using Server.Engines.Mort;
using Server.Engines.Races;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Movement;
using Server.Network;
using Server.Spells;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class TMobile : PlayerMobile
    {

        //public static void Initialize()
        //{
        //    foreach (Mobile m in World.Mobiles.Values)
        //    {
        //        if (m is TMobile)
        //        {
        //            if (!(m.X < 6082 && m.X > 6053 && m.Y < 4064 && m.Y > 4011))
        //            {
        //                if (m.Backpack != null)
        //                    m.Backpack.DropItem(new Gold(2000));
        //            }
        //        }
        //    }
        //}
        #region Variables






        #endregion

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)9);



        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            int count = 0;

            switch (version)
            {
                case 9:



                    

                    break;
                default: break;
            }






        }
    }
}
