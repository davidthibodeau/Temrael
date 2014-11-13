using Server.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Combat
{
    public class ArmeMonstre : BaseWeapon
    {
        public override CombatStrategy Strategy { get { return StrategyMonstre.Strategy; } }

        private int dMinDmg;
        private int dMaxDmg;
        private int dSpeed;

        public override int DefMinDamage { get { return dMinDmg; } }
        public override int DefMaxDamage { get { return dMaxDmg; } }
        public override int DefSpeed { get { return dSpeed; } }

        public ArmeMonstre(int min, int max, int speed) : base(0)
        {
            dMinDmg = min;
            dMaxDmg = max;
            dSpeed = speed;
            Layer = Layer.OneHanded;
        }

        public ArmeMonstre(Serial serial)
            : base(serial)
        {

        }
        
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

            writer.Write(dMinDmg);
            writer.Write(dMaxDmg);
            writer.Write(dSpeed);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            dMinDmg = reader.ReadInt();
            dMaxDmg = reader.ReadInt();
            dSpeed = reader.ReadInt();
		}

    }
}
