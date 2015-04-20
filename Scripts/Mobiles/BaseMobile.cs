using Server.Engines.Hiding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Spells;
using Server.Items;
using Server.Engines.Combat;
using Server.Engines.BuffHandling;

namespace Server.Mobiles
{
    public class BaseMobile : Mobile
    {
        private Timer m_ManaTimer, m_HitsTimer, m_StamTimer;
        private int m_StatCap;
        private int m_Str, m_Dex, m_Int;
        private int m_Hits, m_Stam, m_Mana;
        private bool m_Paralyzed;
        private ParalyzedTimer m_ParaTimer;
        private bool m_Frozen;
        private FrozenTimer m_FrozenTimer;

        [CommandProperty(AccessLevel.Batisseur)]
        public Detection Detection
        {
            get;
            set;
        }

        public BaseMobile()
        {
            Detection = new Detection(this);
        }

        public BaseMobile(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); //version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            Detection = new Detection(this);
        }

        protected override void OnLocationChange(Point3D oldLocation)
        {
            base.OnLocationChange(oldLocation);

            ActiverTestsDetection();
        }

        protected override bool OnMove(Direction d)
        {
            ActiverTestsDetection();

            return base.OnMove(d);
        }

        public override bool CanSee(Mobile m)
        {
            try
            {
                BaseMobile sm = m as BaseMobile;
                if (sm.Detection[this] == DetectionStatus.Visible)
                    return true;
            }
            catch { }

            return base.CanSee(m);
        }

        public void ActiverTestsDetection()
        {
            //Le systeme de detection fonctionne juste pour les joueurs.
            Detection.DetecterAlentours();
        }

        public override void OnHiddenChanged()
        {
            base.OnHiddenChanged();
            Detection.ResetAlentours();
        }

        public override void Damage(int amount)
        {
            Damage(amount, null);
        }

        public override void Damage(int amount, Mobile from)
        {
            double damage = amount;

            SacrificeSpell.GetOnHitEffect(this, ref damage);

            DernierSouffleSpell.GetOnHitEffect(this, ref damage);

            AdrenalineSpell.GetOnHitEffect(this, ref damage);

            Stam -= (int)(amount * 0.60);

            if (BandageContext.m_Table.Contains(this))
                BandageContext.GetContext(this).Slip();

            Damage((int)damage, from, true);
        }
            
        private static VisibleDamageType m_VisibleDamageType;

        public static VisibleDamageType VisibleDamageType
        {
            get { return m_VisibleDamageType; }
            set { m_VisibleDamageType = value; }
        }

        private List<DamageEntry> m_DamageEntries;

        public List<DamageEntry> DamageEntries
        {
            get { return m_DamageEntries; }
        }

        public static Mobile GetDamagerFrom( DamageEntry de )
        {
            return (de == null ? null : de.Damager);
        }

        public override Mobile FindMostRecentDamager( bool allowSelf )
        {
            return GetDamagerFrom( FindMostRecentDamageEntry( allowSelf ) );
        }

        public DamageEntry FindMostRecentDamageEntry( bool allowSelf )
        {
            for( int i = m_DamageEntries.Count - 1; i >= 0; --i )
            {
                if( i >= m_DamageEntries.Count )
                    continue;

                DamageEntry de = m_DamageEntries[i];

                if( de.HasExpired )
                    m_DamageEntries.RemoveAt( i );
                else if( allowSelf || de.Damager != this )
                    return de;
            }

            return null;
        }

        public Mobile FindLeastRecentDamager( bool allowSelf )
        {
            return GetDamagerFrom( FindLeastRecentDamageEntry( allowSelf ) );
        }

        public DamageEntry FindLeastRecentDamageEntry( bool allowSelf )
        {
            for( int i = 0; i < m_DamageEntries.Count; ++i )
            {
                if( i < 0 )
                    continue;

                DamageEntry de = m_DamageEntries[i];

                if( de.HasExpired )
                {
                    m_DamageEntries.RemoveAt( i );
                    --i;
                }
                else if( allowSelf || de.Damager != this )
                {
                    return de;
                }
            }

            return null;
        }

