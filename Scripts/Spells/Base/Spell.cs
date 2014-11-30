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
using Server.Engines.Combat;

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

		public Mobile Caster;
		public Item m_Scroll;
		private SpellInfo m_Info;
		public SpellState State;
		public DateTime m_StartCastTime;

		public SpellInfo Info{ get{ return m_Info; } }
		public string Name{ get{ return m_Info.Name; } }
		public string Mantra{ get{ return m_Info.Mantra; } }
        public int ManaCost { get { return m_Info.manaCost; } }
        public short Circle { get { return m_Info.Circle; } }
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
			Caster = caster;
			m_Scroll = scroll;
			m_Info = info;
		}

        #region Hérité de ISpell
		public virtual bool IsCasting{ get{ return State == SpellState.Casting; } }

        public virtual void OnCasterHurt()
        {
            if (CheckHurt)
            {
                PlayerMobile pm = Caster as PlayerMobile;
                double chance = Caster.Skills[SkillName.ArtMagique].Value / 333;

                if (pm != null)
                {
                    chance += pm.Skills[SkillName.Meditation].Value / 333;

                    if (this is NecromancerSpell) //La nécro est une école de contact, donc besoin d'un bonus pour ne pas Fizzle
                        chance += pm.Skills[SkillName.Animisme].Value / 333;
                }
                if (chance > Utility.RandomDouble())
                    Caster.SendMessage("Vous réussissez à garder votre concentration.");
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
				Caster.SendLocalizedMessage( 500111 ); // You are frozen and can not move.
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

        public virtual bool OnCasterUsingObject(object o)
		{
			if ( State == SpellState.Sequencing )
				Disturb( DisturbType.UseRequest );

			return true;
		}

        public virtual bool OnCastInTown(Region r)
		{
            return true;
		}
        #endregion

        public virtual bool ConsumeReagents()
		{
			if ( m_Scroll != null || !Caster.Player )
				return true;

			Container pack = Caster.Backpack;

			if ( pack == null )
				return false;

            if (Caster is PlayerMobile)
            {
                PlayerMobile tmob = (PlayerMobile)Caster;

                if (pack.ConsumeTotal(m_Info.Reagents, Info.Amounts) == -1)
                    return true;
            }

			return false;
		}

		public virtual bool CheckResisted( Mobile target )
        {
            return (Caster.Skills[SkillName.ResistanceMagique].Value + Utility.Random(100) >= Caster.Skills[Info.skillForCasting].Value + Utility.Random(100));
		}

        #region Mana.
        public static int GetBaseManaCost(short cercle)
        {
            return cercle * 10;
        }

        public virtual void SpellManaCost(int mana)
        {
            double scalar = 1.0;

            if (PourritureDEspritSpell.HasMindRotScalar(Caster))
                scalar = PourritureDEspritSpell.GetMindRotScalar(Caster);

            if (scalar < 1.0)
                scalar = 1.0;

            Caster.Mana -= (int)(mana * scalar);
        }
        #endregion

        #region Disturb / Fizzle.
        public void Disturb(DisturbType type)
        {
            if (State == SpellState.Casting)
            {
                State = SpellState.None;
                Caster.Spell = null;

                Caster.SendLocalizedMessage(500641); // Your concentration is disturbed, thus ruining thy spell.

                if (m_CastTimer != null)
                    m_CastTimer.Stop();

                if (m_AnimTimer != null)
                    m_AnimTimer.Stop();

                DoFizzle();

                Caster.NextSpellTime = Core.TickCount + Core.GetTicks(GetDisturbRecovery());
            }
        }

        public virtual void DoFizzle()
		{
			Caster.LocalOverheadMessage( MessageType.Regular, 0x3B2, 502632 ); // The spell fizzles.

			if ( Caster.Player )
			{
				Caster.FixedEffect( 0x3735, 6, 30 );
				Caster.PlaySound( 0x5C );
			}

            CombatStrategy.GetStrategy(Caster).ResetAttackAfterCast(Caster);

		}

        public virtual void DoHurtFizzle()
        {
            Caster.FixedEffect(0x3735, 6, 30);
            Caster.PlaySound(0x5C);
        }
        #endregion

        public CastTimer m_CastTimer;
		public AnimTimer m_AnimTimer;

		public virtual bool CheckCast()
        {
            PlayerMobile caster = Caster as PlayerMobile;

            if (caster != null && caster.Squelched)
            {
                caster.SendMessage("Vous ne pouvez incanter si vous êtes muet.");
                return false;
            }

            BaseCreature bc = Caster as BaseCreature;

            if (bc != null && (bc.Squelched))
                return false;

			return true;
		}

		public virtual void SayMantra()
		{
			if ( m_Info.Mantra != null && m_Info.Mantra.Length > 0 && Caster.Player )
				Caster.PublicOverheadMessage( MessageType.Spell, Caster.SpeechHue, true, Info.Mantra, false );
		}

		public virtual bool BlockedByHorrificBeast{ get{ return false; } }
		public virtual bool BlocksMovement{ get{ return true; } }

		public virtual bool CheckNextSpellTime{ get{ return true; } }

        public bool canCast()
        {
            PlayerMobile pm = Caster as PlayerMobile;

            if (Caster.AccessLevel != AccessLevel.Player)
            {
                return true;
            }
            else
            {
                if (!Caster.CheckAlive())
                {
                }
                else if (Caster.Spell != null && Caster.Spell.IsCasting)
                {
                    Caster.SendLocalizedMessage(502642); // You are already casting a spell.
                }
                else if (BlockedByHorrificBeast && TransformationSpell.UnderTransformation(Caster, typeof(HorrificBeastSpell)))
                {
                    Caster.SendLocalizedMessage(1061091); // You cannot cast that spell in this form.
                }
                else if (Caster.Frozen)
                {
                    Caster.SendLocalizedMessage(502643); // You can not cast a spell while frozen.
                }
                else if (CheckNextSpellTime && Core.TickCount < Caster.NextSpellTime)
                {
                    Caster.SendLocalizedMessage(502644); // You must wait for that spell to have an effect.
                }
                else if (Caster.Skills[m_Info.skillForCasting].Value < m_Info.minSkillForCasting)
                {
                    Caster.SendMessage("Vous n'êtes pas assez doué dans votre école de magie pour lancer ce sort.");
                }
                else if (Caster.Mana < ManaCost)
                {
                    Caster.LocalOverheadMessage(MessageType.Regular, 0, true, "Vous n'avez pas assez de mana pour lancer ce sort.");
                }
                else if (Caster.Spell == null && Caster.CheckSpellCast(this) && CheckCast() && Caster.Region.OnBeginSpellCast(Caster, this))
                {
                    return true;
                }
            }

            return false;
        }

		public virtual bool Cast()
        {
			m_StartCastTime = DateTime.Now;

            if ( canCast() )
            {
                State = SpellState.Casting;
                Caster.Spell = this;

                if (RevealOnCast)
                    Caster.RevealingAction();

                SayMantra();

                TimeSpan castTime = Info.castTime;

                double vitesse = 1 - Caster.Stam / 100.0;
                castTime = castTime.Add(TimeSpan.FromSeconds(vitesse));

                if (LenteurSpell.m_Table.Contains(Caster))
                {
                    int vit = (int)(castTime.TotalSeconds * 1000);
                    LenteurSpell.GetOnHitEffect(Caster, ref vit);
                    castTime = TimeSpan.FromMilliseconds(vit);
                }

                if (Caster.Body.IsHuman)
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

                if (ClearHandsOnCast)
                    Caster.ClearHands();

                m_CastTimer = new CastTimer(this, castTime);
                m_CastTimer.Start();

                OnBeginCast();

                return true;
            }

			return false;
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
                                               //0  1  2   3   4   5   6   7   8   9   10
        private int[] ChanceDeCast = new int[] { 0, 5, 15, 20, 30, 40, 50, 60, 70, 75, 80, 90, 100 };

		public virtual void GetCastSkills( out double min, out double max )
		{
			int circle = (int)m_Info.Circle;

            if (circle < 0)
                circle = 0;

			//double avg = ChanceLength * circle;
            double avg = ChanceDeCast[circle];

			min = avg - ChanceOffsetMin;
            max = avg; // + ChanceOffsetMax;
		}

		public virtual bool CheckFizzle()
		{
			double minSkill, maxSkill;

			GetCastSkills( out minSkill, out maxSkill );

            if (Caster.Mounted)
            {
                if (!Equitation.CheckEquitation(Caster, EquitationType.Cast))
                {
                    return false;
                }
            }

            if (EtouffementSpell.m_Table.Contains(Caster))
            {
                if (Utility.Random(100) <= (int)EtouffementSpell.m_Table[Caster])
                {
                    Caster.SendMessage("Vous vous étouffez en lancant votre sort !");
                    return false;
                }
            }

			return Caster.CheckSkill( CastSkill, minSkill, maxSkill );
		}

        public virtual int RequiredSkillValue { get { return m_Info.minSkillForCasting; } }

		public virtual TimeSpan GetDisturbRecovery()
		{
			double delay = 1.0 - Math.Sqrt( (DateTime.Now - m_StartCastTime).TotalSeconds / GetCastDelay().TotalSeconds );

			if ( delay < 0.1 )
				delay = 0.1;

			return TimeSpan.FromSeconds( delay );
		}

        // Fonction appellée dans CombatStrategy
        // Gère les effets liés à la magie lorsqu'un coup est donné, chez l'attaquant et le défenseur.
        public static int OnHitEffects(Mobile atk, Mobile def, int damage)
        {
            CurseWeaponSpell.GetOnHitEffect(atk, damage);

            BloodOathSpell.GetOnHitEffect(atk, def, ref damage);

            SacrificeSpell.GetOnHitEffect(def, ref damage);

            DernierSouffleSpell.GetOnHitEffect(def, ref damage);

            AdrenalineSpell.GetOnHitEffect(def, ref damage);
            
            return damage;
        }

        const double ScalArtMag      = 0.625; // Bonus lié au skill ArtMagique.
        const double BonusArtMag     = 6.25;

        const double ScalMainBranche = 0.2;  // Bonus sur le skill de la branche passée en paramètre.
        const double BonusMainBranch = 10;

        const double ScalScndBranche = 0;    // Bonus sur les skills des autres branches.
        const double BonusScndBranch = 0;

        const double ScalInscription = 0.5;  // Bonus lié au skill Inscription.
        const double BonusInscription= 5;

        const double ScalIntel       = 0.3;  // Bonus lié à l'intelligence.
        const double BonusIntel      = 5;

        public static double GetSpellScaling(Mobile atk, SkillName branche)
        {
            double Scaling = 0;

            // Les ifs sont gérés à la compilation, donc pas de coût, juste un warning gossant.
            if (ScalArtMag != 0)
            {
                Scaling += Damage.GetBonus(atk.Skills[SkillName.ArtMagique].Value, ScalArtMag, BonusArtMag);
            }

            if (ScalMainBranche != 0)
            {
                // "ScalMainBranche - ScalScndBranche" parce qu'on reprend l'influence de la branche principale comme une branche secondaire, plus tard.
                Scaling += Damage.GetBonus(atk.Skills[branche].Value, (ScalMainBranche - ScalScndBranche), BonusMainBranch);
            }

            if (ScalScndBranche != 0)
            {
                Scaling += Damage.GetBonus(atk.Skills[SkillName.Evocation].Value
                                         + atk.Skills[SkillName.Immuabilite].Value
                                         + atk.Skills[SkillName.Alteration].Value
                                         + atk.Skills[SkillName.Providence].Value
                                         + atk.Skills[SkillName.Transmutation].Value
                                         + atk.Skills[SkillName.Thaumaturgie].Value
                                         + atk.Skills[SkillName.Hallucination].Value
                                         + atk.Skills[SkillName.Ensorcellement].Value
                                         + atk.Skills[SkillName.Animisme].Value, ScalScndBranche, BonusScndBranch);
            }

            if (ScalInscription != 0)
            {
                Scaling += Damage.GetBonus(atk.Skills[SkillName.Inscription].Value, ScalInscription, BonusInscription);
            }

            if (ScalIntel != 0)
            {
                Scaling += Damage.GetBonus(atk.Int, ScalIntel, BonusIntel);
            }

            return Scaling;
        }


		public virtual int CastRecoveryBase{ get{ return 2; } }
		public virtual int CastRecoveryCircleScalar{ get{ return 0; } }
		public virtual int CastRecoveryFastScalar{ get{ return 0; } }
		public virtual int CastRecoveryPerSecond{ get{ return 1; } }
		public virtual int CastRecoveryMinimum{ get{ return 0; } }

		public virtual TimeSpan GetCastRecovery()
		{
            //if (!Core.AOS)
            //    return NextSpellDelay;

            int fcr = 0;

            //fcr -= ThunderstormSpell.GetCastRecoveryMalus(Caster);

            int fcrDelay = -(CastRecoveryFastScalar * fcr);

            int delay = CastRecoveryBase + fcrDelay;

            if (delay < CastRecoveryMinimum)
                delay = CastRecoveryMinimum;

            return TimeSpan.FromSeconds((double)delay / CastRecoveryPerSecond);
		}

		public virtual double CastDelayBase{ get{ return 1.0; } }
		public virtual int CastDelayMinimum{ get{ return 1; } }

		public virtual TimeSpan GetCastDelay()
		{
            double value = CastDelayBase + (double)RequiredSkillValue / 10 * .1;

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

        #region Sequence
        public virtual bool CheckSequence()
		{
            int mana = ManaCost;

            PlayerMobile pm = Caster as PlayerMobile;
            
            if ( Caster.AccessLevel != AccessLevel.Player )
            {
                return true;
            }
            else
            {
			    if ( Caster.Deleted || !Caster.Alive || Caster.Spell != this || State != SpellState.Sequencing )
                {
				    DoFizzle();
			    }
			    else if ( m_Scroll != null && !(m_Scroll is Runebook) && (m_Scroll.Amount <= 0 || m_Scroll.Deleted || m_Scroll.RootParent != Caster) )
			    {
				    DoFizzle();
                }
                else if (!ConsumeReagents() && Caster.AccessLevel < AccessLevel.Batisseur)
                {
                    Caster.LocalOverheadMessage(MessageType.Regular, 0x22, 502630); // More reagents are needed for this spell.
                }
			    else if ( Caster.Mana < mana )
			    {
				    Caster.LocalOverheadMessage( MessageType.Regular, 0x22, 502625 ); // Insufficient mana for this spell.
                }
                else if (pm != null && !Equitation.CheckEquitation(pm,EquitationType.Attacking))
                {
                    DoFizzle();
                }
			    else if ( CheckFizzle() )
			    {
                    SpellManaCost(mana);

				    if ( m_Scroll is SpellScroll )
					    m_Scroll.Consume();

                    if (ClearHandsOnCast)
					    Caster.ClearHands();

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
				Caster.SendLocalizedMessage( 501857 ); // This spell won't work on that!
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
				Caster.SendLocalizedMessage( 501857 ); // This spell won't work on that!
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

        public virtual void FinishSequence()
        {
            State = SpellState.None;

            if (Caster.Spell == this)
                Caster.Spell = null;

            CombatStrategy.GetStrategy(Caster).ResetAttackAfterCast(Caster);
        }
        #endregion

        #region Timers d'animation et de cast.
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
				if ( m_Spell.State != SpellState.Casting || m_Spell.Caster.Spell != m_Spell )
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
                    if (m_Spell != null && m_Spell.Caster != null && m_Spell.State == SpellState.Casting && m_Spell.Caster.Spell == m_Spell)
                    {
                        m_Spell.State = SpellState.Sequencing;
                        m_Spell.m_CastTimer = null;
                        m_Spell.Caster.OnSpellCast(m_Spell);
                        m_Spell.Caster.Region.OnSpellCast(m_Spell.Caster, m_Spell);
                        m_Spell.Caster.NextSpellTime = Core.TickCount + Core.GetTicks(m_Spell.GetCastRecovery());

                        Target originalTarget = m_Spell.Caster.Target;

                        m_Spell.OnCast();

                        if (m_Spell.Caster.Player && m_Spell.Caster.Target != originalTarget && m_Spell.Caster.Target != null)
                            m_Spell.Caster.Target.BeginTimeout(m_Spell.Caster, TimeSpan.FromSeconds(30.0));

                        m_Spell.m_CastTimer = null;

                        m_Spell.OnEndCast();
                    }
                }
                catch
                {
                    m_Spell.m_CastTimer = null;

                    if (m_Spell != null && m_Spell.Caster != null)
                        m_Spell.Caster.NextSpellTime = Core.TickCount;
                }
			}
        }
        #endregion
    }
}