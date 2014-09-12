using System;
using Server.Mobiles;

namespace Server.Engines.Quests.Samurai
{
	public class DeadlyImp : BaseCreature
	{
		[Constructable]
		public DeadlyImp() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a deadly imp";
			Body = 74;
			BaseSoundID = 422;
			Hue = 0x66A;

			SetStr( 91, 115 );
			SetDex( 61, 80 );
			SetInt( 86, 105 );

			SetHits( 1000 );

			SetDamage( 50, 80 );

			SetDamageType( ResistanceType.Contondant, 100 );

			SetResistance( ResistanceType.Physical, 95, 98 );
			SetResistance( ResistanceType.Contondant, 95, 98 );
			SetResistance( ResistanceType.Tranchant, 95, 98 );
			SetResistance( ResistanceType.Perforant, 95, 98 );
			SetResistance( ResistanceType.Magie, 95, 98 );

			SetSkill( SkillName.ArtMagique, 120.0 );
			SetSkill( SkillName.Tactiques, 120.0 );
			SetSkill( SkillName.Anatomie, 120.0 );

			CantWalk = true;
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
						qs.AddObjective( new SecondTrialReturnObjective( false ) );
					}
				}
			}
		}

		public DeadlyImp( Serial serial ) : base( serial )
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