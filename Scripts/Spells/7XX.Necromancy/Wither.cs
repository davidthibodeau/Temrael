using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;

namespace Server.Spells
{
	public class WitherSpell : NecromancerSpell
	{
        public static int spellID { get { return 0; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;

		private static SpellInfo m_Info = new SpellInfo(
                "Flétrir", "Kal Vas An Flam",
				SpellCircle.Sixth,
				203,
				9031,
                s_ManaCost,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.NoxCrystal,
				Reagent.GraveDust,
				Reagent.PigIron
            );

		public WitherSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool DelayedDamage{ get{ return false; } }

		public override void OnCast()
		{
            Party party = Engines.PartySystem.Party.Get(Caster);
            bool inParty = false;

			if ( CheckSequence() )
			{
				/* Creates a withering frost around the Caster,
				 * which deals Cold Damage to all valid targets in a radius of 5 tiles.
				 */

				Map map = Caster.Map;

				if ( map != null )
				{
					ArrayList targets = new ArrayList();

					foreach ( Mobile m in Caster.GetMobilesInRange( GetRadiusForSpell() ) )
					{
						if ( Caster != m && Caster.InLOS( m ) && SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) )
                        {
							if (party != null && party.Count > 0)
                            {
                                for (int k = 0; k < party.Members.Count; ++k)
                                {
                                    PartyMemberInfo pmi = (PartyMemberInfo)party.Members[k];
                                    Mobile member = pmi.Mobile;
                                    if (member.Serial == m.Serial)
                                        inParty = true;
                                }
                                if (!inParty)
                                    targets.Add(m);
                            }
                            else
                            {
                                targets.Add(m);
                            }
                        }
                        inParty = false;
					}

					Effects.PlaySound( Caster.Location, map, 0x1FB );
					Effects.PlaySound( Caster.Location, map, 0x10B );
					Effects.SendLocationParticles( EffectItem.Create( Caster.Location, map, EffectItem.DefaultDuration ), 0x37CC, 1, 40, 97, 3, 9917, 0 );

					for ( int i = 0; i < targets.Count; ++i )
					{
						Mobile m = (Mobile)targets[i];

						Caster.DoHarmful( m );
						m.FixedParticles( 0x374A, 1, 15, 9502, 97, 3, (EffectLayer)255 );

                        double damage = Utility.RandomMinMax(30, 35);

                        damage = SpellHelper.AdjustValue(Caster, damage);

                        if (CheckResisted(m))
                        {
                            damage *= 0.75;

                            m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                        }

						SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );
					}
				}
			}

			FinishSequence();
		}
	}
}