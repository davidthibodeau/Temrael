using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SauvegardeMiracleScroll : SpellScroll
    {
        [Constructable]
        public SauvegardeMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public SauvegardeMiracleScroll(int amount)
            : base(2022, 0x227B, amount)
        {
            Name = "Sauvegarde";
        }

        public SauvegardeMiracleScroll(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}