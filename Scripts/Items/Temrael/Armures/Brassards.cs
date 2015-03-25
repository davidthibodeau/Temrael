using System;
using Server.Items;

namespace Server.Items
{
    public class BrassardsChaotique : BaseArmor
    {
        //public override int NiveauAttirail { get { return 6; } }

        public override double BasePhysicalResistance { get { return ArmorDivers6.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorDivers6.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers6.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers6.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorDivers6.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorDivers6.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public BrassardsChaotique()
            : base(0x287F)
        {
            Weight = 2.0;
            Name = "Brassards Chaotique";
        }

        public BrassardsChaotique(Serial serial)
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
    public class Brassards : BaseArmor
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override double BasePhysicalResistance { get { return ArmorDivers5.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorDivers5.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers5.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers5.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorDivers5.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorDivers5.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public Brassards()
            : base(0x2880)
        {
            Weight = 2.0;
            Name = "Brassards";
        }

        public Brassards(Serial serial)
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
