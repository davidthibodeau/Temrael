using System;
using Server.Items;
using Server.Network;
using Server.Engines.Harvest;

namespace Server.Items
{
    // Une main
    public class Ecracheur : BaseBashing
    {
        public override int DefMinDamage { get { return 10; } }
        public override int DefMaxDamage { get { return 15; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Ecracheur()
            : base(0x3044)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Ecracheur";
        }

        public Ecracheur(Serial serial)
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

    public class Ecraseface : BaseBashing
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Ecraseface()
            : base(0x2964)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Ecraseface";
        }

        public Ecraseface(Serial serial)
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

    public class Mace : BaseBashing
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Mace()
            : base(0xf5c)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Etoile du matin";
        }

        public Mace(Serial serial)
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

    public class Massue : BaseBashing
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Massue()
            : base(0x3043)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Massue";
        }

        public Massue(Serial serial)
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

    public class WarMace : BaseBashing
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public WarMace()
            : base(0x1407)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Masse de guerre";
        }

        public WarMace(Serial serial)
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

    public class Defonceur : BaseBashing
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Defonceur()
            : base(0x2963)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Defonceur";
        }

        public Defonceur(Serial serial)
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

    public class Brisecrane : BaseBashing
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Brisecrane()
            : base(0x0000)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Brisecrane";
        }

        public Brisecrane(Serial serial)
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

    public class Fleau : BaseBashing
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Fleau()
            : base(0x295f)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Fleau";
        }

        public Fleau(Serial serial)
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

    public class Gourdin : BaseBashing
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Gourdin()
            : base(0x2965)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Gourdin";
        }

        public Gourdin(Serial serial)
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

    public class Gourpic : BaseBashing
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Gourpic()
            : base(0x2966)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Gourpic";
        }

        public Gourpic(Serial serial)
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

    public class Club : BaseBashing
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Club()
            : base(0x13b4)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Baton avec un clou";
        }

        public Club(Serial serial)
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

    public class Pickaxe : BaseBashing
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        public virtual HarvestSystem HarvestSystem { get { return Mining.System; } }

        [Constructable]
        public Pickaxe()
            : base(0xe86)
        {
            Weight = 4.0;
            Layer = Layer.OneHanded;
            Name = "Pioche";
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (HarvestSystem == null || Deleted)
                return;

            Point3D loc = this.GetWorldLocation();

            if (!from.InLOS(loc) || !from.InRange(loc, 2))
            {
                from.LocalOverheadMessage(Server.Network.MessageType.Regular, 0x3E9, 1019045); // I can't reach that
                return;
            }
            else if (!this.IsAccessibleTo(from))
            {
                this.PublicOverheadMessage(Server.Network.MessageType.Regular, 0x3E9, 1061637); // You are not allowed to access this.
                return;
            }

            if (!(this.HarvestSystem is Mining))
                from.SendLocalizedMessage(1010018); // What do you want to use this item on?

            HarvestSystem.BeginHarvesting(from, this);
        }

        public Pickaxe(Serial serial)
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


    // Deux mains
    public class Granmace : BaseBashing
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Granmace()
            : base(0x2960)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Grande masse";
        }

        public Granmace(Serial serial)
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

    public class Maul : BaseBashing
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Maul()
            : base(0x143b)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Maul";
        }

        public Maul(Serial serial)
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

    public class Broyeur : BaseBashing
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Broyeur()
            : base(0x3046)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Broyeur";
        }

        public Broyeur(Serial serial)
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

    public class MarteauGuerre : BaseBashing
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public MarteauGuerre()
            : base(0x3045)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Marteau de guerre";
        }

        public MarteauGuerre(Serial serial)
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

    public class WarHammer : BaseBashing
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public WarHammer()
            : base(0x1439)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Ouvreporte";
        }

        public WarHammer(Serial serial)
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

    public class Malert : BaseBashing
    {
        public override int DefMinDamage { get { return 14; } }
        public override int DefMaxDamage { get { return 19; } }
        public override int DefSpeed { get { return 50; } }

        [Constructable]
        public Malert()
            : base(0x317c)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Gourpic";
        }

        public Malert(Serial serial)
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

    public class Batonmace : BaseBashing
    {
        public override int DefMinDamage { get { return 13; } }
        public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Batonmace()
            : base(0x2961)
        {
            Weight = 4.0;
            Layer = Layer.TwoHanded;
            Name = "Baton-masse";
        }

        public Batonmace(Serial serial)
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