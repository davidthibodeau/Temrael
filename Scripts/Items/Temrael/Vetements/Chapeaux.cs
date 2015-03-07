using System;
using Server.Items;

namespace Server.Items
{
    public class ChapeauMage : BaseHat
    {
        [Constructable]
        public ChapeauMage()
            : this(0)
        {
        }

        [Constructable]
        public ChapeauMage(int hue)
            : base(0x2AB0, hue)
        {
            Weight = 5.0;
            Name = "Chapeau de Mage";
        }

        public ChapeauMage(Serial serial)
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

    public class ChapeauCourt : BaseHat
    {
        [Constructable]
        public ChapeauCourt()
            : this(0)
        {
        }

        [Constructable]
        public ChapeauCourt(int hue)
            : base(0x272C, hue)
        {
            Weight = 5.0;
            Name = "Chapeau Court";
        }

        public ChapeauCourt(Serial serial)
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
    public class ChapeauPlume : BaseHat
    {
        [Constructable]
        public ChapeauPlume()
            : this(0)
        {
        }

        [Constructable]
        public ChapeauPlume(int hue)
            : base(0x272D, hue)
        {
            Weight = 5.0;
            Name = "Chapeau a Plume";
        }

        public ChapeauPlume(Serial serial)
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
    public class ChapeauMelon : BaseHat
    {
        [Constructable]
        public ChapeauMelon()
            : this(0)
        {
        }

        [Constructable]
        public ChapeauMelon(int hue)
            : base(0x272E, hue)
        {
            Weight = 5.0;
            Name = "Chapeau Melon";
        }

        public ChapeauMelon(Serial serial)
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
    public class ChapeauNoble : BaseHat
    {
        [Constructable]
        public ChapeauNoble()
            : this(0)
        {
        }

        [Constructable]
        public ChapeauNoble(int hue)
            : base(0x272F, hue)
        {
            Weight = 5.0;
            Name = "Chapeau Noble";
        }

        public ChapeauNoble(Serial serial)
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
    public class ChapeauLoup : BaseHat
    {
        [Constructable]
        public ChapeauLoup()
            : this(0)
        {
        }

        [Constructable]
        public ChapeauLoup(int hue)
            : base(0x2730, hue)
        {
            Weight = 5.0;
            Name = "Tete de Loup";
        }

        public ChapeauLoup(Serial serial)
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
