using System;
using System.Collections;
using Server;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Prompts;
using Server.Spells;
using Server.Spells.Fifth;
using Server.Mobiles;
using Server.Spells.Necromancy;
using Server.Targeting;
using Server.Scripts.Commands;

namespace Server.Spells
{
    public class MetamorphoseSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Metamorphose", "Vas Ylem Rel",
				SpellCircle.Seventh,
				221,
				9002,
				Reagent.Bloodmoss,
				Reagent.SpidersSilk,
				Reagent.MandrakeRoot
			);

		private int m_NewBody;
        private int m_StrMod;
        private int m_DexMod;
        private int m_IntMod;
        private int m_HueMod;
        private double m_SkillReq;
        private string m_NameMod;

        public static Hashtable m_Mods = new Hashtable();

		public MetamorphoseSpell( Mobile caster, Item scroll, string name, int body, int StrMod, int DexMod, int IntMod, double SkillReq, int hue) : base( caster, scroll, m_Info )
		{
			m_NewBody = body;
            m_StrMod = StrMod;
            m_DexMod = DexMod;
            m_IntMod = IntMod;
            m_SkillReq = SkillReq;
            m_NameMod = name;
            m_HueMod = hue;
		}

		public MetamorphoseSpell( Mobile caster, Item scroll ) : this(caster,scroll,null,0, 0, 0, 0, 0, 0)
		{
		}

		public override void OnCast()
		{
            if (m_NewBody == 0)
                Caster.Target = new InternalTarget(this);
            else
                ToogleMetamorphose();
		}

        public void Target(BaseCreature m)
        {
            if (CheckSequence())
            {
                if (m.Alive && Caster.CanSee(m) && m.BodyMod == 0)
                {
                    MetamorphoseGump.MetamorphoseEntry entry = new MetamorphoseGump.MetamorphoseEntry(m.Name, ShrinkTable.Lookup(m.Body), m.Body, 0, (int)(Caster.Skills[SkillName.Reve].Base / 4), (int)(Caster.Skills[SkillName.Reve].Base / 4), (int)(Caster.Skills[SkillName.Reve].Base / 4), 0, m.Hue);

                    if (Caster is TMobile)
                    {
                        TMobile pm = (TMobile)Caster;

                        if (pm.MetamorphoseList == null)
                            pm.MetamorphoseList = new ArrayList();

                        int max = (int)(pm.Skills[SkillName.Reve].Base / 5);

                        if (pm.MetamorphoseList.Count >= max)
                            pm.SendMessage("Vous ne pouvez pas avoir plus de " + max.ToString() + " créatures dans votre liste de métamorphoses.");
                        else
                        {
                            pm.MetamorphoseList.Add((object)entry);
                            pm.SendMessage("Vous ajoutez avec succès la créature à votre liste de métamorphoses.");

                            Caster.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                            Caster.PlaySound(0x3BD);

                            m.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                            m.PlaySound(0x3BD);
                        }
                    }
                }
                else
                    Caster.SendMessage("Vous ne pouvez pas cibler des créatures transformées.");
            }

            FinishSequence();
        }

        public void ToogleMetamorphose()
        {
            if (!Caster.CanBeginAction(typeof(MetamorphoseSpell)))
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
                    Caster.HueMod = -1;
                }

                Caster.EndAction(typeof(MetamorphoseSpell));

                if (Caster is TMobile)
                    ((TMobile)Caster).CheckRaceGump();

                BaseArmor.ValidateMobile(Caster);

                Caster.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                Caster.PlaySound(0x3BD);

                string name = String.Format("[Transformation] {0} Offset", StatType.Str);
                StatMod mod = Caster.GetStatMod(name);

                if (mod != null)
                    Caster.RemoveStatMod(name);

                name = String.Format("[Transformation] {0} Offset", StatType.Dex);
                mod = Caster.GetStatMod(name);

                if (mod != null)
                    Caster.RemoveStatMod(name);

                name = String.Format("[Transformation] {0} Offset", StatType.Int);
                mod = Caster.GetStatMod(name);

                if (mod != null)
                    Caster.RemoveStatMod(name);
            }
            else if (m_NewBody == 0)
            {
                ArrayList entries = null;

                if (Caster is TMobile)
                    entries = ((TMobile)Caster).MetamorphoseList;

                if(entries != null)
                    Caster.SendGump(new MetamorphoseGump(Caster, Scroll, entries, 5));
            }
            else if (!CheckTransformation(Caster, Caster))
            {
                DoFizzle();
            }
            else if (CheckSequence())
            {
                if (Caster.BeginAction(typeof(MetamorphoseSpell)))
                {
                    if (m_NewBody != 0)
                    {
                        if (!((Body)m_NewBody).IsHuman)
                        {
                            Mobiles.IMount mt = Caster.Mount;

                            if (mt != null)
                                mt.Rider = null;
                        }

                        Caster.AddStatMod(new StatMod(StatType.Str, String.Format("[Transformation] {0} Offset", StatType.Str), m_StrMod, TimeSpan.Zero));
                        Caster.AddStatMod(new StatMod(StatType.Dex, String.Format("[Transformation] {0} Offset", StatType.Dex), m_DexMod, TimeSpan.Zero));
                        Caster.AddStatMod(new StatMod(StatType.Int, String.Format("[Transformation] {0} Offset", StatType.Int), m_IntMod, TimeSpan.Zero));

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
            if (!m.CanBeginAction(typeof(MetamorphoseSpell)))
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

                m.EndAction(typeof(MetamorphoseSpell));

                if (m is TMobile)
                    ((TMobile)m).CheckRaceGump();

                BaseArmor.ValidateMobile(m);

                m.FixedParticles(0x373A, 10, 15, 5036, EffectLayer.Head);
                m.PlaySound(0x3BD);

                string name = String.Format("[Transformation] {0} Offset", StatType.Str);
                StatMod mod = m.GetStatMod(name);

                if (mod != null)
                    m.RemoveStatMod(name);

                name = String.Format("[Transformation] {0} Offset", StatType.Dex);
                mod = m.GetStatMod(name);

                if (mod != null)
                    m.RemoveStatMod(name);

                name = String.Format("[Transformation] {0} Offset", StatType.Int);
                mod = m.GetStatMod(name);

                if (mod != null)
                    m.RemoveStatMod(name);
            }
        }

        private class InternalTarget : Target
        {
            private MetamorphoseSpell m_Owner;

            public InternalTarget(MetamorphoseSpell owner)
                : base(12, false, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is BaseCreature)
                    m_Owner.Target((BaseCreature)o);
                else if (o is TMobile && from == o)
                    m_Owner.ToogleMetamorphose();
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
	}
}
