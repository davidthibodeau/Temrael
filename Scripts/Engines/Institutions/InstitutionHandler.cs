using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Server.Mobiles;
using Server.Commands;
using Server.Engines.Institutions;

namespace Server.Items
{

    class InstitutionHandler : TownCrier
    {
        #region Membres / Consts
        public static ArrayList m_InstancesList;

        private Dictionary<Mobile, int> m_Mobiles;  // Mobile --- Rang.
        private List<Mobile> m_RegisteredMobiles;   // Contient tous ceux qui ont déjà joint cette institution. (Empêche l'abus du rang 1)

        public const int RANKMAX = 4;
        public string Titre = "NOT SET";            // Contient le nom de l'institution.
        public string Description = "NOT SET";      // Contient la description de l'institution.
        public List<Container> Containers;          // Contient les containers à duper lors du rankup.
        public List<String> RangTitre;              // Contient les titres des différents échelons.
        public static readonly int[] RangSalaire =  // Contient les salaires des différents échelons.
        {
            0,   // Aucun rang.
            250, // Rang 1. Matelot etc.
            500, // Rang 2.
            1000,// Rang 3.
            1500 // Rang 4.
        };
        #endregion

        #region Methodes static
        /// <summary>
        /// Trouve les titres que possède le mobile dans toutes les institutions existantes.
        /// </summary>
        /// <param name="m">Mobile dont on veut connaître les titres.</param>
        /// <returns>Un tableau de strings contenant les titres du personnage.</returns>
        public static List<String> GetTitreList(Mobile m)
        {
            List<String> s = new List<String>();

            foreach (InstitutionHandler i in m_InstancesList)
            {
                if (i.m_Mobiles.ContainsKey(m))
                {
                    s.Add(i.GetTitre((int)i.m_Mobiles[m]));
                }
            }

            return s;
        }

        /// <summary>
        /// Verse un salaire pour tous les mobiles qui sont dans une institution. Dans le cas
        /// où un joueur est dans deux institutions, il touche le salaire le plus élevé.
        /// </summary>
        public static void Pay()
        {
            if (m_InstancesList != null)
            {
                if (m_InstancesList.Count > 0)
                {
                    Dictionary<Mobile,int> Paie = new Dictionary<Mobile,int>();

                    // Construit une liste key-val pour chaque Mobile institutionnalisé.
                    // Lui set un salaire qui correspond au salaire le plus élevé de toutes les institutions dans lesquelles il a un rang.
                    foreach (InstitutionHandler i in m_InstancesList)
                    {
                        if (i != null)
                        {
                            foreach (KeyValuePair<Mobile, int> pair in i.m_Mobiles)
                            {
                                if (!Paie.ContainsKey(pair.Key))
                                {
                                    Paie.Add(pair.Key, GetSalaire(pair.Value));
                                }
                                else
                                {
                                    Paie[pair.Key] = Math.Max(Paie[pair.Key], GetSalaire(pair.Value));
                                }
                            }
                        }
                    }

                    foreach (KeyValuePair<Mobile, int> pair in Paie)
                    {
                        if (Banker.Deposit(pair.Key, pair.Value))
                        {
                            pair.Key.SendMessage("Un dépot de " + pair.Value + " pièces d'or a été fait par votre institution.");
                        }
                        else
                        {
                            pair.Key.SendMessage("Il y a eu une erreur lors du dépot de " +  pair.Value + " pièces d'or dans votre coffre de banque. Le salaire a donc été versé directement dans votre sac pour éviter la perte.");
                            pair.Key.AddToBackpack(new Gold(pair.Value));
                        }

                        PayLogging(pair.Key, pair.Value);
                    }
                }
            }
        }

        private static void PayLogging(Mobile m, int amount)
        {
            if (m != null && m.Account != null)
            {
                string path = "Logging/PayLogging";
                string fileName = path + m.Account.Username + ".txt";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (StreamWriter sw = new StreamWriter(fileName, true))
                    sw.WriteLine(
                        "Joueur : " + m.Name + "\r\n" +
                        "Date : " + DateTime.Now.ToString() + "\r\n" +
                        "Montant : " + amount.ToString() + "\r\n\n");
            }
        }
        #endregion

