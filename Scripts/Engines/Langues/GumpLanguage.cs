using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Engines.Langues
{
    public class GumpLanguage : GumpGenerique
    {
        private PlayerMobile m_owner;
        private bool m_apprentissage = false;

        public GumpLanguage(PlayerMobile _owner, bool apprentissage)
            : base((apprentissage ? "Apprentissage des langues" : "Choix d'un langage"), 250, 250)
        {
            m_owner = _owner;
            m_apprentissage = apprentissage;
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 21;

            AddHtml(x, y + line * scale, 200, 20, "<h3><basefont color=#E2CDAA>Liste des langues:<basefont></h3>", false, false); //Anciennement 5A4A31
            line++;

            for (int i = 0; i < 8; i++)
            {
                if (m_apprentissage)
                {
                    if (m_owner.Langues[i])
                        AddButtonTrueFalse(x, y + line * scale, 666, true, ((Langue)i).ToString());
                    else
                        AddButtonTrueFalse(x, y + line * scale, 50 + i, false, ((Langue)i).ToString());
                    line++;
                }
                else
                {
                    if (m_owner.Langues[i])
                    {
                        if ((int)m_owner.Langues.CurrentLangue == i)
                            AddButtonTrueFalse(x, y + line * scale, 666, true, ((Langue)i).ToString());
                        else
                            AddButtonTrueFalse(x, y + line * scale, 100 + i, false, ((Langue)i).ToString());
                        line++;
                    }
                }
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile f = sender.Mobile;
            PlayerMobile from = f as PlayerMobile;

            if (info.ButtonID >= 50 && info.ButtonID < 100)
            {
                int nbrLangue = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (from.Langues[i])
                        nbrLangue++;
                }
                
                if (nbrLangue < from.Skills.Langues.Fixed / 200 + 2)
                {
                    from.Langues.Apprendre(info.ButtonID - 50);
                }
                else
                {
                    from.SendMessage("Pas assez de compétence en connaissance des langues pour apprendre une langue supplémentaire");
                }

            }
            else if (info.ButtonID >= 100 && info.ButtonID < 150)
            {
                if (from.Langues[info.ButtonID - 100])
                {
                    from.Langues.CurrentLangue = (Langue)info.ButtonID - 100;
                    from.SendMessage("Vous parlez maintenant la langue: " + from.Langues.CurrentLangue.ToString());
                }
                else
                {
                    from.SendMessage("Vous ne pouvez pas parler une langue que vous ne connaissez pas.");
                }
            }

        }

    }
}