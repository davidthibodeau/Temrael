using System;
using Server.Items;

namespace Server.Items
{
    public class MaillonsGreaves : BaseArmor
    {
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return Maillons_Brassards; } }
        public override int BaseContondantResistance { get { return Maillons_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return Maillons_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return Maillons_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return Maillons_Brassards_Magique; } }

        public override int InitMinHits { get { return Maillons_MinDurabilite; } }
        public override int InitMaxHits { get { return Maillons_MaxDurabilite; } }

        public override int AosStrReq { get { return Maillons_Brassards_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MaillonsGreaves()
            : base(0x284F)
        {
            Weight = 2.0;
            Name = "Brassards de Maillons";
        }

        public MaillonsGreaves(Serial serial)
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
    public class MaillonsLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return Maillons_Jambieres; } }
        public override int BaseContondantResistance { get { return Maillons_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Maillons_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Maillons_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Maillons_Jambieres_Magique; } }

        public override int InitMinHits { get { return Maillons_MinDurabilite; } }
        public override int InitMaxHits { get { return Maillons_MaxDurabilite; } }

        public override int AosStrReq { get { return Maillons_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MaillonsLeggings()
            : base(0x2850)
        {
            Weight = 2.0;
            Name = "Jambieres de Maillons";
        }

        public MaillonsLeggings(Serial serial)
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
    public class MaillonsTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return Maillons_Cuirasse; } }
        public override int BaseContondantResistance { get { return Maillons_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return Maillons_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return Maillons_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return Maillons_Cuirasse_Magique; } }

        public override int InitMinHits { get { return Maillons_MinDurabilite; } }
        public override int InitMaxHits { get { return Maillons_MaxDurabilite; } }

        public override int AosStrReq { get { return Maillons_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MaillonsTunic()
            : base(0x2851)
        {
            Weight = 2.0;
            Name = "Tunique de Maillons";
        }

        public MaillonsTunic(Serial serial)
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
