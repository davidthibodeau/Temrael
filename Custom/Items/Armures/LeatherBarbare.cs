using System;
using Server.Items;

namespace Server.Items
{
    public class LeatherBarbareLeggings : BaseArmor
    {
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Leather_Jambieres; } }
        public override int BaseContondantResistance { get { return Leather_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return Leather_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return Leather_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return Leather_Jambieres_Magique; } }

        public override int InitMinHits { get { return Leather_MinDurabilite; } }
        public override int InitMaxHits { get { return Leather_MaxDurabilite; } }

        public override int AosStrReq { get { return Leather_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public LeatherBarbareLeggings()
            : base(0x286E)
        {
            Weight = 2.0;
            Name = "Jambieres Barbare";
        }

        public LeatherBarbareLeggings(Serial serial)
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
    public class LeatherBarbareTunic : BaseArmor
    {
        public override int NiveauAttirail { get { return 1; } }

        public override int BasePhysicalResistance { get { return Leather_Cuirasse; } }
        public override int BaseContondantResistance { get { return Leather_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return Leather_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return Leather_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return Leather_Cuirasse_Magique; } }

        public override int InitMinHits { get { return Leather_MinDurabilite; } }
        public override int InitMaxHits { get { return Leather_MaxDurabilite; } }

        public override int AosStrReq { get { return Leather_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Leather; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public LeatherBarbareTunic()
            : base(0x286F)
        {
            Weight = 2.0;
            Name = "Tunique Barbare";
        }

        public LeatherBarbareTunic(Serial serial)
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
