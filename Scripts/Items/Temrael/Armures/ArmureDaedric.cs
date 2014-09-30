using System;
using Server.Items;

namespace Server.Items
{
    public class ArmureDaedricGreaves : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDaedric_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDaed.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorPlaqueDaed.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDaed.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDaed.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaqueDaed.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaqueDaed.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricGreaves()
            : base(0x1476)
        {
            Weight = 2.0;
            Name = "Brassards Daedric";
        }

        public ArmureDaedricGreaves(Serial serial)
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
    public class ArmureDaedricTunic : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDaedric_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDaed.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorPlaqueDaed.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDaed.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDaed.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaqueDaed.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaqueDaed.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricTunic()
            : base(0x1475)
        {
            Weight = 2.0;
            Name = "Tunique Daedric";
        }

        public ArmureDaedricTunic(Serial serial)
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
    public class ArmureDaedricHelm : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDaedric_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDaed.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorPlaqueDaed.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDaed.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDaed.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaqueDaed.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaqueDaed.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricHelm()
            : base(0x1477)
        {
            Weight = 2.0;
            Name = "Casque Daedric";
        }

        public ArmureDaedricHelm(Serial serial)
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
    public class ArmureDaedricGloves : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDaedric_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDaed.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorPlaqueDaed.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDaed.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDaed.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaqueDaed.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaqueDaed.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricGloves()
            : base(0x147A)
        {
            Weight = 2.0;
            Name = "Gants Daedric";
        }

        public ArmureDaedricGloves(Serial serial)
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
    public class ArmureDaedricGorget : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDaedric_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDaed.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorPlaqueDaed.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDaed.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDaed.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaqueDaed.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaqueDaed.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricGorget()
            : base(0x1479)
        {
            Weight = 2.0;
            Name = "Gorget Daedric";
        }

        public ArmureDaedricGorget(Serial serial)
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
    public class ArmureDaedricLeggings : BaseArmor
    {
        public override double BasePhysicalResistance { get { return ArmorPlaqueDaed.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorPlaqueDaed.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDaed.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDaed.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorPlaqueDaed.force_Requise; } }
        public override int AosDexBonus { get { return ArmorPlaqueDaed.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public ArmureDaedricLeggings()
            : base(0x1478)
        {
            Weight = 2.0;
            Name = "Jambieres Daedric";
        }

        public ArmureDaedricLeggings(Serial serial)
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