        #region Methodes

        #region Get
        public List<Mobile> GetList()
        {
            return m_Mobiles.Keys.ToList<Mobile>();
        }

        /// <summary>
        /// Trouve le titre lié au rang passé en paramètre.
        /// </summary>
        /// <param name="rank">Le rang, doit être entre 0 et RANKMAX.</param>
        /// <returns>Une string contenant le titre lié au rang. Si le rang est invalide, il retourne "Aucun Titre" par défaut.</returns>
        public String GetTitre(int rank)
        {
            if (CheckValidRank(rank))
            {
                try
                {
                    return RangTitre[rank];
                }
                catch (Exception)
                {
                }
            }
            return RangTitre[0];
        }

        /// <summary>
        /// Trouve le salaire lié au rang passé en paramètre.
        /// </summary>
        /// <param name="rank">Le rang, doit être entre 0 et RANKMAX.</param>
        /// <returns>Une string contenant le salaire lié au rang. Si le salaire est invalide, il retourne le salaire[0] par défaut.</returns>
        public static int GetSalaire(int rank)
        {
            if (CheckValidRank(rank))
            {
                try
                {
                    return RangSalaire[rank];
                }
                catch (Exception)
                {
                }
            }
            return RangSalaire[0];
        }

        /// <summary>
        /// Trouve le rang lié au mobile passé en paramètre.
        /// </summary>
        /// <param name="m">Le mobile dont on veut connaître le rang.</param>
        /// <returns>Le rang du mobile. Si le mobile n'a pas de rang au sein de l'institution, il retourne le rang 0 par défaut.</returns>
        public int GetRank(Mobile m)
        {
            if (m_Mobiles.ContainsKey(m))
            {
                return m_Mobiles[m];
            }
            return -1;
        }
        #endregion

        #region Gérance du m_MobilesList
        /// <summary>
        /// Ajoute un mobile à la liste des joueurs dans l'institution.
        /// </summary>
        /// <param name="m">Le mobile à ajouter.</param>
        public void AjouterInstitution(Mobile m)
        {
            if(m != null)
            {
                if (!m_Mobiles.ContainsKey(m))
                {
                    m_Mobiles.Add(m, 0); // Rang 0 par défaut, augmenté à 1 juste après pour dropper l'item lié au rang.
                    RankUp(m);
                }

                if (!m_RegisteredMobiles.Contains(m))
                {
                    m_RegisteredMobiles.Add(m);
                }
            }
        }


        /// <summary>
        /// Retire un mobile de la liste des joueurs dans l'institution, si il est présent.
        /// </summary>
        /// <param name="m">Le mobile à retirer.</param>
        public void RetirerInstitution(Mobile m)
        {
            if (m != null)
            {
                if (m_Mobiles.ContainsKey(m))
                {
                    m_Mobiles.Remove(m);
                }
            }
        }
        #endregion

