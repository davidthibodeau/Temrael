using System;
using Server.Items;

namespace Server.Items
{
    public class TunicBarbare : BaseArmor
    {
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return ArmureBarbare_Cuirasse; } }
        public override int BaseContondantResistance { get { return ArmureBarbare_Cuirasse_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmureBarbare_Cuirasse_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmureBarbare_Cuirasse_Perforant; } }
        public override int BaseMagieResistance { get { return ArmureBarbare_Cuirasse_Magique; } }

        public override int InitMinHits { get { return ArmureBarbare_MinDurabilite; } }
        public override int InitMaxHits { get { return ArmureBarbare_MaxDurabilite; } }

        public override int AosStrReq { get { return ArmureBarbare_Cuirasse_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public TunicBarbare()
            : base(0x287C)
        {
            Weight = 2.0;
            Name = "Tunique Barbare";
        }

        public TunicBarbare(Serial serial)
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
    public class LeggingsBarbare : BaseArmor
    {
        public override int NiveauAttirail { get { return 3; } }

        public override int BasePhysicalResistance { get { return ArmureBarbare_Jambieres; } }
        public override int BaseContondantResistance { get { return ArmureBarbare_Jambieres_Contondant; } }
        public override int BaseTranchantResistance { get { return ArmureBarbare_Jambieres_Tranchant; } }
        public override int BasePerforantResistance { get { return ArmureBarbare_Jambieres_Perforant; } }
        public override int BaseMagieResistance { get { return ArmureBarbare_Jambieres_Magique; } }

        public override int InitMinHits { get { return ArmureBarbare_MinDurabilite; } }
        public override int InitMaxHits { get { return ArmureBarbare_MaxDurabilite; } }

        public override int AosStrReq { get { return ArmureBarbare_Jambieres_Force; } }
        public override int OldStrReq { get { return 40; } }

        public override int OldDexBonus { get { return -2; } }

        public override int ArmorBase { get { return 30; } }
        public override int RevertArmorBase { get { return 4; } }

        public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
        public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

        [Constructable]
        public LeggingsBarbare()
            : base(0x287D)
        {
            Weight = 2.0;
            Name = "Jambieres Barbare";
        }

        public LeggingsBarbare(Serial serial)
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
