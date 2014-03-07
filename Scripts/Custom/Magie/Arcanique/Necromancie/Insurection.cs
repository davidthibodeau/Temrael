using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class InsurectionSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Insurection", "Kal Xen In Ylem Corp Sanct",
				SpellCircle.Eighth,
				269,
				9070,
				false,
                Reagent.GraveDust,
                Reagent.GraveDust,
                Reagent.DaemonBlood
			);

        public override int RequiredAptitudeValue { get { return 6; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Necromancie }; } }

        public override SkillName CastSkill { get { return SkillName.ArtMagique; } }
        public override SkillName DamageSkill { get { return SkillName.Goetie; } }

        public override bool Invocation { get { return true; } }

        public InsurectionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 5) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
                TimeSpan duration = GetDurationForSpell(30, 1.2);

				SpellHelper.Summon( new SummonedAncientLich(), Caster, 0x217, duration, false, false );
                //else
                //    SpellHelper.Summon( new AncientLich(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}
	}
}