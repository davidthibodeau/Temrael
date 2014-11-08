using System;
using Server.Items;

namespace Server.Items
{
    public class MailluresGreaves : BaseArmor
    {
        //public override int NiveauAttirail { get { return Maillures_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorMaillures.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorMaillures.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMaillures.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMaillures.min_Durabilite; } }

        public override int BaseStrReq { get { return ArmorMaillures.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorMaillures.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public MailluresGreaves()
            : base(0x284C)
        {
            Weight = 2.0;
            Name = "Brassards de Maillures";
            Layer = Layer.Arms;
        }

        public MailluresGreaves(Serial serial)
            : base(serial)
        {
            Layer = Layer.Arms;
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
            Layer = Layer.Arms;
        }
    }
    public class MailluresLeggings : BaseArmor
    {
        //public override int NiveauAttirail { get { return Maillures_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorMaillures.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorMaillures.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMaillures.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMaillures.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorMaillures.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorMaillures.malus_Dex; } }

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
        //public override int NiveauAttirail { get { return Maillures_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorMaillures.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorMaillures.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorMaillures.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorMaillures.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorMaillures.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorMaillures.malus_Dex; } }

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
