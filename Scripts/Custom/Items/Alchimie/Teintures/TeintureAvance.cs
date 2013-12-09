using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class HuileSulfureDilue : BaseTeinture
    {
        public override int Couleur { get { return 1944; } }

        [Constructable]
        public HuileSulfureDilue()
            : base(0xEFC)
        {
            Weight = 0.1;
            Name = "Huile de Sulfure Dilué";
            Hue = 1944;
        }

        public HuileSulfureDilue(Serial s)
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

    public class HuileTerreBouillie : BaseTeinture
    {
        public override int Couleur { get { return 2399; } }

        [Constructable]
        public HuileTerreBouillie()
            : base(0xEFC)
        {
            Weight = 0.1;
            Name = "Huile de terre bouillie";
            Hue = 2399;
        }

        public HuileTerreBouillie(Serial s)
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

    public class HuileCendreLiquefie : BaseTeinture
    {
        public override int Couleur { get { return 2041; } }

        [Constructable]
        public HuileCendreLiquefie()
            : base(0xEFC)
        {
            Weight = 0.1;
            Name = "Huile de cendres liquéfié";
            Hue = 2041;
        }

        public HuileCendreLiquefie(Serial s)
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

    public class HuileRaisinFermente : BaseTeinture
    {
        public override int Couleur { get { return 2048; } }

        [Constructable]
        public HuileRaisinFermente()
            : base(0xEFC)
        {
            Weight = 0.1;
            Name = "Huile de raisins fermentés";
            Hue = 2048;
        }

        public HuileRaisinFermente(Serial s)
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

    public class HuileOeufMortifie : BaseTeinture
    {
        public override int Couleur { get { return 2052; } }

        [Constructable]
        public HuileOeufMortifie()
            : base(0xEFC)
        {
            Weight = 0.1;
            Name = "Huile d'oeufs mortifiés";
            Hue = 2052;
        }

        public HuileOeufMortifie(Serial s)
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

    public class HuileSangCoagule : BaseTeinture
    {
        public override int Couleur { get { return 2241; } }

        [Constructable]
        public HuileSangCoagule()
            : base(0xEFC)
        {
            Weight = 0.1;
            Name = "Huile de sang coagulé";
            Hue = 2241;
        }

        public HuileSangCoagule(Serial s)
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

    public class HuileVeninNeutralise : BaseTeinture
    {
        public override int Couleur { get { return 2393; } }

        [Constructable]
        public HuileVeninNeutralise()
            : base(0xEFC)
        {
            Weight = 0.1;
            Name = "Huile de venin neutralisé";
            Hue = 2393;
        }

        public HuileVeninNeutralise(Serial s)
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

    public class HuileCoquillageMacere : BaseTeinture
    {
        public override int Couleur { get { return 2188; } }

        [Constructable]
        public HuileCoquillageMacere()
            : base(0xEFC)
        {
            Weight = 0.1;
            Name = "Huile de coquillages macérés";
            Hue = 2188;
        }

        public HuileCoquillageMacere(Serial s)
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

    public class HuileResineAmbreBleue : BaseTeinture
    {
        public override int Couleur { get { return 2347; } }

        [Constructable]
        public HuileResineAmbreBleue()
            : base(0xEFC)
        {
            Weight = 0.1;
            Name = "Huile de résine d'ambre bleue";
            Hue = 2347;
        }

        public HuileResineAmbreBleue(Serial s)
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
