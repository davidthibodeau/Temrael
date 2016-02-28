using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles.GuardsVersion2
{
    public class GuardVer2 : Mobile
    {
        enum HarmType
        {
            Snoop,
            Steal,
            Hit,
            HarmSpell,
            Death
        }

        #region Props
        bool m_ReactsToSnoop;
        [CommandProperty(AccessLevel.Batisseur)]
        public bool ReactsToSnoop
        {
            get { return m_ReactsToSnoop; }
            set { m_ReactsToSnoop = value; }
        }

        bool m_ReactsToSteal;
        [CommandProperty(AccessLevel.Batisseur)]
        public bool ReactsToSteal
        {
            get { return m_ReactsToSteal; }
            set { m_ReactsToSteal = value; }
        }

        bool m_ReactsToHit;
        [CommandProperty(AccessLevel.Batisseur)]
        public bool ReactsToHit
        {
            get { return m_ReactsToHit; }
            set { m_ReactsToHit = value; }
        }

        bool m_ReactsToDeath;
        [CommandProperty(AccessLevel.Batisseur)]
        public bool ReactsToDeath
        {
            get { return m_ReactsToDeath; }
            set { m_ReactsToDeath = value; }
        }

        bool m_ReactsToHarmfulSpell;
        [CommandProperty(AccessLevel.Batisseur)]
        public bool ReactsToHarmfulSpell
        {
            get { return m_ReactsToHarmfulSpell; }
            set { m_ReactsToHarmfulSpell = value; }
        }
        #endregion

        #region Fonctions de check publiques.
        public static void CheckOnSnoop(Mobile sataniste)
        {
            Check(sataniste, sataniste.Skills[SkillName.Fouille].Value, HarmType.Snoop);
        }

        public static void CheckOnSteal(Mobile sataniste)
        {
            Check(sataniste, sataniste.Skills[SkillName.Vol].Value, HarmType.Steal);
        }

        public static void CheckOnHit(Mobile sataniste)
        {
            Check(sataniste, 0, HarmType.Hit);
        }

        public static void CheckOnDeath(Mobile sataniste)
        {
            Check(sataniste, 0, HarmType.Death);
        }

        public static void CheckOnHSpell(Mobile sataniste)
        {
            Check(sataniste, 0, HarmType.HarmSpell);
        }
        #endregion


        private static void Check(Mobile sataniste, double skillval, HarmType type)
        {
            IPooledEnumerable<Mobile> list = sataniste.GetMobilesInRange(5);

            foreach (Mobile mob in list)
            {
                if (mob is GuardVer2)
                {
                    GuardVer2 guard = (GuardVer2)mob;
                    if (guard.CheckReaction(type))
                    {
                        double chance = (skillval / guard.Skills[SkillName.Detection].Value) / 2;
                        if (Utility.RandomDouble() >= chance)
                        {
                            guard.Say("Je te vois !");
                            sataniste.Emote("*Est pointé par " + guard.Name + "*");

                            // Devrait envoyer un message au groupe de joueurs représentant la garde. Moyen de lier ceci à l'InstitutionHandler ?
                        }
                    }
                }
            }
        }

        private bool CheckReaction(HarmType type)
        {
            switch (type)
            {
                case HarmType.Snoop: return m_ReactsToSnoop;
                case HarmType.Steal: return m_ReactsToSteal;
                case HarmType.Hit: return m_ReactsToHit;
                case HarmType.Death: return m_ReactsToDeath;
                case HarmType.HarmSpell: return m_ReactsToHarmfulSpell;
            }

            return false;
        }


        [Constructable]
        public GuardVer2()
            : base()
        {
            m_ReactsToSnoop = true;
            m_ReactsToSteal = true;
            m_ReactsToHit = true;
            m_ReactsToDeath = true;
            m_ReactsToHarmfulSpell = true;

            Blessed = true;
            Frozen = true;

            // Choppé de la classe WarriorGuard, probablement à ajuster.

            InitStats(1000, 1000, 1000);
            Title = "the guard";

            SpeechHue = Utility.RandomDyedHue();

            Hue = Utility.RandomSkinHue();

            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");

                switch (Utility.Random(2))
                {
                    case 0: AddItem(new LeatherSkirt()); break;
                    case 1: AddItem(new LeatherShorts()); break;
                }

                switch (Utility.Random(5))
                {
                    case 0: AddItem(new FemaleLeatherChest()); break;
                    case 1: AddItem(new FemaleStuddedChest()); break;
                    case 2: AddItem(new LeatherBustierArms()); break;
                    case 3: AddItem(new StuddedBustierArms()); break;
                    case 4: AddItem(new FemalePlateChest()); break;
                }
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");

                AddItem(new PlateChest());
                AddItem(new PlateArms());
                AddItem(new PlateLegs());

                switch (Utility.Random(3))
                {
                    case 0: AddItem(new Doublet(Utility.RandomNondyedHue())); break;
                    case 1: AddItem(new Tunic(Utility.RandomNondyedHue())); break;
                    case 2: AddItem(new BodySash(Utility.RandomNondyedHue())); break;
                }
            }
            Utility.AssignRandomHair(this);

            if (Utility.RandomBool())
                Utility.AssignRandomFacialHair(this, HairHue);

            Halberd weapon = new Halberd();

            weapon.Movable = false;
            weapon.Crafter = this;
            weapon.Quality = WeaponQuality.Exceptional;

            AddItem(weapon);

            Container pack = new Backpack();

            pack.Movable = false;

            pack.DropItem(new Gold(10, 25));

            AddItem(pack);

            //Skills[SkillName.Anatomy].Base = 120.0;
            Skills[SkillName.Tactiques].Base = 120.0;
            Skills[SkillName.Epee].Base = 120.0;
            Skills[SkillName.Concentration].Base = 120.0;
            Skills[SkillName.Detection].Base = 100.0;

            Blessed = true;
            Frozen = true;
        }

        public GuardVer2(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            int version = 0;
            writer.Write(version);

            writer.Write(m_ReactsToSnoop);
            writer.Write(m_ReactsToSteal);
            writer.Write(m_ReactsToHit);
            writer.Write(m_ReactsToDeath);
            writer.Write(m_ReactsToHarmfulSpell);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version == 0)
            {
                m_ReactsToSnoop = reader.ReadBool();
                m_ReactsToSteal = reader.ReadBool();
                m_ReactsToHit = reader.ReadBool();
                m_ReactsToDeath = reader.ReadBool();
                m_ReactsToHarmfulSpell = reader.ReadBool();
            }
        }
    }
}