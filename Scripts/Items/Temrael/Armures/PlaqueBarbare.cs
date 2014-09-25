using System;
using Server.Items;

namespace Server.Items
{
    public class PlaqueBarbareGreaves : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueBarbare_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorPlaqueBarb.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorPlaqueBarb.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueBarb.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueBarb.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaqueBarb.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaqueBarb.malus_Dex ; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueBarbareGreaves()
            : base(0x2878)
        {
            Weight = 2.0;
            Name = "Brassards Barbare";
        }

        public PlaqueBarbareGreaves(Serial serial)
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
    public class PlaqueBarbareGorget : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueBarbare_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorPlaqueBarb.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorPlaqueBarb.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueBarb.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueBarb.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaqueBarb.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaqueBarb.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueBarbareGorget()
            : base(0x2879)
        {
            Weight = 2.0;
            Name = "Gorget Barbare";
        }

        public PlaqueBarbareGorget(Serial serial)
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
    public class PlaqueBarbareLeggings : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueBarbare_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorPlaqueBarb.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorPlaqueBarb.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueBarb.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueBarb.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaqueBarb.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaqueBarb.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueBarbareLeggings()
            : base(0x287A)
        {
            Weight = 2.0;
            Name = "Jambieres Barbares";
        }

        public PlaqueBarbareLeggings(Serial serial)
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
    public class PlaqueBarbareTunic : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueBarbare_Niveau; } }

        public override int BasePhysicalResistance { get { return ArmorPlaqueBarb.resistance_Physique; } }
        public override int BaseMagieResistance { get { return ArmorPlaqueBarb.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueBarb.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueBarb.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaqueBarb.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaqueBarb.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public PlaqueBarbareTunic()
            : base(0x287B)
        {
            Weight = 2.0;
            Name = "Tunique Barbare";
        }

        public PlaqueBarbareTunic(Serial serial)
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
