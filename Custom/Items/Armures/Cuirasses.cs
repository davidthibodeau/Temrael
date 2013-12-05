using System;
using Server.Items;

namespace Server.Items
{
    public class CuirasseReligieuse : BaseArmor
    {
        public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return CuirasseReligieuse; } }
        public override int BaseContondantResistance { get { return CuirasseReligieuse_Contondant; } }
        public override int BaseTranchantResistance { get { return CuirasseReligieuse_Tranchant; } }
        public override int BasePerforantResistance { get { return CuirasseReligieuse_Perforant; } }
        public override int BaseMagieResistance { get { return CuirasseReligieuse_Magique; } }

        public override int InitMinHits { get { return CuirasseReligieuse_MinDurabilite; } }
        public override int InitMaxHits { get { return CuirasseReligieuse_MaxDurabilite; } }

        public override int AosStrReq { get { return CuirasseReligieuse_Force; } }
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
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return TuniqueChaine; } }
        public override int BaseContondantResistance { get { return TuniqueChaine_Contondant; } }
        public override int BaseTranchantResistance { get { return TuniqueChaine_Tranchant; } }
        public override int BasePerforantResistance { get { return TuniqueChaine_Perforant; } }
        public override int BaseMagieResistance { get { return TuniqueChaine_Magique; } }

        public override int InitMinHits { get { return TuniqueChaine_MinDurabilite; } }
        public override int InitMaxHits { get { return TuniqueChaine_MaxDurabilite; } }

        public override int AosStrReq { get { return TuniqueChaine_Force; } }
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
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return Cuirasse; } }
        public override int BaseContondantResistance { get { return Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return Cuirasse_Magique; } }

        public override int InitMinHits { get { return Cuirasse_MinDurabilite; } }
        public override int InitMaxHits { get { return Cuirasse_MaxDurabilite; } }

        public override int AosStrReq { get { return Cuirasse_Force; } }
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
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return CuirasseDraconique_Cuirasse; } }
        public override int BaseContondantResistance { get { return CuirasseDraconique_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return CuirasseDraconique_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return CuirasseDraconique_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return CuirasseDraconique_Cuirasse_Magique; } }

        public override int InitMinHits { get { return CuirasseDraconique_MinDurabilite; } }
        public override int InitMaxHits { get { return CuirasseDraconique_MaxDurabilite; } }

        public override int AosStrReq { get { return CuirasseDraconique_Cuirasse_Force; } }
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
        public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return CuirasseBarbare; } }
        public override int BaseContondantResistance { get { return CuirasseBarbare_Contondant; } }
        public override int BaseTranchantResistance { get { return CuirasseBarbare_Tranchant; } }
        public override int BasePerforantResistance { get { return CuirasseBarbare_Perforant; } }
        public override int BaseMagieResistance { get { return CuirasseBarbare_Magique; } }

        public override int InitMinHits { get { return CuirasseBarbare_MinDurabilite; } }
        public override int InitMaxHits { get { return CuirasseBarbare_MaxDurabilite; } }

        public override int AosStrReq { get { return CuirasseBarbare_Force; } }
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
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return CuirasseNordique; } }
        public override int BaseContondantResistance { get { return CuirasseNordique_Contondant; } }
        public override int BaseTranchantResistance { get { return CuirasseNordique_Tranchant; } }
        public override int BasePerforantResistance { get { return CuirasseNordique_Perforant; } }
        public override int BaseMagieResistance { get { return CuirasseNordique_Magique; } }

        public override int InitMinHits { get { return CuirasseNordique_MinDurabilite; } }
        public override int InitMaxHits { get { return CuirasseNordique_MaxDurabilite; } }

        public override int AosStrReq { get { return CuirasseNordique_Force; } }
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
