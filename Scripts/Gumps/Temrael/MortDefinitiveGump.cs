using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using System.Collections;
using Server.Misc;
using Server.Accounting;
using Server.Engines.Mort;

namespace Server.Gumps
{
    class MortDefinitiveGump : Gump
    {
        private PlayerMobile m_From;

        public MortDefinitiveGump(PlayerMobile from)
            : base(0, 0)
        {
            m_From = from;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddBackground(80, 72, 420, 500, 3600);
            AddBackground(90, 82, 400, 480, 9200);
            AddBackground(100, 92, 380, 460, 3500);
            AddBackground(115, 105, 350, 330, 9300);
            AddBackground(115, 435, 350, 100, 9300);

            AddImage(39, 53, 10440);
            AddImage(459, 53, 10441);

            AddImage(125, 110, 95);
            AddImage(132, 119, 96);
            AddImage(268, 119, 96);
            AddImage(445, 110, 97);

            AddHtml(230, 105, 200, 20, "<h3><basefont color=#025a>Mort Définitive<basefont></h3>", false, false);

            AddButton(195, 130, 442, 442, 1, GumpButtonType.Reply, 0);

            AddHtml(120, 440, 340, 90, "Cliquez l'image ci-haut pour activer la mort definitive ou revenir a la vie. Si vous avez encore des points de destin, vous reviendrez directement a la vie. Si vous n'en avez plus vous regagnerez 95% de votre experience a la creation de votre prochain personnage.", true, true);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    /*m_From.Hits = (m_From.HitsMax / 2) + Utility.RandomMinMax(-5, 5);
                    m_From.Frozen = true;
                    if (Temrael.beta)
                        m_From.Map = Map.Ilshenar;
                    m_From.Location = m_From.EndroitMort;
                    m_From.MortEngine.MortCurrentState = MortState.Resurrection;
                    m_From.Mort = false;
                    m_From.Resurrect();
                    m_From.Frozen = false;

                    if (m_From.Corpse != null)
                    {
                        ArrayList list = new ArrayList();

                        foreach (Item item in m_From.Corpse.Items)
                        {
                            list.Add(item);
                        }

                        foreach (Item item in list)
                        {
                            if (item.Layer == Layer.Hair || item.Layer == Layer.FacialHair)
                                item.Delete();

                            if (item is BaseRaceGumps || (m_From.Corpse is Corpse && ((Corpse)m_From.Corpse).EquipItems.Contains(item)))
                            {
                                if (!m_From.EquipItem(item))
                                    m_From.AddToBackpack(item);
                            }
                            else
                            {
                                m_From.AddToBackpack(item);
                            }
                        }

                        m_From.Corpse.Delete();
                    }

                    m_From.CheckStatTimers();
                    m_From.CheckRaceGump();
                    m_From.PointDestin -= 1;*/

                    int exp = 0;

                    Account act = m_From.Account as Account;


                    if (act.GetTag("XP") == "")
                        act.RemoveTag("XP");

                    if (!(m_From.MortEngine.MortCurrentState == MortState.Delete))
                    {
                        exp = (int) (m_From.Experience.XP * 0.95);

                        act.SetTag("XP",exp.ToString());
                        m_From.MortEngine.MortCurrentState = MortState.Delete;
                        m_From.SendMessage("Votre prochain personnage débutera avec " + act.GetTag("XP"));
                        //m_From.MortEngine.MortCurrentState = MortState.MortDefinitive;
                        //m_From.Delete();
                    }
                    else if (m_From.MortEngine.MortCurrentState == MortState.Delete)
                    {
                        m_From.SendMessage("Vous avez déjà transféré votre expérience sur votre compte.");
                    }
                    else
                    {
                        m_From.SendMessage("Vous avez présentement encore " + act.GetTag("XP") + " points d'expérience pour votre prochain personnage.");
                    }
                break;
            }
        }
    }
}
