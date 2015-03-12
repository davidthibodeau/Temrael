using Server.Mobiles;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.SkillHandlers;
using Server.Commands;
using Server.Targeting;

namespace Server.Engines.Hiding
{
    public enum DetectionStatus
    {
        None,            //Aucun test effectue
        Tentative5,      //5 tiles test effectue
        Tentative1,      //1 tiles test effectue
        Tentative0,      //0 tiles test effectue
        Deplacement5,    //5 tiles test effectue, mais bouge depuis
        Deplacement1,    //1 tiles test effectue, mais bouge depuis
        Deplacement0,    //0 tiles test effectue, mais bouge depuis
        Test5Dep1,       //1 tiles test effectue, mais bouge depuis, test 5 effectue ensuite
        Test5Dep0,       //0 tiles test effectue, mais bouge depuis, test 5 effectue ensuite
        Test1Dep0,       //0 tiles test effectue, mais bouge depuis, test 1 effectue ensuite
        Visible,
        Jet
    }

    public enum DetectionZone
    {
        Outside,
        CinqTiles,
        UneTile,
        ZeroTile
    }

    /// <summary>
    /// Sert a mesurer ceux qui voient le mobile a qui cela appartient
    /// </summary>
    public class Detection
    {
        // TODO: En ce moment, rien n'est sauve dans les saves. Si ca change. ScripPlayerMobile doit etre modifie.

        /// <summary>
        /// Indique le statut de visibilite du proprietaire de l'instance envers m.
        /// </summary>
        /// <param name="m">La personne qui observe le joueur a qui appartient l'instance.</param>
        /// <returns></returns>
        public DetectionStatus this[Mobile m] { get { return alentours[m]; } }

        protected Mobile mobile; // Proprietaire de l'instance de detection
        private Dictionary<Mobile, DetectionStatus> alentours; //Indique a qui tu es visible.

        #region Initialization / OnLogin, OnLogout / Constructeur
        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(EventSink_Login);
            EventSink.Logout += new LogoutEventHandler(EventSink_Logout);
            CommandSystem.Register("signaler", AccessLevel.Player, new CommandEventHandler(Signaler_OnCommand));
        }

        private static void EventSink_Login(LoginEventArgs e)
        {
            ScriptMobile sm = e.Mobile as ScriptMobile;

            sm.ActiverTestsDetection();
        }

        private static void EventSink_Logout(LogoutEventArgs e)
        {
            ScriptMobile sm = e.Mobile as ScriptMobile;

            sm.Detection.ResetAlentours();
            foreach (NetState state in NetState.Instances)
            {
                ScriptMobile m = state.Mobile as ScriptMobile;
                if (m != null)
                    m.Detection.RetirerJoueurDesAlentours(sm);
            }
        }

        public Detection(Mobile m)
        {
            mobile = m;
            alentours = new Dictionary<Mobile, DetectionStatus>();
        }
        #endregion

        #region Fonction .signaler
        private static void Signaler_OnCommand(CommandEventArgs e)
        {
            ScriptMobile from = e.Mobile as ScriptMobile;

            if (!from.Hidden)
            {
                from.SendMessage("Vous devez être caché pour signaler votre présence à quelqu'un.");
                return;
            }

            from.SendMessage("Veuillez viser le joueur à qui vous désirez signaler votre présence. (Vous devez lui être adjacent.)");
            from.Target = new SignalerTarget();
        }

        private class SignalerTarget : Target
        {
            public SignalerTarget()
                : base(1, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                ScriptMobile target = targeted as ScriptMobile;
                ScriptMobile sfrom = from as ScriptMobile;

                if (target == null)
                {
                    from.SendMessage("Vous devez viser un joueur.");
                    return;
                }

                sfrom.Detection.AfficherVisiblePour(target);
                from.SendMessage("Vous signalez à {0} votre présence.", target.GetNameUsedBy(from));
                target.SendMessage("{0} vous signale sa présence.", from.GetNameUsedBy(target));
            }
        }
        #endregion

        #region Fonctions publiques.
        // Retourne true si le jet de detection a été reussi.
        public bool FaireJet(Mobile obs, DetectionZone zone)
        {
            DetectionStatus status = DetectionStatus.None;

            double chance = DetectionChance(obs, zone, ref status);

            return JetEtUpdate(obs, chance, status);
        }

        public bool FaireJet(Mobile obs, double chance)
        {
            DetectionStatus status = DetectionStatus.Jet;
            return JetEtUpdate(obs, chance * SkillChance(obs), DetectionStatus.Jet);
        }

