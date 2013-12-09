using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Fourth
{
	public class LightningSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Éclair", "Por Ort Grav",
				SpellCircle.Fourth,
				239,
				9021,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
            );

        public override int RequiredAptitudeValue { get { return 5; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] {NAptitude.Evocation }; } }

		public LightningSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
            /*Server.Misc.Weather weather = Server.Misc.Weather.GetWeather(m.Location);

            if (weather.Cloud == DensityOfCloud.FaiblePluie || weather.Cloud == DensityOfCloud.Pluie || weather.Cloud == DensityOfCloud.FortePluie)
            {*/
                if (!Caster.CanSee(m))
                {
                    Caster.SendLocalizedMessage(500237); // Target can not be seen.
                }
                else if (CheckHSequence(m))
                {
                    SpellHelper.Turn(Caster, m);

                    SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                //    double damage = Utility.RandomMinMax(35, 70);
                    double damage = Utility.RandomMinMax(40, 50);

                    damage = SpellHelper.AdjustValue(Caster, damage, NAptitude.Sorcellerie);

                    if (CheckResisted(m))
                    {
                        damage *= 0.75;

                        m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                    }

                    damage *= GetDamageScalar(m);

                    m.BoltEffect(0);

                    SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);
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
			private LightningSpell m_Owner;

			public InternalTarget( LightningSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}