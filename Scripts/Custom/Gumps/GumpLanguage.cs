using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Multis;
using Server.Mobiles;

namespace Server.Gumps
{
    public class GumpLanguage : GumpGenerique
    {
        private TMobile m_owner;
        private bool m_apprentissage = false;

        public GumpLanguage(TMobile _owner, bool apprentissage)
            : base((apprentissage ? "Apprentissage (langage)" : "Choix d'un language"), 200, 200)
        {
            m_owner = _owner;
            m_apprentissage = apprentissage;
            int y = YBase;
            int x = XBase;
            int line = 0;
            int scale = 21;

            AddHtml(x, y + line * scale, 200, 20, "<h3><basefont color=#5A4A31>Langues:<basefont></h3>", false, false);
            line++;

            for (int i = 0; i < 8; i++)
            {
                if (m_apprentissage)
                {
                    if (m_owner.understandLangue((Langue)i))
                        AddButtonTrueFalse(x, y + line * scale, 666, true, ((Langue)i).ToString());
                    else
                        AddButtonTrueFalse(x, y + line * scale, 50 + i, false, ((Langue)i).ToString());
                    line++;
                }
                else
                {
                    if (m_owner.understandLangue((Langue)i))
                    {
                        if ((int)m_owner.CurrentLangue == i)
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
            TMobile from = f as TMobile;
            //Augmentation de matirise:

            if (info.ButtonID >= 50 && info.ButtonID < 100)
            {
                int nbrLangue = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (from.understandLangue((Langue)i))
                        nbrLangue++;
                }
                
                if (nbrLangue < from.Skills.ConnaissanceLangue.Fixed / 200 + 2)
                {
                    from.apprendreLangue((Langue)(info.ButtonID - 50));
                }
                else
                {
                    from.SendMessage("Pas assez de compétence en language pour apprendre une langue supplémentaire");
                }

            }
            else if (info.ButtonID >= 100 && info.ButtonID < 150)
            {
                if (from.understandLangue((Langue)(info.ButtonID - 100)))
                {
                    from.CurrentLangue = (Langue)info.ButtonID - 100;
                    from.SendMessage("Vous parlez maintenant la langue: " + from.CurrentLangue.ToString());
                }
                else
                {
                    from.SendMessage("Vous ne pouvez pas parlez une langue que vous ne connaissez pas");
                }
            }

        }

    }
}