using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
    public class Knitting : BaseTool
    {
        public override CraftSystem CraftSystem { get { return DefBoneLeatherTailoring.CraftSystem; } }

        [Constructable]
        public Knitting()
            : base(0xDF6)
        {
            Weight = 2.0;
            Name = "Kit de couture (Cuir/Os)";
            Layer = Layer.TwoHanded;
        }

        [Constructable]
        public Knitting(int uses)
            : base(uses, 0xDF6)
        {
            Weight = 2.0;
            Name = "Kit de couture (Cuir/Os)";
            Layer = Layer.TwoHanded;
        }

        public Knitting(Serial serial)
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