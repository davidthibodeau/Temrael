using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.Engines.Quests;
using Server.Engines.Quests.Haven;
using Server.ContextMenus;

namespace Server.Mobiles
{
	public class CorruptedSoul : BaseCreature
	{
		public override bool DeleteCorpseOnDeath{ get{ return true; } }
		
		[Constructable]
		public CorruptedSoul() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, .1, 5 )
		{
			Name = "a corrupted soul";
            Body = 400;
			Hue = 0x453;

			SetStr( 102, 115 );
			SetDex( 101, 115 );
			SetInt( 203, 215 );

			SetHits( 61, 69 );

			SetDamage( 4, 40 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 61, 74 );
			SetResistance( ResistanceType.Contondant, 22, 48 );
			SetResistance( ResistanceType.Tranchant, 73, 100 );
			SetResistance( ResistanceType.Perforant, 0 );
			SetResistance( ResistanceType.Magie, 51, 60 );

			SetSkill( SkillName.Concentration, 80.2, 89.4 );
			SetSkill( SkillName.Tactiques, 81.3-89.9 );
			SetSkill( SkillName.ArmePoing, 80.1, 88.7 );

			Fame = 5000;
			Karma = -5000;

			// VirtualArmor = 6; Not sure
		}

		public override bool AlwaysAttackable{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } } // NEED TO VERIFY

		// NEED TO VERIFY SOUNDS! Known: No Idle Sound.

		/*public override int GetAngerSound()
		{
			return 0x0;
		}*/

		public override int GetAttackSound()
		{
			return 0x233;
		}

		/*public override int GetDeathSound()
		{
			return 0x0;
		}*/

		public override bool AlwaysMurderer{ get{ return true; } }

		// TODO: Proper OnDeath Effect

		public override bool OnBeforeDeath()
		{
			if ( !base.OnBeforeDeath() )
				return false;

			// 1 in 20 chance that a Thread of Fate will appear in the killer's pack

			Effects.SendLocationEffect( Location, Map, 0x376A, 10, 1 );
			return true;
		}

		public CorruptedSoul( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
