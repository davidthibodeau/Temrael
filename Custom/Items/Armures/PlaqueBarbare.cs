using System;
using Server.Items;

namespace Server.Items
{
    public class PlaqueBarbareGreaves : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return PlaqueBarbare_Brassards; } }
        public override int BaseContondantResistance { get { return PlaqueBarbare_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueBarbare_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueBarbare_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueBarbare_Brassards_Magique; } }

        public override int InitMinHits { get { return PlaqueBarbare_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueBarbare_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueBarbare_Brassards_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueBarbareGreaves()
            : base(0x2878)
        {
            Weight = 2.0;
            Name = "Brassards Barbare";
        }

        public PlaqueBarbareGreaves(Serial serial)
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
    public class PlaqueBarbareGorget : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return PlaqueBarbare_Gorget; } }
        public override int BaseContondantResistance { get { return PlaqueBarbare_Gorget_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueBarbare_Gorget_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueBarbare_Gorget_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueBarbare_Gorget_Magique; } }

        public override int InitMinHits { get { return PlaqueBarbare_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueBarbare_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueBarbare_Gorget_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueBarbareGorget()
            : base(0x2879)
        {
            Weight = 2.0;
            Name = "Gorget Barbare";
        }

        public PlaqueBarbareGorget(Serial serial)
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
    public class PlaqueBarbareLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return PlaqueBarbare_Jambieres; } }
        public override int BaseContondantResistance { get { return PlaqueBarbare_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueBarbare_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueBarbare_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueBarbare_Jambieres_Magique; } }

        public override int InitMinHits { get { return PlaqueBarbare_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueBarbare_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueBarbare_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueBarbareLeggings()
            : base(0x287A)
        {
            Weight = 2.0;
            Name = "Jambieres Barbares";
        }

        public PlaqueBarbareLeggings(Serial serial)
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
    public class PlaqueBarbareTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

        public override int BasePhysicalResistance { get { return PlaqueBarbare_Cuirasse; } }
        public override int BaseContondantResistance { get { return PlaqueBarbare_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueBarbare_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueBarbare_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueBarbare_Cuirasse_Magique; } }

        public override int InitMinHits { get { return PlaqueBarbare_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueBarbare_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueBarbare_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueBarbareTunic()
            : base(0x287B)
        {
            Weight = 2.0;
            Name = "Tunique Barbare";
        }

        public PlaqueBarbareTunic(Serial serial)
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
