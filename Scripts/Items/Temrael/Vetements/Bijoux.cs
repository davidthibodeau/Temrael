using System;
using Server.Items;

namespace Server.Items
{
    public class ColierCoquillages : BaseNecklace
    {
        [Constructable]
        public ColierCoquillages()
            : base(0x3171)
        {
            GoldValue = 9;
            Weight = 0.1;
            Name = "Collier de Coquillages";
        }

        public ColierCoquillages(Serial serial)
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
    public class ColierSud : BaseNecklace
    {
        [Constructable]
        public ColierSud()
            : base(0x2647)
        {
            Weight = 0.1;
            Name = "Collier";
        }

        public ColierSud(Serial serial)
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
    public class Bijoux : BaseBracelet
    {
        [Constructable]
        public Bijoux()
            : base(0x264E)
        {
            Weight = 0.1;
            Name = "Bijoux";
        }

        public Bijoux(Serial serial)
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
    public class ColierSimple : BaseNecklace
    {
        [Constructable]
        public ColierSimple()
            : base(0x264F)
        {
            Weight = 0.1;
            Name = "Collier Simple";
        }

        public ColierSimple(Serial serial)
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
    public class ColierOrne : BaseNecklace
    {
        [Constructable]
        public ColierOrne()
            : base(0x2650)
        {
            Weight = 0.1;
            Name = "Collier Orne";
        }

        public ColierOrne(Serial serial)
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
    public class ColierLong : BaseNecklace
    {
        [Constructable]
        public ColierLong()
            : base(0x2651)
        {
            Weight = 0.1;
            Name = "Collier Long";
        }

        public ColierLong(Serial serial)
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
    public class ColierRubis : BaseNecklace
    {
        [Constructable]
        public ColierRubis()
            : base(0x2652)
        {
            Weight = 0.1;
            Name = "Collier de Rubis";
        }

        public ColierRubis(Serial serial)
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
    public class Couronne : BaseHat
    {
        [Constructable]
        public Couronne()
            : base(0x2653)
        {
            Weight = 0.1;
            Name = "Couronne";
        }

        public Couronne(Serial serial)
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
    public class ColierSerpantin : BaseNecklace
    {
        [Constructable]
        public ColierSerpantin()
            : base(0x2654)
        {
            Weight = 0.1;
            Name = "Collier Serpantin";
        }

        public ColierSerpantin(Serial serial)
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
    public class ColierFer : BaseNecklace
    {
        [Constructable]
        public ColierFer()
            : base(0x2655)
        {
            Weight = 0.1;
            Name = "Collier de Fer";
        }

        public ColierFer(Serial serial)
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
    public class ColierSaphyre : BaseNecklace
    {
        [Constructable]
        public ColierSaphyre()
            : base(0x2656)
        {
            Weight = 0.1;
            Name = "Collier de Saphyre";
        }

        public ColierSaphyre(Serial serial)
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
    public class ColierTriple : BaseNecklace
    {
        [Constructable]
        public ColierTriple()
            : base(0x2657)
        {
            Weight = 0.1;
            Name = "Collier Triple";
        }

        public ColierTriple(Serial serial)
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
    public class ColierLargeRubis : BaseNecklace
    {
        [Constructable]
        public ColierLargeRubis()
            : base(0x2658)
        {
            Weight = 0.1;
            Name = "Collier de Large Rubis";
        }

        public ColierLargeRubis(Serial serial)
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
    public class ColierAraignee : BaseNecklace
    {
        [Constructable]
        public ColierAraignee()
            : base(0x2659)
        {
            Weight = 0.1;
            Name = "Collier Araignee";
        }

        public ColierAraignee(Serial serial)
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
    public class ColierDents : BaseNecklace
    {
        [Constructable]
        public ColierDents()
            : base(0x265A)
        {
            Weight = 0.1;
            Name = "Collier de Dents";
        }

        public ColierDents(Serial serial)
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
    public class ColierNordique : BaseNecklace
    {
        [Constructable]
        public ColierNordique()
            : base(0x265B)
        {
            Weight = 0.1;
            Name = "Collier Nordique";
        }

        public ColierNordique(Serial serial)
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
    public class ColierEmeraudes : BaseNecklace
    {
        [Constructable]
        public ColierEmeraudes()
            : base(0x265C)
        {
            Weight = 0.1;
            Name = "Collier d'Emeraudes";
        }

        public ColierEmeraudes(Serial serial)
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
    public class Diaphene : BaseNecklace
    {
        [Constructable]
        public Diaphene()
            : base(0x265D)
        {
            Weight = 0.1;
            Name = "Diaphene";
        }

        public Diaphene(Serial serial)
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
    public class BracerMetal : BaseBrassards
    {
        [Constructable]
        public BracerMetal()
            : base(0x2686)
        {
            GoldValue = 9;
            Weight = 0.1;
            Name = "Bracer de Metal";
        }

        public BracerMetal(Serial serial)
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
