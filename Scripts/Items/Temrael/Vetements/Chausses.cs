using System;
using Server.Items;

namespace Server.Items
{
    public class BottesBoucles : BaseShoes
    {
        [Constructable]
        public BottesBoucles()
            : this(0)
        {
        }

        [Constructable]
        public BottesBoucles(int hue)
            : base(0x2731, hue)
        {
            Weight = 5.0;
            Name = "Bottes Boucles";
        }

        public BottesBoucles(Serial serial)
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
    public class Bottes : BaseShoes
    {
        [Constructable]
        public Bottes()
            : this(0)
        {
        }

        [Constructable]
        public Bottes(int hue)
            : base(0x2732, hue)
        {
            Weight = 5.0;
            Name = "Bottes";
        }

        public Bottes(Serial serial)
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
    public class SouliersBoucles : BaseShoes
    {
        [Constructable]
        public SouliersBoucles()
            : this(0)
        {
        }

        [Constructable]
        public SouliersBoucles(int hue)
            : base(0x2733, hue)
        {
            Weight = 5.0;
            Name = "Souliers Boucles";
        }

        public SouliersBoucles(Serial serial)
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
    public class BottesFourrure : BaseShoes
    {
        [Constructable]
        public BottesFourrure()
            : this(0)
        {
        }

        [Constructable]
        public BottesFourrure(int hue)
            : base(0x2734, hue)
        {
            Weight = 5.0;
            Name = "Bottes de Fourrure";
        }

        public BottesFourrure(Serial serial)
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
    public class BottesNoble : BaseShoes
    {
        [Constructable]
        public BottesNoble()
            : this(0)
        {
        }

        [Constructable]
        public BottesNoble(int hue)
            : base(0x2735, hue)
        {
            Weight = 5.0;
            Name = "Bottes de Noble";
        }

        public BottesNoble(Serial serial)
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
    public class BottesPetites : BaseShoes
    {
        [Constructable]
        public BottesPetites()
            : this(0)
        {
        }

        [Constructable]
        public BottesPetites(int hue)
            : base(0x2736, hue)
        {
            Weight = 5.0;
            Name = "Petites Bottes";
        }

        public BottesPetites(Serial serial)
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
    public class SouliersFourrure : BaseShoes
    {
        [Constructable]
        public SouliersFourrure()
            : this(0)
        {
        }

        [Constructable]
        public SouliersFourrure(int hue)
            : base(0x2737, hue)
        {
            Weight = 5.0;
            Name = "Souliers de Fourrure";
        }

        public SouliersFourrure(Serial serial)
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
    public class BottesSombres : BaseShoes
    {
        [Constructable]
        public BottesSombres()
            : this(0)
        {
        }

        [Constructable]
        public BottesSombres(int hue)
            : base(0x316F, hue)
        {
            Weight = 5.0;
            Name = "Bottes Sombres";
        }

        public BottesSombres(Serial serial)
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
    public class BottesLourdes : BaseShoes
    {
        [Constructable]
        public BottesLourdes()
            : this(0)
        {
        }

        [Constructable]
        public BottesLourdes(int hue)
            : base(0x2FE8, hue)
        {
            Weight = 5.0;
            Name = "Bottes Lourdes";
        }

        public BottesLourdes(Serial serial)
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
    public class BottesVoyage : BaseShoes
    {
        [Constructable]
        public BottesVoyage()
            : this(0)
        {
        }

        [Constructable]
        public BottesVoyage(int hue)
            : base(0x2FE9, hue)
        {
            Weight = 5.0;
            Name = "Bottes de Voyage";
        }

        public BottesVoyage(Serial serial)
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
