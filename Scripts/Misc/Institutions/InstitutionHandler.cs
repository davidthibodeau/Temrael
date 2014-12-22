using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using Server.Commands;

namespace Server.Items
{

    class InstitutionHandler : TownCrier
    {
        #region Membres / Consts
        private static ArrayList m_InstancesList;

        private Dictionary<Mobile, int> m_Mobiles;  // Mobile --- Rang.
        private List<Mobile> m_RegisteredMobiles;   // Contient tous ceux qui ont déjà joint cette institution. (Empêche l'abus du rang 1)

        public const int NBRANK = 4;
        public List<Container> m_Containers;    // Contient les containers à duper lors du rankup.
        public List<String> m_RangTitre;        // Contient les titres des différents échelons.
        private readonly int[] m_RangSalaire =  // Contient les salaires des différents échelons.
        {
            250,
            500,
            1000,
            1500
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
                                if (!Paie.Contains(pair))
                                {
                                    Paie.Add(pair.Key, pair.Value);
                                }
                                else
                                {
                                    Paie[pair.Key] = Math.Max(Paie[pair.Key], pair.Value);
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
                    }
                }
            }
        }
        #endregion

        #region Methodes

        #region Get
        /// <summary>
        /// Trouve le titre lié au rang passé en paramètre.
        /// </summary>
        /// <param name="rank">Le rang, doit être entre 1 et 5 [].</param>
        /// <returns>Une string contenant le titre lié au rang.</returns>
        public String GetTitre(int rank)
        {
            try
            {
                return m_RangTitre[rank];
            }
            catch (Exception)
            {
            }
            return "NON INITIALISÉ";
        }

        /// <summary>
        /// Trouve le salaire lié au rang passé en paramètre.
        /// </summary>
        /// <param name="rank">Le rang, doit être entre 1 et 5 [].</param>
        /// <returns>Une string contenant le salaire lié au rang.</returns>
        public int GetSalaire(int rank)
        {
            try
            {
                return m_RangSalaire[rank];
            }
            catch (Exception)
            {
            }
            return 0;
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
                if (!m_RegisteredMobiles.Contains(m))
                {
                    m_RegisteredMobiles.Add(m);
                }

                if (!m_Mobiles.ContainsKey(m))
                {
                    m_Mobiles.Add(m, 0); // Rang 0 par défaut, augmenté à 1 juste après pour dropper l'item lié au rang.
                    RankUp(m);
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
                if (m_Mobiles[m] < NBRANK)
                {
                    m_Mobiles[m]++;
                    if (!(m_RegisteredMobiles.Contains(m) && (m_Mobiles[m]-1) == 1)) // Si l'ancien rang == 1.
                    {
                        if (m_Containers[m_Mobiles[m]] != null)
                        {
                            m.AddToBackpack(Dupe.DupeItem(null, m_Containers[m_Mobiles[m]], true)); // On dupe le container lié au rang du mobile.
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
                if (m_Mobiles[m] > 1)
                {
                    m_Mobiles[m]--;
                }
            }
        }
        #endregion

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
            m_RangTitre = new List<String>();
            m_Containers = new List<Container>();
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

            writer.Write(m_Containers.Count);
            foreach (Container c in m_Containers)
            {
                writer.Write((Item)c);
            }

            writer.Write(m_RangTitre.Count);
            foreach (String s in m_RangTitre)
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

            if (m_Containers == null)
                m_Containers = new List<Container>();
            count = reader.ReadInt();
            for (int i = 0; i < count; ++i)
            {
                m_Containers.Add((Container)reader.ReadItem());
            }

            if (m_RangTitre == null)
                m_RangTitre = new List<String>();
            count = reader.ReadInt();
            for (int i = 0; i < count; ++i)
            {
                m_RangTitre.Add(reader.ReadString());
            }
            #endregion

            if (m_InstancesList == null)
                m_InstancesList = new ArrayList();
            m_InstancesList.Add(this);
        }
        #endregion
    }
}
