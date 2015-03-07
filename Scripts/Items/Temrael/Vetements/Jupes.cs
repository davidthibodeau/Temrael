using System;
using Server.Items;

namespace Server.Items
{
    public class JupeDaedric : BasePants
    {
        [Constructable]
        public JupeDaedric()
            : this(0)
        {
        }

        [Constructable]
        public JupeDaedric(int hue)
            : base(0x2B0B, hue)
        {
            Weight = 5.0;
            Name = "Jupe Daedric";
        }

        public JupeDaedric(Serial serial)
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

    public class JupeLongueBarbare : BasePants
    {
        [Constructable]
        public JupeLongueBarbare()
            : this(0)
        {
        }

        [Constructable]
        public JupeLongueBarbare(int hue)
            : base(0x2727, hue)
        {
            Weight = 5.0;
            Name = "Jupe Longue Barbare";
        }

        public JupeLongueBarbare(Serial serial)
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
    public class JupeCourteBarbare : BasePants
    {
        [Constructable]
        public JupeCourteBarbare()
            : this(0)
        {
        }

        [Constructable]
        public JupeCourteBarbare(int hue)
            : base(0x2728, hue)
        {
            Weight = 5.0;
            Name = "Jupe Courte Barbare";
        }

        public JupeCourteBarbare(Serial serial)
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
    public class JupeBordel : BasePants
    {
        [Constructable]
        public JupeBordel()
            : this(0)
        {
        }

        [Constructable]
        public JupeBordel(int hue)
            : base(0x272B, hue)
        {
            Weight = 5.0;
            Name = "Jupe Bordel";
        }

        public JupeBordel(Serial serial)
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
    public class Jupette : BasePants
    {
        [Constructable]
        public Jupette()
            : this(0)
        {
        }

        [Constructable]
        public Jupette(int hue)
            : base(0x2740, hue)
        {
            Weight = 5.0;
            Name = "Jupette";
        }

        public Jupette(Serial serial)
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
    public class Jupe : BasePants
    {
        [Constructable]
        public Jupe()
            : this(0)
        {
        }

        [Constructable]
        public Jupe(int hue)
            : base(0x2741, hue)
        {
            Weight = 5.0;
            Name = "Jupe";
        }

        public Jupe(Serial serial)
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
    public class JupeHakama : BasePants
    {
        [Constructable]
        public JupeHakama()
            : this(0)
        {
        }

        [Constructable]
        public JupeHakama(int hue)
            : base(0x2742, hue)
        {
            Weight = 5.0;
            Name = "Hakama";
        }

        public JupeHakama(Serial serial)
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
    public class JupeLongue : BasePants
    {
        [Constructable]
        public JupeLongue()
            : this(0)
        {
        }

        [Constructable]
        public JupeLongue(int hue)
            : base(0x2743, hue)
        {
            Weight = 5.0;
            Name = "Jupe Longue";
        }

        public JupeLongue(Serial serial)
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
    public class JupeAmple : BasePants
    {
        [Constructable]
        public JupeAmple()
            : this(0)
        {
        }

        [Constructable]
        public JupeAmple(int hue)
            : base(0x2744, hue)
        {
            Weight = 5.0;
            Name = "Jupe Ample";
        }

        public JupeAmple(Serial serial)
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
    public class JupeElfique : BasePants
    {
        [Constructable]
        public JupeElfique()
            : this(0)
        {
        }

        [Constructable]
        public JupeElfique(int hue)
            : base(0x2892, hue)
        {
            Weight = 5.0;
            Name = "Jupe Elfique";
        }

        public JupeElfique(Serial serial)
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
    public class JupeOrient : BasePants
    {
        [Constructable]
        public JupeOrient()
            : this(0)
        {
        }

        [Constructable]
        public JupeOrient(int hue)
            : base(0x2BE6, hue)
        {
            Weight = 5.0;
            Name = "Jupe d'Orient";
        }

        public JupeOrient(Serial serial)
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
    public class JupeCuir : BasePants
    {
        [Constructable]
        public JupeCuir()
            : this(0)
        {
        }

        [Constructable]
        public JupeCuir(int hue)
            : base(0x312B, hue)
        {
            Weight = 5.0;
            Name = "Jupe de Cuir";
        }

        public JupeCuir(Serial serial)
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
    public class JupeOuvrier : BasePants
    {
        [Constructable]
        public JupeOuvrier()
            : this(0)
        {
        }

        [Constructable]
        public JupeOuvrier(int hue)
            : base(0x314B, hue)
        {
            Weight = 5.0;
            Name = "Jupe d'Ouvrier";
        }

        public JupeOuvrier(Serial serial)
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
    public class JupeGrande : BasePants
    {
        [Constructable]
        public JupeGrande()
            : this(0)
        {
        }

        [Constructable]
        public JupeGrande(int hue)
            : base(0x315C, hue)
        {
            Weight = 5.0;
            Name = "Grande Jupe";
        }

        public JupeGrande(Serial serial)
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
    public class JupeOrcish : BasePants
    {
        [Constructable]
        public JupeOrcish()
            : this(0)
        {
        }

        [Constructable]
        public JupeOrcish(int hue)
            : base(0x315D, hue)
        {
            Weight = 5.0;
            Name = "Jupe Orcish";
        }

        public JupeOrcish(Serial serial)
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
    public class JupeCourte : BasePants
    {
        [Constructable]
        public JupeCourte()
            : this(0)
        {
        }

        [Constructable]
        public JupeCourte(int hue)
            : base(0x3168, hue)
        {
            Weight = 5.0;
            Name = "Jupe Courte";
        }

        public JupeCourte(Serial serial)
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
    public class JupeOuverte : BasePants
    {
        [Constructable]
        public JupeOuverte()
            : this(0)
        {
        }

        [Constructable]
        public JupeOuverte(int hue)
            : base(0x3173, hue)
        {
            Weight = 5.0;
            Name = "Jupe Ouverte";
        }

        public JupeOuverte(Serial serial)
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
    public class JupeDecore : BasePants
    {
        [Constructable]
        public JupeDecore()
            : this(0)
        {
        }

        [Constructable]
        public JupeDecore(int hue)
            : base(0x3174, hue)
        {
            Weight = 5.0;
            Name = "Jupe Decore";
        }

        public JupeDecore(Serial serial)
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
    public class JupeAPans : BasePants
    {
        [Constructable]
        public JupeAPans()
            : this(0)
        {
        }

        [Constructable]
        public JupeAPans(int hue)
            : base(0x3175, hue)
        {
            Weight = 5.0;
            Name = "Jupe a Pans";
        }

        public JupeAPans(Serial serial)
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
    public class JupeNoble : BasePants
    {
        [Constructable]
        public JupeNoble()
            : this(0)
        {
        }

        [Constructable]
        public JupeNoble(int hue)
            : base(0x3176, hue)
        {
            Weight = 5.0;
            Name = "Jupe Noble";
        }

        public JupeNoble(Serial serial)
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
    public class JupeNomade : BasePants
    {
        [Constructable]
        public JupeNomade()
            : this(0)
        {
        }

        [Constructable]
        public JupeNomade(int hue)
            : base(0x3181, hue)
        {
            Weight = 5.0;
            Name = "Jupe Nomade";
        }

        public JupeNomade(Serial serial)
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
