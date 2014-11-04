using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Engines.Combat;

namespace Server.Spells
{
	public class LightningSpell : Spell
	{
        public static int m_SpellID { get { return 105; } } // TOCHANGE

        private static short s_Cercle = 5;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Éclair", "Por Ort Grav",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.Evocation,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
            );

		public LightningSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

                    m.BoltEffect(0);

                    Damage.instance.AppliquerDegatsMagiques(m, Damage.instance.GetDegatsMagiques(Caster, Info.skillForCasting, Info.Circle, Info.castTime));
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