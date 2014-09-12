using System;
using Server.Mobiles;

namespace Server.Engines.Quests.Samurai
{
	public class FierceDragon : BaseCreature
	{
		[Constructable]
		public FierceDragon() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a fierce dragon";
			Body = 103;
			BaseSoundID = 362;

			SetStr( 6000, 6020 );
			SetDex( 0 );
			SetInt( 850, 870 );

			SetDamage( 50, 80 );

			SetDamageType( ResistanceType.Contondant, 100 );

			SetResistance( ResistanceType.Physical, 95, 98 );
			SetResistance( ResistanceType.Contondant, 95, 98 );
			SetResistance( ResistanceType.Tranchant, 95, 98 );
			SetResistance( ResistanceType.Perforant, 95, 98 );
			SetResistance( ResistanceType.Magie, 95, 98 );

			SetSkill( SkillName.Tactiques, 120.0 );
			SetSkill( SkillName.Anatomie, 120.0 );
			SetSkill( SkillName.ArtMagique, 120.0 );

			CantWalk = true;
		}

		public override int GetIdleSound()
		{
			return 0x2C4;
		}

		public override int GetAttackSound()
		{
			return 0x2C0;
		}

		public override int GetDeathSound()
		{
			return 0x2C1;
		}

		public override int GetAngerSound()
		{
			return 0x2C4;
		}

		public override int GetHurtSound()
		{
			return 0x2C3;
		}

		public override void AggressiveAction( Mobile aggressor, bool criminal )
		{
			base.AggressiveAction( aggressor, criminal );

			PlayerMobile player = aggressor as PlayerMobile;
			if ( player != null )
			{
				QuestSystem qs = player.Quest;
				if ( qs is HaochisTrialsQuest )
				{
					QuestObjective obj = qs.FindObjective( typeof( SecondTrialAttackObjective ) );
					if ( obj != null && !obj.Completed )
					{
						obj.Complete();
						qs.AddObjective( new SecondTrialReturnObjective( true ) );
					}
				}
			}
		}

		public FierceDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}