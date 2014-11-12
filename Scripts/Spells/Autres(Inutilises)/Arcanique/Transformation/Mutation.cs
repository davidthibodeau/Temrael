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
    public class MutationSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Mutation", "Quas Rel Sar Beh Bal",
                8,
				221,
				9002,
                Reagent.SulfurousAsh,
                Reagent.SulfurousAsh,
                Reagent.SulfurousAsh
			);

		private int m_NewBody;
        private int m_HueMod;
        private string m_NameMod;

        public static Hashtable m_Mods = new Hashtable();

		public MutationSpell( Mobile caster, Item scroll, string name, int body, int hue) : base( caster, scroll, Info )
		{
			m_NewBody = body;
            m_NameMod = name;
            m_HueMod = hue;
		}

		public MutationSpell( Mobile caster, Item scroll ) : this(caster, scroll, null, 0, -1)
		{
		}

		public override void OnCast()
		{
            if (!Caster.CanBeginAction(typeof(MutationSpell)))
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

                Caster.EndAction(typeof(MutationSpell));

                Caster.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                Caster.PlaySound(0x3BD);

                if (Caster is PlayerMobile)
                    ((PlayerMobile)Caster).CheckRaceGump();

                BaseArmor.ValidateMobile(Caster);
            }
            else if (m_NewBody == 0)
            {
                ArrayList entries = new ArrayList();
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Dragonnet", ShrinkTable.Lookup(12), 12, 1015237, 0, 0, 0, 0, 2174));
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Arbre sylvestre", ShrinkTable.Lookup(301), 301, 1015246, 0, 0, 0, 0, 0));
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Golem d'os", ShrinkTable.Lookup(308), 308, 1015246, 0, 0, 0, 0, 0));
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Golem de chaire", ShrinkTable.Lookup(304), 304, 1015237, 0, 0, 0, 0, 0));
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Demonologue", ShrinkTable.Lookup(318), 318, 1015246, 0, 0, 0, 0, 0));
                entries.Add(new MetamorphoseGump.MetamorphoseEntry("Mangeur d'âmes", ShrinkTable.Lookup(303), 303, 1015246, 0, 0, 0, 0, 0));

                Caster.SendGump(new MetamorphoseGump(Caster, Scroll, entries, 6));
            }
            else if (!CheckTransformation(Caster, Caster))
            {
                DoFizzle();
            }
            else if (CheckSequence())
            {
                if (Caster.BeginAction(typeof(MutationSpell)))
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
            if (!m.CanBeginAction(typeof(MutationSpell)))
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

                m.EndAction(typeof(MutationSpell));

                m.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                m.PlaySound(0x3BD);

                if (m is PlayerMobile)
                    ((PlayerMobile)m).CheckRaceGump();

                BaseArmor.ValidateMobile(m);
            }
        }
	}
}
