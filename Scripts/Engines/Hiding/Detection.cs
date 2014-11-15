using Server.Mobiles;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        Visible
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
        public static void Initialize()
        {
            EventSink.Connected += new ConnectedEventHandler(EventSink_Connected);
            EventSink.Disconnected += new DisconnectedEventHandler(EventSink_Disconnected);
        }

		private static void EventSink_Connected( ConnectedEventArgs e )
		{
            ScriptMobile sm = e.Mobile as ScriptMobile;

            sm.ActiverTestsDetection();
		}

		private static void EventSink_Disconnected( DisconnectedEventArgs e )
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

        private Mobile mobile; // Proprietaire de l'instance de detection
        private Dictionary<Mobile, DetectionStatus> alentours;

        public Detection(Mobile m)
        {
            mobile = m;
            alentours = new Dictionary<Mobile, DetectionStatus>();
        }
        // TODO: En ce moment, rien n'est sauve dans les saves. Si ca change. ScripPlayerMobile doit etre modifie.

        public void DetecterAlentours()
        {
            IPooledEnumerable<Mobile> eable = mobile.GetMobilesInRange(5);
            foreach (Mobile mob in eable)
            {
                ScriptMobile m = mob as ScriptMobile;
                if (!m.Hidden || !mobile.InLOS(m))
                    continue;
                double chance = 0;
                DetectionStatus status;
                if (mobile.InRange(m, 0))
                    chance = m.Detection.DetectionChance(mobile, DetectionZone.ZeroTile, out status);
                else if (mobile.InRange(m, 1))
                    chance = m.Detection.DetectionChance(mobile, DetectionZone.UneTile, out status);
                else
                    chance = m.Detection.DetectionChance(mobile, DetectionZone.CinqTiles, out status);

                if (status == DetectionStatus.Visible)
                    continue;

                if (chance >= Utility.RandomDouble())
                    m.Detection.AfficherVisiblePour(mobile);
                else
                    m.Detection.MettreAJourAlentours(mobile, status);
            }

            eable.Free();
        }

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

        public void TesterPresenceAlentours()
        {
            IPooledEnumerable<Mobile> eable = mobile.GetMobilesInRange(5);
            foreach (Mobile m in eable)
            {
                if (!m.InLOS(mobile))
                    continue;
                double chance = 0;
                DetectionStatus status;
                if (mobile.InRange(m, 0))
                    chance = DetectionChance(m, DetectionZone.ZeroTile, out status);
                else if (mobile.InRange(m, 1))
                    chance = DetectionChance(m, DetectionZone.UneTile, out status);
                else
                    chance = DetectionChance(m, DetectionZone.CinqTiles, out status);

                if (status == DetectionStatus.Visible)
                    continue;

                if (chance >= Utility.RandomDouble())
                {
                    AfficherVisiblePour(m);
                }
                else
                    alentours[m] = status;
            }

            eable.Free();
        }

        public void AfficherVisiblePour(Mobile obs)
        {
            NetState ns = obs.NetState;
            if (ns != null)
            {
                if (ns.StygianAbyss)
                    obs.Send(new MobileIncoming(obs, mobile));
                else
                    obs.Send(new MobileIncomingOld(obs, mobile));
                if (ObjectPropertyList.Enabled)
                {
                    ns.Send(mobile.OPLPacket);

                    foreach (Item item in mobile.Items)
                        ns.Send(item.OPLPacket);
                }

                alentours[obs] = DetectionStatus.Visible;

                // On test un gain de skill seulement en cas de reussite pour eviter que le joueur sache
                // que son jet a echoue a cause d'un gain de skill.
                obs.CheckSkill(SkillName.Detection, 0);

                obs.SendMessage("Vous détectez la présence de {0}", mobile.GetNameUseBy(obs));
            }
        }

        public double DetectionChance(Mobile obs, DetectionZone zone, out DetectionStatus status)
        {
            DetectionStatus det = DetectionStatus.None;
            try { det = alentours[obs]; }
            catch { alentours.Add(obs, DetectionStatus.None); }

            if(det == DetectionStatus.Visible)
            {
                status = DetectionStatus.Visible;
                return 0;
            }

            double detection = obs.Skills.Detection.Value * 2;
            double cachette = mobile.Skills.Infiltration.Value + mobile.Skills.Discretion.Value;

            double chance = detection / cachette;
            status = det;

            switch(zone)
            {
                case DetectionZone.Outside:
                    chance = BaseChance(zone, false); // Should never be hit
                    break;
                case DetectionZone.CinqTiles:
                    switch (det)
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
                    switch (det)
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
                    switch (det)
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
                    if (det != DetectionStatus.Visible)
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

        private double CombinerChanceJets(double[] jets)
        {
            double chance = 0;
            for (int i = 0; i < jets.Length; i++)
                chance += (1 - chance) * jets[i];
            return chance;
        }

    }
}