        public Mobile FindMostTotalDamger( bool allowSelf )
        {
            return GetDamagerFrom( FindMostTotalDamageEntry( allowSelf ) );
        }

        public DamageEntry FindMostTotalDamageEntry( bool allowSelf )
        {
            DamageEntry mostTotal = null;

            for( int i = m_DamageEntries.Count - 1; i >= 0; --i )
            {
                if( i >= m_DamageEntries.Count )
                    continue;

                DamageEntry de = m_DamageEntries[i];

                if( de.HasExpired )
                    m_DamageEntries.RemoveAt( i );
                else if( (allowSelf || de.Damager != this) && (mostTotal == null || de.DamageGiven > mostTotal.DamageGiven) )
                    mostTotal = de;
            }

            return mostTotal;
        }

        public Mobile FindLeastTotalDamger( bool allowSelf )
        {
            return GetDamagerFrom( FindLeastTotalDamageEntry( allowSelf ) );
        }

        public DamageEntry FindLeastTotalDamageEntry( bool allowSelf )
        {
            DamageEntry mostTotal = null;

            for( int i = m_DamageEntries.Count - 1; i >= 0; --i )
            {
                if( i >= m_DamageEntries.Count )
                    continue;

                DamageEntry de = m_DamageEntries[i];

                if( de.HasExpired )
                    m_DamageEntries.RemoveAt( i );
                else if( (allowSelf || de.Damager != this) && (mostTotal == null || de.DamageGiven < mostTotal.DamageGiven) )
                    mostTotal = de;
            }

            return mostTotal;
        }

        public DamageEntry FindDamageEntryFor( Mobile m )
        {
            for( int i = m_DamageEntries.Count - 1; i >= 0; --i )
            {
                if( i >= m_DamageEntries.Count )
                    continue;

                DamageEntry de = m_DamageEntries[i];

                if( de.HasExpired )
                    m_DamageEntries.RemoveAt( i );
                else if( de.Damager == m )
                    return de;
            }

            return null;
        }

        public override Mobile GetDamageMaster( Mobile damagee )
        {
            return null;
        }

        public virtual DamageEntry RegisterDamage( int amount, Mobile from )
        {
            DamageEntry de = FindDamageEntryFor( from );

            if( de == null )
                de = new DamageEntry( from );

            de.DamageGiven += amount;
            de.LastDamage = DateTime.Now;

            m_DamageEntries.Remove( de );
            m_DamageEntries.Add( de );

            Mobile master = from.GetDamageMaster( this );

            if( master != null )
            {
                List<DamageEntry> list = de.Responsible;

                if( list == null )
                    de.Responsible = list = new List<DamageEntry>();

                DamageEntry resp = null;

                for( int i = 0; i < list.Count; ++i )
                {
                    DamageEntry check = list[i];

                    if( check.Damager == master )
                    {
                        resp = check;
                        break;
                    }
                }

                if( resp == null )
                    list.Add( resp = new DamageEntry( master ) );

                resp.DamageGiven += amount;
                resp.LastDamage = DateTime.Now;
            }

            return de;
        }

        public override void InitStats(int str, int dex, int intel)
        {
            m_StatCap = 225;
            m_Str = str;
            m_Dex = dex;
            m_Int = intel;

            Hits = HitsMax;
            Stam = StamMax;
            Mana = ManaMax;

            Delta( MobileDelta.Stat | MobileDelta.Hits | MobileDelta.Stam | MobileDelta.Mana );
        }

        public override int StatCap
        {
            get
            {
                return m_StatCap;
            }
            set
            {
                if (m_StatCap != value)
                {
                    m_StatCap = value;

                    Delta(MobileDelta.StatCap);
                }
            }
        }

        /// <summary>
        /// Overridable. Virtual event invoked when the <see cref="RawStr" /> changes.
        /// <seealso cref="RawStr" />
        /// <seealso cref="OnRawStatChange" />
        /// </summary>
        public virtual void OnRawStrChange( int oldValue )
        {
        }

