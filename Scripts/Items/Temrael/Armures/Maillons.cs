using System;
using Server.Items;

namespace Server.Items
{
    public class MaillonsGreaves : BaseArmor
    {
        //public override int NiveauAttirail { get { return Maillons_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorMaillons.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorMaillons.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMaillons.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMaillons.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorMaillons.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorMaillons.malus_Dex; } }

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

        public override double BasePhysicalResistance { get { return ArmorMaillons.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorMaillons.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMaillons.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMaillons.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorMaillons.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorMailles.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MaillonsLeggings()
            : base(0x2850)
        {
            Weight = 2.0;
            Name = "Jambieres de Maillons";
            Layer = Layer.Pants;
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
            Layer = Layer.Pants;
        }
    }
    public class MaillonsTunic : BaseArmor
    {
        //public override int NiveauAttirail { get { return Maillons_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorMaillons.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorMaillons.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMaillons.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMaillons.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorMaillons.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorMailles.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MaillonsTunic()
            : base(0x2851)
        {
            Weight = 2.0;
            Name = "Tunique de Maillons";
            Layer = Layer.InnerTorso;
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
            Layer = Layer.InnerTorso;
        }
    }
}
