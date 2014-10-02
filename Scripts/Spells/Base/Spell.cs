using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Spells;
using System.Collections;
using Server.Custom;
using Server.Scripts.Commands;
using Server.Engines.Equitation;

//Adjuration

namespace Server.Spells
{
	public abstract class Spell : ISpell
	{
        public static bool CheckTransformation(Mobile Caster, Mobile m)
        {
            if (!m.CanBeginAction(typeof(IncognitoSpell)))
            {
                Caster.SendMessage(m.Name + " est déjà affecté par Incognito.");
                return false;
            }
            else if (!m.CanBeginAction(typeof(MetamorphoseSpell)) || !m.CanBeginAction(typeof(MutationSpell)) || !m.CanBeginAction(typeof(AlterationSpell)) || !m.CanBeginAction(typeof(SubterfugeSpell)) || !m.CanBeginAction(typeof(ChimereSpell)) || !m.CanBeginAction(typeof(TransmutationSpell)))
            {
                Caster.SendMessage(m.Name + " est déjà transformé.");
                return false;
            }
            else if (!m.CanBeginAction(typeof(InstinctCharnelSpell)))
            {
                Caster.SendMessage(m.Name + " est déjà transformé.");
                return false;
            }
            else if (m.BodyMod == 183 || m.BodyMod == 184)
            {
                Caster.SendLocalizedMessage(1042512); // You cannot polymorph while wearing body paint
                return false;
            }
            else if (m.Blessed)
            {
                Caster.SendMessage(m.Name + " ne peut être la cible de sorts changeant l'apparence.");
                return false;
            }

            return true;
        }

		public Mobile m_Caster;
		public Item m_Scroll;
		private SpellInfo m_Info;
		public SpellState m_State;
		public DateTime m_StartCastTime;

		public SpellState State{ get{ return m_State; } set{ m_State = value; } }
		public Mobile Caster{ get{ return m_Caster; } }
		public SpellInfo Info{ get{ return m_Info; } }
		public string Name{ get{ return m_Info.Name; } }
		public string Mantra{ get{ return m_Info.Mantra; } }
        public int ManaCost { get { return m_Info.manaCost; } }
		public SpellCircle Circle{ get{ return m_Info.Circle; } }
		public Type[] Reagents{ get{ return m_Info.Reagents; } }
		public Item Scroll{ get{ return m_Scroll; } }

		private static TimeSpan AnimateDelay = TimeSpan.FromSeconds( 1.5 );

		public virtual SkillName CastSkill{ get{ return SkillName.ArtMagique; } }
		public virtual SkillName DamageSkill{ get{ return SkillName.ArtMagique; } }

        public virtual StatType DamageStat { get { return StatType.Int; } }

		public virtual bool RevealOnCast{ get{ return true; } }
		public virtual bool ClearHandsOnCast{ get{ return false; } }

		public virtual bool DelayedDamage{ get{ return false; } }

        public virtual bool AnimateOnCast { get { return true; } }
        public virtual bool CheckHurt { get { return true; } }

		public Spell( Mobile caster, Item scroll, SpellInfo info )
		{
			m_Caster = caster;
			m_Scroll = scroll;
			m_Info = info;
		}

        public virtual int GetNewAosDamage( int bonus, int dice, int sides, bool playerVsPlayer)
        {
            return GetNewAosDamage(null, bonus, dice, sides, playerVsPlayer);
        }

