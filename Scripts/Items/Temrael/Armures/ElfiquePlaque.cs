using System;
using Server.Items;

namespace Server.Items
{
    public class ElfiquePlaqueGorget : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueElfique_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueElf.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorPlaqueElf.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueElf.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueElf.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueElf.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueElf.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ElfiquePlaqueGorget()
            : base(0x2899)
        {
            Weight = 2.0;
            Name = "Gorget Elfique";
        }

        public ElfiquePlaqueGorget(Serial serial)
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
    public class ElfiquePlaqueLeggings : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueElfique_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueElf.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorPlaqueElf.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueElf.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueElf.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueElf.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueElf.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ElfiquePlaqueLeggings()
            : base(0x289A)
        {
            Weight = 2.0;
            Name = "Jambieres Elfiques";
        }

        public ElfiquePlaqueLeggings(Serial serial)
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
    public class ElfiquePlaqueTunic : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueElfique_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueElf.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorPlaqueElf.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueElf.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueElf.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueElf.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueElf.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ElfiquePlaqueTunic()
            : base(0x289B)
        {
            Weight = 2.0;
            Name = "Tunique Elfique";
        }

        public ElfiquePlaqueTunic(Serial serial)
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