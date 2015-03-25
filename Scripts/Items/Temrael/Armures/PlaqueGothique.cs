using System;
using Server.Items;

namespace Server.Items
{
    public class CasqueGothique : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueGothique_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueGoth.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaqueGoth.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueGoth.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueGoth.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueGoth.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueGoth.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueGothique()
            : base(0x288A)
        {
            Weight = 2.0;
            Name = "Casque Gothique";
        }

        public CasqueGothique(Serial serial)
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
    public class BrassardsGothique : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueGothique_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueGoth.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaqueGoth.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueGoth.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueGoth.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueGoth.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueGoth.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public BrassardsGothique()
            : base(0x288B)
        {
            Weight = 2.0;
            Name = "Brassards Gothiques";
        }

        public BrassardsGothique(Serial serial)
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
    public class CuirasseGothique : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueGothique_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueGoth.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaqueGoth.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueGoth.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueGoth.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueGoth.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueGoth.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CuirasseGothique()
            : base(0x288C)
        {
            Weight = 2.0;
            Name = "Cuirasse Gothique";
            Layer = Layer.InnerTorso;
        }

        public CuirasseGothique(Serial serial)
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
