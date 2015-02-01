using System;
using Server;
using Server.Items;
using Server.Targets;
using Server.Engines.Combat;

namespace Server.Items
{
    public abstract class BaseEstoc : BaseMeleeWeapon
    {
        public override WeaponType DefType { get { return WeaponType.Slashing; } }
        public override WeaponAnimation DefAnimation { get { return WeaponAnimation.Slash1H; } }

        public override CombatStrategy Strategy { get { return StrategyPerforante.Strategy; } }

        public BaseEstoc(int itemID)
            : base(itemID)
        {
        }

        public BaseEstoc(Serial serial)
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

        public override void OnDoubleClick(Mobile from)
        {
            from.SendLocalizedMessage(1010018); // What do you want to use this item on?

            from.Target = new BladedItemTarget(this);
        }
    }
}
