using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Races
{
    public class Elfe : Race
    {
        public static int RaceId { get { return 5; } }

        public override int Id { get { return RaceId; } }

        public static int[] Hues = new int[]
            {
                1023,
                1011,
                1002
            };

        public override Type Skin { get { return typeof(CorpsElfe); } }

        public override string Name { get { return "Elfe"; } }
        public override string NameF { get { return "Elfe"; } }

        public override bool isAasimaar { get { return false; } }
        public override bool isTieffelin { get { return false; } }
        public override bool Transformed { get { return false; } set { } }

        public override int Image { get { return 174; } }
        public override int Tooltip { get { return 3006422; } }
        public override string Description { get { return "Vous vivez dans les plus vastes et secrètes forêts de Temrael, blottis sous le couvert de votre divinité nature. Depuis toujours dévoué à leur protection, par tous les moyens nécessaires, vous êtes de ces ancêtres sans temps ni âge qui subjuguent le commun des mortels. Le plus grand nombre d'entre vous, malgré les siècles qui passent, ne verrons probablement jamais l'extérieur de leur boisé. Ils sont, et vous êtes, les racines du savoir de Temrael."; } }

        public Elfe(int hue) : base(hue)
        {
        }

        public Elfe(GenericReader reader) : base(reader)
        {
            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); //version
        }
    }
}