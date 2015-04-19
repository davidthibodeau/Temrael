using System;
using Server.Items;

namespace Server.Items
{
    
    public class CasqueClosDecorer : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDecore_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDeco.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaqueDeco.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDeco.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDeco.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueDeco.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueDeco.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueClosDecorer()
            : base(0x2882)
        {
            Weight = 2.0;
            Name = "Casque Clos Decore";
        }

        public CasqueClosDecorer(Serial serial)
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
    public class CasqueDecorer : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDecore_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDeco.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaqueDeco.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDeco.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDeco.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueDeco.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueDeco.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CasqueDecorer()
            : base(0x2884)
        {
            Weight = 2.0;
            Name = "Casque Decore";
        }

        public CasqueDecorer(Serial serial)
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
    public class GorgetDecorer : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDecore_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDeco.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaqueDeco.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDeco.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDeco.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueDeco.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueDeco.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public GorgetDecorer()
            : base(0x2885)
        {
            Weight = 2.0;
            Name = "Gorget Decore";
        }

        public GorgetDecorer(Serial serial)
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
    public class JambieresDecorer : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDecore_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDeco.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaqueDeco.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDeco.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDeco.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueDeco.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueDeco.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public JambieresDecorer()
            : base(0x2886)
        {
            Weight = 2.0;
            Name = "Jambieres Decores";
            Layer = Layer.Pants;
        }

        public JambieresDecorer(Serial serial)
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
    public class GantsDecorer : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDecore_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDeco.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaqueDeco.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDeco.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDeco.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueDeco.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueDeco.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public GantsDecorer()
            : base(0x2887)
        {
            Weight = 2.0;
            Name = "Gants Decores";
        }

        public GantsDecorer(Serial serial)
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
    public class CuirasseDecorer : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDecore_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDeco.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaqueDeco.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDeco.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDeco.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueDeco.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueDeco.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public CuirasseDecorer()
            : base(0x2888)
        {
            Weight = 2.0;
            Name = "Cuirasse Decore";
            Layer = Layer.InnerTorso;
        }

        public CuirasseDecorer(Serial serial)
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
    public class BrassardsDecorer : BaseArmor
    {
        //public override int NiveauAttirail { get { return PlaqueDecore_Niveau; } }

        public override double BasePhysicalResistance { get { return ArmorPlaqueDeco.resistance_Physique; } }
        public override double BaseMagicalResistance { get { return ArmorPlaqueDeco.resistance_Magique; } }

        public override int InitMinHits { get { return ArmorPlaqueDeco.min_Durabilite; } }
        public override int InitMaxHits { get { return ArmorPlaqueDeco.max_Durabilite; } }

        public override int BaseStrReq { get { return ArmorPlaqueDeco.force_Requise; } }
        public override int BaseDexBonus { get { return ArmorPlaqueDeco.malus_Dex; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Plate; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public BrassardsDecorer()
            : base(0x2889)
        {
            Weight = 2.0;
            Name = "Brassards Decores";
        }

        public BrassardsDecorer(Serial serial)
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
