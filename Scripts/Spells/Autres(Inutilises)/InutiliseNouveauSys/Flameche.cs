using System;
using Server.Targeting;
using Server.Network;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Items;
using System.Collections;

namespace Server.Spells
{
    public class Flameche : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static short s_Cercle = 0;

        public static readonly new SpellInfo Info = new SpellInfo(
            "Flameche", "In Flam",
            s_Cercle,
            203,
            9031,
            GetBaseManaCost(s_Cercle),
            TimeSpan.FromSeconds(1),
            SkillName.ArtMagique,
            Reagent.BlackPearl
        );

        public Flameche(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(IPoint3D p)
        {
            if (!Caster.CanSee(p))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, p);

                SpellHelper.GetSurfaceTop(ref p);

                int dx = Caster.Location.X - p.X;
                int dy = Caster.Location.Y - p.Y;
                int rx = (dx - dy) * 44;
                int ry = (dx + dy) * 44;

                bool eastToWest;

                if (rx >= 0 && ry >= 0)
                {
                    eastToWest = false;
                }
                else if (rx >= 0)
                {
                    eastToWest = true;
                }
                else if (ry >= 0)
                {
                    eastToWest = true;
                }
                else
                {
                    eastToWest = false;
                }

                Effects.PlaySound(p, Caster.Map, 0x20C);

                int itemID = eastToWest ? 0x19AB : 0x19AB;

                double duration = 4.0 + (Caster.Skills[SkillName.Evocation].Value * 0.4);

                duration = SpellHelper.AdjustValue(Caster, duration);

                //for ( int i = -3; i <= 3; ++i )
                //{
                Point3D loc = new Point3D(p.X, p.Y, p.Z);

                new FlamecheItem(this, itemID, loc, Caster, Caster.Map, TimeSpan.FromSeconds(duration), 1);
                //}
            }

            FinishSequence();
        }

        [DispellableField]
        public class FlamecheItem : Item
        {
            public override bool CanBeAltered { get { return false; } }

            private Spell m_Spell;
            private Timer m_Timer;
            private DateTime m_End;
            private Mobile m_Caster;

            public Mobile Caster { get { return m_Caster; } }

            public override bool BlocksFit { get { return true; } }

            public FlamecheItem(Spell spell, int itemID, Point3D loc, Mobile caster, Map map, TimeSpan duration, int val)
                : base(itemID)
            {
                bool canFit = SpellHelper.AdjustField(ref loc, map, 12, false);

                Visible = false;
                Movable = false;
                Light = LightType.Circle300;

                MoveToWorld(loc, map);

                m_Spell = spell;
                m_Caster = caster;

                m_End = DateTime.Now + duration;

                m_Timer = new InternalTimer(this, TimeSpan.FromSeconds( /*Math.Abs( val ) * 0.2*/ 0.5), caster.InLOS(this), canFit);
                m_Timer.Start();
            }

            public override void OnAfterDelete()
            {
                base.OnAfterDelete();

                if (m_Timer != null)
                    m_Timer.Stop();
            }

            public FlamecheItem(Serial serial)
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

                            m_Timer = new InternalTimer(this, TimeSpan.Zero, true, true);
                            m_Timer.Start();

                            break;
                        }
                }
            }

            public override bool OnMoveOver(Mobile m)
            {
                if (Visible && m_Caster != null && SpellHelper.ValidIndirectTarget(m_Caster, m) && m_Caster.CanBeHarmful(m, false))
                {
                    if (m == m_Caster)
                        return true;
                    if (m is BaseCreature)
                    {
                        if (((BaseCreature)m).ControlMaster == m_Caster)
                            return true;
                    }
                    m_Caster.DoHarmful(m);

                    //     double damage = Utility.RandomMinMax(5, 8);
                    double damage = Utility.RandomMinMax(3, 4);

                    damage = SpellHelper.AdjustValue(m_Caster, damage);

                    if (m_Spell.CheckResisted(m))
                    {
                        damage *= 0.75;

                        m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                    }

                    AOS.Damage(m, m_Caster, (int)damage, 0, 100, 0, 0, 0);
                    m.PlaySound(0x208);

                }

                return true;
            }

            private class InternalTimer : Timer
            {
                private FlamecheItem m_Item;
                private bool m_InLOS, m_CanFit;

                private static Queue m_Queue = new Queue();

                public InternalTimer(FlamecheItem item, TimeSpan delay, bool inLOS, bool canFit)
                    : base(delay, TimeSpan.FromSeconds(1.0))
                {
                    m_Item = item;
                    m_InLOS = inLOS;
                    m_CanFit = canFit;

                    Priority = TimerPriority.FiftyMS;
                }

                protected override void OnTick()
                {
                    if (m_Item.Deleted)
                        return;

                    if (m_Item == null)
                        return;

                    if (!m_Item.Visible)
                    {
                        if (m_InLOS && m_CanFit)
                            m_Item.Visible = true;
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
                    else
                    {
                        Map map = m_Item.Map;
                        Mobile caster = m_Item.m_Caster;

                        if (map != null && caster != null)
                        {
                            foreach (Mobile m in m_Item.GePlayerMobilesInRange(0))
                            {
                                if ((m.Z + 16) > m_Item.Z && (m_Item.Z + 12) > m.Z && SpellHelper.ValidIndirectTarget(caster, m) && caster.CanBeHarmful(m, false))
                                    m_Queue.Enqueue(m);
                            }

                            while (m_Queue.Count > 0)
                            {
                                Mobile m = (Mobile)m_Queue.Dequeue();

                                bool valid = true;
                                if (m == m_Item.Caster)
                                    valid = false;
                                if (m is BaseCreature)
                                {
                                    if (((BaseCreature)m).ControlMaster == m_Item.Caster)
                                        valid = false;
                                }

                                if (valid)
                                {

                                    caster.DoHarmful(m);

                                    // double damage = Utility.RandomMinMax(5, 8);
                                    double damage = Utility.RandomMinMax(3, 4);


                                    damage = SpellHelper.AdjustValue(caster, damage);

                                    if (m_Item.m_Spell.CheckResisted(m))
                                    {
                                        damage *= 0.75;

                                        m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                                    }

                                    AOS.Damage(m, caster, (int)damage, 0, 100, 0, 0, 0);
                                    m.PlaySound(0x208);
                                }
                            }
                        }
                    }
                }
            }
        }

        private class InternalTarget : Target
        {
            private Flameche m_Owner;

            public InternalTarget(Flameche owner)
                : base(12, true, TargetFlags.None)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is IPoint3D)
                    m_Owner.Target((IPoint3D)o);
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