        public virtual void DetecterAlentours()
        {
            IPooledEnumerable<Mobile> eable = mobile.GetMobilesInRange(5);
            foreach (Mobile mob in eable)
            {
                ScriptMobile m = mob as ScriptMobile;

                if (m != null)
                {
                    if (m != mobile)
                    {
                        if (mobile.InRange(m, 0))
                            FaireJet(m, DetectionZone.ZeroTile);
                        else if (mobile.InRange(m, 1))
                            FaireJet(m, DetectionZone.UneTile);
                        else
                            m.Detection.FaireJet(m, DetectionZone.CinqTiles);
                    }
                }
            }

            eable.Free();
        }

        public void TesterPresenceAlentours()
        {
            if (mobile.AccessLevel > AccessLevel.Player)
                return;

            IPooledEnumerable<Mobile> eable = mobile.GetMobilesInRange(5);
            foreach (Mobile m in eable)
            {
                if (!m.InLOS(mobile) || mobile  == m)
                    continue;

                Garde garde = m as Garde;
                if (garde != null)
                {
                    garde.Detection.DetecterAlentours();
                    continue;
                }

                if (mobile.InRange(m, 0))
                    FaireJet(m, DetectionZone.ZeroTile);
                else if (mobile.InRange(m, 1))
                    FaireJet(m, DetectionZone.UneTile);
                else
                    FaireJet(m, DetectionZone.CinqTiles);
            }

            eable.Free();
        }
        #endregion

        #region Gestion de la liste de vision des alentours.
        private void MettreAJourAlentours(Mobile m, DetectionStatus d)
        {
            alentours[m] = d;
        }

        public void ResetAlentours()
        {
            alentours = new Dictionary<Mobile, DetectionStatus>();
        }

        public void RetirerJoueurDesAlentours(Mobile m)
        {
            alentours.Remove(m);
        }

        public void AfficherVisiblePour(Mobile obs)
        {
            alentours[obs] = DetectionStatus.Visible;

            if (Utility.InUpdateRange(obs, mobile))
            {
                NetState ns = obs.NetState;
                if (ns != null)
                {
                    if (obs.CanSee(mobile))
                    {
                        obs.Send(MobileIncoming.Create(ns, obs, mobile));
                        if (ObjectPropertyList.Enabled)
                        {
                            ns.Send(mobile.OPLPacket);

                            foreach (Item item in mobile.Items)
                                ns.Send(item.OPLPacket);
                        }

                        // On test un gain de skill seulement en cas de reussite pour eviter que le joueur sache
                        // que son jet a echoue a cause d'un gain de skill.
                        obs.CheckSkill(SkillName.Detection, 0);

                        obs.SendMessage("Vous détectez la présence de {0}", mobile.GetNameUsedBy(obs));
                    }
                    else
                    {
                        ns.Send(mobile.RemovePacket);
                    }
                }
            }
        }
        #endregion

        #region Fonctions de calcul des chances

        // Fait un jet avec les chances, update la vision, et met à jour le status au besoin.
        private bool JetEtUpdate(Mobile obs, double chance, DetectionStatus status)
        {
            ScriptMobile m = mobile as ScriptMobile;
            if (m == null || obs == mobile || !m.Hidden || !mobile.InLOS(m) || m.AccessLevel > AccessLevel.Player || status == DetectionStatus.Visible)
                return false;
            obs.SendMessage("Debug -- Chances de detection : " + String.Format("{0:0.00}", chance));

            if (chance >= Utility.RandomDouble())
            {
                m.Detection.AfficherVisiblePour(obs);
                return true;
            }
            else
            {
                m.Detection.MettreAJourAlentours(mobile, status);
                return false;
            }
        }