        #region Gérance du rang des joueurs
        /// <summary>
        /// Augmente le rang du joueur de 1 si c'est possible, et lui donne le stock lié à son nouveau rang.
        /// Si le rang est == à 1, on vérifie si il n'a pas déjà eu son stock de départ.
        /// </summary>
        /// <param name="m">Le mobile à rankup.</param>
        public void RankUp(Mobile m)
        {
            if (m_Mobiles.ContainsKey(m))
            {
                if (m_Mobiles[m] >= 0 && m_Mobiles[m] < RANKMAX)
                {
                    m_Mobiles[m]++;
                    if ( !(m_RegisteredMobiles.Contains(m)) || m_Mobiles[m] != 1) // Si le nouveau rang est == 1, cela veut dire que l'ancien était 0.
                    {
                        if (Containers[m_Mobiles[m]] != null)
                        {
                            Item i = Dupe.DupeItem(m, Containers[m_Mobiles[m]], true); // On dupe le container lié au rang du mobile.
                            i.Visible = true;
                            m.Backpack.AddItem(i);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Descends le rang du joueur de 1 si c'est possible.
        /// </summary>
        /// <param name="m">Le mobile à rankdown.</param>
        public void RankDown(Mobile m)
        {
            if (m_Mobiles.ContainsKey(m))
            {
                if (m_Mobiles[m] > 0 && m_Mobiles[m] <= RANKMAX)
                {
                    m_Mobiles[m]--;
                }
            }
        }
        #endregion

        private static bool CheckValidRank(int rank)
        {
            return (rank >= 0 && rank <= RANKMAX);
        }

        #endregion

        #region Ctor / Delete override
        [Constructable]
        public InstitutionHandler()
        {
            Name = "Gérant d'institution";
            Title = ""; // Pour override le towncrier.

            if (m_InstancesList == null)
                m_InstancesList = new ArrayList();

            m_InstancesList.Add(this);

            Hue = Utility.RandomSkinHue();

            m_Mobiles = new Dictionary<Mobile,int>();
            m_RegisteredMobiles = new List<Mobile>();

            RangTitre = new List<String>();
            for (int i = 0; i <= RANKMAX; i++)
            {
                RangTitre.Add("NOT SET");
            }
            RangTitre[0] = "Aucun titre.";

            Containers = new List<Container>();
            for (int i = 0; i <= RANKMAX; i++)
            {
                Containers.Add(null);
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendGump(new InstitutionGump(from, this));
        }

        protected override void OnLocationChange(Point3D oldLocation)
        {
            VerifyLocation();

            base.OnLocationChange(oldLocation);
        }

        public void VerifyLocation()
        {
            if (Containers != null)
            {
                foreach (Container c in Containers)
                {
                    if (c != null)
                    {
                        c.Location = new Point3D(Location.X, Location.Y, Location.Z - 50); // Berk, mais le seul moyen que j'ai trouvé.
                    }
                }
            }
        }

        public override void Delete()
        {
            if (m_InstancesList != null)
                m_InstancesList.Remove(this);

            base.Delete();
        }

        public InstitutionHandler(Serial serial)
            : base(serial)
        {
        }
        #endregion

        #region Serialize / Deserialize
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_Mobiles.Count);
            foreach (KeyValuePair<Mobile, int> pair in m_Mobiles)
            {
                writer.Write(pair.Key);
                writer.Write(pair.Value);
            }

            writer.Write(m_RegisteredMobiles.Count);
            foreach (Mobile m in m_RegisteredMobiles)
            {
                writer.Write(m);
            }

            writer.Write(Titre);
            writer.Write(Description);

            writer.Write(Containers.Count);
            foreach (Container c in Containers)
            {
                writer.Write((Item)c);
            }

            writer.Write(RangTitre.Count);
            foreach (String s in RangTitre)
            {
                writer.Write(s);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            #region Tableaux
            if (m_Mobiles == null)
                m_Mobiles = new Dictionary<Mobile, int>();
            int count = reader.ReadInt();
            for (int i = 0; i < count; ++i)
            {
                Mobile key = reader.ReadMobile();
                int val = reader.ReadInt();

                m_Mobiles.Add(key, val);
            }

            if (m_RegisteredMobiles == null)
                m_RegisteredMobiles = new List<Mobile>();
            count = reader.ReadInt();
            for (int i = 0; i < count; ++i)
            {
                m_RegisteredMobiles.Add(reader.ReadMobile());
            }

            Titre = reader.ReadString();
            Description = reader.ReadString();

            if (Containers == null)
                Containers = new List<Container>();
            count = reader.ReadInt();
            for (int i = 0; i < count; ++i)
            {
                Containers.Add((Container)reader.ReadItem());
            }

            if (RangTitre == null)
                RangTitre = new List<String>();
            count = reader.ReadInt();
            for (int i = 0; i < count; ++i)
            {
                RangTitre.Add(reader.ReadString());
            }
            #endregion

            if (m_InstancesList == null)
                m_InstancesList = new ArrayList();
            m_InstancesList.Add(this);
        }
        #endregion
    }
}
