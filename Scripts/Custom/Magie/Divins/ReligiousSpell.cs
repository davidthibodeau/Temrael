using System;
using System.Text;
using Server;
using Server.Mobiles;
using Server.Network;

namespace Server.Spells
{
	public abstract class ReligiousSpell : Spell
	{
        public override SkillName CastSkill { get { return SkillName.Miracles; } }
        public override SkillName DamageSkill { get { return SkillName.Miracles; } }

        public override StatType DamageStat { get { return StatType.Cha; } }

        public ReligiousSpell(Mobile caster, Item scroll, SpellInfo info) : base(caster, scroll, info)
		{
        }

        public static void MiracleEffet(Mobile Caster, Mobile mob, int ID, int speed, int dura, int effect, int hue, int render, EffectLayer layer)
        {
            mob.FixedParticles(ID, speed, dura, effect, layer);
            /*if (mob != null && mob.Map != null)
            {
                Packet p = null;
                IPooledEnumerable eable = mob.Map.GetClientsInRange(mob.Location);

                foreach (NetState state in eable)
                {
                    if (state.Mobile.CanSee(mob) && (state.Mobile.InLOS(mob)))
                    {
                        if (state.Mobile is TMobile && Caster is TMobile)
                        {
                            if (((TMobile)state.Mobile).Dieux == ((TMobile)Caster).Dieux)
                            if (p == null)
                            {
                                p = new HuedEffect(EffectType.FixedFrom, Caster.Serial, mob.Serial, ID, Caster.Location, mob.Location, speed, dura, true, false, hue, render);
                                p.Acquire();
                            }
                            state.Send(p);
                        }
                    }
                }
                Packet.Release(p);
                eable.Free();
            }*/
        }
    }
}