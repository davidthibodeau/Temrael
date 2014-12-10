using System;
using System.Collections;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
	public class SagesseSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Sagesse", "Reta Toki",
				3,
				203,
				9031
            );

		public SagesseSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !(m is BaseCreature || m is PlayerMobile) )
			{
				Caster.SendLocalizedMessage( 1060508 ); // You can't curse that.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

                m.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(514);

                SkillMod[] mods = (SkillMod[])m_Table[m];

				if ( mods == null )
				{
                    /*mods = new SkillMod[7]
                    {
                        new DefaultSkillMod( SkillName.Tactiques, false, m.Skills[SkillName.Tactiques].Base + (Caster.Skills[CastSkill].Value / 4) ),
                        new DefaultSkillMod( SkillName.Parer, false, m.Skills[SkillName.Parer].Base + (Caster.Skills[CastSkill].Value / 4) ),
                        new DefaultSkillMod( SkillName.ArmeTranchante, false, m.Skills[SkillName.ArmeTranchante].Base + (Caster.Skills[CastSkill].Value / 4) ),
                        new DefaultSkillMod( SkillName.ArmeHaste, false, m.Skills[SkillName.ArmeHaste].Base + (Caster.Skills[CastSkill].Value / 4) ),
                        new DefaultSkillMod( SkillName.ArmeDistance, false, m.Skills[SkillName.ArmeDistance].Base + (Caster.Skills[CastSkill].Value / 4) ),
                        new DefaultSkillMod( SkillName.ArmePerforante, false, m.Skills[SkillName.ArmePerforante].Base + (Caster.Skills[CastSkill].Value / 4) ),
                        new DefaultSkillMod( SkillName.ArmePoing, false, m.Skills[SkillName.ArmePoing].Base + (Caster.Skills[CastSkill].Value / 4) ),
                        new DefaultSkillMod( SkillName.ArmeArmorMaillons.resistance_Contondante, false, m.Skills[SkillName.ArmeArmorMaillons.resistance_Contondante].Base + (Caster.Skills[CastSkill].Value / 4) )
                    };*/

                    for (int i = 0; i < mods.Length; ++i)
                        m.AddSkillMod(mods[i]);

					m_Table[m] = mods;

                    TimeSpan duration = TimeSpan.FromSeconds(0);

                    new SagesseSpell.InternalTimer(m, duration).Start();
				}
			}

			FinishSequence();
		}

		private static Hashtable m_Table = new Hashtable();

		public static void StopTimer( Mobile m )
		{
            SkillMod[] mods = (SkillMod[])m_Table[m];

            if (mods != null)
            {
                for (int i = 0; i < mods.Length; ++i)
                    m.RemoveSkillMod(mods[i]);

                m.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(514);

                m_Table.Remove(m);
            }
		}

        private class InternalTimer : Timer
        {
            private Mobile target;

            public InternalTimer(Mobile targ, TimeSpan duration)
                : base(duration)
            {
                target = targ;
            }

            protected override void OnTick()
            {
                if (target == null || target.Deleted)
                    return;

                SkillMod[] mods = (SkillMod[])m_Table[target];

                target.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                target.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                target.PlaySound(514);

                m_Table.Remove(target);

                for (int i = 0; i < mods.Length; ++i)
                    target.RemoveSkillMod(mods[i]);
            }
        }

		private class InternalTarget : Target
		{
            private SagesseSpell m_Owner;

            public InternalTarget(SagesseSpell owner)
                : base(12, false, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
				else
					from.SendLocalizedMessage( 1060508 ); // You can't curse that.
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}