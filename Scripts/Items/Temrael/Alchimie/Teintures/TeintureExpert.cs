using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class PigmentCitrine : BaseTeinture
    {
        public override int Couleur { get { return 2360; } }

        [Constructable]
        public PigmentCitrine()
            : base(0x103D)
        {
            Weight = 0.1;
            Name = "Pigment de citrine fondu";
            Hue = 2360;
        }

        public PigmentCitrine(Serial s)
            : base(s)
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

    public class PigmentObsidienne : BaseTeinture
    {
        public override int Couleur { get { return 2398; } }

        [Constructable]
        public PigmentObsidienne()
            : base(0x103D)
        {
            Weight = 0.1;
            Name = "Pigment d'Obsidienne fondu";
            Hue = 2398;
        }

        public PigmentObsidienne(Serial s)
            : base(s)
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

    public class PigmentAmethyste : BaseTeinture
    {
        public override int Couleur { get { return 2368; } }

        [Constructable]
        public PigmentAmethyste()
            : base(0x103D)
        {
            Weight = 0.1;
            Name = "Pigment d'Améthyste fondu";
            Hue = 2368;
        }

        public PigmentAmethyste(Serial s)
            : base(s)
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

    public class PigmentDiamant : BaseTeinture
    {
        public override int Couleur { get { return 2394; } }

        [Constructable]
        public PigmentDiamant()
            : base(0x103D)
        {
            Weight = 0.1;
            Name = "Pigment de diamant fondu";
            Hue = 2394;
        }

        public PigmentDiamant(Serial s)
            : base(s)
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

    public class PigmentRubis : BaseTeinture
    {
        public override int Couleur { get { return 2380; } }

        [Constructable]
        public PigmentRubis()
            : base(0x103D)
        {
            Weight = 0.1;
            Name = "Pigment de rubis fondu";
            Hue = 2380;
        }

        public PigmentRubis(Serial s)
            : base(s)
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

    public class PigmentEmeraude : BaseTeinture
    {
        public override int Couleur { get { return 2389; } }

        [Constructable]
        public PigmentEmeraude()
            : base(0x103D)
        {
            Weight = 0.1;
            Name = "Pigment d'émeraude fondu";
            Hue = 2389;
        }

        public PigmentEmeraude(Serial s)
            : base(s)
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

    public class PigmentSaphir : BaseTeinture
    {
        public override int Couleur { get { return 2346; } }

        [Constructable]
        public PigmentSaphir()
            : base(0x103D)
        {
            Weight = 0.1;
            Name = "Pigment de saphir fondu";
            Hue = 2346;
        }

        public PigmentSaphir(Serial s)
            : base(s)
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
