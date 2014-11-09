using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Races
{
    public class Nordique : Humain
    {
        public static int RaceId { get { return 2; } }

        public override int Id { get { return RaceId; } }

        public static int[] Hues = new int[]
            {
                1023,
                1002,
                1013
            };

        public override Type Skin { get { return typeof(CorpsNordique); } }

        public override string Name { get { return "Nordique"; } }
        public override string NameF { get { return "Nordique"; } }

        public override int Image { get { return 416; } }
        public override int Tooltip { get { return 3006420; } }
        public override string Description { get { return "Vous êtes nés, ou vous avez vécu dans les Terres Blanches, hostiles et glaciales où des créatures improbables rôdent au détour de chaque montagne. Les pires légendes courent sur ce pays de neige et de glaces, où seule la force permet de survivre, mais votre sang glacé fait de vous un héritier des anciens héros qui combattirent les démons, et apportèrent Paix et Prospérité au Nord."; } }

        public Nordique(RaceSecrete r, int regHue, int secHue)
            : base(r, regHue, secHue)
        {
        }

        public Nordique(int hue)
            : base(hue)
        {
        }

        public Nordique(GenericReader reader) : base(reader)
        {
            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            
            writer.Write(0); //version
        }

        public override void Detransformer(PlayerMobile from)
        {
            base.Detransformer(from);

            from.EquipItem(new CorpsNordique(from.Hue));
        }
    }
}