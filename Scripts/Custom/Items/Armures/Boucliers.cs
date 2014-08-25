using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class BouclierDecorer : BaseShield
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def6; } }
        public override int BaseContondantResistance { get { return Bouclier_Def6; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def6; } }
        public override int BasePerforantResistance { get { return Bouclier_Def6; } }
        public override int BaseMagieResistance { get { return Bouclier_Def6; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite6; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite6; } }

        public override int AosStrReq { get { return Bouclier_Force6; } }

        public override int ArmorBase { get { return 30; } }

        [Constructable]
        public BouclierDecorer()
            : base(0x2883)
        {
            Weight = 2.0;
            Name = "Bouclier Decoré";
        }

        public BouclierDecorer(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    
    public class BouclierElfique : BaseShield
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def5; } }
        public override int BaseContondantResistance { get { return Bouclier_Def5; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def5; } }
        public override int BasePerforantResistance { get { return Bouclier_Def5; } }
        public override int BaseMagieResistance { get { return Bouclier_Def5; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite5; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite5; } }

        public override int AosStrReq { get { return Bouclier_Force5; } }

        public override int ArmorBase { get { return 10; } }

        [Constructable]
        public BouclierElfique()
            : base(0x289E)
        {
            Weight = 6.0;
            Name = "Bouclier Elfique";
        }

        public BouclierElfique(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
    public class BouclierCuir : BaseShield
    {
        //public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def1; } }
        public override int BaseContondantResistance { get { return Bouclier_Def1; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def1; } }
        public override int BasePerforantResistance { get { return Bouclier_Def1; } }
        public override int BaseMagieResistance { get { return Bouclier_Def1; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite1; } }
        public override int InitMaxHits { get { return Bouclier_MinDurabilite1; } }

        public override int AosStrReq { get { return Bouclier_Force1; } }

        public override int ArmorBase { get { return 10; } }

        [Constructable]
        public BouclierCuir()
            : base(0x2A41)
        {
            Weight = 6.0;
            Name = "Bouclier de Cuir";
        }

        public BouclierCuir(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
    public class BouclierNordique : BaseShield
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def5; } }
        public override int BaseContondantResistance { get { return Bouclier_Def5; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def5; } }
        public override int BasePerforantResistance { get { return Bouclier_Def5; } }
        public override int BaseMagieResistance { get { return Bouclier_Def5; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite5; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite5; } }

        public override int AosStrReq { get { return Bouclier_Force5; } }

        public override int ArmorBase { get { return 10; } }

        [Constructable]
        public BouclierNordique()
            : base(0x2A42)
        {
            Weight = 6.0;
            Name = "Bouclier Nordique";
        }

        public BouclierNordique(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
    public class BouclierChevaleresque : BaseShield
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def5; } }
        public override int BaseContondantResistance { get { return Bouclier_Def5; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def5; } }
        public override int BasePerforantResistance { get { return Bouclier_Def5; } }
        public override int BaseMagieResistance { get { return Bouclier_Def5; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite5; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite5; } }

        public override int AosStrReq { get { return Bouclier_Force5; } }

        public override int ArmorBase { get { return 10; } }

        [Constructable]
        public BouclierChevaleresque()
            : base(0x2A43)
        {
            Weight = 6.0;
            Name = "Bouclier Chevaleresque";
        }

        public BouclierChevaleresque(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
    public class BouclierVieux : BaseShield
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def6; } }
        public override int BaseContondantResistance { get { return Bouclier_Def6; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def6; } }
        public override int BasePerforantResistance { get { return Bouclier_Def6; } }
        public override int BaseMagieResistance { get { return Bouclier_Def6; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite6; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite6; } }

        public override int AosStrReq { get { return Bouclier_Force6; } }

        public override int ArmorBase { get { return 10; } }

        [Constructable]
        public BouclierVieux()
            : base(0x2A44)
        {
            Weight = 6.0;
            Name = "Vieux Bouclier";
        }

        public BouclierVieux(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
    public class BouclierComte : BaseShield
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def4; } }
        public override int BaseContondantResistance { get { return Bouclier_Def4; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def4; } }
        public override int BasePerforantResistance { get { return Bouclier_Def4; } }
        public override int BaseMagieResistance { get { return Bouclier_Def4; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite4; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite4; } }

        public override int AosStrReq { get { return Bouclier_Force4; } }

        public override int ArmorBase { get { return 10; } }

        [Constructable]
        public BouclierComte()
            : base(0x2A45)
        {
            Weight = 6.0;
            Name = "Bouclier de Karmilide";
        }

        public BouclierComte(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
    public class BouclierMarquis : BaseShield
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def4; } }
        public override int BaseContondantResistance { get { return Bouclier_Def4; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def4; } }
        public override int BasePerforantResistance { get { return Bouclier_Def4; } }
        public override int BaseMagieResistance { get { return Bouclier_Def4; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite4; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite4; } }

        public override int AosStrReq { get { return Bouclier_Force4; } }

        public override int ArmorBase { get { return 10; } }

        [Constructable]
        public BouclierMarquis()
            : base(0x2A46)
        {
            Weight = 6.0;
            Name = "Bouclier de Faréligue";
        }

        public BouclierMarquis(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
    public class BouclierDuc : BaseShield
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def4; } }
        public override int BaseContondantResistance { get { return Bouclier_Def4; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def4; } }
        public override int BasePerforantResistance { get { return Bouclier_Def4; } }
        public override int BaseMagieResistance { get { return Bouclier_Def4; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite4; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite4; } }

        public override int AosStrReq { get { return Bouclier_Force4; } }

        public override int ArmorBase { get { return 10; } }

        [Constructable]
        public BouclierDuc()
            : base(0x2A47)
        {
            Weight = 6.0;
            Name = "Bouclier d'Horlé";
        }

        public BouclierDuc(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
    public class BouclierPavoisNoir : BaseShield
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def6; } }
        public override int BaseContondantResistance { get { return Bouclier_Def6; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def6; } }
        public override int BasePerforantResistance { get { return Bouclier_Def6; } }
        public override int BaseMagieResistance { get { return Bouclier_Def6; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite6; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite6; } }

        public override int AosStrReq { get { return Bouclier_Force6; } }

        public override int ArmorBase { get { return 10; } }

        [Constructable]
        public BouclierPavoisNoir()
            : base(0x2A48)
        {
            Weight = 6.0;
            Name = "Pavois Royal";
        }

        public BouclierPavoisNoir(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
    public class BouclierGarde : BaseShield
    {
        //public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return Bouclier_Def3; } }
        public override int BaseContondantResistance { get { return Bouclier_Def3; } }
        public override int BaseTranchantResistance { get { return Bouclier_Def3; } }
        public override int BasePerforantResistance { get { return Bouclier_Def3; } }
        public override int BaseMagieResistance { get { return Bouclier_Def3; } }

        public override int InitMinHits { get { return Bouclier_MinDurabilite3; } }
        public override int InitMaxHits { get { return Bouclier_MaxDurabilite3; } }

        public override int AosStrReq { get { return Bouclier_Force3; } }

        public override int ArmorBase { get { return 10; } }

        [Constructable]
        public BouclierGarde()
            : base(0x2A49)
        {
            Weight = 6.0;
            Name = "Bouclier Métallique";
        }

        public BouclierGarde(Serial serial)
            : base(serial)
        {
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);//version
        }
    }
}
