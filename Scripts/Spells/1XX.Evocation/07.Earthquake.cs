using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;
using Server.Engines.Combat;

namespace Server.Spells
{
	public class EarthquakeSpell : Spell
	{
        public static int m_SpellID { get { return 107; } } // TOCHANGE

        private static short s_Cercle = 7;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Tremblement", "In Vas Por",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.Bloodmoss,
				Reagent.Ginseng,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
            );

		public EarthquakeSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

                double damage = Damage.instance.GetDegatsMagiques(Caster, Info.skillForCasting, Info.Circle, Info.castTime) / 2;

				for ( int i = 0; i < targets.Count; ++i )
				{
                    Mobile m = (Mobile)targets[i];

					Caster.DoHarmful( m );
                    Damage.instance.AppliquerDegatsMagiques(m, damage);
				}
			}

			FinishSequence();
		}
	}
}