using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Items;

namespace Server.Spells
{
	public class MiracleSpell : ReligiousSpell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Miracle", "Wun Gebo",
				SpellCircle.Eighth,
				212,
				9041
            );

        public MiracleSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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
                SpellHelper.Turn(Caster, p);

				SpellHelper.GetSurfaceTop( ref p );

                int ItemID = 4825;
                string name = "Miracle";
                int hue = 2041;

                TotemType type = TotemType.Miracle;
                DateTime delete = DateTime.Now + GetDurationForSpell(0.2);
                int range = 1 + (int)(Caster.Skills[CastSkill].Value / 10);
                double bonus = 0.10 + (double)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 400);

                int effectid = 14138;
                int effectspeed = 10;
                int effectduration = 20;
                EffectLayer layer = EffectLayer.Head;
                int soundid = 532;

                Totem totem = new Totem(ItemID, name, hue, range, type, delete, Caster, bonus, effectid, effectspeed, effectduration, layer, soundid);

                if (totem != null)
                {
                    totem.MoveToWorld(new Point3D(p), Caster.Map);
                    totem.FixedParticles(effectid, effectspeed, effectduration, 5005, hue, 0, layer);
                    totem.PlaySound(soundid); 
                }

                new MiracleTimer(totem).Start();
            }

            FinishSequence();
        }

        public class MiracleTimer : Timer
        {
            private Totem m_BaseTotem;

            public MiracleTimer(Totem totem)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(5))
            {
                m_BaseTotem = totem;
            }

            protected override void OnTick()
            {
                if (m_BaseTotem == null || m_BaseTotem.Deleted || m_BaseTotem.Caster == null || m_BaseTotem.Caster.Deleted || !m_BaseTotem.Caster.Alive)
                {
                    Stop();
                    m_BaseTotem.Delete();
                    return;
                }

                foreach (Item itema in m_BaseTotem.GetItemsInRange(1 + (int)(m_BaseTotem.Caster.Skills[SkillName.ArtMagique].Base / 10)))
                {
                    if (itema != null && itema is Corpse)
                    {
                        Corpse c = (Corpse)itema;

                        if (c != null && c.Owner != null && c.Owner is TMobile)
                        {
                            TMobile pm = (TMobile)(c.Owner);

                            if (pm.MortCurrentState == MortState.Assomage || pm.MortCurrentState == MortState.MortDefinitive)
                            {
                                //pm.AddFatigue(-100);

                                SpellHelper.Turn(m_BaseTotem.Caster, pm);

                                pm.PlaySound(0x214);
                                pm.FixedEffect(0x376A, 10, 16);

                                if (pm.TimerEvanouie != null)
                                {
                                    pm.TimerEvanouie.Stop();
                                    pm.TimerEvanouie = null;
                                }

                                if (pm.TimerMort != null)
                                {
                                    pm.TimerMort.Stop();
                                    pm.TimerMort = null;
                                }

                                pm.Location = c.Location;
                                pm.EndroitMort = c.Location;
                                pm.RisqueDeMort = false;
                                pm.Mort = false;
                                pm.Frozen = false;

                                pm.Direction = c.Direction;
                                pm.MoveToWorld(c.Location, c.Map);
                                pm.Animate(21, 5, 1, false, false, 0);

                                pm.Resurrect();

                                if (c != null)
                                {
                                    ArrayList list = new ArrayList();

                                    foreach (Item item in c.Items)
                                    {
                                        list.Add(item);
                                    }

                                    foreach (Item item in list)
                                    {
                                        if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
                                            item.Delete();

                                        if (item is BaseRaceGumps || c.EquipItems.Contains(item))
                                        {
                                            if (!pm.EquipItem(item))
                                                pm.AddToBackpack(item);
                                        }
                                        else
                                        {
                                            pm.AddToBackpack(item);
                                        }
                                    }
                                }

                                pm.CheckRaceGump();
                                pm.CheckStatTimers();

                                pm.MortCurrentState = MortState.Resurrection;
                            }
                        }
                    }
                }
            }
        }

		private class InternalTarget : Target
		{
            private MiracleSpell m_Owner;

            public InternalTarget(MiracleSpell owner)
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
	}
}