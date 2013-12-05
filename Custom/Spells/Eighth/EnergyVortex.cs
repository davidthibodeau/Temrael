using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Eighth
{
	public class EnergyVortexSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Vortex", "Vas Corp Por",
				SpellCircle.Eighth,
				260,
				9032,
				false,
				Reagent.Bloodmoss,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
            );

        public override int RequiredAptitudeValue { get { return 11; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Evocation }; } }

		public EnergyVortexSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 8) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( IPoint3D p )
		{
            Server.Misc.Weather weather = Server.Misc.Weather.GetWeather(Caster.Location);

            if (weather.Wind == QuantityOfWind.Typhon || weather.Wind == QuantityOfWind.Tornade || weather.Wind == QuantityOfWind.Tempete)
            {
                Map map = Caster.Map;

                SpellHelper.GetSurfaceTop(ref p);

                if (map == null || !map.CanSpawnMobile(p.X, p.Y, p.Z))
                {
                    Caster.SendLocalizedMessage(501942); // That location is blocked.
                }
                else if (CheckSequence())
                {
                    double duration = Utility.Random(40, 80);

                    duration = SpellHelper.AdjustValue(Caster, duration, NAptitude.Spiritisme);

                    BaseCreature.Summon(new EnergyVortex(), false, Caster, new Point3D(p), 0x212, TimeSpan.FromSeconds(duration));
                }
            }
            else
            {
                Caster.SendMessage("Il n'y a pas assez de vent pour lancer un vortex !");
            }

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private EnergyVortexSpell m_Owner;

			public InternalTarget( EnergyVortexSpell owner ) : base( 12, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is IPoint3D )
					m_Owner.Target( (IPoint3D)o );
			}

			protected override void OnTargetOutOfLOS( Mobile from, object o )
			{
				from.SendLocalizedMessage( 501943 ); // Target cannot be seen. Try again.
				from.Target = new InternalTarget( m_Owner );
				from.Target.BeginTimeout( from, TimeoutTime - DateTime.Now );
				m_Owner = null;
			}

			protected override void OnTargetFinish( Mobile from )
			{
				if ( m_Owner != null )
					m_Owner.FinishSequence();
			}
        }

        public override TimeSpan GetCastDelay()
        {
            return base.GetCastDelay() + TimeSpan.FromSeconds(4.0);
        }
	}
}