using Server.Accounting;
using Server.Mobiles;
using Server.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Evolution
{
    [PropertyObject]
    public class Experience
    {
        private const int ExpGain = 750;

        [CommandProperty(AccessLevel.Batisseur)]
        //false = daily. true = hebdo
        public bool XPMode { get; set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime NextExp { get; set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public int Niveau { get; set; }

        public bool[,] Ticks { get; private set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public int XP { get; set; }

        [CommandProperty(AccessLevel.Batisseur)]
        public Cotes Cotes { get; set; }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(1); //version
            
            writer.Write(XP);
            writer.Write(Niveau);
            writer.Write(XPMode);
            writer.Write(NextExp);

            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 9; j++)
                    writer.Write(Ticks[i, j]);

            Cotes.Serialize(writer);
        }

        public Experience(GenericReader reader)
        {
            int version = reader.ReadInt();

            XP = reader.ReadInt();
            Niveau = reader.ReadInt();
            XPMode = reader.ReadBool();
            if (version == 0)
                reader.ReadDateTime();
            NextExp = reader.ReadDateTime();

            Ticks = new bool[7, 9];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 9; j++)
                    Ticks[i, j] = reader.ReadBool();

            if(version == 0)
                Cotes = new Cotes();
            else
                Cotes = new Cotes(reader);
        }

        public Experience()
        {
            XPMode = true;
            NextExp = DateTime.Now.AddMinutes(20);
            Ticks = new bool[7, 9];
            Cotes = new Cotes();
        }

        public void Tick(PlayerMobile pm)
        {
            if (pm == null || pm.Experience != this || pm.Region is ZoneInterne || NextExp > DateTime.Now)
                return;

            int tick = GetNextTick();
            int valeur = ExpGain;
            if(tick == -1)
                valeur = ExpGain / 100;
            else
                valeur = (int)(valeur * (1 - tick * 0.05));

            valeur = Cotes.OctroyerXP(valeur);

            XP += valeur;

            CompensationGump.MJ mj = CompensationGump.GetMJ((Account)pm.Account);
            if (mj != null)
            {
                mj.XpGainedThisWeek += valeur;
                CompensationGump.WriteLine(String.Format("{0} recoit {1} xp. Le total courant de la semaine est de {2}.",
                    mj.Nom, valeur, mj.XpGainedThisWeek));
            }

            NextExp = DateTime.Now.AddMinutes(20);
        }

        private int GetNextTick()
        {
            DateTime now = DateTime.Now;
            bool[,] ticks = Ticks;

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i <= (XPMode ? 6 : (int)now.DayOfWeek); i++)
                {
                    if (ticks != null && !ticks[i, j])
                    {
                        ticks[i, j] = true;
                        return j;
                    }
                }
            }
            return -1;
        }

        public void ResetTicks()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Ticks[i, j] = false;
                }
            }
        }

        public static void ResetAllTicks()
        {
            foreach (Mobile m in World.Mobiles.Values)
            {
                PlayerMobile pm = m as PlayerMobile;
                if (pm != null)
                {
                    pm.Experience.ResetTicks();
                }
            }
        }
    }
}
