using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;
using Server.Misc;

namespace Server.Spells
{
    class TotemRegenSpell : Spell
	{
        private const int MaxDuration = 60; // Un tick au 3 secondes.
        private const int MaxHealed = 5;
        public static int m_SpellID { get { return 604; } } // TOCHANGE

        private static short s_Cercle = 4;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Totem de Regeneration", "Goos Fraba",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(5),
                SkillName.Thaumaturgie,
                Reagent.SpidersSilk,
				Reagent.MandrakeRoot
            );

        public TotemRegenSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
        }

        private static Hashtable m_SpellDejaActif = new Hashtable();

        public override void OnCast()
        {
            if (CheckSequence())
            {
                Caster.Target = new InternalTarget(this);
            }
        }

        public void Target( Point3D p )
		{
            if ( CheckBSequence( Caster ) )
			{
                if (m_SpellDejaActif.Contains(Caster))
                {
                    ((Item)m_SpellDejaActif[Caster]).Delete();
                }

				SpellHelper.Turn( Caster, p );

                Totem totem = new Totem(p, Caster.Map);

                m_SpellDejaActif[Caster] = totem;

                TimeSpan duration = TimeSpan.FromSeconds( MaxDuration * GetSpellScaling(Caster, Info.skillForCasting));

				Effects.PlaySound( p, Caster.Map, 0x506 );
                Caster.FixedParticles(0x373A, 1, 17, 9919, 0x527, 0, EffectLayer.Waist);

                new RegenTimer(Caster, totem, duration).Start();
			}

			FinishSequence();
		}

        private class RegenTimer : Timer
        {
            private Mobile m_Caster;
            private Totem m_Totem;
            private DateTime m_End;

            public RegenTimer(Mobile caster, Totem totem, TimeSpan duration)
                : base(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(3.0))
            {
                m_Caster = caster;
                m_Totem = totem;
                m_End = DateTime.Now + duration;

                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (DateTime.Now < m_End)
                {
                    if (!m_Totem.Deleted)
                    {
                        Effects.SendLocationParticles(m_Totem, 0x376A, 2, 50, 0);
                        foreach (Mobile m in m_Totem.GePlayerMobilesInRange(5))
                        {
                            m.Heal((int)(MaxHealed * GetSpellScaling(m_Caster, TotemRegenSpell.Info.skillForCasting)));
                            m.FixedParticles(0x376A, 2, 50, 9919, 0x527, 0, EffectLayer.Waist);
                        }
                    }
                    else
                    {
                        Stop();
                    }
                }
                else
                {
                    Effects.PlaySound(m_Totem.Location, m_Caster.Map, 0x201);
                    Effects.SendLocationParticles(m_Totem, 0x3728, 10, 10, 0);
                    m_Totem.Delete();
                    Stop();
                }
            }
        }
		

        private class InternalTarget : Target
		{
			private TotemRegenSpell m_Owner;

            public InternalTarget(TotemRegenSpell owner)
                : base(12, true, TargetFlags.Beneficial)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
                if (o is LandTarget)
                    m_Owner.Target(((LandTarget)o).Location);
                else
                    from.SendMessage("Vous devez viser le sol.");
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}

        [DispellableField]
        private class Totem : Item
        {
            public Totem(Point3D p, Map m)
                : base(0x38D7)
            {
                Name = "Totem de regeneration";
                Movable = false;
                MoveToWorld(p, m);
                Visible = true;
            }

            public Totem(Serial serial)
                : base(serial)
            {

            }

            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);

                writer.Write((int)1); // version
            }

            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);

                int version = reader.ReadInt();
            }
        }
	}
}
