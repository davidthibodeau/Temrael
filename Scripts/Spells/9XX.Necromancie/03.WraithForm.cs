using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
    //public class WraithFormSpell : TransformationSpell
    //{
    //    public static int m_SpellID { get { return 903; } } // TOCHANGE

    //    private static short s_Cercle = 3;

    //    public static readonly new SpellInfo Info = new SpellInfo(
    //            "Spectre", "Rel Xen Um",
    //            s_Cercle,
    //            203,
    //            9031,
    //            GetBaseManaCost(s_Cercle),
    //            TimeSpan.FromSeconds(1),
    //            SkillName.Animisme,
    //            Reagent.NoxCrystal,
    //            Reagent.PigIron
    //        );

    //    public override int Body{ get{ return Caster.Female ? 84 : 26; } }
    //    public override int Hue { get { return 0; } }
    //    public override int IntOffset { get { return 5; } }

    //    public WraithFormSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
    //    {
    //    }

    //    public override void PlayEffect( Mobile m )
    //    {
    //        m.PlaySound( 0x17F );
    //        Effects.SendTargetParticles(m, 0x374A, 1, 15, 9902, 1108, 4, EffectLayer.Waist );
    //    }
    //}
}