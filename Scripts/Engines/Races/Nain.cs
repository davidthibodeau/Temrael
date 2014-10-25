using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Engines.Races
{
    public class Nain : Race
    {
        public static int RaceId { get { return 7; } }

        public override int Id { get { return RaceId; } }

        public static int[] Hues = new int[]
            {
                1054,
                1052,
                1057
            };

        public override int Skin { get { return 0x27f6; } }

        public override string Name { get { return "Nain"; } }
        public override string NameF { get { return "Naine"; } }

        public override bool isAasimaar { get { return false; } }
        public override bool isTieffelin { get { return false; } }
        public override bool Transformed { get { return false; } set { } }

        public override int Image { get { return 269; } }
        public override int Tooltip { get { return 3006425; } }
        public override string Description { get { return "Vous êtes du peuple des montagnes, du roc et des minéraux. Contrairement à ces grands pics vous n'êtes pas majestueux. Mais, tout comme ces grandes collines le peuple nain renferme lui aussi un secret. Depuis des siècles, la langue ancienne des nains ainsi que la technique de leurs forgerons demeurent un mystère aux autres peuples de Temrael. Malgré toute votre réserve, vous savez être jovial et un très bon compagnon de route lors d'aventures."; } }

        public Nain(int hue) : base(hue)
        {
        }

        public Nain(GenericReader reader)
            : base(reader)
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