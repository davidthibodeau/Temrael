using System;
using Server.Items;

namespace Server.Items
{
    public class MaillesHelm : BaseArmor
    {
        public override int NiveauAttirail { get { return Mailles_Niveau; } }

        public override int BasePhysicalResistance { get { return Mailles_Physique; } }
        public override int BaseContondantResistance { get { return Mailles_Contondant; } }
        public override int BaseTranchantResistance { get { return Mailles_Tranchant; } }
        public override int BasePerforantResistance { get { return Mailles_Perforant; } }
        public override int BaseMagieResistance { get { return Mailles_Magique; } }

        public override int InitMinHits { get { return Mailles_MinDurabilite; } }
        public override int InitMaxHits { get { return Mailles_MaxDurabilite; } }

        public override int AosStrReq { get { return Mailles_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MaillesHelm()
            : base(0x285B)
        {
            Weight = 2.0;
            Name = "Casque de Maille";
        }

        public MaillesHelm(Serial serial)
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
    public class MaillesTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return Mailles_Niveau; } }

        public override int BasePhysicalResistance { get { return Mailles_Physique; } }
        public override int BaseContondantResistance { get { return Mailles_Contondant; } }
        public override int BaseTranchantResistance { get { return Mailles_Tranchant; } }
        public override int BasePerforantResistance { get { return Mailles_Perforant; } }
        public override int BaseMagieResistance { get { return Mailles_Magique; } }

        public override int InitMinHits { get { return Mailles_MinDurabilite; } }
        public override int InitMaxHits { get { return Mailles_MaxDurabilite; } }

        public override int AosStrReq { get { return Mailles_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MaillesTunic()
            : base(0x285C)
        {
            Weight = 2.0;
            Name = "Tunique de Mailles";
        }

        public MaillesTunic(Serial serial)
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
    public class MaillesLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return Mailles_Niveau; } }

        public override int BasePhysicalResistance { get { return Mailles_Physique; } }
        public override int BaseContondantResistance { get { return Mailles_Contondant; } }
        public override int BaseTranchantResistance { get { return Mailles_Tranchant; } }
        public override int BasePerforantResistance { get { return Mailles_Perforant; } }
        public override int BaseMagieResistance { get { return Mailles_Magique; } }

        public override int InitMinHits { get { return Mailles_MinDurabilite; } }
        public override int InitMaxHits { get { return Mailles_MaxDurabilite; } }

        public override int AosStrReq { get { return Mailles_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MaillesLeggings()
            : base(0x285D)
        {
            Weight = 2.0;
            Name = "Jambieres de Mailles";
        }

        public MaillesLeggings(Serial serial)
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
