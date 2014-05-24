using System;
using Server.Items;

namespace Server.Items
{
    public class CasqueChaine : BaseArmor
    {
        public override int NiveauAttirail { get { return 3; } }

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

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueChaine()
            : base(0x2874)
        {
            Weight = 2.0;
            Name = "Casque de Chaine";
        }

        public CasqueChaine(Serial serial)
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
    public class CasqueSudiste : BaseArmor
    {
        public override int NiveauAttirail { get { return 4; } }

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

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueSudiste()
            : base(0x2875)
        {
            Weight = 2.0;
            Name = "Casque de Nomade";
        }

        public CasqueSudiste(Serial serial)
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
    public class CasqueCorne : BaseArmor
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
        public CasqueCorne()
            : base(0x287E)
        {
            Weight = 2.0;
            Name = "Casque a Cornes";
        }

        public CasqueCorne(Serial serial)
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
    public class CasqueNordique : BaseArmor
    {
        public override int NiveauAttirail { get { return 4; } }

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
        public CasqueNordique()
            : base(0x288D)
        {
            Weight = 2.0;
            Name = "Casque Nordique";
        }

        public CasqueNordique(Serial serial)
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
