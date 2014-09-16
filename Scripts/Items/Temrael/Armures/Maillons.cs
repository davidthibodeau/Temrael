using System;
using Server.Items;

namespace Server.Items
{
    public class MaillonsGreaves : BaseArmor
    {
        //public override int NiveauAttirail { get { return Maillons_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorMaillons.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorMaillons.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorMaillons.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorMaillons.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorMaillons.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMaillons.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMaillons.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorMaillons.force_Requise; } }
        public override int AosDexBonus { get { return ArmorMaillons.malus_Dex; } }

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
        //public override int NiveauAttirail { get { return Maillons_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorMaillons.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorMaillons.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorMaillons.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorMaillons.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorMaillons.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMaillons.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMaillons.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorMaillons.force_Requise; } }
        public override int AosDexBonus { get { return ArmorMailles.malus_Dex; } }

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
        //public override int NiveauAttirail { get { return Maillons_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorMaillons.resistance_Physique; } }
        public override int BaseContondantResistance { get { return ArmorMaillons.resistance_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmorMaillons.resistance_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmorMaillons.resistance_Perforant; } }
        public override int BaseMagieResistance { get { return ArmorMaillons.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMaillons.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMaillons.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorMaillons.force_Requise; } }
        public override int AosDexBonus { get { return ArmorMailles.malus_Dex; } }

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
