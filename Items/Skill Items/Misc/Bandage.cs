using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Gumps;
using System.Collections.Generic;

namespace Server.Items
{
    public class Bandage : Item, IDyable
    {
        [Constructable]
        public Bandage()
            : this(1)
        {
        }

        [Constructable]
        public Bandage(int amount)
            : base(0xE21)
        {
            Stackable = true;
            Weight = 0.1;
            Amount = amount;
        }

        public Bandage(Serial serial)
            : base(serial)
        {
        }

        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
                return false;

            //Hue = sender.DyedHue;

            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            Weight = 0.1;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!HasFreeHand(from))
            {
                from.SendMessage("Vous devez avoir les mains libres pour pouvoir soigner.");
            }
            else if (from.Mounted)
            {
                from.SendMessage("Vous ne pouvez soigner sur une monture.");
            }
            else if (from.InRange(GetWorldLocation(), 1))
            {
                from.RevealingAction();

                from.SendLocalizedMessage(500948); // Who will you use the bandages on?

                from.Target = new InternalTarget(this);
            }
            else
            {
                from.SendLocalizedMessage(500295); // You are too far away to do that.
            }
        }

        /*public override Item Dupe(int amount)
        {
            return base.Dupe(new Bandage(), amount);
        }*/

        public static bool HasFreeHand(Mobile m)
        {
            Item handOne = m.FindItemOnLayer(Layer.OneHanded);
            Item handTwo = m.FindItemOnLayer(Layer.TwoHanded);

            if (handTwo is BaseWeapon)
                handOne = handTwo;

            return (handOne == null && handTwo == null);
        }

        public static bool HasChestArmor(Mobile m)
        {
            List<Item> items = m.Items;
            bool can = true;

            foreach (Item item in items)
            {
                if (item is BaseArmor)
                {
                    BaseArmor armor = item as BaseArmor;

                    if (armor.BodyPosition == ArmorBodyType.Chest)
                    {
                        can = false;
                        break;
                    }

                }
            }

            return !can;
        }

        private class InternalTarget : Target
        {
            private Bandage m_Bandage;

            public InternalTarget(Bandage bandage)
                : base(1, false, TargetFlags.Beneficial)
            {
                m_Bandage = bandage;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (m_Bandage.Deleted)
                    return;

                if (targeted is Mobile)
                {
                    if (!HasFreeHand(from))
                    {
                        from.SendMessage("Vous devez avoir les mains libres pour pouvoir soigner.");
                    }
                    else if (from.Mounted)
                    {
                        from.SendMessage("Vous ne pouvez soigner sur une monture.");
                    }
                    else if (targeted is TMobile && ((TMobile)targeted).RisqueDeMort)
                    {
                        from.SendMessage("Cette personne est trop affaiblie pour être soignée.");
                    }
                    else if (HasChestArmor((Mobile)targeted))
                    {
                        from.SendMessage("Vous ne pouvez soigner si la personne porte un plastron.");
                    }
                    else if (from.InRange(m_Bandage.GetWorldLocation(), 1))
                    {
                        BandageContext context = BandageContext.GetContext((Mobile)targeted);

                        if (context != null)
                        {
                            from.SendMessage("Vous devez attendre avant de soigner à nouveau cette personne.");
                        }
                        else if (BandageContext.BeginHeal(from, (Mobile)targeted) != null)
                        {
                            m_Bandage.Consume();
                        }
                    }
                    else
                    {
                        from.SendLocalizedMessage(500295); // You are too far away to do that.
                    }
                }
                else
                {
                    from.SendLocalizedMessage(500970); // Bandages can not be used on that.
                }
            }
        }
    }

    public class BandageContext
    {
        private Mobile m_Healer;
        private Mobile m_Patient;
        private int m_Slips;
        private Timer m_Timer;

        public Mobile Healer { get { return m_Healer; } }
        public Mobile Patient { get { return m_Patient; } }
        public int Slips { get { return m_Slips; } set { m_Slips = value; } }
        public Timer Timer { get { return m_Timer; } }

        public void Slip()
        {
            m_Healer.SendLocalizedMessage(500961); // Your fingers slip!
            ++m_Slips;
        }

        public BandageContext(Mobile healer, Mobile patient, TimeSpan delay)
        {
            m_Healer = healer;
            m_Patient = patient;

            m_Timer = new InternalTimer(this, delay);
            m_Timer.Start();
        }

        public void StopHeal()
        {
            m_Table.Remove(m_Healer);

            if (m_Timer != null)
                m_Timer.Stop();

            m_Timer = null;
        }

        private static Hashtable m_Table = new Hashtable();

        public static BandageContext GetContext(Mobile healer)
        {
            return (BandageContext)m_Table[healer];
        }

        public static SkillName GetPrimarySkill(Mobile m)
        {
            /*if (!m.Player && (m.Body.IsMonster || m.Body.IsAnimal))
                return SkillName.Veterinary;
            else
                return SkillName.Healing;*/
            return SkillName.Soins;
        }

        public static SkillName GetSecondarySkill(Mobile m)
        {
            /*if (!m.Player && (m.Body.IsMonster || m.Body.IsAnimal))
                return SkillName.AnimalLore;
            else
                return SkillName.Anatomy;*/
            return SkillName.Restoration;
        }

        public void EndHeal()
        {
            StopHeal();

            int healerNumber = -1, patientNumber = -1;
            bool playSound = true;
            bool checkSkills = false;

            SkillName primarySkill = GetPrimarySkill(m_Patient);
            SkillName secondarySkill = GetSecondarySkill(m_Patient);

            BaseCreature petPatient = m_Patient as BaseCreature;

            if (!m_Healer.Alive)
            {
                healerNumber = 500962; // You were unable to finish your work before you died.
                patientNumber = -1;
                playSound = false;
            }
            else if (!Bandage.HasFreeHand(m_Healer))
            {
                m_Healer.SendMessage("Vous devez avoir les mains libres pour pouvoir soigner.");
            }
            else if (m_Healer.Mounted)
            {
                m_Healer.SendMessage("Vous ne pouvez soigner sur une monture.");
            }
            else if (!m_Healer.InRange(m_Patient, 1))
            {
                healerNumber = 500963; // You did not stay close enough to heal your target.
                patientNumber = -1;
                playSound = false;
            }
            else if (m_Patient is TMobile && ((TMobile)m_Patient).RisqueDeMort)
            {
                m_Healer.SendMessage("Cette personne est trop affaiblie pour être soignée.");
            }
            else if (Bandage.HasChestArmor(m_Patient))
            {
                m_Healer.SendMessage("Vous ne pouvez soigner si la personne porte un plastron.");
            }
            /*else if ( !m_Patient.Alive || (petPatient != null && petPatient.IsDeadPet) )
            {
                double healing = m_Healer.Skills[primarySkill].Value;
                double anatomy = m_Healer.Skills[secondarySkill].Value;
                double chance = ((healing - 68.0) / 50.0) - (m_Slips * 0.02);

                if ( (checkSkills = (healing >= 80.0 && anatomy >= 80.0)) && chance > Utility.RandomDouble() )
                {
                    if ( m_Patient.Map == null || !m_Patient.Map.CanFit( m_Patient.Location, 16, false, false ) )
                    {
                        healerNumber = 501042; // Target can not be resurrected at that location.
                        patientNumber = 502391; // Thou can not be resurrected there!
                    }
                    else if ( m_Patient.Region != null && m_Patient.Region.Name == "Khaldun" )
                    {
                        healerNumber = 1010395; // The veil of death in this area is too strong and resists thy efforts to restore life.
                        patientNumber = -1;
                    }
                    else
                    {
                        healerNumber = 500965; // You are able to resurrect your patient.
                        patientNumber = -1;

                        m_Patient.PlaySound( 0x214 );
                        m_Patient.FixedEffect( 0x376A, 10, 16 );

                        if ( petPatient != null && petPatient.IsDeadPet )
                        {
                            Mobile master = petPatient.ControlMaster;

                            if ( master != null && master.InRange( petPatient, 3 ) )
                            {
                                healerNumber = 503255; // You are able to resurrect the creature.

                                master.CloseGump( typeof( PetResurrectGump ) );
                                master.SendGump( new PetResurrectGump( m_Healer, petPatient ) );
                            }
                            else
                            {
                                bool found = false;

                                ArrayList friends = petPatient.Friends;

                                for ( int i = 0; friends != null && i < friends.Count; ++i )
                                {
                                    Mobile friend = (Mobile) friends[i];

                                    if ( friend.InRange( petPatient, 3 ) )
                                    {
                                        healerNumber = 503255; // You are able to resurrect the creature.

                                        friend.CloseGump( typeof( PetResurrectGump ) );
                                        friend.SendGump( new PetResurrectGump( m_Healer, petPatient ) );

                                        found = true;
                                        break;
                                    }
                                }

                                if ( !found )
                                    healerNumber = 1049670; // The pet's owner must be nearby to attempt resurrection.
                            }
                        }
                        else
                        {
                            m_Patient.CloseGump( typeof( ResurrectGump ) );
                            m_Patient.SendGump( new ResurrectGump( m_Patient, m_Healer ) );
                        }
                    }
                }
                else
                {
                    if ( petPatient != null && petPatient.IsDeadPet )
                        healerNumber = 503256; // You fail to resurrect the creature.
                    else
                        healerNumber = 500966; // You are unable to resurrect your patient.

                    patientNumber = -1;
                }
            }*/
            else if (m_Patient.Poisoned)
            {
                m_Healer.SendLocalizedMessage(500969); // You finish applying the bandages.

                double healing = m_Healer.Skills[primarySkill].Value;
                double anatomy = m_Healer.Skills[secondarySkill].Value;
                double chance = ((healing - 30.0) / 50.0) - (m_Patient.Poison.Level * 0.1) - (m_Slips * 0.02);

                if ((checkSkills = (healing >= 60.0 && anatomy >= 60.0)) && chance > Utility.RandomDouble())
                {
                    if (m_Healer is TMobile)
                    {
                        TMobile pm = (TMobile)m_Healer;

                        if (pm.CheckFatigue(3))
                        {
                            healerNumber = 1010060; // You have failed to cure your target!
                            patientNumber = -1;

                            goto end;
                        }
                    }

                    if (m_Patient.CurePoison(m_Healer))
                    {
                        healerNumber = (m_Healer == m_Patient) ? -1 : 1010058; // You have cured the target of all poisons.
                        patientNumber = 1010059; // You have been cured of all poisons.
                    }
                    else
                    {
                        healerNumber = -1;
                        patientNumber = -1;
                    }
                }
                else
                {
                    healerNumber = 1010060; // You have failed to cure your target!
                    patientNumber = -1;
                }
            }
            else if (m_Patient.Hits == m_Patient.HitsMax)
            {
                healerNumber = 500967; // You heal what little damage your patient had.
                patientNumber = -1;
            }
            else
            {
                checkSkills = true;
                patientNumber = -1;

                double healing = m_Healer.Skills[primarySkill].Value;
                double anatomy = m_Healer.Skills[secondarySkill].Value;
                double chance = (((healing + anatomy / 2) + 10.0) / 100.0) - (m_Slips * 0.02);

                if (chance > Utility.RandomDouble())
                {
                    if (m_Healer is TMobile)
                    {
                        TMobile pm = (TMobile)m_Healer;

                        if (pm.CheckFatigue(3))
                        {
                            healerNumber = 500968; // You apply the bandages, but they barely help.
                            playSound = false;

                            goto end;
                        }
                    }

                    healerNumber = 500969; // You finish applying the bandages.

                    double min, max;

                    min = (anatomy / 5.0) + (healing / 5.0) + 5;
                    max = (anatomy / 1.5) + (healing / 1.5) + 20;

                    double toHeal = min + (Utility.RandomDouble() * (max - min));

                    if (m_Patient.Body.IsMonster || m_Patient.Body.IsAnimal)
                        toHeal += m_Patient.HitsMax / 100;

                    if (toHeal < 1)
                    {
                        toHeal = 1;
                        healerNumber = 500968; // You apply the bandages, but they barely help.
                    }

                    m_Patient.Heal((int)toHeal);
                }
                else
                {
                    healerNumber = 500968; // You apply the bandages, but they barely help.
                    playSound = false;
                }
            }

        end:

            if (healerNumber != -1)
                m_Healer.SendLocalizedMessage(healerNumber);

            if (patientNumber != -1)
                m_Patient.SendLocalizedMessage(patientNumber);

            Console.WriteLine("Test");
            if (75 > Utility.Random(100))
            {
                m_Healer.AddToBackpack(new BloodyBandage());
                Console.WriteLine("Test 2");
            }

            if (playSound)
                m_Patient.PlaySound(0x57);

            if (checkSkills)
            {
                m_Healer.CheckSkill(secondarySkill, 0.0, 120.0);
                m_Healer.CheckSkill(primarySkill, 0.0, 120.0);
            }
        }

        private class InternalTimer : Timer
        {
            private BandageContext m_Context;

            public InternalTimer(BandageContext context, TimeSpan delay)
                : base(delay)
            {
                m_Context = context;
                Priority = TimerPriority.FiftyMS;
            }

            protected override void OnTick()
            {
                m_Context.EndHeal();
            }
        }

        public static BandageContext BeginHeal(Mobile healer, Mobile patient)
        {
            bool isDeadPet = (patient is BaseCreature && ((BaseCreature)patient).IsDeadPet);

            if (patient is BaseCreature && ((BaseCreature)patient).IsAnimatedDead)
            {
                healer.SendLocalizedMessage(500951); // You cannot heal that.
            }
            else if (!patient.Poisoned && patient.Hits == patient.HitsMax && !isDeadPet)
            {
                healer.SendLocalizedMessage(500955); // That being is not damaged!
            }
            else if (!patient.Alive && (patient.Map == null || !patient.Map.CanFit(patient.Location, 16, false, false)))
            {
                healer.SendLocalizedMessage(501042); // Target cannot be resurrected at that location.
            }
            else if (healer.CanBeBeneficial(patient, true, true))
            {
                healer.DoBeneficial(patient);

                bool onSelf = (healer == patient);
                int dex = healer.Dex;

                double seconds;
                double resDelay = AOS.GeneralTimeScaling * (patient.Alive ? 0.0 : 5.0);

                if (onSelf)
                {
                    seconds = AOS.GeneralTimeScaling * (9.4 + (0.6 * ((double)(120 - dex) / 10)));
                }
                else
                {
                    if (dex > 150)
                        dex = 150;

                    seconds = AOS.GeneralTimeScaling * (0.6 * ((double)(150 - dex) / 9));
                }

                BandageContext context = GetContext(healer);

                if (context != null)
                    context.StopHeal();

                context = new BandageContext(healer, patient, TimeSpan.FromSeconds(seconds));

                m_Table[healer] = context;

                if (!onSelf)
                    patient.SendLocalizedMessage(1008078, false, healer.Name); //  : Attempting to heal you.

                healer.SendLocalizedMessage(500956); // You begin applying the bandages.
                return context;
            }

            return null;
        }
    }
}