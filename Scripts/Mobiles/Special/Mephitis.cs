using System;
using Server;
using Server.Items;
using Server.Engines.CannedEvil;

namespace Server.Mobiles
{
	public class Mephitis : BaseChampion
	{
		public override ChampionSkullType SkullType{ get{ return ChampionSkullType.Venom; } }

        public override Type[] UniqueList { get { return new Type[] { }; } }
		public override Type[] SharedList { get { return new Type[] { typeof(ANecromancerShroud), typeof(EmbroideredOakLeafCloak), typeof(TheMostKnowledgePerson) }; } }
		public override Type[] DecorativeList{ get{ return new Type[] { typeof( Web ), typeof( MonsterStatuette ) }; } }

		public override MonsterStatuetteType[] StatueTypes{ get{ return new MonsterStatuetteType[] { MonsterStatuetteType.Spider }; } }

		[Constructable]
		public Mephitis() : base( AIType.AI_Melee )
		{
			Body = 173;
			Name = "Mephitis";

			BaseSoundID = 0x183;

			SetStr( 505, 1000 );
			SetDex( 102, 300 );
			SetInt( 402, 600 );

			SetHits( 3000 );
			SetStam( 105, 600 );

			SetDamage( 21, 33 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Perforant, 50 );

			SetResistance( ResistanceType.Physical, 75, 80 );
			SetResistance( ResistanceType.Contondant, 60, 70 );
			SetResistance( ResistanceType.Tranchant, 60, 70 );
			SetResistance( ResistanceType.Perforant, 100 );
			SetResistance( ResistanceType.Magie, 60, 70 );

			SetSkill( SkillName.Concentration, 70.7, 140.0 );
			SetSkill( SkillName.Tactiques, 97.6, 100.0 );
			SetSkill( SkillName.Anatomie, 97.6, 100.0 );

			VirtualArmor = 80;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 4 );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			// TODO: Web ability
		}

		public Mephitis( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}