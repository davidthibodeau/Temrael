using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class TeintureMiel : BaseTeinture
    {
        public override int Couleur { get { return 1940; } }

        [Constructable]
        public TeintureMiel()
            : base(0xF8F)
        {
            Weight = 0.1;
            Name = "Teinture de miel";
            Hue = 1940;
        }

        public TeintureMiel(Serial s)
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

    public class TeintureFumier : BaseTeinture
    {
        public override int Couleur { get { return 2167; } }

        [Constructable]
        public TeintureFumier()
            : base(0xF8F)
        {
            Weight = 0.1;
            Name = "Teinture de fumier";
            Hue = 2167;
        }

        public TeintureFumier(Serial s)
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

    public class TeinturePerleNoire : BaseTeinture
    {
        public override int Couleur { get { return 2167; } }

        [Constructable]
        public TeinturePerleNoire()
            : base(0xF8F)
        {
            Weight = 0.1;
            Name = "Teinture de perles noires";
            Hue = 2167;
        }

        public TeinturePerleNoire(Serial s)
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

    public class TeintureExtraitDatte : BaseTeinture
    {
        public override int Couleur { get { return 1942; } }

        [Constructable]
        public TeintureExtraitDatte()
            : base(0xF8F)
        {
            Weight = 0.1;
            Name = "Teinture d'extraits de dattes";
            Hue = 1942;
        }

        public TeintureExtraitDatte(Serial s)
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

    public class TeinturePlumeBlanche : BaseTeinture
    {
        public override int Couleur { get { return 2053; } }

        [Constructable]
        public TeinturePlumeBlanche()
            : base(0xF8F)
        {
            Weight = 0.1;
            Name = "Teinture de plumes blanches";
            Hue = 2053;
        }

        public TeinturePlumeBlanche(Serial s)
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

    public class TeinturePierreVolcanique : BaseTeinture
    {
        public override int Couleur { get { return 2381; } }

        [Constructable]
        public TeinturePierreVolcanique()
            : base(0xF8F)
        {
            Weight = 0.1;
            Name = "Teinture de pierres volcanique";
            Hue = 2381;
        }

        public TeinturePierreVolcanique(Serial s)
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

    public class TeinturePeauSerpent : BaseTeinture
    {
        public override int Couleur { get { return 2391; } }

        [Constructable]
        public TeinturePeauSerpent()
            : base(0xF8F)
        {
            Weight = 0.1;
            Name = "Teinture de peaux de serpent";
            Hue = 2391;
        }

        public TeinturePeauSerpent(Serial s)
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

    public class TeintureGueuleLoup : BaseTeinture
    {
        public override int Couleur { get { return 2325; } }

        [Constructable]
        public TeintureGueuleLoup()
            : base(0xF8F)
        {
            Weight = 0.1;
            Name = "Teinture de gueule de loup";
            Hue = 2325;
        }

        public TeintureGueuleLoup(Serial s)
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

    public class TeintureEau : BaseTeinture
    {
        public override int Couleur { get { return 2341; } }

        [Constructable]
        public TeintureEau()
            : base(0xF8F)
        {
            Weight = 0.1;
            Name = "Teinture d'eau";
            Hue = 2341;
        }

        public TeintureEau(Serial s)
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
