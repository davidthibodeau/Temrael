using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class EssenceSouci : BaseTeinture
    {
        public override int Couleur { get { return 2146; } }

        [Constructable]
        public EssenceSouci()
            : base(0xE28)
        {
            Weight = 0.1;
            Name = "Essence de Souci";
            Hue = 2146;
        }

        public EssenceSouci(Serial s)
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

    public class EssenceImmortelle : BaseTeinture
    {
        public override int Couleur { get { return 2171; } }

        [Constructable]
        public EssenceImmortelle()
            : base(0xE28)
        {
            Weight = 0.1;
            Name = "Essence de l'Immortelle";
            Hue = 2171;
        }

        public EssenceImmortelle(Serial s)
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

    public class EssenceKalmia : BaseTeinture
    {
        public override int Couleur { get { return 2039; } }

        [Constructable]
        public EssenceKalmia()
            : base(0xE28)
        {
            Weight = 0.1;
            Name = "Essence de Kalmia";
            Hue = 2039;
        }

        public EssenceKalmia(Serial s)
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

    public class EssenceAgastache : BaseTeinture
    {
        public override int Couleur { get { return 2045; } }

        [Constructable]
        public EssenceAgastache()
            : base(0xE28)
        {
            Weight = 0.1;
            Name = "Essence d'Agastache";
            Hue = 2045;
        }

        public EssenceAgastache(Serial s)
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

    public class EssenceMelaleuca : BaseTeinture
    {
        public override int Couleur { get { return 2065; } }

        [Constructable]
        public EssenceMelaleuca()
            : base(0xE28)
        {
            Weight = 0.1;
            Name = "Essence de Melaleuca";
            Hue = 2065;
        }

        public EssenceMelaleuca(Serial s)
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

    public class EssenceAirelleRouge : BaseTeinture
    {
        public override int Couleur { get { return 2160; } }

        [Constructable]
        public EssenceAirelleRouge()
            : base(0xE28)
        {
            Weight = 0.1;
            Name = "Essence d'Airelle Rouge";
            Hue = 2160;
        }

        public EssenceAirelleRouge(Serial s)
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

    public class EssenceAchillee : BaseTeinture
    {
        public override int Couleur { get { return 2396; } }

        [Constructable]
        public EssenceAchillee()
            : base(0xE28)
        {
            Weight = 0.1;
            Name = "Essence d'Achillée";
            Hue = 2396;
        }

        public EssenceAchillee(Serial s)
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

    public class EssencedeCiste : BaseTeinture
    {
        public override int Couleur { get { return 2076; } }

        [Constructable]
        public EssencedeCiste()
            : base(0xE28)
        {
            Weight = 0.1;
            Name = "Essence de Ciste";
            Hue = 2076;
        }

        public EssencedeCiste(Serial s)
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
