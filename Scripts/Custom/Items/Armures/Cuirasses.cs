using System;
using Server.Items;

namespace Server.Items
{
    public class CuirasseReligieuse : BaseArmor
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return ArmureDivers_Def4; } }
        public override int BaseContondantResistance { get { return ArmureDivers_Def4; } }
        public override int BaseTranchantResistance { get { return ArmureDivers_Def4; } }
        public override int BasePerforantResistance { get { return ArmureDivers_Def4; } }
        public override int BaseMagieResistance { get { return ArmureDivers_Def4; } }

        public override int InitMinHits { get { return ArmureDivers_MinDurabilite4; } }
        public override int InitMaxHits { get { return ArmureDivers_MaxDurabilite4; } }

        public override int AosStrReq { get { return ArmureDivers_Force4; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CuirasseReligieuse()
            : base(0x2876)
        {
            Weight = 2.0;
            Name = "Cuirasse Religieuse";
        }

        public CuirasseReligieuse(Serial serial)
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
    public class TuniqueChaine : BaseArmor
    {
        //public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return ArmureDivers_Def3; } }
        public override int BaseContondantResistance { get { return ArmureDivers_Def3; } }
        public override int BaseTranchantResistance { get { return ArmureDivers_Def3; } }
        public override int BasePerforantResistance { get { return ArmureDivers_Def3; } }
        public override int BaseMagieResistance { get { return ArmureDivers_Def3; } }

        public override int InitMinHits { get { return ArmureDivers_MinDurabilite3; } }
        public override int InitMaxHits { get { return ArmureDivers_MaxDurabilite3; } }

        public override int AosStrReq { get { return ArmureDivers_Force3; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public TuniqueChaine()
            : base(0x2877)
        {
            Weight = 2.0;
            Name = "Tunique de Chaine";
        }

        public TuniqueChaine(Serial serial)
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
    public class Cuirasse : BaseArmor
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return ArmureDivers_Def5; } }
        public override int BaseContondantResistance { get { return ArmureDivers_Def5; } }
        public override int BaseTranchantResistance { get { return ArmureDivers_Def5; } }
        public override int BasePerforantResistance { get { return ArmureDivers_Def5; } }
        public override int BaseMagieResistance { get { return ArmureDivers_Def5; } }

        public override int InitMinHits { get { return ArmureDivers_MinDurabilite5; } }
        public override int InitMaxHits { get { return ArmureDivers_MaxDurabilite5; } }

        public override int AosStrReq { get { return ArmureDivers_Force5; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public Cuirasse()
            : base(0x2881)
        {
            Weight = 2.0;
            Name = "Cuirasse";
        }

        public Cuirasse(Serial serial)
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
    public class CuirasseDraconique : BaseArmor
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return ArmureDivers_Def6; } }
        public override int BaseContondantResistance { get { return ArmureDivers_Def6; } }
        public override int BaseTranchantResistance { get { return ArmureDivers_Def6; } }
        public override int BasePerforantResistance { get { return ArmureDivers_Def6; } }
        public override int BaseMagieResistance { get { return ArmureDivers_Def6; } }

        public override int InitMinHits { get { return ArmureDivers_MinDurabilite6; } }
        public override int InitMaxHits { get { return ArmureDivers_MaxDurabilite6; } }

        public override int AosStrReq { get { return ArmureDivers_Force6; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CuirasseDraconique()
            : base(0x2890)
        {
            Weight = 2.0;
            Name = "Cuirasse Draconique";
        }

        public CuirasseDraconique(Serial serial)
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
    public class CuirasseBarbare : BaseArmor
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return ArmureDivers_Def4; } }
        public override int BaseContondantResistance { get { return ArmureDivers_Def4; } }
        public override int BaseTranchantResistance { get { return ArmureDivers_Def4; } }
        public override int BasePerforantResistance { get { return ArmureDivers_Def4; } }
        public override int BaseMagieResistance { get { return ArmureDivers_Def4; } }

        public override int InitMinHits { get { return ArmureDivers_MinDurabilite4; } }
        public override int InitMaxHits { get { return ArmureDivers_MaxDurabilite4; } }

        public override int AosStrReq { get { return ArmureDivers_Force4; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CuirasseBarbare()
            : base(0x2891)
        {
            Weight = 2.0;
            Name = "Cuirasse Barbare";
        }

        public CuirasseBarbare(Serial serial)
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
    public class CuirasseNordique : BaseArmor
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return ArmureDivers_Def5; } }
        public override int BaseContondantResistance { get { return ArmureDivers_Def5; } }
        public override int BaseTranchantResistance { get { return ArmureDivers_Def5; } }
        public override int BasePerforantResistance { get { return ArmureDivers_Def5; } }
        public override int BaseMagieResistance { get { return ArmureDivers_Def5; } }

        public override int InitMinHits { get { return ArmureDivers_MinDurabilite5; } }
        public override int InitMaxHits { get { return ArmureDivers_MaxDurabilite5; } }

        public override int AosStrReq { get { return ArmureDivers_Force5; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CuirasseNordique()
            : base(0x2BDD)
        {
            Weight = 2.0;
            Name = "Cuirasse Nordique";
        }

        public CuirasseNordique(Serial serial)
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
}
