using System;
using Server.Items;

namespace Server.Items
{
    public class CasqueChaine : BaseArmor
    {
        //public override int NiveauAttirail { get { return 3; } }

        public override double BasePhysicalResistance { get { return ArmorDivers3.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorDivers3.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers3.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers3.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorDivers3.force_Requise; } }
        public override int AosDexBonus { get { return ArmorDivers3.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueChaine()
            : base(0x2874)
        {
            Weight = 2.0;
            Name = "Casque de Chaine";
        }

        public CasqueChaine(Serial serial)
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
    public class CasqueSudiste : BaseArmor
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override double BasePhysicalResistance { get { return ArmorDivers4.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorDivers4.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers4.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers4.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorDivers4.force_Requise; } }
        public override int AosDexBonus { get { return ArmorDivers4.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Chainmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueSudiste()
            : base(0x2875)
        {
            Weight = 2.0;
            Name = "Casque de Nomade";
        }

        public CasqueSudiste(Serial serial)
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
    public class CasqueCorne : BaseArmor
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override double BasePhysicalResistance { get { return ArmorDivers5.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorDivers5.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers5.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers5.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorDivers5.force_Requise; } }
        public override int AosDexBonus { get { return ArmorDivers5.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueCorne()
            : base(0x287E)
        {
            Weight = 2.0;
            Name = "Casque a Cornes";
        }

        public CasqueCorne(Serial serial)
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
    public class CasqueNordique : BaseArmor
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override double BasePhysicalResistance { get { return ArmorDivers4.resistance_Physique; } }
        public override double BaseMagieResistance { get { return ArmorDivers4.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorDivers4.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorDivers4.max_Durabilite; } }

        public override int AosStrReq { get { return ArmorDivers4.force_Requise; } }
        public override int AosDexBonus { get { return ArmorDivers4.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueNordique()
            : base(0x288D)
        {
            Weight = 2.0;
            Name = "Casque Nordique";
        }

        public CasqueNordique(Serial serial)
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
