using System;
using Server.Items;

namespace Server.Items
{
    public class DrowHelm : BaseArmor
    {
        public override int NiveauAttirail { get { return 2; } }

        public override Layer Layer
        {
            get
            {
                return Server.Layer.Helm;
            }
            set
            {
                base.Layer = value;
            }
        }

        public override int BasePhysicalResistance { get { return Ring_Casque; } }
        public override int BaseContondantResistance { get { return Ring_Casque_Contondant; } }
        public override int BaseTranchantResistance { get { return Ring_Casque_Tranchant; } }
        public override int BasePerforantResistance { get { return Ring_Casque_Perforant; } }
        public override int BaseMagieResistance { get { return Ring_Casque_Magique; } }

        public override int InitMinHits { get { return Ring_MinDurabilite; } }
        public override int InitMaxHits { get { return Ring_MaxDurabilite; } }

        public override int AosStrReq { get { return Ring_Casque_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return Ring_Casque_Dex; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public DrowHelm()
            : base(0x2D2D)
        {
            Weight = 2.0;
            Name = "Tiara d'Elfe Noir";
        }

        public DrowHelm(Serial serial)
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
    public class DrowGorget : BaseArmor
    {
        public override int NiveauAttirail { get { return 2; } }

        public override Layer Layer
        {
            get
            {
                return Server.Layer.Neck;
            }
            set
            {
                base.Layer = value;
            }
        }

        public override int BasePhysicalResistance { get { return Ring_Gants; } }
        public override int BaseContondantResistance { get { return Ring_Gants_Contondant; } }
        public override int BaseTranchantResistance { get { return Ring_Gants_Tranchant; } }
        public override int BasePerforantResistance { get { return Ring_Gants_Perforant; } }
        public override int BaseMagieResistance { get { return Ring_Gants_Magique; } }

        public override int InitMinHits { get { return Ring_MinDurabilite; } }
        public override int InitMaxHits { get { return Ring_MaxDurabilite; } }

        public override int AosStrReq { get { return Ring_Gants_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return Ring_Gants_Dex; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public DrowGorget()
            : base(0x2D2B)
        {
            Weight = 2.0;
            Name = "Gorget d'Elfe Noir";
        }

        public DrowGorget(Serial serial)
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
    public class DrowArms : BaseArmor
    {
        public override int NiveauAttirail { get { return 2; } }

        public override Layer Layer
        {
            get
            {
                return Server.Layer.Arms;
            }
            set
            {
                base.Layer = value;
            }
        }

        public override int BasePhysicalResistance { get { return Ring_Brassards; } }
        public override int BaseContondantResistance { get { return Ring_Brassards_Contondant; } }
        public override int BaseTranchantResistance { get { return Ring_Brassards_Tranchant; } }
        public override int BasePerforantResistance { get { return Ring_Brassards_Perforant; } }
        public override int BaseMagieResistance { get { return Ring_Brassards_Magique; } }

        public override int InitMinHits { get { return Ring_MinDurabilite; } }
        public override int InitMaxHits { get { return Ring_MaxDurabilite; } }

        public override int AosStrReq { get { return Ring_Brassards_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return Ring_Brassards_Dex; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public DrowArms()
            : base(0x2D29)
        {
            Weight = 2.0;
            Name = "Brassards d'Elfe Noir";
        }

        public DrowArms(Serial serial)
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
    public class DrowLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 2; } }

        public override Layer Layer
        {
            get
            {
                return Server.Layer.Pants;
            }
            set
            {
                base.Layer = value;
            }
        }

        public override int BasePhysicalResistance { get { return Ring_Jambieres; } }
        public override int BaseContondantResistance { get { return Ring_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Ring_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Ring_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Ring_Jambieres_Magique; } }

        public override int InitMinHits { get { return Ring_MinDurabilite; } }
        public override int InitMaxHits { get { return Ring_MaxDurabilite; } }

        public override int AosStrReq { get { return Ring_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return Ring_Jamvieres_Dex; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public DrowLeggings()
            : base(0x2D2C)
        {
            Weight = 2.0;
            Name = "Jambieres d'Elfe Noir";
        }

        public DrowLeggings(Serial serial)
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
    public class DrowTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 2; } }

        public override Layer Layer
        {
            get
            {
                return Server.Layer.MiddleTorso;
            }
            set
            {
                base.Layer = value;
            }
        }

        public override int BasePhysicalResistance { get { return Ring_Cuirasse; } }
        public override int BaseContondantResistance { get { return Ring_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return Ring_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return Ring_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return Ring_Cuirasse_Magique; } }

        public override int InitMinHits { get { return Ring_MinDurabilite; } }
        public override int InitMaxHits { get { return Ring_MaxDurabilite; } }

        public override int AosStrReq { get { return Ring_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return Ring_Cuirasse_Dex; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Ringmail; } }
        public override CraftResource DefaultResource { get { return CraftResource.Fer; } }

        [Constructable]
        public DrowTunic()
            : base(0x2D2A)
        {
            Weight = 2.0;
            Name = "Tunique d'Elfe Noir";
        }

        public DrowTunic(Serial serial)
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