using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Items;

namespace Server.Mobiles
{
    public class ArmyAI : BaseAI
    {
        private Point3D m_ArmyHome;
        public Point3D ArmyHome
        { get { return m_ArmyHome; } set { m_ArmyHome = value; } }

        private Direction m_ArmyDirection;
        public Direction ArmyDirection
        { get { return m_ArmyDirection; } set { m_ArmyDirection = value; } }

        private FightMode m_ArmyFightMode;
        public FightMode ArmyFightMode
        { get { return m_ArmyFightMode; } set { m_ArmyFightMode = value; } }

        private BaseAI m_PreviousAI;

        public ArmyAI(BaseCreature m)
            : base(m)
        {
            m_ArmyHome = m.Location;
            m_ArmyDirection = m.Direction;
            m_ArmyFightMode = FightMode.Aggressor;
            CreatePreviousAIType();
            Action = ActionType.Backoff;
        }

        public override bool Obey()
        {
            return Think();
        }

        public virtual void CreatePreviousAIType()
        {
            if (m_PreviousAI != null)
                m_PreviousAI.m_Timer.Stop();

            m_PreviousAI = null;

            switch (m_Mobile.DefaultAI)
            {
                case AIType.AI_Melee:
                    m_PreviousAI = new MeleeAI(m_Mobile);
                    break;
                case AIType.AI_Animal:
                    m_PreviousAI = new AnimalAI(m_Mobile);
                    break;
                case AIType.AI_Berserk:
                    m_PreviousAI = new BerserkAI(m_Mobile);
                    break;
                case AIType.AI_Archer:
                    m_PreviousAI = new ArcherAI(m_Mobile);
                    break;
                case AIType.AI_Healer:
                    m_PreviousAI = new HealerAI(m_Mobile);
                    break;
                case AIType.AI_Vendor:
                    m_PreviousAI = new VendorAI(m_Mobile);
                    break;
                case AIType.AI_Mage:
                    m_PreviousAI = new MageAI(m_Mobile);
                    break;
                case AIType.AI_Predator:
                    m_PreviousAI = new PredatorAI(m_Mobile);
                    break;
                case AIType.AI_Thief:
                    m_PreviousAI = new ThiefAI(m_Mobile);
                    break;
                default:
                    break;
            }
            if (m_PreviousAI != null)
                m_PreviousAI.m_Timer.Stop();
        }

        public override bool DoActionWander()
        {
            m_Mobile.DebugSay("ARMY: Wandering");
            if (m_PreviousAI != null)
            {
                bool action = m_PreviousAI.DoActionWander();
                m_Mobile.DebugSay("Default result={0}", action);
                return action;
            }
            else
                return true;
        }

        public override bool DoActionCombat()
        {
            m_Mobile.DebugSay("ARMY: Combating");
            if (m_PreviousAI != null)
            {
                bool action = m_PreviousAI.DoActionCombat();
                m_Mobile.DebugSay("Default restult={0}", action);
                return action;
            }
            else
                return true;
        }

