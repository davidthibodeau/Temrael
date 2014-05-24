using System;
using Server.Items;

namespace Server.Items
{
    public class BrassardsChaotique : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

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
        public BrassardsChaotique()
            : base(0x287F)
        {
            Weight = 2.0;
            Name = "Brassards Chaotique";
        }

        public BrassardsChaotique(Serial serial)
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
    public class Brassards : BaseArmor
    {
        public override int NiveauAttirail { get { return 5; } }

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
        public Brassards()
            : base(0x2880)
        {
            Weight = 2.0;
            Name = "Brassards";
        }

        public Brassards(Serial serial)
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
