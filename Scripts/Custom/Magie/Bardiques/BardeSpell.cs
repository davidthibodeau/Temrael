using System;
using System.Text;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;

namespace Server.Spells
{
	public abstract class BardeSpell : Spell
	{
        public override SkillName CastSkill { get { return SkillName.Musique; } }
        public override SkillName DamageSkill { get { return SkillName.Musique; } }

        public override StatType DamageStat { get { return StatType.Cha; } }

        public BaseInstrument m_Instrument;

        public BardeSpell(Mobile caster, Item scroll, SpellInfo info)
            : base(caster, scroll, info)
		{
        }

        public override TimeSpan GetDurationForSpell(double min, double scale)
        {
            double valeur = (min + Caster.Skills[SkillName.Musique].Base + Caster.Cha) * scale;

            return TimeSpan.FromSeconds(valeur);
        }

        public override bool Cast()
        {
            TMobile pm = m_Caster as TMobile;
            m_StartCastTime = DateTime.Now;

            Item item = m_Caster.FindItemOnLayer(Layer.TwoHanded);

            foreach (Item i in m_Caster.Backpack.Items)
            {
                if (i is BaseInstrument)
                {
                    m_Instrument = (BaseInstrument)i;
                }
            }
            
            if(item is BaseInstrument)
                m_Instrument = (BaseInstrument)item;

            if (!m_Caster.CheckAlive())
            {
                return false;
            }
            else if (m_Caster.Spell != null && m_Caster.Spell.IsCasting)
            {
                m_Caster.SendLocalizedMessage(502642); // You are already casting a spell.
            }
            else if (m_Caster.Frozen)
            {
                m_Caster.SendLocalizedMessage(502643); // You can not cast a spell while frozen.
            }
            else if (CheckNextSpellTime && DateTime.Now < m_Caster.NextSpellTime)
            {
                m_Caster.SendLocalizedMessage(502644); // You must wait for that spell to have an effect.
            }
            else if (!(this is BardeSpell) || m_Instrument == null || (!(item is BaseInstrument) && !(item == null)))
            {
                m_Caster.SendMessage("Vous devez avoir un instrument dans les mains pour utiliser cette faculté.");
            }
            else if (CheckFizzle())
            {
                if (m_Instrument != null && m_Caster.Spell == null && m_Caster.CheckSpellCast(this) && CheckCast() && m_Caster.Region.OnBeginSpellCast(m_Caster, this))
                {
                    m_State = SpellState.Casting;
                    m_Caster.Spell = this;

                    if (RevealOnCast)
                        m_Caster.RevealingAction();

                    TimeSpan castDelay = this.GetCastDelay();

                    m_Instrument.PlayInstrumentWell(m_Caster);

                    m_CastTimer = new CastTimer(this, castDelay);
                    m_CastTimer.Start();

                    OnBeginCast();

                    return true;
                }
                else
                {
                    m_Caster.Freeze(TimeSpan.FromSeconds(4));
                    m_Instrument.PlayInstrumentBadly(m_Caster);
                    return false;
                }
            }
            else if (m_Instrument != null)
            {
                m_Caster.Freeze(TimeSpan.FromSeconds(4));
                m_Instrument.PlayInstrumentBadly(m_Caster);
            }

            return false;
        }

        public override int CastDelayMinimum { get { return 4; } }

        public override TimeSpan GetCastDelay()
        {
            double value = CastDelayMinimum;

            /*if (AOS.Testing)
            {
                Caster.SendMessage("Délais : " + value.ToString());
            }*/

            return TimeSpan.FromSeconds(value);
        }

        public override bool CheckSequence()
        {

            TMobile pm = m_Caster as TMobile;

            /*if (pm != null)
            {
                pm.CheckPraying();
                pm.CheckEtude();
            }*/

            if (m_Caster.Deleted || !m_Caster.Alive || m_Caster.Spell != this || m_State != SpellState.Sequencing)
            {
                DoFizzle();
            }
            else 
            {
                return true;
            }

            return false;
        }

        public override bool CheckFizzle()
        {
            if (m_Caster is TMobile)
            {
                TMobile pm = (TMobile)m_Caster;

                if (pm.CheckFatigue(6))
                    return false;
            }

            if (m_Caster is TMobile && m_Caster.Mounted)
            {
                TMobile pm = (TMobile)m_Caster;

                if (pm.AccessLevel == AccessLevel.Player)
                {
                    double chance = 100 - pm.Skills.Equitation.Value;

                    if (Utility.Random(0, 100) <= chance)
                        return false;
                }
            }

            if (BaseInstrument.CheckMusicianship(m_Caster))
            {
                return true;
            }

            return false;
        }
	}
}