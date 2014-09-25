using System;
using Server.Items;

namespace Server.Items
{
    public class MaillesHelm : BaseArmor
    {
        //public override int NiveauAttirail { get { return Mailles_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorMailles.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorMailles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMailles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMailles.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorMailles.force_Requise; } }
        public override int AosDexBonus { get { return ArmorMailles.malus_Dex; } }

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
        //public override int NiveauAttirail { get { return Mailles_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorMailles.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorMailles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMailles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMailles.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorMailles.force_Requise; } }
        public override int AosDexBonus { get { return ArmorMailles.malus_Dex; } }

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
        //public override int NiveauAttirail { get { return Mailles_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorMailles.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorMailles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMailles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMailles.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorMailles.force_Requise; } }
        public override int AosDexBonus { get { return ArmorMailles.malus_Dex; } }

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
