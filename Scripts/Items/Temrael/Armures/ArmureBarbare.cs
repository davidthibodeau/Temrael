using System;
using Server.Items;

namespace Server.Items
{
    public class TunicBarbare : BaseArmor
    {
        //public override int NiveauAttirail { get { return ArmureBarbare_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorBarbare.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorBarbare.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorBarbare.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorBarbare.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorBarbare.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorBarbare.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public TunicBarbare()
            : base(0x287C)
        {
            Weight = 2.0;
            Name = "Tunique Barbare";
            Layer = Layer.InnerTorso;
        }

        public TunicBarbare(Serial serial)
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
    public class LeggingsBarbare : BaseArmor
    {
        //public override int NiveauAttirail { get { return ArmureBarbare_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorBarbare.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorBarbare.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorBarbare.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorBarbare.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorBarbare.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorBarbare.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public LeggingsBarbare()
            : base(0x287D)
        {
            Weight = 2.0;
            Name = "Jambieres Barbares";
            Layer = Layer.Pants;
        }

        public LeggingsBarbare(Serial serial)
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
}
