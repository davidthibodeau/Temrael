using System;
using Server.Items;

namespace Server.Items
{
    public class MailluresGreaves : BaseArmor
    {
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return Maillures_Brassards; } }
        public override int BaseContondantResistance { get { return Maillures_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return Maillures_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return Maillures_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return Maillures_Brassards_Magique; } }

        public override int InitMinHits { get { return Maillures_MinDurabilite; } }
        public override int InitMaxHits { get { return Maillures_MaxDurabilite; } }

        public override int AosStrReq { get { return Maillures_Brassards_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MailluresGreaves()
            : base(0x284C)
        {
            Weight = 2.0;
            Name = "Brassards de Maillures";
        }

        public MailluresGreaves(Serial serial)
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
    public class MailluresLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return Maillures_Jambieres; } }
        public override int BaseContondantResistance { get { return Maillures_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Maillures_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Maillures_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Maillures_Jambieres_Magique; } }

        public override int InitMinHits { get { return Maillures_MinDurabilite; } }
        public override int InitMaxHits { get { return Maillures_MaxDurabilite; } }

        public override int AosStrReq { get { return Maillures_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MailluresLeggings()
            : base(0x284D)
        {
            Weight = 2.0;
            Name = "Jambieres de Maillures";
        }

        public MailluresLeggings(Serial serial)
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
    public class MailluresTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return Maillures_Cuirasse; } }
        public override int BaseContondantResistance { get { return Maillures_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return Maillures_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return Maillures_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return Maillures_Cuirasse_Magique; } }

        public override int InitMinHits { get { return Maillures_MinDurabilite; } }
        public override int InitMaxHits { get { return Maillures_MaxDurabilite; } }

        public override int AosStrReq { get { return Maillures_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MailluresTunic()
            : base(0x284E)
        {
            Weight = 2.0;
            Name = "Tunique de Maillures";
        }

        public MailluresTunic(Serial serial)
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
