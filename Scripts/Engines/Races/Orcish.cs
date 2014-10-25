using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;

namespace Server.Engines.Races
{
    public class Orcish : Race
    {
        public static int RaceId { get { return 6; } }

        public override int Id { get { return RaceId; } }

        public static int[] Hues = new int[]
            {
                1446,
                2207,
                1437
            };

        public override int Skin { get { return 0x27f9; } }

        public override string Name { get { return "Orcish"; } }
        public override string NameF { get { return "Orcish"; } }

        public override bool isAasimaar { get { return false; } }
        public override bool isTieffelin { get { return false; } }
        public override bool Transformed { get { return false; } set { } }

        public override int Image { get { return 434; } }
        public override int Tooltip { get { return 3006427; } }
        public override string Description { get { return "Vous êtes né dans l'oppression. Vos pairs vous ont comptés l'histoire du grand esclavage de votre peuple. Plus jamais. Il y a déjà plusieurs décennies que votre peuple n'est plus en chaînes et c'est regroupé en plusieurs clans, toujours séparés et gouvernés par différents chefs. Depuis ce temps, vous avez été élevé à inspirer la peur chez les autres races du royaume et de les intimider à la soumission. C'est ainsi que les bêtes féroces tel que vous parvenez à survivre dans un endroit aussi civilisé que le royaume de Temrael."; } }

        public Orcish(int hue) : base(hue)
        {
        }

        public Orcish(GenericReader reader) : base(reader)
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