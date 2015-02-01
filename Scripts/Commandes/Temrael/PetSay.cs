using System;
using System.Collections;
using System.IO;
using System.Text;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Gumps;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class PetSay
    {
        public static void Initialize()
        {
            CommandSystem.Register("paroler", AccessLevel.Player, new CommandEventHandler(PetSay_OnCommand));
            CommandSystem.Register("p", AccessLevel.Player, new CommandEventHandler(PetSay_OnCommand));
        }

        [Usage("PetSay")]
        [Description("Permet de faire dire quelque chose à ses compagnons")]
        public static void PetSay_OnCommand(CommandEventArgs e)
        {
            if (e.Length < 1)
            {
                e.Mobile.SendMessage("Utilisation : paroler <paroles>");
            }
            else
            {
                string tot = "";
                for (int i = 0; i < e.Length; i++)
                {
                    tot = tot + " "+ e.GetString(i);
                }
                e.Mobile.Target = new PetSayTarget(tot);
            }
        }
    }

    public class PetSayTarget : Target
    {
        private string m_Message;

        public PetSayTarget(string mess)
            : base(-1, false, TargetFlags.None)
        {
            m_Message = mess;
        }

        protected override void OnTarget(Mobile from, object targeted)
        {
            if (targeted is BaseCreature)
            {
                BaseCreature targ = (BaseCreature)targeted;

                if (from.AccessLevel >= AccessLevel.Counselor)
                {
                    targ.Say(m_Message);
                }
                else if (targ.Summoned && (from == targ.SummonMaster || from == targ.ControlMaster))
                {
                    targ.Say(m_Message);
                }
                else if (from == targ.ControlMaster && targ.Controlled && from.Skills[SkillName.Dressage].Base >= targ.MinTameSkill)
                {
                    targ.Say(m_Message);
                }
                else
                    from.SendMessage("Vous n'etes pas son maitre ou n'avez pas assez de competences en dressage.");

            }
            else
                from.SendMessage(256, "Il faut choisir une creature.");
        }
    }
}