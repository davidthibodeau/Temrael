using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Engines.Races
{
    public class Nomade : Humain
    {
        public static int RaceId { get { return 3; } }

        public override int Id { get { return RaceId; } }

        public static int[] Hues = new int[]
            {
                1044,
                1142,
                1881
            };

        public override Type Skin { get { return null; } }

        public override string Name { get { return "Nomade"; } }
        public override string NameF { get { return "Nomade"; } }

        public override int Image { get { return 310; } }
        public override int Tooltip { get { return 3006424; } }
        public override string Description { get { return "Vous êtes nés dans les profondeurs d'un désert aride, et vous avez vécu où le vent vous apportait. Vous êtes de ces gens aux traditions riches et diversifiées, même au sein de votre propre peuple, offrant à chacun de vos clans un aspect unique particulier. Vos traditions ne sont racontés que par vous seuls, ou par les miettes que vous laissez de villes en villes. Vous êtes une source infatigable de cette liberté dont rêve les citadins qui peuplent vos voyages."; } }

        public Nomade(RaceSecrete r, int regHue, int secHue)
            : base(r, regHue, secHue)
        {
        }

        public Nomade(int hue)
            : base(hue)
        {
        }

        public Nomade(GenericReader reader) : base(reader)
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