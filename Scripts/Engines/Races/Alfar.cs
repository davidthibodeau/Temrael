using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Races
{
    public class Alfar : Race
    {
        public static int RaceId { get { return 4; } }

        public override int Id { get { return RaceId; } }

        public static int[] Hues = new int[]
            {
                2410,
                2412,
                1908
            };

        public override Type Skin { get { return typeof(CorpsElfe); } }

        public override string Name { get { return "Elfe Noir"; } }
        public override string NameF { get { return "Elfe Noire"; } }

        public override bool isAasimaar { get { return false; } }
        public override bool isTieffelin { get { return false; } }
        public override bool Transformed { get { return false; } set { } }


        public override int Image { get { return 178; } }
        public override int Tooltip { get { return 3006421; } }
        public override string Description { get { return "Vous avez vécu toute votre vie dans l'ombre et la noirceur. Le continent gauche ne vous effraie plus, il est votre terre. Vous partagez vos pas auprès de créatures tout aussi fourbes que vos personnes, et vous survivez avec magnificience. Mais contrairement à eux, vous êtes partie intégrante du Royaume de Temrael. Gouverné par un Roi humain, gouverné par la religion humaine, qu'en dites-vous ?"; } }

        public Alfar(int hue) : base(hue)
        {
        }

        public Alfar(GenericReader reader) : base(reader)
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