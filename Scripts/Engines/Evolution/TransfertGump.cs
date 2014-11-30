using Server.Accounting;
using Server.Commands;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Evolution
{
    public class TransfertGump : Gump
    {

        public static void Initialize()
        {
            CommandSystem.Register("Transfert", AccessLevel.Player, new CommandEventHandler(Transfert_OnCommand));
        }

        [Usage("Compensation")]
        [Description("Accès au système de compensation MJ")]
        private static void Transfert_OnCommand(CommandEventArgs e)
        {
            PlayerMobile m = e.Mobile as PlayerMobile;

            if (m != null)
                m.SendGump(new TransfertGump(m));
        }

        private enum Buttons 
        { 
            PremierSupprimer = 1, SecondSupprimer = 2, TroisiemeSupprimer = 3, 
            ChoisirPremier = 4, ChoisirSecond = 5, ChoisirTroisieme = 6,
            Transferer = 7
        }

        PlayerMobile mobile;

        public TransfertGump(PlayerMobile m)
            : base(50, 50)
        {
            mobile = m;

            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;

            Transfert tr = Transfert.GetTransfert(m);
            if (tr == null)
                return;

            AddPage(0);
            AddBackground(31, 48, 416, 232, 9250);
            AddBackground(39, 56, 400, 217, 3500);
            AddLabel(144, 78, 1301, @"Vos personnages sauvergardés");
            AddButton(375, 230, 4005, 4006, (int)Buttons.Transferer, GumpButtonType.Reply, 0);
            AddLabel(80, 231, 1301, @"Transférer l'expérience courante dans la banque.");

            if (tr.Premier != null)
            {
                AddLabel(80, 120, 1301, tr.Premier.Left);
                AddLabel(270, 120, 1301, tr.Premier.Right.XP.ToString());
                AddButton(383, 119, 4017, 4019, (int)Buttons.PremierSupprimer, GumpButtonType.Reply, 0);
                if (m.Region is ZoneCreation)
                    AddButton(345, 119, 4005, 4007, (int)Buttons.ChoisirPremier, GumpButtonType.Reply, 0);
            }

            if (tr.Second != null)
            {
                AddLabel(80, 150, 1301, tr.Second.Left);
                AddLabel(270, 150, 1301, tr.Second.Right.XP.ToString());
                AddButton(383, 149, 4017, 4019, (int)Buttons.SecondSupprimer, GumpButtonType.Reply, 0);
                if (m.Region is ZoneCreation)
                    AddButton(345, 149, 4005, 4007, (int)Buttons.ChoisirSecond, GumpButtonType.Reply, 0);
            }

            if (tr.Troisieme != null)
            {
                AddLabel(80, 180, 1301, tr.Troisieme.Left);
                AddLabel(270, 180, 1301, tr.Troisieme.Right.XP.ToString());
                AddButton(383, 179, 4017, 4019, (int)Buttons.TroisiemeSupprimer, GumpButtonType.Reply, 0);
                if (m.Region is ZoneCreation)
                    AddButton(345, 179, 4005, 4007, (int)Buttons.ChoisirTroisieme, GumpButtonType.Reply, 0);
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if(info.ButtonID == 0)
                return;

            switch (info.ButtonID)
            {
                case (int)Buttons.PremierSupprimer:
                    sender.Mobile.Prompt = new ConfirmationPrompt(mobile, Buttons.PremierSupprimer);
                    break;
                case (int)Buttons.SecondSupprimer:
                    sender.Mobile.Prompt = new ConfirmationPrompt(mobile, Buttons.SecondSupprimer);
                    break;
                case (int)Buttons.TroisiemeSupprimer:
                    sender.Mobile.Prompt = new ConfirmationPrompt(mobile, Buttons.TroisiemeSupprimer);
                    break;
                case (int)Buttons.Transferer:
                    sender.Mobile.Prompt = new ConfirmationPrompt(mobile, Buttons.Transferer);
                    break;
                case (int)Buttons.ChoisirPremier:
                    sender.Mobile.Prompt = new ConfirmationPrompt(mobile, Buttons.ChoisirPremier);
                    break;
                case (int)Buttons.ChoisirSecond:
                    sender.Mobile.Prompt = new ConfirmationPrompt(mobile, Buttons.ChoisirSecond);
                    break;
                case (int)Buttons.ChoisirTroisieme:
                    sender.Mobile.Prompt = new ConfirmationPrompt(mobile, Buttons.ChoisirTroisieme);
                    break;
            }
        }

        private class ConfirmationPrompt : Prompt
        {
            Buttons button;
            PlayerMobile mobile;

            public ConfirmationPrompt(PlayerMobile m, Buttons b)
            {
                mobile = m;
                button = b;

                switch (b)
                {
                    case Buttons.PremierSupprimer:
                    case Buttons.SecondSupprimer:
                    case Buttons.TroisiemeSupprimer:
                        m.SendMessage("Êtes-vous certain de vouloir supprimer cette entrée? Elle ne peut être récupérée. (Répondez oui ou non)");
                        break;
                        
                    case Buttons.Transferer:
                        m.SendMessage("Êtes-vous certain de vouloir transférer l'expérience de ce personnage dans votre banque? Seulement " 
                            + "{0}% de votre expérience sera conservé. Cette opération ne peut être renversée. (Répondez oui ou non)", 
                            Transfert.pourcentageConserve * 100);
                        break;
                    case Buttons.ChoisirPremier:
                    case Buttons.ChoisirSecond:
                    case Buttons.ChoisirTroisieme:
                        m.SendMessage("Êtes-vous certain de vouloir choisr cette entrée? L'expérience sera transféré sur votre personnage"
                            + " actuel et écrasera l'expérience couramment sur ce personnage. Le ramener en banque va coûter 20% de votre" 
                            + " expérience. (Répondez oui ou non)");
                        break;
                }
            }

            public override void OnResponse(Mobile from, string text)
            {
                if (text.ToLower() == "non")
                    from.SendMessage("L'opération fut annulée.");
                else if (text.ToLower() == "oui")
                {
                    Transfert tr = Transfert.GetTransfert(mobile);
                    if (tr == null)
                    {
                        ExceptionLogging.WriteLine(new NullReferenceException(), "Mobile sans transfert: {0}", mobile);
                        return;
                    }

                    switch (button)
                    {
                        case Buttons.PremierSupprimer:
                            tr.Supprimer(Transfert.Position.Premier);
                            break;
                        case Buttons.SecondSupprimer:
                            tr.Supprimer(Transfert.Position.Second);
                            break;
                        case Buttons.TroisiemeSupprimer:
                            tr.Supprimer(Transfert.Position.Troisieme);
                            break;
                        case Buttons.Transferer:
                            tr.Extraire(mobile);
                            break;
                        case Buttons.ChoisirPremier:
                            if (!(from.Region is ZoneCreation))
                            {
                                from.SendMessage("Vous n'êtes plus dans la zone de création. Vous ne pouvez donc plus effectuer un tel transfert.");
                                return;
                            }
                            tr.Transferer(mobile, Transfert.Position.Premier);
                            break;
                        case Buttons.ChoisirSecond:
                            if (!(from.Region is ZoneCreation))
                            {
                                from.SendMessage("Vous n'êtes plus dans la zone de création. Vous ne pouvez donc plus effectuer un tel transfert.");
                                return;
                            }
                            tr.Transferer(mobile, Transfert.Position.Second);
                            break;
                        case Buttons.ChoisirTroisieme:
                            if (!(from.Region is ZoneCreation))
                            {
                                from.SendMessage("Vous n'êtes plus dans la zone de création. Vous ne pouvez donc plus effectuer un tel transfert.");
                                return;
                            }
                            tr.Transferer(mobile, Transfert.Position.Troisieme);
                            break;
                    }
                    from.SendMessage("Opération effectuée.");
                }
                else
                {
                    from.SendMessage("Veuillez répondre par oui ou par non.");
                    from.Prompt = this;
                }
            }
        }
    }
}
