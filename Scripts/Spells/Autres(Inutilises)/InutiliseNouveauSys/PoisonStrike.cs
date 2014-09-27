using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;

namespace Server.Spells
{
	public class PoisonStrikeSpell : NecromancerSpell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_DureeCastCast = TimeSpan.FromSeconds(1);

		private static SpellInfo m_Info = new SpellInfo(
				"Venin", "In Vas Nox",
				SpellCircle.Seventh,
				203,
				9031,
                s_ManaCost,
                s_DureeCastCast,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.NoxCrystal
            );

		public PoisonStrikeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

		public void Target( Mobile m )
		{
            Party party = Engines.PartySystem.Party.Get(Caster);
            bool inParty = false;

			if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				/* Creates a blast of poisonous energy centered on the target.
				 * The main target is inflicted with a large amount of Poison damage, and all valid targets in a radius of 2 tiles around the main target are inflicted with a lesser effect.
				 * One tile from main target receives 50% damage, two tiles from target receives 33% damage.
				 */

				CheckResisted( m ); // Check magic resist for skill, but do not use return value

				Effects.SendLocationParticles( EffectItem.Create( m.Location, m.Map, EffectItem.DefaultDuration ), 0x36B0, 1, 14, 63, 7, 9915, 0 );
				Effects.PlaySound( m.Location, m.Map, 0x229 );

                //double damage = Utility.RandomMinMax(10, 20) * ((300 + (GetDamageSkill(Caster) * 9)) / 1000);

                //damage = SpellHelper.AdjustValue(Caster, damage);

                int level;

                double total = Caster.Skills[SkillName.Necromancie].Value; // + Caster.Skills[SkillName.Empoisonner].Value;

                if (total >= 90.0)
                    level = 3;
                else if (total > 70.0)
                    level = 2;
                else if (total > 45.0)
                    level = 1;
                else
                    level = 0;

                m.ApplyPoison(Caster, Poison.GetPoison(level));

                //SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);

				Map map = m.Map;

				if ( map != null )
				{
					ArrayList targets = new ArrayList();

					foreach ( Mobile targ in m.GetMobilesInRange( GetRadiusForSpell() ) )
					{
                        if ((Caster != targ && m != targ && SpellHelper.ValidIndirectTarget(Caster, targ)) && Caster.CanBeHarmful(targ, false))
                        {
                            if (party != null && party.Count > 0)
                            {
                                for (int k = 0; k < party.Members.Count; ++k)
                                {
                                    PartyMemberInfo pmi = (PartyMemberInfo)party.Members[k];
                                    Mobile member = pmi.Mobile;
                                    if (member.Serial == targ.Serial)
                                        inParty = true;
                                }
                                if (!inParty)
                                    targets.Add(targ);
                            }
                            else
                            {
                                targets.Add(targ);
                            }
                        }
                        inParty = false;
					}

					for ( int i = 0; i < targets.Count; ++i )
					{
						Mobile targ = (Mobile)targets[i];

                        targ.ApplyPoison(Caster, Poison.GetPoison(level));

                        //SpellHelper.Damage(this, targ, damage, 0, 0, 0, 0, 100);

                        /*if (!m_Table.Contains(targ))
                        {
                            Timer t = new InternalTimer(targ, Caster);
                            t.Start();

                            m_Table[targ] = t;
                        }*/
					}
				}
			}

			FinishSequence();
        }

        /*private class InternalTimer : Timer
        {
            private Mobile m_Target;
            private Mobile m_Caster;

            private DateTime m_NextHit, m_LastHit;
            private int m_HitDelay;

            public InternalTimer(Mobile target, Mobile caster) : base(TimeSpan.FromSeconds(0.1), TimeSpan.FromSeconds(0.1))
            {
                Priority = TimerPriority.FiftyMS;

                m_Target = target;
                m_Caster = caster;

                m_HitDelay = 1;
                m_NextHit = DateTime.Now + TimeSpan.FromSeconds(m_HitDelay);
                m_LastHit = DateTime.Now + TimeSpan.FromSeconds(5.1);
            }

            protected override void OnTick()
            {
                if (!m_Target.Alive || DateTime.Now > m_LastHit)
                {
                    if (m_Table.Contains(m_Target))
                        m_Table.Remove(m_Target);

                    Stop();
                }

                if (!m_Target.Alive || DateTime.Now < m_NextHit || DateTime.Now > m_LastHit)
                    return;

                m_NextHit = DateTime.Now + TimeSpan.FromSeconds(m_HitDelay);

                double toDamage = 5 + (10 * ((m_Caster.Skills[SkillName.ArtMagique].Value + m_Caster.Skills[SkillName.Necromancie].Value) / 200));

                m_Target.Damage((int)toDamage);
            }
        }*/

        private static Hashtable m_Table = new Hashtable();

		private class InternalTarget : Target
		{
			private PoisonStrikeSpell m_Owner;

			public InternalTarget( PoisonStrikeSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}