        private double DetectionChance(Mobile obs, DetectionZone zone, ref DetectionStatus status)
        {
            double chance = SkillChance(obs);

            if (status == DetectionStatus.Jet)
                return chance;

            try { status = alentours[obs]; }
            catch { alentours.Add(obs, DetectionStatus.None); }

            if (status == DetectionStatus.Visible)
            {
                return 0;
            }

            switch(zone)
            {
                case DetectionZone.Outside:
                    chance = BaseChance(zone, false); // Should never be hit
                    break;
                case DetectionZone.CinqTiles:
                    switch (status)
                    {
                        case DetectionStatus.None:
                            chance *= BaseChance(zone, true);
                            status = DetectionStatus.Tentative5;
                            break;
                        case DetectionStatus.Deplacement5:
                            chance *= BaseChance(zone, false);
                            status = DetectionStatus.Tentative5;
                            break;
                        case DetectionStatus.Deplacement1:
                            chance *= BaseChance(zone, false);
                            status = DetectionStatus.Test5Dep1;
                            break;
                        case DetectionStatus.Deplacement0:
                            chance *= BaseChance(zone, false);
                            status = DetectionStatus.Test5Dep0;
                            break;
                        default:
                            chance = 0; //On a deja tente pour 5 tiles
                            break;
                    }
                    break;
                case DetectionZone.UneTile:
                    switch (status)
                    {
                        case DetectionStatus.None:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.CinqTiles, true) 
                                                                      , BaseChance(DetectionZone.UneTile, true)});
                            status = DetectionStatus.Tentative1;
                            break;
                        case DetectionStatus.Tentative5:
                            chance *= BaseChance(zone, true);
                            status = DetectionStatus.Tentative1;
                            break;
                        case DetectionStatus.Deplacement5:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.CinqTiles, false) 
                                                                      , BaseChance(DetectionZone.UneTile, true)});
                            status = DetectionStatus.Tentative1;
                            break;
                        case DetectionStatus.Deplacement1:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.CinqTiles, false) 
                                                                      , BaseChance(DetectionZone.UneTile, false)});
                            status = DetectionStatus.Tentative1;
                            break;
                        case DetectionStatus.Deplacement0:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.CinqTiles, false) 
                                                                      , BaseChance(DetectionZone.UneTile, false)});
                            status = DetectionStatus.Test1Dep0;
                            break;
                        case DetectionStatus.Test5Dep1:
                            chance *= BaseChance(zone, false);
                            status = DetectionStatus.Tentative1;
                            break;
                        case DetectionStatus.Test5Dep0:
                            chance *= BaseChance(zone, false);
                            status = DetectionStatus.Test1Dep0;
                            break;
                        default:
                            chance = 0; // On a deja tente pour 1 tile
                            break;
                    }
                    break;
                case DetectionZone.ZeroTile:
                    switch (status)
                    {
                        case DetectionStatus.None:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.CinqTiles, true) 
                                                                      , BaseChance(DetectionZone.UneTile, true)
                                                                      , BaseChance(DetectionZone.ZeroTile, true) });
                            break;
                        case DetectionStatus.Tentative5:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.UneTile, true)
                                                                      , BaseChance(DetectionZone.ZeroTile, true) });
                            break;
                        case DetectionStatus.Tentative1:
                            chance *= BaseChance(DetectionZone.ZeroTile, true);
                            break;
                        case DetectionStatus.Deplacement5:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.CinqTiles, false) 
                                                                      , BaseChance(DetectionZone.UneTile, true)
                                                                      , BaseChance(DetectionZone.ZeroTile, true) });
                            break;
                        case DetectionStatus.Deplacement1:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.CinqTiles, false) 
                                                                      , BaseChance(DetectionZone.UneTile, false)
                                                                      , BaseChance(DetectionZone.ZeroTile, true) });
                            break;
                        case DetectionStatus.Deplacement0:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.CinqTiles, false) 
                                                                      , BaseChance(DetectionZone.UneTile, false)
                                                                      , BaseChance(DetectionZone.ZeroTile, false) });
                            break;
                        case DetectionStatus.Test5Dep1:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.UneTile, false)
                                                                      , BaseChance(DetectionZone.ZeroTile, true) });
                            break;
                        case DetectionStatus.Test5Dep0:
                            chance *= CombinerChanceJets(new double[] { BaseChance(DetectionZone.UneTile, false)
                                                                      , BaseChance(DetectionZone.ZeroTile, false) });
                            break;
                        case DetectionStatus.Test1Dep0:
                            chance *= BaseChance(DetectionZone.ZeroTile, false);
                            break;
                    }
                    if (status != DetectionStatus.Visible)
                        status = DetectionStatus.Tentative0;
                    break;
            }
            if (chance > 1)
                chance = 1;

            return chance;
        }

        private double BaseChance(DetectionZone zone, bool premierEssai)
        {
            if (premierEssai)
            {
                switch (zone)
                {
                    case DetectionZone.Outside: return 0; // Si changement ici, detectionChance doit etre revise (Outside should not be hit)
                    case DetectionZone.CinqTiles: return 0.3;
                    case DetectionZone.UneTile: return 0.3;
                    case DetectionZone.ZeroTile: return 0.2;
                }
            }
            else
            {
                switch (zone)
                {
                    case DetectionZone.Outside: return 0;
                    case DetectionZone.CinqTiles: return 0.1;
                    case DetectionZone.UneTile: return 0.1;
                    case DetectionZone.ZeroTile: return 0.1;
                }
            }
            return 0; // Unreachable
        }

        private double SkillChance(Mobile obs)
        {
            double detection = obs.Skills.Detection.Value * 2;
            double cachette = (mobile.Skills.Infiltration.Value + mobile.Skills.Discretion.Value) * Stealth.ScalMalusArmure(mobile);

            return detection / cachette;
        }

        private double CombinerChanceJets(double[] jets)
        {
            double chance = 0;
            for (int i = 0; i < jets.Length; i++)
                chance += (1 - chance) * jets[i];
            return chance;
        }
        #endregion
    }
}
