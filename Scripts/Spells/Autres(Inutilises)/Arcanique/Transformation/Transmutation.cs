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
    public class TransmutationSpell : Spell
	{
        private static SpellInfo m_Info = new SpellInfo(
                "Transmutation", "Quas Rel Vas Xen An Mani",
                SpellCircle.Fifth,
                221,
                9002,
                Reagent.BlackPearl,
                Reagent.Ginseng,
                Reagent.SulfurousAsh
            );

		private int m_NewBody;
        private int m_HueMod;
        private string m_NameMod;

        public static Hashtable m_Mods = new Hashtable();

		public TransmutationSpell( Mobile caster, Item scroll, string name, int body, int hue) : base( caster, scroll, m_Info )
		{
			m_NewBody = body;
            m_NameMod = name;
            m_HueMod = hue;
		}

		public TransmutationSpell( Mobile caster, Item scroll ) : this(caster, scroll, null, 0, -1)
		{
		}

		public override void OnCast()
		{
            if (!Caster.CanBeginAction(typeof(TransmutationSpell)))
            {
                if (Caster is TMobile)
                {
                    TMobile pm = (TMobile)Caster;
                    pm.OnTransformationChange(0, null, -1, true);
                }
                else
                {
                    Caster.BodyMod = 0;
                    Caster.NameMod = null;
                }

                Caster.EndAction(typeof(TransmutationSpell));

                Caster.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                Caster.PlaySound(0x3BD);

                if (Caster is TMobile)
                    ((TMobile)Caster).CheckRaceGump();

                BaseArmor.ValidateMobile(Caster);
            }
            else if (m_NewBody == 0)
            {
                ArrayList entries = new ArrayList();
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Ours Polaire", ShrinkTable.Lookup(0xD5), 0xD5, 1015237, 0, 0, 0, 0, 0));
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Momie", ShrinkTable.Lookup(0x9A), 0x9A, 1015246, 0, 0, 0, 0, 0));
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Ophidien", ShrinkTable.Lookup(0x56), 0x56, 1015246, 0, 0, 0, 0, 0));

                Caster.SendGump(new MetamorphoseGump(Caster, Scroll, entries, 4));
            }
            else if (!CheckTransformation(Caster, Caster))
            {
                DoFizzle();
            }
            else if (CheckSequence())
            {
                if (Caster.BeginAction(typeof(TransmutationSpell)))
                {
                    if (m_NewBody != 0)
                    {
                        if (!((Body)m_NewBody).IsHuman)
                        {
                            Mobiles.IMount mt = Caster.Mount;

                            if (mt != null)
                                mt.Rider = null;
                        }

                        if (Caster is TMobile)
                        {
                            TMobile pm = (TMobile)Caster;
                            pm.OnTransformationChange(m_NewBody, m_NameMod, m_HueMod, true);
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
            if (!m.CanBeginAction(typeof(TransmutationSpell)))
            {
                if (m is TMobile)
                {
                    TMobile pm = (TMobile)m;
                    pm.OnTransformationChange(0, null, -1, true);
                }
                else
                {
                    m.BodyMod = 0;
                    m.NameMod = null;
                    m.HueMod = -1;
                }

                m.EndAction(typeof(TransmutationSpell));

                m.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                m.PlaySound(0x3BD);

                if (m is TMobile)
                    ((TMobile)m).CheckRaceGump();

                BaseArmor.ValidateMobile(m);
            }
        }
	}
}
