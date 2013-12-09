using System;
using Server.Items;

namespace Server.Items
{
    public class BourgeonGreaves : BaseArmor
    {
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Bourgeon_Brassards; } }
        public override int BaseContondantResistance { get { return Bourgeon_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return Bourgeon_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return Bourgeon_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return Bourgeon_Brassards_Magique; } }

        public override int InitMinHits { get { return Bourgeon_MinDurabilite; } }
        public override int InitMaxHits { get { return Bourgeon_MaxDurabilite; } }

        public override int AosStrReq { get { return Bourgeon_Brassards_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public BourgeonGreaves()
            : base(0x2858)
        {
            Weight = 2.0;
            Name = "Bourgeon";
        }

        public BourgeonGreaves(Serial serial)
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
    public class BourgeonLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Bourgeon_Jambieres; } }
        public override int BaseContondantResistance { get { return Bourgeon_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Bourgeon_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Bourgeon_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Bourgeon_Jambieres_Magique; } }

        public override int InitMinHits { get { return Bourgeon_MinDurabilite; } }
        public override int InitMaxHits { get { return Bourgeon_MaxDurabilite; } }

        public override int AosStrReq { get { return Bourgeon_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public BourgeonLeggings()
            : base(0x2859)
        {
            Weight = 2.0;
            Name = "Bourgeon";
        }

        public BourgeonLeggings(Serial serial)
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
    public class BourgeonTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 2; } }

        public override int BasePhysicalResistance { get { return Bourgeon_Cuirasse; } }
        public override int BaseContondantResistance { get { return Bourgeon_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return Bourgeon_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return Bourgeon_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return Bourgeon_Cuirasse_Magique; } }

        public override int InitMinHits { get { return Bourgeon_MinDurabilite; } }
        public override int InitMaxHits { get { return Bourgeon_MaxDurabilite; } }

        public override int AosStrReq { get { return Bourgeon_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public BourgeonTunic()
            : base(0x285A)
        {
            Weight = 2.0;
            Name = "Bourgeon";
        }

        public BourgeonTunic(Serial serial)
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
