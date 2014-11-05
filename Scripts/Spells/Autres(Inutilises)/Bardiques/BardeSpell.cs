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
        public override StatType DamageStat { get { return StatType.Int; } }

        public BaseInstrument m_Instrument;

        public BardeSpell(Mobile caster, Item scroll, SpellInfo info)
            : base(caster, scroll, info)
		{
        }

        public override bool Cast()
        {
            TMobile pm = Caster as TMobile;
            m_StartCastTime = DateTime.Now;

            Item item = Caster.FindItemOnLayer(Layer.TwoHanded);

            foreach (Item i in Caster.Backpack.Items)
            {
                if (i is BaseInstrument)
                {
                    m_Instrument = (BaseInstrument)i;
                }
            }
            
            if(item is BaseInstrument)
                m_Instrument = (BaseInstrument)item;

            if (!Caster.CheckAlive())
            {
                return false;
            }
            else if (Caster.Spell != null && Caster.Spell.IsCasting)
            {
                Caster.SendLocalizedMessage(502642); // You are already casting a spell.
            }
            else if (Caster.Frozen)
            {
                Caster.SendLocalizedMessage(502643); // You can not cast a spell while frozen.
            }
            else if (CheckNextSpellTime && Core.TickCount < Caster.NextSpellTime)
            {
                Caster.SendLocalizedMessage(502644); // You must wait for that spell to have an effect.
            }
            else if (!(this is BardeSpell) || m_Instrument == null || (!(item is BaseInstrument) && !(item == null)))
            {
                Caster.SendMessage("Vous devez avoir un instrument dans les mains pour utiliser cette faculté.");
            }
            else if (CheckFizzle())
            {
                if (m_Instrument != null && Caster.Spell == null && Caster.CheckSpellCast(this) && CheckCast() && Caster.Region.OnBeginSpellCast(Caster, this))
                {
                    State = SpellState.Casting;
                    Caster.Spell = this;

                    if (RevealOnCast)
                        Caster.RevealingAction();

                    TimeSpan castDelay = this.GetCastDelay();

                    m_Instrument.PlayInstrumentWell(Caster);

                    m_CastTimer = new CastTimer(this, castDelay);
                    m_CastTimer.Start();

                    OnBeginCast();

                    return true;
                }
                else
                {
                    Caster.Freeze(TimeSpan.FromSeconds(4));
                    m_Instrument.PlayInstrumentBadly(Caster);
                    return false;
                }
            }
            else if (m_Instrument != null)
            {
                Caster.Freeze(TimeSpan.FromSeconds(4));
                m_Instrument.PlayInstrumentBadly(Caster);
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

            TMobile pm = Caster as TMobile;

            /*if (pm != null)
            {
                pm.CheckPraying();
                pm.CheckEtude();
            }*/

            if (Caster.Deleted || !Caster.Alive || Caster.Spell != this || State != SpellState.Sequencing)
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
            if (Caster is TMobile)
            {
                TMobile pm = (TMobile)Caster;

                if (pm.CheckFatigue(6))
                    return false;
            }

            if (Caster is TMobile && Caster.Mounted)
            {
                TMobile pm = (TMobile)Caster;

                ClasseInfo cInfo = Classes.GetInfos(pm.ClasseType);

                if (pm.AccessLevel == AccessLevel.Player)
                {
                    double chance = 100 - pm.Skills.Equitation.Value;

                    if (Utility.Random(0, 100) <= chance)
                        return false;
                }
            }

            if (BaseInstrument.CheckMusicianship(Caster))
            {
                return true;
            }

            return false;
        }
	}
}