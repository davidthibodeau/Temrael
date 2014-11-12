using System;
using System.Collections;
using Server;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Prompts;
using Server.Spells;
using Server.Mobiles;
using Server.Targeting;
using Server.Scripts.Commands;

namespace Server.Spells
{
    public class SubterfugeSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static readonly new SpellInfo Info = new SpellInfo(
                "Subterfuge", "Quas Rel Xen Corp",
                2,
                221,
                9002,
                Reagent.Garlic,
                Reagent.Ginseng,
                Reagent.Nightshade
            );

		private int m_NewBody;
        private int m_HueMod;
        private string m_NameMod;

        public static Hashtable m_Mods = new Hashtable();

		public SubterfugeSpell( Mobile caster, Item scroll, string name, int body, int hue) : base( caster, scroll, Info )
		{
			m_NewBody = body;
            m_NameMod = name;
            m_HueMod = hue;
		}

		public SubterfugeSpell( Mobile caster, Item scroll ) : this(caster, scroll, null, 0, -1)
		{
		}

		public override void OnCast()
		{
            if (!Caster.CanBeginAction(typeof(SubterfugeSpell)))
            {
                if (Caster is PlayerMobile)
                {
                    PlayerMobile pm = (PlayerMobile)Caster;
                    pm.Transformation.OnTransformationChange(0, null, -1, true);
                }
                else
                {
                    Caster.BodyMod = 0;
                    Caster.NameMod = null;
                }

                Caster.EndAction(typeof(SubterfugeSpell));

                Caster.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                Caster.PlaySound(0x3BD);

                if (Caster is PlayerMobile)
                    ((PlayerMobile)Caster).CheckRaceGump();

                BaseArmor.ValidateMobile(Caster);
            }
            else if (m_NewBody == 0)
            {
                ArrayList entries = new ArrayList();
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Panthère", ShrinkTable.Lookup(0xD6), 0xD6, 1015237, 0, 0, 0, 0, 0));
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Spectre", ShrinkTable.Lookup(0x1A), 0x1A, 1015246, 0, 0, 0, 0, 999999));
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Wisp", ShrinkTable.Lookup(0x3A), 0x3A, 1015246, 0, 0, 0, 0, 0));

                Caster.SendGump(new MetamorphoseGump(Caster, Scroll, entries, 2));
            }
            else if (!CheckTransformation(Caster, Caster))
            {
                DoFizzle();
            }
            else if (CheckSequence())
            {
                if (Caster.BeginAction(typeof(SubterfugeSpell)))
                {
                    if (m_NewBody != 0)
                    {
                        if (!((Body)m_NewBody).IsHuman)
                        {
                            Mobiles.IMount mt = Caster.Mount;

                            if (mt != null)
                                mt.Rider = null;
                        }

                        if (Caster is PlayerMobile)
                        {
                            PlayerMobile pm = (PlayerMobile)Caster;
                            pm.Transformation.OnTransformationChange(m_NewBody, m_NameMod, m_HueMod, true);
                        }
                        else
                        {
                            Caster.BodyMod = m_NewBody;
                            Caster.NameMod = m_NameMod;
                            Caster.HueMod = m_HueMod;
                        }

                        Caster.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                        Caster.PlaySound(0x3BD);
                    }
                }
            }

			FinishSequence();
		}

        public static void StopTimer(Mobile m)
        {
            if (!m.CanBeginAction(typeof(SubterfugeSpell)))
            {
                if (m is PlayerMobile)
                {
                    PlayerMobile pm = (PlayerMobile)m;
                    pm.Transformation.OnTransformationChange(0, null, -1, true);
                }
                else
                {
                    m.BodyMod = 0;
                    m.NameMod = null;
                    m.HueMod = -1;
                }

                m.EndAction(typeof(SubterfugeSpell));

                if (m is PlayerMobile)
                    ((PlayerMobile)m).CheckRaceGump();

                m.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                m.PlaySound(0x3BD);

                BaseArmor.ValidateMobile(m);
            }
        }
	}
}
