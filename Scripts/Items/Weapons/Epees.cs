using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class EpeeTest : BaseSword
    {
        public override int DefMinDamage { get { return 10; } }
        public override int DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public EpeeTest()
            : base(0x2a14)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "EpeeTest - 10";
        }

        public EpeeTest(Serial serial)
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


    // Une main - Vitesse de 25 à 40
    // Main gauche.
    public class Ferel : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Ferel()
            : base(0x2a06)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Ferel";
        }

        public Ferel(Serial serial)
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

    public class Mirilione : BaseSword
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Mirilione()
            : base(0x2a1a)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Mirilione";
        }

        public Mirilione(Serial serial)
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

    public class Niropie : BaseSword
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Niropie()
            : base(0x2a23)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Niropie";
        }

        public Niropie(Serial serial)
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

    public class Sefrio : BaseSword
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Sefrio()
            : base(0x2a05)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Sefrio";
        }

        public Sefrio(Serial serial)
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

    public class Zarel : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Zarel()
            : base(0x29db)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Zarel";
        }

        public Zarel(Serial serial)
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

    public class Longsword : BaseSword
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Longsword()
            : base(0xf61)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Epee longue";
        }

        public Longsword(Serial serial)
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

    public class Cutlass : BaseSword
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Cutlass()
            : base(0x1441)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Coutelas";
        }

        public Cutlass(Serial serial)
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


    // Main droite.
    public class Astoria : BaseSword
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Astoria()
            : base(0x315a)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Astoria";
        }

        public Astoria(Serial serial)
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

    public class Biliome : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Biliome()
            : base(0x2a1f)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Biliome";
        }

        public Biliome(Serial serial)
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

    public class Dawn : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Dawn()
            : base(0x1441)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Dawn";
        }

        public Dawn(Serial serial)
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

    public class Draglast : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Draglast()
            : base(0x2a1b)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Draglast";
        }

        public Draglast(Serial serial)
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

    public class Dravene : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Dravene()
            : base(0x29d4)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Dravene";
        }

        public Dravene(Serial serial)
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

    public class Gerumir : BaseSword
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Gerumir()
            : base(0x2a21)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Gerumir";
        }

        public Gerumir(Serial serial)
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

    public class Hectmore : BaseSword
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Hectmore()
            : base(0x2a21)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Hectmore";
        }

        public Hectmore(Serial serial)
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

    public class Lerise : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Lerise()
            : base(0x29d3)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Lerise";
        }

        public Lerise(Serial serial)
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

    public class Merlame : BaseSword
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Merlame()
            : base(0x2a24)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Merlame";
        }

        public Merlame(Serial serial)
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

    public class Mersang : BaseSword
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Mersang()
            : base(0x2a1d)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Mersang";
        }

        public Mersang(Serial serial)
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

    public class Myliron : BaseSword
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Myliron()
            : base(0x2a0b)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Myliron";
        }

        public Myliron(Serial serial)
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

    public class Narvegne : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Narvegne()
            : base(0x2a0b)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Narvegne";
        }

        public Narvegne(Serial serial)
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

    public class Prisienne : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Prisienne()
            : base(0x2a19)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Prisienne";
        }

        public Prisienne(Serial serial)
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

    public class Raghash : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Raghash()
            : base(0x2a18)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Raghash";
        }

        public Raghash(Serial serial)
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

    public class Rodere : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 13; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Rodere()
            : base(0x2a18)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Rodere";
        }

        public Rodere(Serial serial)
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

    public class Runire : BaseSword
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Runire()
            : base(0x2a27)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Runire";
        }

        public Runire(Serial serial)
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

    public class Sabre : BaseSword
    {
        public override int DefMinDamage { get { return 3; } }
        public override int DefMaxDamage { get { return 7; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Sabre()
            : base(0x2a1c)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Sabre";
        }

        public Sabre(Serial serial)
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

    public class Scimitar : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 11; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Scimitar()
            : base(0x13b6)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Cimeterre";
        }

        public Scimitar(Serial serial)
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

    public class Vorlame : BaseSword
    {
        public override int DefMinDamage { get { return 5; } }
        public override int DefMaxDamage { get { return 9; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Vorlame()
            : base(0x13b6)
        {
            Weight = 5.0;
            Layer = Layer.OneHanded;
            Name = "Vorlame";
        }

        public Vorlame(Serial serial)
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

    // Deux mains - Vitesse de 25 à 45

    public class Abysse : BaseSword
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Abysse()
            : base(0x315f)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Abysse";
        }

        public Abysse(Serial serial)
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

    public class Atargne : BaseSword
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Atargne()
            : base(0x2a0c)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Atargne";
        }

        public Atargne(Serial serial)
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

    public class Auderre : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Auderre()
            : base(0x29d6)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Auderre";
        }

        public Auderre(Serial serial)
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

    public class Batarde : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Batarde()
            : base(0x2a16)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Batarde";
        }

        public Batarde(Serial serial)
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

    public class Conquise : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Conquise()
            : base(0x2a07)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Conquise";
        }

        public Conquise(Serial serial)
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

    public class Couliere : BaseSword
    {
        public override int DefMinDamage { get { return 6; } }
        public override int DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Couliere()
            : base(0x2a1e)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Couliere";
        }

        public Couliere(Serial serial)
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

    public class Dorleane : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Dorleane()
            : base(0x29d2)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Dorleane";
        }

        public Dorleane(Serial serial)
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

    public class Excalior : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Excalior()
            : base(0x2a0e)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Excalior";
        }

        public Excalior(Serial serial)
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

    public class Nerfille : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Nerfille()
            : base(0x2a09)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Nerfille";
        }

        public Nerfille(Serial serial)
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

    public class Nhilarte : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Nhilarte()
            : base(0x29d7)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Nhilarte";
        }

        public Nhilarte(Serial serial)
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

    public class Querquoise : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Querquoise()
            : base(0x2a0a)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Querquoise";
        }

        public Querquoise(Serial serial)
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

    public class Tranchevil : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Tranchevil()
            : base(0x2a0d)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Tranchevil";
        }

        public Tranchevil(Serial serial)
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

    public class Ventmore : BaseSword
    {
        public override int DefMinDamage { get { return 6; } }
        public override int DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Ventmore()
            : base(0x29d1)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Ventmore";
        }

        public Ventmore(Serial serial)
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

    public class Vifcoupe : BaseSword
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Vifcoupe()
            : base(0x29d5)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Vifcoupe";
        }

        public Vifcoupe(Serial serial)
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

    public class Granlame : BaseSword
    {
        public override int DefMinDamage { get { return 13; } }
        public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Granlame()
            : base(0x2a28)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Granlame";
        }

        public Granlame(Serial serial)
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

    public class Courbelle : BaseSword
    {
        public override int DefMinDamage { get { return 13; } }
        public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Courbelle()
            : base(0x2a10)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Courbelle";
        }

        public Courbelle(Serial serial)
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

    public class Espadon : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Espadon()
            : base(0x13b6)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Espadon";
        }

        public Espadon(Serial serial)
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

    public class Flamberge : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public Flamberge()
            : base(0x2a08)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Flamberge";
        }

        public Flamberge(Serial serial)
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

    public class Marquaise : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Marquaise()
            : base(0x29d9)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Marquaise";
        }

        public Marquaise(Serial serial)
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

    public class Monarque : BaseSword
    {
        public override int DefMinDamage { get { return 7; } }
        public override int DefMaxDamage { get { return 12; } }
        public override int DefSpeed { get { return 30; } }

        [Constructable]
        public Monarque()
            : base(0x29d8)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Monarque";
        }

        public Monarque(Serial serial)
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

    public class Morsame : BaseSword
    {
        public override int DefMinDamage { get { return 13; } }
        public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Morsame()
            : base(0x2a13)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Morsame";
        }

        public Morsame(Serial serial)
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

    public class Mortimer : BaseSword
    {
        public override int DefMinDamage { get { return 13; } }
        public override int DefMaxDamage { get { return 18; } }
        public override int DefSpeed { get { return 45; } }

        [Constructable]
        public Mortimer()
            : base(0x2a12)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Mortimer";
        }

        public Mortimer(Serial serial)
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

    public class Rougegorge : BaseSword
    {
        public override int DefMinDamage { get { return 6; } }
        public override int DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Rougegorge()
            : base(0x2a15)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Rougegorge";
        }

        public Rougegorge(Serial serial)
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

    public class Sombrimur : BaseSword
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Sombrimur()
            : base(0x13b6)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Sombrimur";
        }

        public Sombrimur(Serial serial)
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

    public class Tranchor : BaseSword
    {
        public override int DefMinDamage { get { return 11; } }
        public override int DefMaxDamage { get { return 16; } }
        public override int DefSpeed { get { return 40; } }

        [Constructable]
        public Tranchor()
            : base(0x2a20)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Tranchor";
        }

        public Tranchor(Serial serial)
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

    public class VikingSword : BaseSword
    {
        public override int DefMinDamage { get { return 9; } }
        public override int DefMaxDamage { get { return 14; } }
        public override int DefSpeed { get { return 35; } }

        [Constructable]
        public VikingSword()
            : base(0x13b9)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Epee de viking";
        }

        public VikingSword(Serial serial)
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

    public class Zweihander : BaseSword
    {
        public override int DefMinDamage { get { return 6; } }
        public override int DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Zweihander()
            : base(0x29da)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Zweihander";
        }

        public Zweihander(Serial serial)
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

    public class Claymore : BaseSword
    {
        public override int DefMinDamage { get { return 6; } }
        public override int DefMaxDamage { get { return 10; } }
        public override int DefSpeed { get { return 25; } }

        [Constructable]
        public Claymore()
            : base(0x29d0)
        {
            Weight = 5.0;
            Layer = Layer.TwoHanded;
            Name = "Claymore";
        }

        public Claymore(Serial serial)
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
