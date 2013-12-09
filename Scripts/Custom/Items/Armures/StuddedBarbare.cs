using System;
using Server.Items;

namespace Server.Items
{
    public class StuddedBarbareGreaves : BaseArmor
    {
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Studded_Brassards; } }
        public override int BaseContondantResistance { get { return Studded_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return Studded_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return Studded_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return Studded_Brassards_Magique; } }

        public override int InitMinHits { get { return Studded_MinDurabilite; } }
        public override int InitMaxHits { get { return Studded_MaxDurabilite; } }

        public override int AosStrReq { get { return Studded_Brassards_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
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
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Studded_Gorget; } }
        public override int BaseContondantResistance { get { return Studded_Gorget_Contondant; } }
        public override int BaseTranchantResistance { get { return Studded_Gorget_Tranchant; } }
        public override int BasePerforantResistance { get { return Studded_Gorget_Perforant; } }
        public override int BaseMagieResistance { get { return Studded_Gorget_Magique; } }

        public override int InitMinHits { get { return Studded_MinDurabilite; } }
        public override int InitMaxHits { get { return Studded_MaxDurabilite; } }

        public override int AosStrReq { get { return Studded_Gorget_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
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
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Studded_Jambieres; } }
        public override int BaseContondantResistance { get { return Studded_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Studded_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Studded_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Studded_Jambieres_Magique; } }

        public override int InitMinHits { get { return Studded_MinDurabilite; } }
        public override int InitMaxHits { get { return Studded_MaxDurabilite; } }

        public override int AosStrReq { get { return Studded_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
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
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Studded_Cuirasse; } }
        public override int BaseContondantResistance { get { return Studded_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return Studded_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return Studded_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return Studded_Cuirasse_Magique; } }

        public override int InitMinHits { get { return Studded_MinDurabilite; } }
        public override int InitMaxHits { get { return Studded_MaxDurabilite; } }

        public override int AosStrReq { get { return Studded_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
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