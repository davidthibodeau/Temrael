using System;
using Server.Items;

namespace Server.Items
{
    public class BarbeAmple : Beard
    {
        private BarbeAmple()
            : this(0)
        {
        }

        private BarbeAmple(int hue)
            : base(0x283C, hue)
        {
        }

        public BarbeAmple(Serial serial)
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
    public class BarbeTresse : Beard
    {
        private BarbeTresse()
            : this(0)
        {
        }

        private BarbeTresse(int hue)
            : base(0x283D, hue)
        {
        }

        public BarbeTresse(Serial serial)
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
    public class BarbeBarbare : Beard
    {
        private BarbeBarbare()
            : this(0)
        {
        }

        private BarbeBarbare(int hue)
            : base(0x283E, hue)
        {
        }

        public BarbeBarbare(Serial serial)
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
    public class BarbeLongue : Beard
    {
        private BarbeLongue()
            : this(0)
        {
        }

        private BarbeLongue(int hue)
            : base(0x283F, hue)
        {
        }

        public BarbeLongue(Serial serial)
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
    public class BarbeNordique : Beard
    {
        private BarbeNordique()
            : this(0)
        {
        }

        private BarbeNordique(int hue)
            : base(0x2840, hue)
        {
        }

        public BarbeNordique(Serial serial)
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
    public class BarbeTresser : Beard
    {
        private BarbeTresser()
            : this(0)
        {
        }

        private BarbeTresser(int hue)
            : base(0x2841, hue)
        {
        }

        public BarbeTresser(Serial serial)
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
    public class BarbeCourte : Beard
    {
        private BarbeCourte()
            : this(0)
        {
        }

        private BarbeCourte(int hue)
            : base(0x2842, hue)
        {
        }

        public BarbeCourte(Serial serial)
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
    public class BarbeAncienne : Beard
    {
        private BarbeAncienne()
            : this(0)
        {
        }

        private BarbeAncienne(int hue)
            : base(0x2843, hue)
        {
        }

        public BarbeAncienne(Serial serial)
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
    public class BarbeJeune : Beard
    {
        private BarbeJeune()
            : this(0)
        {
        }

        private BarbeJeune(int hue)
            : base(0x2844, hue)
        {
        }

        public BarbeJeune(Serial serial)
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
    public class BarbeAncestrale : Beard
    {
        private BarbeAncestrale()
            : this(0)
        {
        }

        private BarbeAncestrale(int hue)
            : base(0x2845, hue)
        {
        }

        public BarbeAncestrale(Serial serial)
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
    public class BarbeMince : Beard
    {
        private BarbeMince()
            : this(0)
        {
        }

        private BarbeMince(int hue)
            : base(0x2848, hue)
        {
        }

        public BarbeMince(Serial serial)
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
    public class BarbeLongueTresses : Beard
    {
        private BarbeLongueTresses()
            : this(0)
        {
        }

        private BarbeLongueTresses(int hue)
            : base(0x2849, hue)
        {
        }

        public BarbeLongueTresses(Serial serial)
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
    public class BarbeCourteTresses : Beard
    {
        private BarbeCourteTresses()
            : this(0)
        {
        }

        private BarbeCourteTresses(int hue)
            : base(0x284A, hue)
        {
        }

        public BarbeCourteTresses(Serial serial)
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
    public class BarbeMoustache : Beard
    {
        private BarbeMoustache()
            : this(0)
        {
        }

        private BarbeMoustache(int hue)
            : base(0x284B, hue)
        {
        }

        public BarbeMoustache(Serial serial)
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
