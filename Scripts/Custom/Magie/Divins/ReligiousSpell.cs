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

        }
    }
}