        /// <summary>
        /// Overridable. Virtual event invoked when <see cref="RawDex" /> changes.
        /// <seealso cref="RawDex" />
        /// <seealso cref="OnRawStatChange" />
        /// </summary>
        public virtual void OnRawDexChange( int oldValue )
        {
        }

        /// <summary>
        /// Overridable. Virtual event invoked when the <see cref="RawInt" /> changes.
        /// <seealso cref="RawInt" />
        /// <seealso cref="OnRawStatChange" />
        /// </summary>
        public virtual void OnRawIntChange( int oldValue )
        {
        }

        /// <summary>
        /// Overridable. Virtual event invoked when the <see cref="RawStr" />, <see cref="RawDex" />, or <see cref="RawInt" /> changes.
        /// <seealso cref="OnRawStrChange" />
        /// <seealso cref="OnRawDexChange" />
        /// <seealso cref="OnRawIntChange" />
        /// </summary>
        public virtual void OnRawStatChange( StatType stat, int oldValue )
        {
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Buffs Buffs
        {
            get;
            private set;
        }

        public void AddBuff(BaseBuff buff)
        {
            Buffs.AddBuff(buff);

            if (buff.ContainsEffect(BuffEffect.Str) 
                || buff.ContainsEffect(BuffEffect.Dex) 
                || buff.ContainsEffect(BuffEffect.Int))
                Delta(MobileDelta.Stat);

            if (buff.ContainsEffect(BuffEffect.HitsMax))
                Delta(MobileDelta.Hits);
            if (buff.ContainsEffect(BuffEffect.StamMax))
                Delta(MobileDelta.Stam);
            if (buff.ContainsEffect(BuffEffect.ManaMax))
                Delta(MobileDelta.Mana);

            if (buff.ContainsEffect(BuffEffect.ResistancePhysique)
                || buff.ContainsEffect(BuffEffect.ResistanceMagique))
                Delta(MobileDelta.Resistances);
        }

        [CommandProperty( AccessLevel.Batisseur )]
        public override int RawStr
        {
            get
            {
                return m_Str;
            }
            set
            {
                if (value < 1)
                    value = 1;
                else if (value > 65000)
                    value = 65000;

                if (m_Str != value)
                {
                    int oldValue = m_Str;

                    m_Str = value;
                    Delta(MobileDelta.Stat | MobileDelta.Hits);

                    if (Hits < HitsMax)
                    {
                        if (m_HitsTimer == null)
                            m_HitsTimer = new HitsTimer(this);

                        m_HitsTimer.Start();
                    }
                    else if (Hits > HitsMax)
                    {
                        Hits = HitsMax;
                    }

                    OnRawStrChange(oldValue);
                    OnRawStatChange(StatType.Str, oldValue);
                }
            }
        }

        public override int Str
        {
            get
            {
                int value = RawStr + Buffs.Str;

                if (value < 1)
                    value = 1;
                else if (value > 65000)
                    value = 65000;

                return value;
            }
            set
            {
                RawStr = value;
            }
        }


        [CommandProperty( AccessLevel.Batisseur )]
        public override int RawDex
        {
            get
            {
                return m_Dex;
            }
            set
            {
                if( value < 1 )
                    value = 1;
                else if( value > 65000 )
                    value = 65000;

                if( m_Dex != value )
                {
                    int oldValue = m_Dex;

                    m_Dex = value;
                    Delta( MobileDelta.Stat | MobileDelta.Stam );

                    if( Stam < StamMax )
                    {
                        if( m_StamTimer == null )
                            m_StamTimer = new StamTimer( this );

                        m_StamTimer.Start();
                    }
                    else if( Stam > StamMax )
                    {
                        Stam = StamMax;
                    }

                    OnRawDexChange( oldValue );
                    OnRawStatChange( StatType.Dex, oldValue );
                }
            }
        }

        [CommandProperty( AccessLevel.Batisseur )]
        public override int Dex
        {
            get
            {
                int value = m_Dex + Buffs.Dex;

                if( value < 1 )
                    value = 1;
                else if( value > 65000 )
                    value = 65000;

                return value;
            }
        }

        [CommandProperty( AccessLevel.Batisseur )]
        public override int RawInt
        {
            get
            {
                return m_Int;
            }
            set
            {
                if( value < 1 )
                    value = 1;
                else if( value > 65000 )
                    value = 65000;

                if( m_Int != value )
                {
                    int oldValue = m_Int;

                    m_Int = value;
                    Delta( MobileDelta.Stat | MobileDelta.Mana );

                    if( Mana < ManaMax )
                    {
                        if( m_ManaTimer == null )
                            m_ManaTimer = new ManaTimer( this );

                        m_ManaTimer.Start();
                    }
                    else if( Mana > ManaMax )
                    {
                        Mana = ManaMax;
                    }

                    OnRawIntChange( oldValue );
                    OnRawStatChange( StatType.Int, oldValue );
                }
            }
        }

        [CommandProperty( AccessLevel.Batisseur )]
        public override int Int
        {
            get
            {
                int value = m_Int + Buffs.Int;

                if( value < 1 )
                    value = 1;
                else if( value > 65000 )
                    value = 65000;

                return value;
            }
        }


        public virtual void OnHitsChange( int oldValue )
        {
        }

        public virtual void OnStamChange( int oldValue )
        {
        }

        public virtual void OnManaChange( int oldValue )
        {
        }

        private int curHitsM = -1, curStamM = -1, curManaM = -1;

        public override int Hits
        {
            get
            {
                return m_Hits;
            }
            set
            {
                if (Deleted)
                    return;

                if (value < 0)
                {
                    value = 0;
                }
                else if (value >= HitsMax)
                {
                    value = HitsMax;

                    if (m_HitsTimer != null)
                        m_HitsTimer.Stop();

                    for (int i = 0; i < Aggressors.Count; i++) //reset reports on full HP
                    Aggressors[i].CanReportMurder = false;

                    if (m_DamageEntries.Count > 0)
                        m_DamageEntries.Clear(); // reset damage entries on full HP
                }

                if (value < HitsMax)
                {
                    if (CanRegenHits)
                    {
                        if (m_HitsTimer == null)
                            m_HitsTimer = new HitsTimer(this);

                        m_HitsTimer.Start();
                    }
                    else if (m_HitsTimer != null)
                    {
                        m_HitsTimer.Stop();
                    }
                }

                if (m_Hits != value)
                {
                    int oldValue = m_Hits;
                    m_Hits = value;
                    Delta(MobileDelta.Hits);
                    OnHitsChange(oldValue);
                }
            }
        }

        public override int HitsMax
        {
            get
            {
                int value = (RawStr == 100 ? 110 : 100) + Str + Buffs.HitsMax;

                if (curHitsM == -1)
                    curHitsM = value;
                else if (curHitsM != value)
                    Hits = (int) (Hits * value / (double) curHitsM);

                return value;
            }
        }

        [CommandProperty( AccessLevel.Batisseur )]
        public override int Stam
        {
            get
            {
                return m_Stam;
            }
            set
            {
                if( Deleted )
                    return;

                if( value < 0 )
                {
                    value = 0;
                }
                else if( value >= StamMax )
                {
                    value = StamMax;

                    if( m_StamTimer != null )
                        m_StamTimer.Stop();
                }

                if( value < StamMax )
                {
                    if( CanRegenStam )
                    {
                        if( m_StamTimer == null )
                            m_StamTimer = new StamTimer( this );

                        m_StamTimer.Start();
                    }
                    else if( m_StamTimer != null )
                    {
                        m_StamTimer.Stop();
                    }
                }

                if( m_Stam != value )
                {
                    int oldValue = m_Stam;
                    m_Stam = value;
                    Delta( MobileDelta.Stam );
                    OnStamChange( oldValue );
                }
            }
        }

        public override int StamMax
        {
            get
            {
                int value = (RawDex == 100 ? 110 : 100) + Dex + Buffs.StamMax;

                if (curStamM == -1)
                    curStamM = value;
                else if (curStamM != value)
                    Stam = (int) (Stam * value / (double) curStamM);

                return value;
            }
        }

        /// <summary>
        /// Gets or sets the current stamina of the Mobile. This value ranges from 0 to <see cref="ManaMax" />, inclusive.
        /// </summary>
        [CommandProperty( AccessLevel.Batisseur )]
        public override int Mana
        {
            get
            {
                return m_Mana;
            }
            set
            {
                if( Deleted )
                    return;

                if( value < 0 )
                {
                    value = 0;
                }
                else if( value >= ManaMax )
                {
                    value = ManaMax;

                    if( m_ManaTimer != null )
                        m_ManaTimer.Stop();

                    if( Meditating )
                    {
                        Meditating = false;
                        SendLocalizedMessage( 501846 ); // You are at peace.
                    }
                }

                if( value < ManaMax )
                {
                    if( CanRegenMana )
                    {
                        if( m_ManaTimer == null )
                            m_ManaTimer = new ManaTimer( this );

                        m_ManaTimer.Start();
                    }
                    else if( m_ManaTimer != null )
                    {
                        m_ManaTimer.Stop();
                    }
                }

                if( m_Mana != value )
                {
                    int oldValue = m_Mana;
                    m_Mana = value;
                    Delta( MobileDelta.Mana );
                    OnManaChange( oldValue );
                }
            }
        }

        /// <summary>
        /// Overridable. Gets the maximum mana of the Mobile. By default, this returns: <c><see cref="Int" /></c>
        /// </summary>
        [CommandProperty( AccessLevel.Batisseur )]
        public override int ManaMax
        {
            get
            {
                int value = (RawInt == 100 ? 110 : 100) + Int + Buffs.ManaMax;

                if (curManaM == -1)
                    curManaM = value;
                else if (curManaM != value)
                    Mana = (int) (Mana * value / (double) curManaM);

                return value;
            }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public override int Vitesse
        {
            get
            {
                return (int) ((Dex + Stam * Dex / (double)StamMax) / 4 * (1 + Buffs.Vitesse));
            }
        }

        public override double PhysicalResistance
        {
            get { return ComputePhysicalResistance(); }
        }

        private double ComputePhysicalResistance()
        {
            double res = 0;

            if (ShieldArmor is BaseShield)
                res += ((BaseShield)ShieldArmor).PhysicalResistance;
            if (NeckArmor is BaseArmor)
                res += ((BaseArmor)NeckArmor).PhysicalResistance;
            if (HandArmor is BaseArmor)
                res += ((BaseArmor)HandArmor).PhysicalResistance;
            if (HeadArmor is BaseArmor)
                res += ((BaseArmor)HeadArmor).PhysicalResistance;
            if (ArmsArmor is BaseArmor)
                res += ((BaseArmor)ArmsArmor).PhysicalResistance;
            if (LegsArmor is BaseArmor)
                res += ((BaseArmor)LegsArmor).PhysicalResistance;
            if (ChestArmor is BaseArmor)
                res += ((BaseArmor)ChestArmor).PhysicalResistance;

            res += ArmureNaturelle;
            res += Buffs.ResistancePhysique;

            return res;
        }

        public override double MagicalResistance
        {
            get
            {
                double sk = Skills[SkillName.ResistanceMagique].Value;
                double resist = sk * 0.35;
                if (sk >= 100)
                    resist *= 1.05;

                resist += Buffs.ResistanceMagique;
                return resist;
            }
        }

        public override double ArmureNaturelle
        {
            get
            {
                double ArNatSkill = Skills[SkillName.ArmureNaturelle].Value;

                double baseArNat = ArNatSkill * 0.25 + (ArNatSkill >= 100 ? 5 : 0);
                double reducedAr = (75 - PhysicalResistance * 5 / 4) / 75 * baseArNat;

                if (reducedAr < 0)
                    return 0;
                else
                    return reducedAr;
            }
        }

        public override double Penetration
        {
            get
            {
                double pen = GetBonus(Skills[SkillName.Penetration].Value, 0.35);
                pen += Weapon.Penetration;
                pen += Buffs.Penetration;
                return pen;
            }
        }

        
        public static double GetBonus(double value, double scalar)
        {
            double bonus = value * scalar;

            if (value >= 100)
                bonus += scalar * 5; // 5% de la valeur a 100 est donnee en bonus.

            return bonus / 100;
        }



        public virtual void Damage( int amount, Mobile from, bool informMount )
        {
            if( !CanBeDamaged() || Deleted )
                return;

            if( !this.Region.OnDamage( this, ref amount ) )
                return;

            if( amount > 0 )
            {
                int oldHits = Hits;
                int newHits = oldHits - amount;

                if( Spell != null )
                    Spell.OnCasterHurt();

                //if ( m_Spell != null && m_Spell.State == SpellState.Casting )
                //  m_Spell.Disturb( DisturbType.Hurt, false, true );

                if( from != null )
                    RegisterDamage( amount, from );

                DisruptiveAction();

                Paralyzed = false;

                switch( m_VisibleDamageType )
                {
                    case VisibleDamageType.Related:
                        {
                            SendVisibleDamageRelated(from, amount);
                            break;
                        }
                    case VisibleDamageType.Everyone:
                        {
                            SendVisibleDamageEveryone(amount);
                            break;
                        }
                    case VisibleDamageType.Selective:
                        {
                            SendVisibleDamageSelective(from, amount);
                            break;
                        }
                }

                OnDamage( amount, from, newHits < 0 );

                IMount m = this.Mount;
                if( m != null && informMount )
                    m.OnRiderDamaged( amount, from, newHits < 0 );

                if( newHits < 0 )
                {
                    LastKiller = from;

                    Hits = 0;

                    if( oldHits >= 0 )
                        Kill();
                }
                else
                {
                    Hits = newHits;
                }
            }
        }

        private static bool m_GlobalRegenThroughPoison = true;

        public static bool GlobalRegenThroughPoison
        {
            get { return m_GlobalRegenThroughPoison; }
            set { m_GlobalRegenThroughPoison = value; }
        }

        public virtual bool RegenThroughPoison { get { return m_GlobalRegenThroughPoison; } }

        public override bool CanRegenHits { get { return this.Alive && (RegenThroughPoison || !this.Poisoned); } }
        public override bool CanRegenStam { get { return this.Alive; } }
        public override bool CanRegenMana { get { return this.Alive; } }

        private class ManaTimer : Timer
        {
            private Mobile m_Owner;

            public ManaTimer( Mobile m )
                : base( Mobile.GetManaRegenRate( m ), Mobile.GetManaRegenRate( m ) )
            {
                this.Priority = TimerPriority.FiftyMS;
                m_Owner = m;
            }

            protected override void OnTick()
            {
                if( m_Owner.CanRegenMana )// m_Owner.Alive )
                    m_Owner.Mana++;

                Delay = Interval = Mobile.GetManaRegenRate( m_Owner );
            }
        }

        private class HitsTimer : Timer
        {
            private Mobile m_Owner;

            public HitsTimer( Mobile m )
                : base( Mobile.GetHitsRegenRate( m ), Mobile.GetHitsRegenRate( m ) )
            {
                this.Priority = TimerPriority.FiftyMS;
                m_Owner = m;
            }

            protected override void OnTick()
            {
                if( m_Owner.CanRegenHits )// m_Owner.Alive && !m_Owner.Poisoned )
                    m_Owner.Hits++;

                Delay = Interval = Mobile.GetHitsRegenRate( m_Owner );
            }
        }

        private class StamTimer : Timer
        {
            private Mobile m_Owner;

            public StamTimer( Mobile m )
                : base( Mobile.GetStamRegenRate( m ), Mobile.GetStamRegenRate( m ) )
            {
                this.Priority = TimerPriority.FiftyMS;
                m_Owner = m;
            }

            protected override void OnTick()
            {
                if( m_Owner.CanRegenStam )// m_Owner.Alive )
                    m_Owner.Stam++;

                Delay = Interval = Mobile.GetStamRegenRate( m_Owner );
            }
        }

        public override bool ShouldCheckStatTimers { get { return true; } }

        public override void CheckStatTimers()
        {
            if (Deleted)
                return;

            if( Hits < HitsMax )
            {
                if( CanRegenHits )
                {
                    if( m_HitsTimer == null )
                        m_HitsTimer = new HitsTimer( this );

                    m_HitsTimer.Start();
                }
                else if( m_HitsTimer != null )
                {
                    m_HitsTimer.Stop();
                }
            }
            else
            {
                Hits = HitsMax;
            }

            if( Stam < StamMax )
            {
                if( CanRegenStam )
                {
                    if( m_StamTimer == null )
                        m_StamTimer = new StamTimer( this );

                    m_StamTimer.Start();
                }
                else if( m_StamTimer != null )
                {
                    m_StamTimer.Stop();
                }
            }
            else
            {
                Stam = StamMax;
            }

            if( Mana < ManaMax )
            {
                if( CanRegenMana )
                {
                    if( m_ManaTimer == null )
                        m_ManaTimer = new ManaTimer( this );

                    m_ManaTimer.Start();
                }
                else if( m_ManaTimer != null )
                {
                    m_ManaTimer.Stop();
                }
            }
            else
            {
                Mana = ManaMax;
            }
        }

        /// <summary>
        /// Overridable. Invoked after the mobile is deleted. When overriden, be sure to call the base method.
        /// </summary>
        protected override void OnAfterDelete()
        {
            if( m_HitsTimer != null )
                m_HitsTimer.Stop();

            if( m_StamTimer != null )
                m_StamTimer.Stop();

            if( m_ManaTimer != null )
                m_ManaTimer.Stop();

            if( m_ParaTimer != null )
                m_ParaTimer.Stop();

            if( m_FrozenTimer != null )
                m_FrozenTimer.Stop();

            base.OnAfterDelete();
        }


        [CommandProperty( AccessLevel.Batisseur )]
        public override bool Paralyzed
        {
            get
            {
                return m_Paralyzed;
            }
            set
            {
                if( m_Paralyzed != value )
                {
                    m_Paralyzed = value;
                    Delta( MobileDelta.Flags );

                    this.SendLocalizedMessage( m_Paralyzed ? 502381 : 502382 );

                    if( m_ParaTimer != null )
                    {
                        m_ParaTimer.Stop();
                        m_ParaTimer = null;
                    }
                }
            }
        }

        public override bool Frozen
        {
            get
            {
                return m_Frozen;
            }
            set
            {
                if( m_Frozen != value )
                {
                    m_Frozen = value;
                    Delta( MobileDelta.Flags );

                    if( m_FrozenTimer != null )
                    {
                        m_FrozenTimer.Stop();
                        m_FrozenTimer = null;
                    }
                }
            }
        }

        public override void Paralyze( TimeSpan duration )
        {
            if( !m_Paralyzed )
            {
                Paralyzed = true;

                m_ParaTimer = new ParalyzedTimer( this, duration );
                m_ParaTimer.Start();
            }
        }

        public override void Freeze( TimeSpan duration )
        {
            if( !m_Frozen )
            {
                Frozen = true;

                m_FrozenTimer = new FrozenTimer( this, duration );
                m_FrozenTimer.Start();
            }
        }

        private class ParalyzedTimer : Timer
        {
            private Mobile m_Mobile;

            public ParalyzedTimer( Mobile m, TimeSpan duration )
                : base( duration )
            {
                this.Priority = TimerPriority.TwentyFiveMS;
                m_Mobile = m;
            }

            protected override void OnTick()
            {
                m_Mobile.Paralyzed = false;
            }
        }

        private class FrozenTimer : Timer
        {
            private Mobile m_Mobile;

            public FrozenTimer( Mobile m, TimeSpan duration )
                : base( duration )
            {
                this.Priority = TimerPriority.TwentyFiveMS;
                m_Mobile = m;
            }

            protected override void OnTick()
            {
                m_Mobile.Frozen = false;
            }
        }

        public override void Kill()
        {
            if( Paralyzed )
            {
                Paralyzed = false;

                if( m_ParaTimer != null )
                    m_ParaTimer.Stop();
            }

            if( Frozen )
            {
                Frozen = false;

                if( m_FrozenTimer != null )
                    m_FrozenTimer.Stop();
            }

            base.Kill();
        }

    }
}
