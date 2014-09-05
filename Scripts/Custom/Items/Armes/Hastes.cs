using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
    public class Granbarde : BasePoleArm
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hallebarde_Force6; } }
        public override int AosMinDamage { get { return Hallebarde_MinDam6; } }
        public override int AosMaxDamage { get { return Hallebarde_MaxDam6; } }
        public override double AosSpeed { get { return Hallebarde_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Granbarde()
            : base(0x2977)
        {
            Weight = 4.0;
            Name = "Granbarde";
        }

        public Granbarde(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class Guisarme : BasePoleArm
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Bardiche_Force6; } }
        public override int AosMinDamage { get { return Bardiche_MinDam6; } }
        public override int AosMaxDamage { get { return Bardiche_MaxDam6; } }
        public override double AosSpeed { get { return Bardiche_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Guisarme()
            : base(0x2978)
        {
            Weight = 4.0;
            Name = "Guisarme";
        }

        public Guisarme(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class Bardine : BasePoleArm
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hallebarde_Force3; } }
        public override int AosMinDamage { get { return Hallebarde_MinDam3; } }
        public override int AosMaxDamage { get { return Hallebarde_MaxDam3; } }
        public override double AosSpeed { get { return Hallebarde_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Bardine()
            : base(0x2979)
        {
            Weight = 4.0;
            Name = "Bardine";
        }

        public Bardine(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class Vougue : BasePoleArm
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Bardiche_Force3; } }
        public override int AosMinDamage { get { return Bardiche_MinDam3; } }
        public override int AosMaxDamage { get { return Bardiche_MaxDam3; } }
        public override double AosSpeed { get { return Bardiche_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Vougue()
            : base(0x297A)
        {
            Weight = 4.0;
            Name = "Vougue";
        }

        public Vougue(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class Hastiche : BasePoleArm
    {
        //public override int NiveauAttirail { get { return 4; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hallebarde_Force4; } }
        public override int AosMinDamage { get { return Hallebarde_MinDam4; } }
        public override int AosMaxDamage { get { return Hallebarde_MaxDam4; } }
        public override double AosSpeed { get { return Hallebarde_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Hastiche()
            : base(0x297B)
        {
            Weight = 4.0;
            Name = "Hastiche";
        }

        public Hastiche(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class Helbarde : BasePoleArm
    {
        //public override int NiveauAttirail { get { return 5; } }

        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Hallebarde_Force5; } }
        public override int AosMinDamage { get { return Hallebarde_MinDam5; } }
        public override int AosMaxDamage { get { return Hallebarde_MaxDam5; } }
        public override double AosSpeed { get { return Hallebarde_Vitesse; } }
        public override float MlSpeed { get { return 4.25f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Helbarde()
            : base(0x3042)
        {
            Weight = 4.0;
            Name = "Helbarde";
        }

        public Helbarde(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
    public class Cythe : BasePoleArm
    {
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.CrushingBlow; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.Dismount; } }

        public override int AosStrengthReq { get { return Bardiche_Force5; } }
        public override int AosMinDamage { get { return Bardiche_MinDam5; } }
        public override int AosMaxDamage { get { return Bardiche_MaxDam5; } }
        public override double AosSpeed { get { return Bardiche_Vitesse; } }
        public override float MlSpeed { get { return 3.75f; } }

        public override int InitMinHits { get { return 31; } }
        public override int InitMaxHits { get { return 110; } }

        [Constructable]
        public Cythe()
            : base(0x3041)
        {
            Weight = 4.0;
            Name = "Cythe";
        }

        public Cythe(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
