using System;
using Server.Items;

namespace Server.Items
{
    public class StuddedBarbareGreaves : BaseArmor
    {

        public override int BasePhysicalResistance { get { return ArmorStudded.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorStudded.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorStudded.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorStudded.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorStudded.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorStudded.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorStudded.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorStudded.force_Requise; } }
        public override int AosDexBonus { get { return ArmorStudded.malus_Dex; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public StuddedBarbareGreaves()
            : base(0x2870)
        {
            Weight = 2.0;
            Name = "Brassards Barbares";
        }

        public StuddedBarbareGreaves(Serial serial)
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
    public class StuddedBarbareGorget : BaseArmor
    {

        public override int BasePhysicalResistance { get { return ArmorStudded.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorStudded.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorStudded.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorStudded.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorStudded.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorStudded.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorStudded.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorStudded.force_Requise; } }
        public override int AosDexBonus { get { return ArmorStudded.malus_Dex; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public StuddedBarbareGorget()
            : base(0x2871)
        {
            Weight = 2.0;
            Name = "Gorget Barbare";
        }

        public StuddedBarbareGorget(Serial serial)
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
    public class StuddedBarbareLeggings : BaseArmor
    {

        public override int BasePhysicalResistance { get { return ArmorStudded.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorStudded.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorStudded.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorStudded.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorStudded.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorStudded.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorStudded.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorStudded.force_Requise; } }
        public override int AosDexBonus { get { return ArmorStudded.malus_Dex; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public StuddedBarbareLeggings()
            : base(0x2872)
        {
            Weight = 2.0;
            Name = "Jambieres Barbares";
        }

        public StuddedBarbareLeggings(Serial serial)
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
    public class StuddedBarbareTunic : BaseArmor
    {

        public override int BasePhysicalResistance { get { return ArmorStudded.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorStudded.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorStudded.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorStudded.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorStudded.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorStudded.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorStudded.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorStudded.force_Requise; } }
        public override int AosDexBonus { get { return ArmorStudded.malus_Dex; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public StuddedBarbareTunic()
            : base(0x2873)
        {
            Weight = 2.0;
            Name = "Tunique Barbare";
        }

        public StuddedBarbareTunic(Serial serial)
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