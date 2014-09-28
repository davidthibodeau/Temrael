using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class EnergyVortexSpell : Spell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_DureeCast = TimeSpan.FromSeconds(1);

		public static readonly SpellInfo m_Info = new SpellInfo(
				"Vortex", "Vas Corp Por",
				SpellCircle.Eighth,
				260,
				9032,
                s_ManaCost,
                s_DureeCast,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.Bloodmoss,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
            );

		public EnergyVortexSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 1) > Caster.FollowersMax )
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
            /*Server.Misc.Weather weather = Server.Misc.Weather.GetWeather(Caster.Location);

            if (weather.Wind == QuantityOfWind.Typhon || weather.Wind == QuantityOfWind.Tornade || weather.Wind == QuantityOfWind.Tempete)
            {*/
                Map map = Caster.Map;

                SpellHelper.GetSurfaceTop(ref p);

                if (map == null || !map.CanSpawnMobile(p.X, p.Y, p.Z))
                {
                    Caster.SendLocalizedMessage(501942); // That location is blocked.
                }
                else if (CheckSequence())
                {
                    double duration = Utility.Random(40, 80);

                    duration = SpellHelper.AdjustValue(Caster, duration);

                    BaseCreature.Summon(new EnergyVortex(), true, Caster, new Point3D(p), 0x212, TimeSpan.FromSeconds(duration));
                }
            /*}
            else
            {
                Caster.SendMessage("Il n'y a pas assez de vent pour lancer un vortex !");
            }*/

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