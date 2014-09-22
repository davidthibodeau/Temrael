using System;
using Server;

namespace Server.Spells
{
	public abstract class NecromancerSpell : Spell
	{
        public override SkillName CastSkill { get { return SkillName.ArtMagique; } }
		public override SkillName DamageSkill{ get{ return SkillName.Necromancie; } }

		public override bool ClearHandsOnCast{ get{ return false; } }

	//	public override int CastDelayFastScalar{ get{ return 0; } } // Necromancer spells are not effected by fast cast items, though they are by fast cast recovery

		public NecromancerSpell( Mobile caster, Item scroll, SpellInfo info ) : base( caster, scroll, info )
		{
		}
	}
}