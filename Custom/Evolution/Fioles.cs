using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public abstract class BaseFiole : Item
    {
        public virtual int Couleur { get { return 0; } }
        public virtual int Exp { get { return 0; } }

        public override void OnDoubleClick(Mobile from)
        {
            //base.OnDoubleClick(from);
            from.SendMessage("Vous reçevez " + Exp + " points d'expériences !");
            from.XP += Exp;
            this.Delete();
        }

        public BaseFiole(int itemID)
            : base(itemID)
        {
        }

        public BaseFiole(Serial s)
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

    public class FioleNoir : BaseFiole
    {
        public override int Couleur { get { return 2398; } }
        public override int Exp { get { return 200; } }

        [Constructable]
        public FioleNoir()
            : base(3622)
        {
            Weight = 0.1;
            Name = "Fiole d'Expérience";
            Hue = Couleur;
        }

        public FioleNoir(Serial s)
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

    public class FioleRouge : BaseFiole
    {
        public override int Couleur { get { return 2380; } }
        public override int Exp { get { return 400; } }

        [Constructable]
        public FioleRouge()
            : base(3622)
        {
            Weight = 0.1;
            Name = "Fiole d'Expérience";
            Hue = Couleur;
        }

        public FioleRouge(Serial s)
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

    public class FioleVerte : BaseFiole
    {
        public override int Couleur { get { return 2389; } }
        public override int Exp { get { return 800; } }

        [Constructable]
        public FioleVerte()
            : base(3622)
        {
            Weight = 0.1;
            Name = "Fiole d'Expérience";
            Hue = Couleur;
        }

        public FioleVerte(Serial s)
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

    public class FioleBleue : BaseFiole
    {
        public override int Couleur { get { return 2341; } }
        public override int Exp { get { return 1200; } }

        [Constructable]
        public FioleBleue()
            : base(3622)
        {
            Weight = 0.1;
            Name = "Fiole d'Expérience";
            Hue = Couleur;
        }

        public FioleBleue(Serial s)
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
