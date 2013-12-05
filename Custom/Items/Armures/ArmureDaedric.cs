using System;
using Server.Items;

namespace Server.Items
{
    public class ArmureDaedricGreaves : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDaedric_Brassards; } }
        public override int BaseContondantResistance { get { return PlaqueDaedric_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDaedric_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDaedric_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDaedric_Brassards_Magique; } }

        public override int InitMinHits { get { return PlaqueDaedric_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDaedric_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDaedric_Brassards_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricGreaves()
            : base(0x1476)
        {
            Weight = 2.0;
            Name = "Brassards Daedric";
        }

        public ArmureDaedricGreaves(Serial serial)
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
    public class ArmureDaedricTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDaedric_Cuirasse; } }
        public override int BaseContondantResistance { get { return PlaqueDaedric_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDaedric_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDaedric_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDaedric_Cuirasse_Magique; } }

        public override int InitMinHits { get { return PlaqueDaedric_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDaedric_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDaedric_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricTunic()
            : base(0x1475)
        {
            Weight = 2.0;
            Name = "Tunique Daedric";
        }

        public ArmureDaedricTunic(Serial serial)
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
    public class ArmureDaedricHelm : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDaedric_Casque; } }
        public override int BaseContondantResistance { get { return PlaqueDaedric_Casque_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDaedric_Casque_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDaedric_Casque_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDaedric_Casque_Magique; } }

        public override int InitMinHits { get { return PlaqueDaedric_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDaedric_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDaedric_Casque_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricHelm()
            : base(0x1477)
        {
            Weight = 2.0;
            Name = "Casque Daedric";
        }

        public ArmureDaedricHelm(Serial serial)
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
    public class ArmureDaedricGloves : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDaedric_Gants; } }
        public override int BaseContondantResistance { get { return PlaqueDaedric_Gants_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDaedric_Gants_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDaedric_Gants_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDaedric_Gants_Magique; } }

        public override int InitMinHits { get { return PlaqueDaedric_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDaedric_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDaedric_Gants_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricGloves()
            : base(0x147A)
        {
            Weight = 2.0;
            Name = "Gants Daedric";
        }

        public ArmureDaedricGloves(Serial serial)
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
    public class ArmureDaedricGorget : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDaedric_Gorget; } }
        public override int BaseContondantResistance { get { return PlaqueDaedric_Gorget_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDaedric_Gorget_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDaedric_Gorget_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDaedric_Gorget_Magique; } }

        public override int InitMinHits { get { return PlaqueDaedric_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDaedric_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDaedric_Gorget_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricGorget()
            : base(0x1479)
        {
            Weight = 2.0;
            Name = "Gorget Daedric";
        }

        public ArmureDaedricGorget(Serial serial)
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
    public class ArmureDaedricLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 6; } }

        public override int BasePhysicalResistance { get { return PlaqueDaedric_Jambieres; } }
        public override int BaseContondantResistance { get { return PlaqueDaedric_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return PlaqueDaedric_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return PlaqueDaedric_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return PlaqueDaedric_Jambieres_Magique; } }

        public override int InitMinHits { get { return PlaqueDaedric_MinDurabilite; } }
        public override int InitMaxHits { get { return PlaqueDaedric_MaxDurabilite; } }

        public override int AosStrReq { get { return PlaqueDaedric_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricLeggings()
            : base(0x1478)
        {
            Weight = 2.0;
            Name = "Jambieres Daedric";
        }

        public ArmureDaedricLeggings(Serial serial)
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
