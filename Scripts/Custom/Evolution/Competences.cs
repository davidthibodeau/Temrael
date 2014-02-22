using System;
using Server;
using Server.Mobiles;
using System.Collections;
using Server.Gumps;

namespace Server
{
    public sealed class Competences
    {
        public static void Reset(TMobile from)
        {
            from.SkillsCap = 350 * 10 + (from.Niveau * 15);

            for (int i = 0; i < from.Skills.Length; ++i)
            {
                from.Skills[i].Base = 0.0;
                from.Skills[i].Cap = 40.0 + (from.Niveau * 2.0);
            }

            from.CompetencesLibres = 350 + (from.Niveau * 15);
        }

        public static int GetDisponibleComp(TMobile from)
        {
            return from.CompetencesLibres;
        }

        public static int GetRemainingComp(TMobile from)
        {
            int pc = (from.Niveau * 15) + 350;
            int added = 0;

            try
            {
                for (int i = 0; i < from.Skills.Length; i++)
                {
                    added += Convert.ToInt32(from.Skills[i].Value);
                }
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex, new System.Diagnostics.StackFrame(0, true));
            }

            return pc - added;
        }

        public static int GetValue(TMobile from, SkillName comp)
        {
            for (int i = 0; i < from.Skills.Length; i++)
                if (from.Skills[i].SkillID == (int)comp)
                    return Convert.ToInt32(from.Skills[i].Value);

            return -1;
        }

        public static void Raise(TMobile from, SkillName comp, int value)
        {
            //int value = Convert.ToInt32(from.Skills[comp].Base);

            if (value <= 100)
            {
                from.Skills[(int)comp].Base = value;
            }
        }

        public static bool CanRaise(TMobile from, SkillName comp)
        {
            int value = Convert.ToInt32(from.Skills[comp].Value);

            if (from.Skills[comp].Cap < from.Skills[comp].Value)
            {
                return false;
            }
            else if (from.CompetencesLibres < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void Lower(TMobile from, SkillName comp, int value)
        {
            //int value = Convert.ToInt32(from.Skills[comp].Base);

            if (value >= 0)
            {
                from.Skills[(int)comp].Base = value;
            }
        }

        public static bool CanLower(TMobile from, SkillName comp)
        {
            Skill sk = from.Skills[comp];
            if (sk == null)
            {
                Console.WriteLine("BUG: Skill est null à CanLower. La compétence causant le bug est " + comp); 
                return false;
            }
            int value = Convert.ToInt32(sk.Value);

            if (value > 0)
                return true;

            return false;
        }

        public static bool CanLower(TMobile from, Skill comp)
        {
            int value = Convert.ToInt32(comp.Value);

            if (value > 0)
                return true;

            return false;
        }

        public static bool CanRaise(TMobile from, Skill comp)
        {
            int value = Convert.ToInt32(comp.Value);

            if (comp.Cap <= comp.Value)
            {
                return false;
            }
            else if (from.CompetencesLibres < 1)
            {
                return false;
            }
            else
            {
                return true;
            }

            //return false;
        }
    }
}
