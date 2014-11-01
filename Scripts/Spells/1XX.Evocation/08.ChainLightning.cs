using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;

namespace Server.Spells
{
	public class ChainLightningSpell : Spell
	{
        public static int m_SpellID { get { return 108; } } // TOCHANGE

        private static short s_Cercle = 8;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Éclair en Chaine", "Vas Ort Grav",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.BlackPearl,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
            );

		public ChainLightningSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( IPoint3D p )
		{
            Party party = Engines.PartySystem.Party.Get(Caster);
            bool inParty = false;

            /*Server.Misc.Weather weather = Server.Misc.Weather.GetWeather(Caster.Location);

            if (weather.Cloud == DensityOfCloud.FaiblePluie || weather.Cloud == DensityOfCloud.Pluie || weather.Cloud == DensityOfCloud.FortePluie)
            {*/
                if (!Caster.CanSee(p))
                {
                    Caster.SendLocalizedMessage(500237); // Target can not be seen.
                }
                else if (CheckSequence())
                {
                    SpellHelper.Turn(Caster, p);

                    if (p is Item)
                        p = ((Item)p).GetWorldLocation();

                    ArrayList targets = new ArrayList();

                    Map map = Caster.Map;

                    if (map != null)
                    {
                        IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), GetRadiusForSpell());

                        foreach (Mobile m in eable)
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

                        eable.Free();
                    }

               //     double damage = Utility.RandomMinMax(60, 120);
                    double damage = Utility.RandomMinMax(30, 60);

                    damage = SpellHelper.AdjustValue(Caster, damage);

                    if (targets.Count > 0)
                    {
                        for (int i = 0; i < targets.Count; ++i)
                        {
                            Mobile m = (Mobile)targets[i];

                            if (CheckResisted(m))
                            {
                                damage *= 0.75;

                                m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                            }

                            damage *= GetDamageScalar(m);

                            Caster.DoHarmful(m);
                            SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);

                            m.BoltEffect(0);
                        }
                    }
                }
            /*}
            else
            {
                Caster.SendMessage("Il n'y a pas assez de nuages pour lancer un eclair !");
            }*/

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ChainLightningSpell m_Owner;

			public InternalTarget( ChainLightningSpell owner ) : base( 12, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D p = o as IPoint3D;

				if ( p != null )
					m_Owner.Target( p );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}