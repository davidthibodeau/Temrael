/////////////////////////////////
// Chuchoter                  //
// Scripteur:  Apoc            //
// Adapté par:  Eowymos        //
// Serveur: Crépuscule         //
// 8 Mars 2008                 //
/////////////////////////////////

using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Targeting;
using Server.Mobiles;
using Server.Network;
using Server.Commands;

namespace Server.Misc
{
    public class ChuchoterCommand
    {
        private static string Msg;

        public static void Initialize()
        {
            CommandSystem.Register("Psst", AccessLevel.Player, new CommandEventHandler(Chuchoter_OnCommand));
        }

        [Usage("Psst <text>")]
        [Description("Chuchoter tout en restant caché si c'est le cas.")]
        private static void Chuchoter_OnCommand(CommandEventArgs e)
        {
            PlayerMobile from = ((PlayerMobile)e.Mobile);

            AlertMessage(from, 1);
            double srcSkill = from.Skills[SkillName.Discretion].Value;
            int range = (int)(srcSkill / 20.0);
            Msg = e.ArgString;
            from.Target = new ChutTarget(Msg, range);
        }

        private static void AlertMessage(Mobile from, int Message)
        {
            string texte = null;

            switch (Message)
            {
                case 0: texte = "Vous ne pouvez chuchoter qu'aux autres joueurs !"; break;
                case 1: texte = "À qui voulez-vous chuchoter ?"; break;
                case 3: texte = "Vous chuchotez."; break;
                case 4: texte = "Quelqu'un chuchote près de vous:"; break;
                case 5: texte = "Vous entendez quelqu'un chuchoter tout près:"; break;
                case 6: texte = "Vous parlez trop fort et êtes découvert !"; break;
                case 7: texte = "Vous êtes trop loin pour chuchoter !"; break;
            }

            if (from != null && texte != null)
                from.SendMessage(texte);
        }


        private class ChutTarget : Target
        {
            public ChutTarget(string Msg, int range) : base(range, false, TargetFlags.None)
            {

            }

            protected override void OnTarget(Mobile from, object targ)
            {
                if (!(targ is PlayerMobile)) 
                    AlertMessage(from, 0);
                else
                {
                    PlayerMobile target = ((PlayerMobile)targ);
                    if (from.Skills[SkillName.Discretion].Value < Utility.RandomMinMax(1, 100))
                    {
                        AlertMessage(from, 6);
                        from.RevealingAction();
                    }
                    else 
                        AlertMessage(from, 3);

                    AlertMessage(target, 4);
                    target.SendMessage(170, Msg);
                    SaySomething(from, Msg);
                }
            }

            protected override void OnTargetOutOfRange(Mobile from, object targ)
            {
                if (!(targ is PlayerMobile)) 
                    AlertMessage(from, 0);
                else 
                    AlertMessage(from, 7);
            }
        }

        private static void SaySomething(Mobile from, string texte)
        {
            IPooledEnumerable clientsInRange = from.GetClientsInRange(5);
            foreach (Server.Network.NetState state in clientsInRange)
            {
                Mobile mobile = state.Mobile;
                if (mobile is PlayerMobile)
                {
                    PlayerMobile m = mobile as PlayerMobile;
                    if (m != null && m.AccessLevel >= AccessLevel.Batisseur && m.AccessLevel > from.AccessLevel)
                    {
                        //m.Send(new UnicodeMessage(from.Serial, from.Body, MessageType.Regular, from.SpeechHue, 3, from.Language, ((PlayerMobile)from).PlayerName, String.Format("[Chuchotte]: {0}", texte)));
                        m.Send(new UnicodeMessage(from.Serial, from.Body, MessageType.Regular, from.SpeechHue, 3, from.Language, from.GetNameUseBy(m), String.Format("[Chuchote]: {0}", texte)));
                    }
                    if (m != null && m.Skills[SkillName.Discretion].Value > from.Skills[SkillName.Discretion].Value)
                    {
                        AlertMessage(m, 5);
                        m.SendMessage(170, texte);
                    }
                }
            }

        }
    }
}