		public virtual int GetNewAosDamage( Mobile to, int bonus, int dice, int sides, bool playerVsPlayer )
		{
			int damage = Utility.Dice( dice, sides, bonus ) * 100;
			int damageBonus = 0;

            double anatomySkill = Caster.Skills[SkillName.ArtMagique].Value;
            damageBonus += (int)(anatomySkill / 2.5);

			int intBonus = Caster.Int / 10;
			damageBonus += intBonus;

            if (SerenadeSpell.m_SerenadeTable.Contains(Caster))
            {
                double crideguerre = (double)SerenadeSpell.m_SerenadeTable[Caster];
                damageBonus += (int)(crideguerre * 100);
            }

            if (ConscienceSpell.m_ConscienceTable.Contains(Caster))
            {
                damageBonus += (int)((double)ConscienceSpell.m_ConscienceTable[Caster] * 100 * SpellHelper.GetTotalCreaturesInRange(Caster, 5));
                Caster.FixedParticles(14276, 10, 20, 5013, 1441, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(527);
            }

            if (ExecrationSpell.m_ExecrationTable.Contains(Caster))
                damageBonus -= (int)(((double)ExecrationSpell.m_ExecrationTable[Caster] - 1) * 100);

            if (SoifDuCombatSpell.m_SoifDuCombatTable.Contains(Caster))
            {
                damageBonus += (int)(((double)SoifDuCombatSpell.m_SoifDuCombatTable[Caster] - 1) * 100);
                Caster.FixedParticles(14170, 10, 15, 5013, 44, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
            }

            if (TranscendanceSpell.m_TranscendanceTable.Contains(Caster))
            {
                damageBonus += (int)((double)TranscendanceSpell.m_TranscendanceTable[Caster] * (12 - SpellHelper.GetRangeToMobile(Caster, to, 0, 12)));
                Caster.FixedParticles(14186, 10, 15, 5013, 2061, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(509);
            }

            int evalSkill = GetDamageFixed( m_Caster );
            damageBonus += ((9 * evalSkill) / 100);

            switch (DamageStat)
            {
                case StatType.Int:
                    damageBonus += Caster.Int / 10;
                    break;
            }

			damage = AOS.Scale( damage, 100 + damageBonus );

            if (Caster is BaseCreature) //Les créatures ont toutes 12 de magie offensive.
                damage *= 2;

            return damage / 100;
		}

		public virtual double GetAosDamage( int min, int random, double div )
		{
			double scale = 1.0;

			scale += GetInscribeSkill( m_Caster ) * 0.001;

			if ( Caster.Player )
			{
				scale += Caster.Int * 0.001;
			}

			int baseDamage = min + (int)(GetDamageSkill( m_Caster ) / div);

			double damage = Utility.RandomMinMax( baseDamage, baseDamage + random );

			return damage * scale;
		}

		public virtual bool IsCasting{ get{ return m_State == SpellState.Casting; } }

        public virtual void OnCasterHurt()
        {
            if (CheckHurt)
            {
                TMobile pm = m_Caster as TMobile;
                double chance = m_Caster.Skills[SkillName.ArtMagique].Value / 333;

                if (pm != null)
                {
                    chance += pm.Skills[SkillName.Concentration].Value / 333;

                    if (this is NecromancerSpell) //La nécro est une école de contact, donc besoin d'un bonus pour ne pas Fizzle
                        chance += pm.Skills[SkillName.Necromancie].Value / 333;
                }
                if (chance > Utility.RandomDouble())
                    m_Caster.SendMessage("Vous réussissez à garder votre concentration.");
                else
                    Disturb(DisturbType.Hurt);
            }
        }

		public virtual void OnCasterKilled()
		{
			Disturb( DisturbType.Kill );
		}

		public virtual void OnConnectionChanged()
		{
			FinishSequence();
		}

		public virtual bool OnCasterMoving( Direction d )
		{
			if ( IsCasting && BlocksMovement )
			{
				m_Caster.SendLocalizedMessage( 500111 ); // You are frozen and can not move.
				return false;
			}

			return true;
		}

		public virtual bool OnCasterEquiping( Item item )
		{
			if ( IsCasting )
				Disturb( DisturbType.EquipRequest );

			return true;
		}

		public virtual bool OnCasterUsingObject( object o )
		{
			if ( m_State == SpellState.Sequencing )
				Disturb( DisturbType.UseRequest );

			return true;
		}

		public virtual bool OnCastInTown( Region r )
		{
			return m_Info.AllowTown;
		}

		public virtual bool ConsumeReagents()
		{
			if ( m_Scroll != null || !m_Caster.Player )
				return true;

			if ( AosAttributes.GetValue( m_Caster, AosAttribute.LowerRegCost ) > Utility.Random( 100 ) )
		    	return true;

			Container pack = m_Caster.Backpack;

			if ( pack == null )
				return false;

            if (m_Caster is TMobile)
            {
                TMobile tmob = (TMobile)m_Caster;

                if (pack.ConsumeTotal(m_Info.Reagents, Info.Amounts) == -1)
                    return true;

            }

			return false;
		}

		public virtual bool CheckResisted( Mobile target )
        {
            //Modification majeure, voir AOS.cs
            //return false;

            if (target is TMobile)
            {
                TMobile pm = (TMobile)target;
                
                if (pm.CheckFatigue(4))
                    return false;
            }

            double n = GetResistPercent( target );

            n /= 100.0;

            n += target.MagieResistance / 10;

            if ( n <= 0.0 )
            	return false;

            if ( n >= 1.0 )
                return true;

            int maxSkill = (1 + (int)GetSkillValue()/10) * 10;
            maxSkill += (1 + ((int)GetSkillValue()/10 / 6)) * 25;

            if ( target.Skills[SkillName.Concentration].Value < maxSkill )
                target.CheckSkill( SkillName.Concentration, 0.0, 120.0 );

            return ( n >= Utility.RandomDouble() );
		}

		public virtual double GetInscribeSkill( Mobile m )
		{
			return m.Skills[SkillName.Inscription].Value;
		}

		public virtual int GetInscribeFixed( Mobile m )
		{
			return m.Skills[SkillName.Inscription].Fixed;
		}

		public virtual int GetDamageFixed( Mobile m )
		{
			m.CheckSkill( DamageSkill, 0.0, 120.0 );

			return m.Skills[DamageSkill].Fixed;
		}

		public virtual double GetDamageSkill( Mobile m )
		{
			m.CheckSkill( DamageSkill, 0.0, 120.0 );

			return m.Skills[DamageSkill].Value;
		}

		public virtual int GetResistFixed( Mobile m )
		{
            int maxSkill = (1 + (int)GetSkillValue()/10) * 10;
            maxSkill += (1 + ((int)GetSkillValue()/10 / 6)) * 25;

			if ( m.Skills[SkillName.Concentration].Value < maxSkill )
				m.CheckSkill( SkillName.Concentration, 0.0, 120.0 );

            return 0;
			//return m.Skills[SkillName.Concentration].Fixed;
		}

		public virtual double GetResistSkill( Mobile m )
		{
            int maxSkill = (1 + (int)GetSkillValue()/10) * 10;
            maxSkill += (1 + ((int)GetSkillValue()/10 / 6)) * 25;

			if ( m.Skills[SkillName.Concentration].Value < maxSkill )
				m.CheckSkill( SkillName.Concentration, 0.0, 120.0 );

            return 0;
			//return m.Skills[SkillName.Concentration].Value;
		}

		public virtual double GetResistPercentForCircle( Mobile target, SpellCircle circle )
		{
			double firstPercent = target.Skills[SkillName.Concentration].Value / 5.0;
			double secondPercent = target.Skills[SkillName.Concentration].Value - (((m_Caster.Skills[CastSkill].Value - 20.0) / 5.0) + (1 + (int)circle) * 5.0);

            return 0;
			//return ( firstPercent > secondPercent ? firstPercent : secondPercent ) / 2.0; // Seems should be about half of what stratics says.
		}

        public virtual double GetResistPercentForAptitude(Mobile target, int aptitude)
        {
            double firstPercent = target.Skills[SkillName.Concentration].Value / 5.0;
            double secondPercent = target.Skills[SkillName.Concentration].Value - (((m_Caster.Skills[CastSkill].Value - 20.0) / 5.0) + (1 + (int)aptitude) * 5.0);

            return 0;
            //return ( firstPercent > secondPercent ? firstPercent : secondPercent ) / 2.0; // Seems should be about half of what stratics says.
        }

		public virtual double GetResistPercent( Mobile target )
		{
            return GetResistPercentForAptitude(target, GetSkillValue()/10);
		}

		public virtual double GetDamageScalar( Mobile target )
		{
			double casterEI = m_Caster.Skills[DamageSkill].Value;
			double targetRS = target.Skills[SkillName.Concentration].Value;
			double scalar;

			m_Caster.CheckSkill( DamageSkill, 0.0, 120.0 );

			if ( casterEI > targetRS )
				scalar = (1.0 + ((casterEI - targetRS) / 500.0));
			else
				scalar = (1.0 + ((casterEI - targetRS) / 200.0));

			// magery damage bonus, -25% at 0 skill, +0% at 100 skill, +5% at 120 skill
			scalar += ( m_Caster.Skills[CastSkill].Value - 100.0 ) / 400.0;

			if ( target is BaseCreature )
				scalar += 0.5; // Double magery damage to monsters/animals if not AOS

			if ( target is BaseCreature )
				((BaseCreature)target).AlterDamageScalarFrom( m_Caster, ref scalar );

			if ( m_Caster is BaseCreature )
				((BaseCreature)m_Caster).AlterDamageScalarTo( target, ref scalar );

			target.Region.SpellDamageScalar( m_Caster, target, ref scalar );

			return scalar;
		}

        public virtual TimeSpan GetDurationForSpell(double scale)
        {
            return GetDurationForSpell(5, scale);
        }

        public virtual TimeSpan GetDurationForSpell(double min, double scale)
        {
            double valeur = min + (double)Caster.Skills[CastSkill].Value * scale;
            double valeurbonus = 1;

            valeurbonus += (Caster.Skills[DamageSkill].Value - 50) / 150;

            valeurbonus += Caster.Int / 2000;

            valeur *= valeurbonus;

            if (valeur < 0.5)
                return TimeSpan.FromSeconds(0.5);

            return TimeSpan.FromSeconds(valeur);
        }

        public virtual TimeSpan GetDurationForSpellvortex(double scale)
        {
            return GetDurationForSpell(5, scale);
        }

        public virtual TimeSpan GetDurationForSpellvortex(double min, double scale)
        {
            double valeur = min + (double)Caster.Skills[CastSkill].Value * scale;
            double valeurbonus = 1;

            valeurbonus += (Caster.Skills[DamageSkill].Value - 50) / 150;

            valeurbonus += Caster.Int / 2000;

            valeur *= valeurbonus;

            if (valeur < 0.5)
                return TimeSpan.FromSeconds(0.5);

            return TimeSpan.FromSeconds(valeur);
        }

        public virtual int GetRadiusForSpell()
        {
            return (GetRadiusForSpell(4));
        }

        public virtual int GetRadiusForSpell(int min)
        {
            int bonus = 0;

            return min + bonus;
        }

		public virtual void DoFizzle()
		{
			m_Caster.LocalOverheadMessage( MessageType.Regular, 0x3B2, 502632 ); // The spell fizzles.

			if ( m_Caster.Player )
			{
				m_Caster.FixedEffect( 0x3735, 6, 30 );
				m_Caster.PlaySound( 0x5C );
			}
		}

		public CastTimer m_CastTimer;
		public AnimTimer m_AnimTimer;

		public virtual bool CheckDisturb( DisturbType type )
		{
			return true;
		}

        public void Disturb(DisturbType type)
        {
            if (!CheckDisturb(type))
                return;

            if (m_State == SpellState.Casting)
            {
                m_State = SpellState.None;
                m_Caster.Spell = null;

                OnDisturb(type, true);

                if (m_CastTimer != null)
                    m_CastTimer.Stop();

                if (m_AnimTimer != null)
                    m_AnimTimer.Stop();

                DoFizzle();

                m_Caster.NextSpellTime = Core.TickCount + Core.GetTicks(GetDisturbRecovery());
            }
            /*else if (m_State == SpellState.Sequencing)
            {
                m_State = SpellState.None;
                m_Caster.Spell = null;

                OnDisturb(type, true);

                DoFizzle();

                Targeting.Target.Cancel(m_Caster);
            }*/
        }

		public virtual void DoHurtFizzle()
		{
			m_Caster.FixedEffect( 0x3735, 6, 30 );
			m_Caster.PlaySound( 0x5C );
		}

		public virtual void OnDisturb( DisturbType type, bool message )
		{
			if ( message )
				m_Caster.SendLocalizedMessage( 500641 ); // Your concentration is disturbed, thus ruining thy spell.
		}

		public virtual bool CheckCast()
        {
            TMobile caster = m_Caster as TMobile;

            if (caster != null && (caster.Squelched || caster.Aphonie))
            {
                caster.SendMessage("Vous ne pouvez incanter si vous êtes muet.");
                return false;
            }

            BaseCreature bc = m_Caster as BaseCreature;

            if (bc != null && (bc.Squelched))
                return false;

			return true;
		}

		public virtual void SayMantra()
		{
			if ( m_Info.Mantra != null && m_Info.Mantra.Length > 0 && m_Caster.Player )
				m_Caster.PublicOverheadMessage( MessageType.Spell, m_Caster.SpeechHue, true, Info.Mantra, false );
		}

		public virtual bool BlockedByHorrificBeast{ get{ return false; } }
		public virtual bool BlocksMovement{ get{ return true; } }

		public virtual bool CheckNextSpellTime{ get{ return true; } }

        public bool canCast()
        {
            TMobile pm = m_Caster as TMobile;

            if (m_Caster.AccessLevel != AccessLevel.Player)
            {
                return true;
            }
            else
            {
                if (!m_Caster.CheckAlive())
                {
                }
                else if (m_Caster.Spell != null && m_Caster.Spell.IsCasting)
                {
                    m_Caster.SendLocalizedMessage(502642); // You are already casting a spell.
                }
                else if (BlockedByHorrificBeast && TransformationSpell.UnderTransformation(m_Caster, typeof(HorrificBeastSpell)))
                {
                    m_Caster.SendLocalizedMessage(1061091); // You cannot cast that spell in this form.
                }
                else if (m_Caster.Frozen)
                {
                    m_Caster.SendLocalizedMessage(502643); // You can not cast a spell while frozen.
                }
                else if (CheckNextSpellTime && Core.TickCount < m_Caster.NextSpellTime)
                {
                    m_Caster.SendLocalizedMessage(502644); // You must wait for that spell to have an effect.
                }
                else if (m_Caster.Skills[m_Info.skillForCasting].Value < m_Info.minSkillForCasting)
                {
                    m_Caster.SendMessage("Vous n'êtes pas assez doué dans votre école de magie pour lancer ce sort.");
                }
                else if (m_Caster.Mana >= GetMana())
                {
                    if (m_Caster.Spell == null && m_Caster.CheckSpellCast(this) && CheckCast() && m_Caster.Region.OnBeginSpellCast(m_Caster, this))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

		public virtual bool Cast()
        {
            TMobile pm = m_Caster as TMobile;
			m_StartCastTime = DateTime.Now;

            if ( canCast() )
            {
                m_State = SpellState.Casting;
                m_Caster.Spell = this;

                if (RevealOnCast)
                    m_Caster.RevealingAction();

                SayMantra();

                TimeSpan castTime;
                if (this is Custom.CustomSpell.CustomSpell)
                {
                    castTime = (this as Custom.CustomSpell.CustomSpell).m_info.castTime;
                }
                else
                {
                    castTime = this.GetCastDelay();
                }

                if (m_Caster.Body.IsHuman)
                {
                    int count = (int)Math.Ceiling(castTime.TotalSeconds / AnimateDelay.TotalSeconds);

                    if (count != 0 && AnimateOnCast)
                    {
                        m_AnimTimer = new AnimTimer(this, count);
                        m_AnimTimer.Start();
                    }

                    if (m_Info.LeftHandEffect > 0)
                        Caster.FixedParticles(0, 10, 5, Info.LeftHandEffect, EffectLayer.LeftHand);

                    if (m_Info.RightHandEffect > 0)
                        Caster.FixedParticles(0, 10, 5, Info.RightHandEffect, EffectLayer.RightHand);
                }

                if (CheckHands())
                    m_Caster.ClearHands();

                m_CastTimer = new CastTimer(this, castTime);
                m_CastTimer.Start();

                OnBeginCast();

                return true;
            }

			return false;
		}

        public bool CheckHands()
        {
            bool clear = ClearHandsOnCast;


            return clear;
        }

		public abstract void OnCast();

		public virtual void OnBeginCast()
		{

		}

        public virtual void OnEndCast()
        {
            /*if (RenouvellementSpell.m_RenouvellementTable.Contains(Caster))
            {
                SpellHelper.Heal(Caster, (int)RenouvellementSpell.m_RenouvellementTable[Caster], true);
            }*/

            if (VehemenceMiracle.m_VehemencetTable.Contains(Caster))
            {
                SpellHelper.Heal(Caster, (int)VehemenceMiracle.m_VehemencetTable[Caster], true, true);
            }

            if (ExaltationSpell.m_ExaltationTable.Contains(Caster))
            {
                SpellHelper.Heal(Caster, (int)ExaltationSpell.m_ExaltationTable[Caster], true);
                ExaltationSpell.StopTimer(Caster);

                Caster.FixedParticles(14265, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(534);
            }
        }

		private const double ChanceOffsetMin = 50.0, ChanceOffsetMax = 10.0, ChanceLength = 100.0 / 13.0;

        private int[] ChanceDeCast = new int[] { 0, 5, 15, 20, 30, 40, 50, 60, 70, 75, 80, 90, 100 };

		public virtual void GetCastSkills( out double min, out double max )
		{
			//int circle = (int)m_Info.Circle;
            int circle = GetSkillValue()/10;

			if ( m_Scroll != null )
				circle -= 2;

            if (circle < 0)
                circle = 0;
			//double avg = ChanceLength * circle;
            double avg = ChanceDeCast[circle];

			min = avg - ChanceOffsetMin;
            max = avg; // + ChanceOffsetMax;

            /*if (HypnoseSpell.m_HypnoseTable.Contains(Caster))
            {
                min += (double)HypnoseSpell.m_HypnoseTable[Caster];
                max += (double)HypnoseSpell.m_HypnoseTable[Caster];

                Caster.FixedParticles(14170, 10, 15, 5013, 1108, 0, EffectLayer.CenterFeet);
                Caster.PlaySound(516);
            }*/
		}

		public virtual bool CheckFizzle()
		{
            if (m_Caster is TMobile)
            {
                TMobile pm = (TMobile)m_Caster;

                if (pm.CheckFatigue(6))
                    return false;
            }

			double minSkill, maxSkill;

			GetCastSkills( out minSkill, out maxSkill );

            if (m_Caster is TMobile)
            {
                TMobile tmob = (TMobile)m_Caster;
                int count = 0;

                foreach (Item item in tmob.Items)
                {
                    if (item is BaseArmor)
                    {
                        BaseArmor armor = (BaseArmor)item;

                        int req = tmob.GetArmorLevel(armor);
                    }

                }

                if (Utility.Random(1, 100) < count)
                {
                    tmob.SendMessage("Vous portez une trop grande charge d'armure et d'arme pour lancer un sort !");
                    return true;
                }
            }

            if (m_Caster is TMobile && m_Caster.Mounted)
            {
                TMobile pm = (TMobile)m_Caster;

                Equitation.CheckEquitation(pm,EquitationType.Cast);

                return true;
            }

            /*if (m_Caster.Dex < 50)
            {
                double chance = TMobile.PenaliteStatistique(m_Caster, m_Caster.Dex);

                if (chance < Utility.RandomDouble())
                    return false;
            }*/

            if (FanfareSpell.m_FanfareTable.Contains(m_Caster))
            {
                double fanfare = (double)FanfareSpell.m_FanfareTable[m_Caster];
                minSkill = (int)(minSkill * (1 - fanfare));
                maxSkill = (int)(maxSkill * (1 - fanfare));
            }

            /*minSkill *= (2 - TMobile.PenaliteStatistique(m_Caster, m_Caster.Int));
            maxSkill *= (2 - TMobile.PenaliteStatistique(m_Caster, m_Caster.Int));*/

            Caster.CheckSkill(CastSkill, 0, 120);

			return Caster.CheckSkill( CastSkill, minSkill, maxSkill );
		}

		public virtual int GetMana()
		{
            return ManaCost;
        }

        public static int[] m_PieteTable = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5 };

        public virtual int GetPiete()
        {
            if (!(this is ReligiousSpell))
                return 0;

            try
            {

                //Console.WriteLine(m_PdPTable[(int)GetPouvoirDivin() - 1]);
                return m_PieteTable[(int)GetSkillValue()/10];
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex);
                return 10;
            }
        }

        public virtual int RequiredSkillValue { get { return m_Info.minSkillForCasting; } }

        public virtual int GetSkillValue()
        {
            return RequiredSkillValue;
        }

        public virtual int ScalePdp(int pdp)
        {
            double scalar = 1.0;

            if (PourritureDEspritSpell.HasMindRotScalar(Caster))
                scalar = PourritureDEspritSpell.GetMindRotScalar(Caster);

            if (scalar < 1.0)
                scalar = 1.0;

            return (int)(pdp * scalar);
        }

		public virtual TimeSpan GetDisturbRecovery()
		{
			double delay = 1.0 - Math.Sqrt( (DateTime.Now - m_StartCastTime).TotalSeconds / GetCastDelay().TotalSeconds );

			if ( delay < 0.1 )
				delay = 0.1;

			return TimeSpan.FromSeconds( delay );
		}

        public virtual bool Invocation { get { return false; } }

		public virtual int CastRecoveryBase{ get{ return 2; } }
		public virtual int CastRecoveryCircleScalar{ get{ return 0; } }
		public virtual int CastRecoveryFastScalar{ get{ return 0; } }
		public virtual int CastRecoveryPerSecond{ get{ return 1; } }
		public virtual int CastRecoveryMinimum{ get{ return 0; } }

		public virtual TimeSpan GetCastRecovery()
		{
            //if (!Core.AOS)
            //    return NextSpellDelay;

            int fcr = AosAttributes.GetValue(m_Caster, AosAttribute.CastRecovery);

            if (fcr > 5)
                fcr = 5;

            //fcr -= ThunderstormSpell.GetCastRecoveryMalus(m_Caster);

            int fcrDelay = -(CastRecoveryFastScalar * fcr);

            int delay = CastRecoveryBase + fcrDelay;

            if (delay < CastRecoveryMinimum)
                delay = CastRecoveryMinimum;

            return TimeSpan.FromSeconds((double)delay / CastRecoveryPerSecond);
		}

		public virtual double CastDelayBase{ get{ return 1.0; } }
//		public virtual int CastDelayCircleScalar{ get{ return 1; } }
	//	public virtual int CastDelayFastScalar{ get{ return 0; } }
	//	public virtual int CastDelayPerSecond{ get{ return 1; } }
		public virtual int CastDelayMinimum{ get{ return 1; } }

		public virtual TimeSpan GetCastDelay()
		{
            double value = CastDelayBase + (double)GetSkillValue()/10 * .1;

            double bonus = 4;

            if (PromptitudeSpell.m_PromptitudeTable.Contains(Caster))
            {
                bonus -= (double)PromptitudeSpell.m_PromptitudeTable[Caster];
                Caster.FixedParticles(14186, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.FixedParticles(14154, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(480);
            }

            if (ConscienceSpell.m_ConscienceTable.Contains(Caster))
            {
                bonus -= (double)ConscienceSpell.m_ConscienceTable[Caster] * SpellHelper.GetTotalCreaturesInRange(Caster, 5);
                Caster.FixedParticles(14276, 10, 20, 5013, 1441, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(527);
            }

            if (SoifDuCombatSpell.m_SoifDuCombatTable.Contains(Caster))
            {
                bonus -= ((double)SoifDuCombatSpell.m_SoifDuCombatTable[Caster] - 1);
                Caster.FixedParticles(14170, 10, 15, 5013, 44, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
            }

            if (value < CastDelayMinimum)
                value = CastDelayMinimum;

            return TimeSpan.FromSeconds(value);
		}

		public virtual void FinishSequence()
		{
			m_State = SpellState.None;

			if ( m_Caster.Spell == this )
				m_Caster.Spell = null;
		}

        public virtual bool CheckSequence()
		{
            int mana = GetMana();

            TMobile pm = m_Caster as TMobile;
            
            if ( m_Caster.AccessLevel != AccessLevel.Player )
            {
                return true;
            }
            else
            {
			    if ( m_Caster.Deleted || !m_Caster.Alive || m_Caster.Spell != this || m_State != SpellState.Sequencing )
                {
				    DoFizzle();
			    }
			    else if ( m_Scroll != null && !(m_Scroll is Runebook) && (m_Scroll.Amount <= 0 || m_Scroll.Deleted || m_Scroll.RootParent != m_Caster) )
			    {
				    DoFizzle();
                }
                else if (!ConsumeReagents() && m_Caster.AccessLevel < AccessLevel.Batisseur)
                {
                    m_Caster.LocalOverheadMessage(MessageType.Regular, 0x22, 502630); // More reagents are needed for this spell.
                }
			    else if ( m_Caster.Mana < mana )
			    {
				    m_Caster.LocalOverheadMessage( MessageType.Regular, 0x22, 502625 ); // Insufficient mana for this spell.
                }
                else if (pm != null && !Equitation.CheckEquitation(pm,EquitationType.Attacking))
                {
                    DoFizzle();
                }
			    else if ( CheckFizzle() )
			    {
                    m_Caster.Mana -= mana;

				    if ( m_Scroll is SpellScroll )
					    m_Scroll.Consume();

				    if ( CheckHands() )
					    m_Caster.ClearHands();

				    return true;
			    }
			    else
                {
				    DoFizzle();
			    }
            }

			return false;
		}

		public bool CheckBSequence( Mobile target )
		{
			return CheckBSequence( target, false );
		}

		public bool CheckBSequence( Mobile target, bool allowDead )
		{
			if ( !target.Alive && !allowDead )
			{
				m_Caster.SendLocalizedMessage( 501857 ); // This spell won't work on that!
				return false;
			}
			else if ( Caster.CanBeBeneficial( target, true, allowDead ) && CheckSequence() )
			{
				Caster.DoBeneficial( target );
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool CheckHSequence( Mobile target )
		{
			if ( !target.Alive )
			{
				m_Caster.SendLocalizedMessage( 501857 ); // This spell won't work on that!
				return false;
			}
			else if ( Caster.CanBeHarmful( target ) && CheckSequence() )
			{
				Caster.DoHarmful( target );
				return true;
			}
			else
			{
				return false;
			}
		}

		public class AnimTimer : Timer
		{
			private Spell m_Spell;

			public AnimTimer( Spell spell, int count ) : base( TimeSpan.Zero, AnimateDelay, count )
			{
				m_Spell = spell;

				Priority = TimerPriority.FiftyMS;
			}

			protected override void OnTick()
			{
				if ( m_Spell.State != SpellState.Casting || m_Spell.m_Caster.Spell != m_Spell )
				{
					Stop();
					return;
				}

				if ( !m_Spell.Caster.Mounted && m_Spell.Caster.Body.IsHuman && m_Spell.m_Info.Action >= 0 )
					m_Spell.Caster.Animate( m_Spell.m_Info.Action, 7, 1, true, false, 0 );

				if ( !Running )
					m_Spell.m_AnimTimer = null;
			}
		}

        public static void Disturb(Mobile m)
        {
            m.Paralyzed = false;
        }

		public class CastTimer : Timer
		{
			private Spell m_Spell;

			public CastTimer( Spell spell, TimeSpan castDelay ) : base( castDelay )
			{
				m_Spell = spell;

				Priority = TimerPriority.TwentyFiveMS;
			}

			protected override void OnTick()
			{
                try
                {
                    if (m_Spell != null && m_Spell.m_Caster != null && m_Spell.m_State == SpellState.Casting && m_Spell.m_Caster.Spell == m_Spell)
                    {
                        m_Spell.m_State = SpellState.Sequencing;
                        m_Spell.m_CastTimer = null;
                        m_Spell.m_Caster.OnSpellCast(m_Spell);
                        m_Spell.m_Caster.Region.OnSpellCast(m_Spell.m_Caster, m_Spell);
                        m_Spell.m_Caster.NextSpellTime = Core.TickCount + Core.GetTicks(m_Spell.GetCastRecovery());

                        Target originalTarget = m_Spell.m_Caster.Target;

                        m_Spell.OnCast();

                        if (m_Spell.m_Caster.Player && m_Spell.m_Caster.Target != originalTarget && m_Spell.Caster.Target != null)
                            m_Spell.m_Caster.Target.BeginTimeout(m_Spell.m_Caster, TimeSpan.FromSeconds(30.0));

                        m_Spell.m_CastTimer = null;

                        m_Spell.OnEndCast();
                    }
                }
                catch
                {
                    m_Spell.m_CastTimer = null;

                    if (m_Spell != null && m_Spell.m_Caster != null)
                        m_Spell.m_Caster.NextSpellTime = Core.TickCount;
                }
			}
		}
	}
}