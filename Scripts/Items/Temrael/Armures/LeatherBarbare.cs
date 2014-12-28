using System;
using Server.Items;

namespace Server.Items
{
    public class LeatherBarbareLeggings : BaseArmor
    {

        public override double BasePhysicalResistance { get { return ArmorLeather.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorLeather.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorLeather.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorLeather.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorLeather.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorLeather.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public LeatherBarbareLeggings()
            : base(0x286E)
        {
            Weight = 2.0;
            Name = "Jambieres Barbare";
            Layer = Layer.Pants;
        }

        public LeatherBarbareLeggings(Serial serial)
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
    public class LeatherBarbareTunic : BaseArmor
    {

        public override double BasePhysicalResistance { get { return ArmorLeather.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorLeather.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorLeather.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorLeather.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorLeather.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorLeather.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public LeatherBarbareTunic()
            : base(0x286F)
        {
            Weight = 2.0;
            Name = "Tunique Barbare";
            Layer = Layer.InnerTorso;
        }

        public LeatherBarbareTunic(Serial serial)
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
