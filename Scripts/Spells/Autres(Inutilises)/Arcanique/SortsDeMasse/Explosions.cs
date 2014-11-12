using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using System.Collections;

namespace Server.Spells
{
	public class ExplosionsSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Explosions", "Vas Ort Flam",
				4,
				230,
				9041,
				Reagent.Bloodmoss,
                Reagent.SulfurousAsh,
                Reagent.SulfurousAsh
            );

		public ExplosionsSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

                if (p is Item)
                    p = ((Item)p).GetWorldLocation();

                ArrayList targets = new ArrayList();

                Map map = Caster.Map;

                if (map != null)
                {
                    IPooledEnumerable eable = map.GePlayerMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 2 + Caster.Skills[CastSkill].Value / 50, true));

                    foreach (Mobile m in eable)
                    {
                        if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && !(Caster.Party == m.Party))
                        {
                            targets.Add(m);
                        }
                    }

                    eable.Free();
                }

                if (targets.Count > 0)
                {
                    for (int i = 0; i < targets.Count; ++i)
                    {
                        Mobile m = (Mobile)targets[i];

                        if (Caster.CanSee(m))
                        {
                            Disturb(m);

                            //double damage = GetNewAosDamage(15, 1, 5, true);

                            if (CheckResisted(m))
                            {
                                //damage *= 0.75;

                                m.SendLocalizedMessage(501783); // You feel yourself resisting magical energy.
                            }

                            m.FixedParticles(0x36BD, 20, 10, 5044, EffectLayer.Head);
                            m.PlaySound(0x307);

                            //SpellHelper.Damage(this, m, damage, 0, 100, 0, 0, 0);
                        }
                    }
                }
            }

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ExplosionsSpell m_Owner;

			public InternalTarget( ExplosionsSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
                IPoint3D p = o as IPoint3D;

                if (p != null)
                    m_Owner.Target(p);
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}