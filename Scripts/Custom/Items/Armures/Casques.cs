using System;
using Server.Items;

namespace Server.Items
{
    public class CasqueChaine : BaseArmor
    {
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return CasqueNomade; } }
        public override int BaseContondantResistance { get { return CasqueNomade_Contondant; } }
        public override int BaseTranchantResistance { get { return CasqueNomade_Tranchant; } }
        public override int BasePerforantResistance { get { return CasqueNomade_Perforant; } }
        public override int BaseMagieResistance { get { return CasqueNomade_Magique; } }

        public override int InitMinHits { get { return CasqueNomade_MinDurabilite; } }
        public override int InitMaxHits { get { return CasqueNomade_MaxDurabilite; } }

        public override int AosStrReq { get { return CasqueNomade_Force; } }
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

        public override int BasePhysicalResistance { get { return CasqueNomade; } }
        public override int BaseContondantResistance { get { return CasqueNomade_Contondant; } }
        public override int BaseTranchantResistance { get { return CasqueNomade_Tranchant; } }
        public override int BasePerforantResistance { get { return CasqueNomade_Perforant; } }
        public override int BaseMagieResistance { get { return CasqueNomade_Magique; } }

        public override int InitMinHits { get { return CasqueNomade_MinDurabilite; } }
        public override int InitMaxHits { get { return CasqueNomade_MaxDurabilite; } }

        public override int AosStrReq { get { return CasqueNomade_Force; } }
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

        public override int BasePhysicalResistance { get { return CasqueCorne; } }
        public override int BaseContondantResistance { get { return CasqueCorne_Contondant; } }
        public override int BaseTranchantResistance { get { return CasqueCorne_Tranchant; } }
        public override int BasePerforantResistance { get { return CasqueCorne_Perforant; } }
        public override int BaseMagieResistance { get { return CasqueCorne_Magique; } }

        public override int InitMinHits { get { return CasqueCorne_MinDurabilite; } }
        public override int InitMaxHits { get { return CasqueCorne_MaxDurabilite; } }

        public override int AosStrReq { get { return CasqueCorne_Force; } }
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

        public override int BasePhysicalResistance { get { return CasqueNordique; } }
        public override int BaseContondantResistance { get { return CasqueNordique_Contondant; } }
        public override int BaseTranchantResistance { get { return CasqueNordique_Tranchant; } }
        public override int BasePerforantResistance { get { return CasqueNordique_Perforant; } }
        public override int BaseMagieResistance { get { return CasqueNordique_Magique; } }

        public override int InitMinHits { get { return CasqueNordique_MinDurabilite; } }
        public override int InitMaxHits { get { return CasqueNordique_MaxDurabilite; } }

        public override int AosStrReq { get { return CasqueNordique_Force; } }
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