        public override bool DoActionGuard()
        {
            m_Mobile.DebugSay("ARMY: Guarding");

            /////////////////////////////////
            // Are we really damaged ?
            if (m_Mobile.Combatant != null)
                if (m_Mobile.Hits < m_Mobile.HitsMax * 20 / 100)
                {
                    // We are low on health, should we flee?
                    bool flee = false;
                    int diff = m_Mobile.Combatant.Hits - m_Mobile.Hits;
                    if (diff > 0)
                    {
                        // We are more hurt than them
                        flee = (Utility.Random(0, 100) < (5 + diff)); // (5 + diff)% chance to flee
                    }
                    else
                    {
                        // We are less hurt than them
                        flee = Utility.Random(0, 100) < 5; // 5% chance to flee
                    }
                    if (flee)
                    {
                        m_Mobile.DebugSay("I am going to flee from {0}", m_Mobile.Combatant.Name);
                        Action = ActionType.Flee;
                        return true;
                    }
                }

            /////////////////////////////////////

            //  Do I already have a combatant ?
            if (m_Mobile.Combatant != null)
            {
                m_Mobile.DebugSay("T1=1");
                // Yes, I have a combatant. Is he alive ?
                if (!m_Mobile.Combatant.Deleted && m_Mobile.Combatant.Alive)
                {
                    m_Mobile.DebugSay("T11=1");
                    // Yes I have. Is he in front of me ? 
                    if (m_Mobile.InRange(m_Mobile.Combatant, 1))
                    {
                        m_Mobile.DebugSay("T111=1");
                        // Yes he is in front of me: lets face and fight him!
                        m_Mobile.Direction = m_Mobile.GetDirectionTo(m_Mobile.Combatant);
                        return true;
                    }
                }
                else
                {
                    m_Mobile.DebugSay("T11=0");
                    // My combatant is dead... Let's fins something else more fun.
                    m_Mobile.Combatant = null;
                }
            }

            // Do I focus somebody ?
            if (m_Mobile.FocusMob == null)
            {   // I do not focus anyone. Let's try  to focus on somebody just around me 
                m_Mobile.DebugSay("T2=0");
                if (AcquireFocusMob(1, m_ArmyFightMode, false, false, true))
                {
                    m_Mobile.DebugSay("T21=0");
                    // Ok, I found somebody: does he really close to me ?
                    if (m_Mobile.InRange(m_Mobile.FocusMob, 1))
                    {
                        m_Mobile.DebugSay("T211=0");
                        //Yes, he is! He will be my combatant! I can fight him right now!
                        m_Mobile.Combatant = m_Mobile.FocusMob;
                        m_Mobile.FocusMob = null;
                        m_Mobile.Direction = m_Mobile.GetDirectionTo(m_Mobile.Combatant);
                        return true;
                    }
                }
            }

            bool HasMoved = false;
            // Are we at home ?
            if (m_ArmyHome.X != m_Mobile.Location.X || m_ArmyHome.Y != m_Mobile.Location.Y)
            {
                m_Mobile.DebugSay("T3=1");
                // Let's move home. That's so important for my boss...
                DoMove(m_Mobile.GetDirectionTo(m_ArmyHome));
                HasMoved = true;
            }

            // Now, do I have a combatant ?
            if (m_Mobile.Combatant != null)
            {
                m_Mobile.DebugSay("T4=1");
                // Yes I have! But can I still see him ?
                if (m_Mobile.InRange(m_Mobile.Combatant, m_Mobile.RangePerception))
                {
                    m_Mobile.DebugSay("T41=1");
                    // I can see him! Do I have a gun and ammos?
                    /*******TEST*******/
                    bool I_Have_A_Gun = false;
                    Item item = m_Mobile.FindItemOnLayer(Layer.OneHanded);
                    if (item != null)
                        if (item is BaseRanged)
                            I_Have_A_Gun = true;
                    if (!I_Have_A_Gun)
                    {
                        item = m_Mobile.FindItemOnLayer(Layer.TwoHanded);
                        if (item != null)
                            if (item is BaseRanged)
                                I_Have_A_Gun = true;
                    }
                    bool I_Have_Ammos = false;
                    if (I_Have_A_Gun)
                    {
                        Container pack = m_Mobile.Backpack;
                        if ((pack != null) &&
                             (pack.FindItemByType(((BaseRanged)item).AmmoType) != null))
                        {
                            I_Have_Ammos = true;
                        }
                    }
                    /******** END TEST *******/
                    if (I_Have_Ammos)
                    {
                        m_Mobile.DebugSay("T411=1");
                        // I have a gun and ammos! I can shoot him!
                        m_Mobile.Direction = m_Mobile.GetDirectionTo(m_Mobile.Combatant);
                        return true;
                    }
                    else
                    {
                        m_Mobile.DebugSay("T411=0");
                        // No gun or ammo... shit... but is he close to me enough ?
                        if (m_Mobile.InRange(m_Mobile.Combatant, 3))
                        {
                            m_Mobile.DebugSay("T4111=1");
                            // Yes he is close to me, let's just be ready to fight him
                            m_Mobile.Direction = m_Mobile.GetDirectionTo(m_Mobile.Combatant);
                            return true;
                        }
                        else
                        {
                            m_Mobile.DebugSay("T4111=0");
                            // He is not close enough, lets try to find somebody else...
                            m_Mobile.Combatant = null;
                        }
                    }
                }
                else
                {
                    m_Mobile.DebugSay("T41=0");
                    // I cannot see my combatant anymore... Let's find somebody else...
                    m_Mobile.Combatant = null;
                }
            }


            // Do I focus somebody ?
            if (m_Mobile.FocusMob == null)
            {
                m_Mobile.DebugSay("T5=1");
                // I do not focus anyone. Let's try  to focus on somebody according to my perception
                if (AcquireFocusMob(m_Mobile.RangePerception, m_ArmyFightMode, false, false, true))
                {
                    m_Mobile.DebugSay("T51=1");
                    // I can see him! Do I have a gun and ammos?
                    /*******TEST*******/
                    bool I_Have_A_Gun = false;
                    Item item = m_Mobile.FindItemOnLayer(Layer.OneHanded);
                    if (item != null)
                        if (item is BaseRanged)
                            I_Have_A_Gun = true;
                    if (!I_Have_A_Gun)
                    {
                        item = m_Mobile.FindItemOnLayer(Layer.TwoHanded);
                        if (item != null)
                            if (item is BaseRanged)
                                I_Have_A_Gun = true;
                    }
                    bool I_Have_Ammos = false;
                    if (I_Have_A_Gun)
                    {
                        Container pack = m_Mobile.Backpack;
                        if ((pack != null) &&
                             (pack.FindItemByType(((BaseRanged)item).AmmoType) != null))
                        {
                            I_Have_Ammos = true;
                        }
                    }
                    /******** END TEST *******/
                    if (I_Have_Ammos)
                    {
                        m_Mobile.DebugSay("T511=1");
                        // I have a gun and ammos, he will be my combatant, I can fight him!
                        m_Mobile.Combatant = m_Mobile.FocusMob;
                        m_Mobile.FocusMob = null;
                        m_Mobile.Direction = m_Mobile.GetDirectionTo(m_Mobile.Combatant);
                        return true;
                    }
                    else
                    {
                        m_Mobile.DebugSay("T511=0");
                        // No gun or ammo... shit... but is he close to me enough ?
                        if (m_Mobile.InRange(m_Mobile.Combatant, 3))
                        {
                            m_Mobile.DebugSay("T5111=1");
                            // Yes he is close to me, he will be my combatant, let's just be ready to fight him
                            m_Mobile.Combatant = m_Mobile.FocusMob;
                            m_Mobile.FocusMob = null;
                            m_Mobile.Direction = m_Mobile.GetDirectionTo(m_Mobile.Combatant);
                            return true;
                        }
                        else
                        {
                            m_Mobile.DebugSay("T5111=0");
                            // He is not close enough... nevermind... next time I will retry...
                            m_Mobile.Combatant = null;
                            m_Mobile.Direction = m_ArmyDirection;
                            return true;
                        }
                    }
                }
            }

            // Let's turn on the good direction if I haven't moved...
            if (!HasMoved)
            {
                m_Mobile.DebugSay("T6=1");
                m_Mobile.Direction = m_ArmyDirection;
            }

            return true;
        }

        public override bool DoActionFlee()
        {
            m_Mobile.DebugSay("ARMY: Fleeing");
            if (m_PreviousAI != null)
                return m_PreviousAI.DoActionFlee();
            else
                return true;
        }

        public override bool DoActionInteract()
        {
            m_Mobile.DebugSay("ARMY: Interacting");
            if (m_PreviousAI != null)
                return m_PreviousAI.DoActionInteract();
            else
                return true;
        }

        public override bool DoActionBackoff()
        {
            m_Mobile.DebugSay("ARMY: Backoffing");
            if (m_ArmyHome.X != m_Mobile.Location.X || m_ArmyHome.Y != m_Mobile.Location.Y)
            {
                m_Mobile.DebugSay("I will move towards my army position.");
                DoMove(m_Mobile.GetDirectionTo(m_ArmyHome));
            }
            else
            {
                m_Mobile.DebugSay("I am arrived.");
                if (m_Mobile.Direction != m_ArmyDirection)
                {
                    m_Mobile.DebugSay("I turn in the right direction");
                    m_Mobile.Direction = m_ArmyDirection;
                }
            }
            return true;
        }

    }
}

