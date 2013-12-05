using System;
using Server.Items;

namespace Server.Items
{
    public class ChandailLongBarbare : BaseMiddleTorso
    {
        [Constructable]
        public ChandailLongBarbare()
            : this(0)
        {
        }

        [Constructable]
        public ChandailLongBarbare(int hue)
            : base(0x2726, hue)
        {
            Weight = 5.0;
            Name = "Chandail Long Barbare";
        }

        public ChandailLongBarbare(Serial serial)
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
    public class ChandailCourtBarbare : BaseMiddleTorso
    {
        [Constructable]
        public ChandailCourtBarbare()
            : this(0)
        {
        }

        [Constructable]
        public ChandailCourtBarbare(int hue)
            : base(0x2729, hue)
        {
            Weight = 5.0;
            Name = "Chandail Court Barbare";
        }

        public ChandailCourtBarbare(Serial serial)
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
    public class ChandailBordel : BaseMiddleTorso
    {
        [Constructable]
        public ChandailBordel()
            : this(0)
        {
        }

        [Constructable]
        public ChandailBordel(int hue)
            : base(0x272A, hue)
        {
            Weight = 5.0;
            Name = "Chandail Bordel";
        }

        public ChandailBordel(Serial serial)
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
    public class ChemiseAmple : BaseMiddleTorso
    {
        [Constructable]
        public ChemiseAmple()
            : this(0)
        {
        }

        [Constructable]
        public ChemiseAmple(int hue)
            : base(0x2745, hue)
        {
            Weight = 5.0;
            Name = "Chemise Ample";
        }

        public ChemiseAmple(Serial serial)
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
    public class ChemiseCol : BaseMiddleTorso
    {
        [Constructable]
        public ChemiseCol()
            : this(0)
        {
        }

        [Constructable]
        public ChemiseCol(int hue)
            : base(0x2747, hue)
        {
            Weight = 5.0;
            Name = "Chemise a Col";
        }

        public ChemiseCol(Serial serial)
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
    public class ChemiseNoble : BaseMiddleTorso
    {
        [Constructable]
        public ChemiseNoble()
            : this(0)
        {
        }

        [Constructable]
        public ChemiseNoble(int hue)
            : base(0x274A, hue)
        {
            Weight = 5.0;
            Name = "Chemise Noble";
        }

        public ChemiseNoble(Serial serial)
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
    public class ChemiseGaine : BaseMiddleTorso
    {
        [Constructable]
        public ChemiseGaine()
            : this(0)
        {
        }

        [Constructable]
        public ChemiseGaine(int hue)
            : base(0x274B, hue)
        {
            Weight = 5.0;
            Name = "Chemise a Gaine";
        }

        public ChemiseGaine(Serial serial)
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
    public class ChandailVieux : BaseMiddleTorso
    {
        [Constructable]
        public ChandailVieux()
            : this(0)
        {
        }

        [Constructable]
        public ChandailVieux(int hue)
            : base(0x274C, hue)
        {
            Weight = 5.0;
            Name = "Vieux Chandail";
        }

        public ChandailVieux(Serial serial)
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
    public class ChandailDechire : BaseMiddleTorso
    {
        [Constructable]
        public ChandailDechire()
            : this(0)
        {
        }

        [Constructable]
        public ChandailDechire(int hue)
            : base(0x2750, hue)
        {
            Weight = 5.0;
            Name = "Chandail Dechire";
        }

        public ChandailDechire(Serial serial)
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
    public class Chemiselacee : BaseMiddleTorso
    {
        [Constructable]
        public Chemiselacee()
            : this(0)
        {
        }

        [Constructable]
        public Chemiselacee(int hue)
            : base(0x2751, hue)
        {
            Weight = 5.0;
            Name = "Chandail Lacee";
        }

        public Chemiselacee(Serial serial)
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
    public class ChemiseLongue : BaseMiddleTorso
    {
        [Constructable]
        public ChemiseLongue()
            : this(0)
        {
        }

        [Constructable]
        public ChemiseLongue(int hue)
            : base(0x2753, hue)
        {
            Weight = 5.0;
            Name = "Chemise Longue";
        }

        public ChemiseLongue(Serial serial)
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
    public class ChandailMarin : BaseMiddleTorso
    {
        [Constructable]
        public ChandailMarin()
            : this(0)
        {
        }

        [Constructable]
        public ChandailMarin(int hue)
            : base(0x2759, hue)
        {
            Weight = 5.0;
            Name = "Chandail Marin";
        }

        public ChandailMarin(Serial serial)
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
    public class ChemiseReligieuse : BaseMiddleTorso
    {
        [Constructable]
        public ChemiseReligieuse()
            : this(0)
        {
        }

        [Constructable]
        public ChemiseReligieuse(int hue)
            : base(0x275C, hue)
        {
            Weight = 5.0;
            Name = "Chemise Religieuse";
        }

        public ChemiseReligieuse(Serial serial)
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
    public class ChemiseElfique : BaseMiddleTorso
    {
        [Constructable]
        public ChemiseElfique()
            : this(0)
        {
        }

