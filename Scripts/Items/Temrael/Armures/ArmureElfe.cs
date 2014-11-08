using System;
using Server.Items;

namespace Server.Items
{
    public class ElfeHelm : BaseArmor
    {

        public override double BasePhysicalResistance { get { return ArmorFeuilles.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorFeuilles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorFeuilles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorFeuilles.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorFeuilles.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorFeuilles.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularWood; } }

        [Constructable]
        public ElfeHelm()
            : base(0x2FCC)
        {
            Weight = 2.0;
            Name = "Casque de Feuilles";
        }

        public ElfeHelm(Serial serial)
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
    public class ElfeGorget : BaseArmor
    {

        public override double BasePhysicalResistance { get { return ArmorFeuilles.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorFeuilles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorFeuilles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorFeuilles.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorFeuilles.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorFeuilles.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularWood; } }

        [Constructable]
        public ElfeGorget()
            : base(0x2FCE)
        {
            Weight = 2.0;
            Name = "Gorget de Feuilles";
        }

        public ElfeGorget(Serial serial)
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
    public class ElfeArms : BaseArmor
    {

        public override double BasePhysicalResistance { get { return ArmorFeuilles.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorFeuilles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorFeuilles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorFeuilles.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorFeuilles.force_Requise; } }
        public override int BaseDexReq { get { return ArmorFeuilles.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularWood; } }

        [Constructable]
        public ElfeArms()
            : base(0x2FCA)
        {
            Weight = 2.0;
            Name = "Brassards de Feuilles";
        }

        public ElfeArms(Serial serial)
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
    public class ElfeLeggings : BaseArmor
    {

        public override double BasePhysicalResistance { get { return ArmorFeuilles.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorFeuilles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorFeuilles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorFeuilles.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorFeuilles.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorFeuilles.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularWood; } }

        [Constructable]
        public ElfeLeggings()
            : base(0x2FCD)
        {
            Weight = 2.0;
            Name = "Jambieres de Feuilles";
        }

        public ElfeLeggings(Serial serial)
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
    public class ElfeTunic : BaseArmor
    {

        public override double BasePhysicalResistance { get { return ArmorFeuilles.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorFeuilles.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorFeuilles.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorFeuilles.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorFeuilles.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorFeuilles.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularWood; } }

        [Constructable]
        public ElfeTunic()
            : base(0x2FCB)
        {
            Weight = 2.0;
            Name = "Tunique de Feuilles";
        }

        public ElfeTunic(Serial serial)
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