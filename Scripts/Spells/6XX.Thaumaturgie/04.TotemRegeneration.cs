using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;
using Server.Misc;
using Server.Engines.Combat;
using System.Threading;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Spells
{
    class TotemRegenSpell : Spell
	{
        private const int m_HealPerTick = 5;
        private TimeSpan MaxDuration = TimeSpan.FromSeconds(120);
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

        public void Target( IPoint3D p )
		{
            if (!Caster.CanSee(p))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if ( CheckBSequence( Caster ))
            {
                if (m_SpellDejaActif.Contains(Caster))
                {
                    ((Item)m_SpellDejaActif[Caster]).Delete();
                }

                SpellHelper.GetSurfaceTop(ref p);
				SpellHelper.Turn( Caster, p );

                Point3D point = new Point3D(p);

                Totem totem = new Totem(Caster, point, Caster.Map);

                m_SpellDejaActif[Caster] = totem;

                TimeSpan intervale = TimeSpan.FromSeconds((MaxDuration.TotalSeconds * m_HealPerTick) / (Damage.instance.RandDegatsMagiques(Caster, Info.skillForCasting, Info.Circle, Info.castTime) * 3));

                Effects.PlaySound(p, Caster.Map, 0x506);
                Caster.FixedParticles(0x373A, 1, 17, 9919, 0x527, 0, EffectLayer.Waist);

                new RegenTimer(Caster, totem, MaxDuration, intervale).Start();
			}

			FinishSequence();
		}

        private class RegenTimer : Timer
        {
            private Mobile m_Caster;
            private Totem m_Totem;
            private DateTime m_End;

            public RegenTimer(Mobile caster, Totem totem, TimeSpan duration, TimeSpan intervale)
                : base(TimeSpan.FromSeconds(1.0), intervale)
            {
                m_Caster = caster;
                m_Totem = totem;
                totem.timer = this;
                m_End = DateTime.Now + duration;

                Priority = TimerPriority.FiftyMS;
            }

            protected override void OnTick()
            {
                if (DateTime.Now < m_End)
                {
                    if (!m_Totem.Deleted)
                    {
                        Effects.SendLocationParticles(m_Totem, 0x376A, 2, 50, 0);
                        foreach (Mobile m in m_Totem.GetMobilesInRange(5))
                        {
                            m.Heal(m_HealPerTick);
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
                if (o is IPoint3D)
                    m_Owner.Target((IPoint3D)o);
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}

        [DispellableField]
        private class Totem : Item
        {
            private Mobile Caster;
            public Timer timer;

            public Totem(Mobile caster, Point3D p, Map m)
                : base(0x38D7)
            {
                Name = "Totem de regeneration";
                Movable = false;
                CanBeAltered = false;
                MoveToWorld(p, m);
                Visible = true;
                Caster = caster;
            }

            public Totem(Serial serial)
                : base(serial)
            {

            }

            private class DispelEntry : ContextMenuEntry
            {
                private Mobile m_From;
                private Totem Totem;

                public DispelEntry(Mobile from, Totem totem)
                    : base(6257, 1)
                {
                    m_From = from;
                    Totem = totem;
                }

                public override void OnClick()
                {
                    if (m_From.Alive)
                    {
                        Totem.timer.Stop();
                        Totem.Delete();
                    }
                }
            }

            public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
            {
                if(from == Caster) 
                    list.Add(new DispelEntry(from, this));
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
