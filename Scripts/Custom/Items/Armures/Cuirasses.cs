using System;
using Server.Items;

namespace Server.Items
{
    public class CuirasseReligieuse : BaseArmor
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override int BasePhysicalResistance { get { return ArmorDivers4.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorDivers4.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorDivers4.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorDivers4.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorDivers4.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers4.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers4.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorDivers4.force_Requise; } }
        public override int AosDexBonus { get { return ArmorDivers4.malus_Dex; } }

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

        public override int BasePhysicalResistance { get { return ArmorDivers3.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorDivers3.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorDivers3.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorDivers3.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorDivers3.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers3.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers3.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorDivers3.force_Requise; } }
        public override int AosDexBonus { get { return ArmorDivers3.malus_Dex; } }

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

        public override int BasePhysicalResistance { get { return ArmorDivers5.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorDivers5.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorDivers5.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorDivers5.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorDivers5.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers5.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers5.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorDivers5.force_Requise; } }
        public override int AosDexBonus { get { return ArmorDivers5.malus_Dex; } }

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

        public override int BasePhysicalResistance { get { return ArmorDivers6.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorDivers6.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorDivers6.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorDivers6.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorDivers6.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers6.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers6.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorDivers6.force_Requise; } }
        public override int AosDexBonus { get { return ArmorDivers6.malus_Dex; } }

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

        public override int BasePhysicalResistance { get { return ArmorDivers4.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorDivers4.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorDivers4.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorDivers4.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorDivers4.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers4.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers4.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorDivers4.force_Requise; } }
        public override int AosDexBonus { get { return ArmorDivers4.malus_Dex; } }

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

        public override int BasePhysicalResistance { get { return ArmorDivers5.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorDivers5.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorDivers5.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorDivers5.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorDivers5.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers5.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers5.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorDivers5.force_Requise; } }
        public override int AosDexBonus { get { return ArmorDivers5.malus_Dex; } }

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