        [Constructable]
        public ChemiseElfique(int hue)
            : base(0x275D, hue)
        {
            Weight = 5.0;
            Name = "Chemise Elfique";
        }

        public ChemiseElfique(Serial serial)
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
    public class ChandailFeminin : BaseMiddleTorso
    {
        [Constructable]
        public ChandailFeminin()
            : this(0)
        {
        }

        [Constructable]
        public ChandailFeminin(int hue)
            : base(0x2761, hue)
        {
            Weight = 5.0;
            Name = "Chandail Feminin";
        }

        public ChandailFeminin(Serial serial)
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
    public class ChandailCourt : BaseMiddleTorso
    {
        [Constructable]
        public ChandailCourt()
            : this(0)
        {
        }

        [Constructable]
        public ChandailCourt(int hue)
            : base(0x2762, hue)
        {
            Weight = 5.0;
            Name = "Chandail Court";
        }

        public ChandailCourt(Serial serial)
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
    public class ChandailSoutienGorge : BaseMiddleTorso
    {
        [Constructable]
        public ChandailSoutienGorge()
            : this(0)
        {
        }

        [Constructable]
        public ChandailSoutienGorge(int hue)
            : base(0x2774, hue)
        {
            Weight = 5.0;
            Name = "Soutien Gorge";
        }

        public ChandailSoutienGorge(Serial serial)
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
    public class ChandailNoble : BaseMiddleTorso
    {
        [Constructable]
        public ChandailNoble()
            : this(0)
        {
        }

        [Constructable]
        public ChandailNoble(int hue)
            : base(0x2775, hue)
        {
            Weight = 5.0;
            Name = "Chandail Noble";
        }

        public ChandailNoble(Serial serial)
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
    public class ChandailCourtDechire : BaseMiddleTorso
    {
        [Constructable]
        public ChandailCourtDechire()
            : this(0)
        {
        }

        [Constructable]
        public ChandailCourtDechire(int hue)
            : base(0x277C, hue)
        {
            Weight = 5.0;
            Name = "Chandail Court Dechire";
        }

        public ChandailCourtDechire(Serial serial)
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
    public class Chandail : BaseMiddleTorso
    {
        [Constructable]
        public Chandail()
            : this(0)
        {
        }

        [Constructable]
        public Chandail(int hue)
            : base(0x277E, hue)
        {
            Weight = 5.0;
            Name = "Chandail";
        }

        public Chandail(Serial serial)
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
    public class ChandailLongDechire : BaseMiddleTorso
    {
        [Constructable]
        public ChandailLongDechire()
            : this(0)
        {
        }

        [Constructable]
        public ChandailLongDechire(int hue)
            : base(0x2782, hue)
        {
            Weight = 5.0;
            Name = "Chandail Long Dechire";
        }

        public ChandailLongDechire(Serial serial)
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
    public class ChemiseBourgeoise : BaseMiddleTorso
    {
        [Constructable]
        public ChemiseBourgeoise()
            : this(0)
        {
        }

        [Constructable]
        public ChemiseBourgeoise(int hue)
            : base(0x2783, hue)
        {
            Weight = 5.0;
            Name = "Chemise Bourgeoise";
        }

        public ChemiseBourgeoise(Serial serial)
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
    public class ChandailDecore : BaseMiddleTorso
    {
        [Constructable]
        public ChandailDecore()
            : this(0)
        {
        }

        [Constructable]
        public ChandailDecore(int hue)
            : base(0x316B, hue)
        {
            Weight = 5.0;
            Name = "Chandail Decoré";
        }

        public ChandailDecore(Serial serial)
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
    public class ChandailSombre : BaseMiddleTorso
    {
        [Constructable]
        public ChandailSombre()
            : this(0)
        {
        }

        [Constructable]
        public ChandailSombre(int hue)
            : base(0x316C, hue)
        {
            Weight = 5.0;
            Name = "Chandail Decoré";
        }

        public ChandailSombre(Serial serial)
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
    public class ChemiseOrient : BaseMiddleTorso
    {
        [Constructable]
        public ChemiseOrient()
            : this(0)
        {
        }

        [Constructable]
        public ChemiseOrient(int hue)
            : base(0x316D, hue)
        {
            Weight = 5.0;
            Name = "Chandail d'Orient";
        }

        public ChemiseOrient(Serial serial)
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
    public class ChandailCombat : BaseMiddleTorso
    {
        [Constructable]
        public ChandailCombat()
            : this(0)
        {
        }

        [Constructable]
        public ChandailCombat(int hue)
            : base(0x317F, hue)
        {
            Weight = 5.0;
            Name = "Chandail de Combat";
        }

        public ChandailCombat(Serial serial)
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
    public class CorsetOuvert : BaseMiddleTorso
    {
        [Constructable]
        public CorsetOuvert()
            : this(0)
        {
        }

        [Constructable]
        public CorsetOuvert(int hue)
            : base(0x3172, hue)
        {
            Weight = 5.0;
            Name = "Corset Ouvert";
        }

        public CorsetOuvert(Serial serial)
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
