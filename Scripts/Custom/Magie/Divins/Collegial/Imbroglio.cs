using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Misc;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
	public class ImbroglioSpell : ReligiousSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Imbroglio", "Sanct Ghua Hur",
				SpellCircle.Fifth,
				212,
				9041
            );

        public override int RequiredAptitudeValue { get { return 5; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] {NAptitude.Protection }; } }

        public ImbroglioSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

        public void Target(IPoint3D p)
        {
            if (!Caster.CanSee(p))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                Effects.SendLocationEffect(p, Caster.Map, 14189, 18, 0, 0);

                SpellHelper.Turn(Caster, p);

                if (p is Item)
                    p = ((Item)p).GetWorldLocation();

                Caster.FixedParticles(14276, 10, 20, 5013, 2041, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(21);

                TimeSpan duration = GetDurationForSpell(0.2);

                int Count = 0;
                int Checkcount = 0;

                while (Count < (2 + (int)Caster.Skills[CastSkill].Value / 20) && Checkcount < 15)
                {
                    Point3D location = new Point3D(p.X + Utility.Random(-4, 8), p.Y + Utility.Random(-4, 8), p.Z);

                    bool canFit = SpellHelper.AdjustField(ref location, Caster.Map, 12, false);

                    if (canFit)
                    {
                        Count++;
                        new InternalItem(14120, location, Caster, Caster.Map, duration, 1);
                    }

                    Effects.PlaySound(location, Caster.Map, 531);

                    Checkcount++;
                }

            }

            FinishSequence();
        }

		private class InternalTarget : Target
		{
            private ImbroglioSpell m_Owner;

            public InternalTarget(ImbroglioSpell owner)
                : base(12, true, TargetFlags.None)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is IPoint3D )
				{
                    m_Owner.Target((IPoint3D)o);
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}

        private class InternalItem : Item
        {
            private Timer m_Timer;
            private DateTime m_End;
            private Mobile m_Caster;

            public override bool BlocksFit { get { return true; } }

            public InternalItem(int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, int val)
                : base(itemID)
            {
                bool canFit = SpellHelper.AdjustField(ref loc, caster.Map, 12, false);

                Visible = true;
                Movable = false;

                MoveToWorld(loc, map);

                m_Caster = caster;

                m_End = DateTime.Now + duration;

                m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(Math.Abs(val) * 0.2), caster.InLOS(this), canFit, m_Caster);
                m_Timer.Start();
            }

            public override void OnAfterDelete()
            {
                base.OnAfterDelete();

                if (m_Timer != null)
                    m_Timer.Stop();
            }

            public InternalItem(Serial serial)
                : base(serial)
            {
            }

            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);

                writer.Write((int)1); // version

                writer.Write(m_Caster);
                writer.WriteDeltaTime(m_End);
            }

            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);

                int version = reader.ReadInt();

                switch (version)
                {
                    case 1:
                        {
                            m_Caster = reader.ReadMobile();

                            goto case 0;
                        }
                    case 0:
                        {
                            m_End = reader.ReadDeltaTime();

                            m_Timer = new InternalTimer(this, TimeSpan.Zero, true, true, m_Caster);
                            m_Timer.Start();

                            break;
                        }
                }
            }

            public override bool OnMoveOver(Mobile m)
            {
                return false;
            }

            private class InternalTimer : Timer
            {
                private InternalItem m_Item;
                private bool m_InLOS, m_CanFit;
                private Mobile m_Caster;

                private static Queue m_Queue = new Queue();

                public InternalTimer(InternalItem item, TimeSpan delay, bool inLOS, bool canFit, Mobile caster)
                    : base(delay, TimeSpan.FromSeconds(Utility.Random(2, 2)))
                {
                    m_Item = item;
                    m_InLOS = inLOS;
                    m_CanFit = canFit;
                    m_Caster = caster;

                    Priority = TimerPriority.FiftyMS;
                }

                protected override void OnTick()
                {
                    if (m_Item.Deleted)
                        return;

                    if (!m_Caster.Alive)
                    {
                        m_Item.Delete();
                        Stop();
                    }
                    else if (!m_Item.Visible)
                    {
                        if (m_InLOS && m_CanFit)
                            m_Item.Visible = false;
                        else
                            m_Item.Delete();

                        if (!m_Item.Deleted)
                        {
                            m_Item.ProcessDelta();
                            Effects.SendLocationParticles(EffectItem.Create(m_Item.Location, m_Item.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 5029);
                        }
                    }
                    else if (DateTime.Now > m_Item.m_End)
                    {
                        m_Item.Delete();
                        Stop();
                    }
                }
            }
        }
	}
}