using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;

namespace Server.Spells.Eighth
{
	public class EarthquakeSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Tremblement", "In Vas Por",
				SpellCircle.Eighth,
				233,
				9012,
				false,
				Reagent.Bloodmoss,
				Reagent.Ginseng,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
            );

        public override int RequiredAptitudeValue { get { return 10; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Evocation }; } }

		public EarthquakeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
        }

        public override bool DelayedDamage { get { return true; } }

		public override void OnCast()
		{
            Party party = Engines.PartySystem.Party.Get(Caster);
            bool inParty = false;

			if ( CheckSequence() )
			{
				ArrayList targets = new ArrayList();

				Map map = Caster.Map;

				if ( map != null )
                {
                    double tile = GetRadiusForSpell();

                    if (tile > 12)
                        tile = 12;

					foreach ( Mobile m in Caster.GetMobilesInRange( (int)tile ) )
					{
                        if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false))
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
				}

                Caster.PlaySound(0x2F3);

                double damage = Utility.RandomMinMax(50, 100);

                damage = SpellHelper.AdjustValue(Caster, damage, Aptitude.Sorcellerie);

				for ( int i = 0; i < targets.Count; ++i )
				{
                    Mobile m = (Mobile)targets[i];

					Caster.DoHarmful( m );
					SpellHelper.Damage( TimeSpan.Zero, m, Caster, damage, 0, 0, 0, 0, 100 );
				}
			}

			FinishSequence();
		}
	}
}