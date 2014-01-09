using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Server.Items;
using Server.Network;

namespace Server.Systemes.Geopolitique
{
    /* Plan: 
     *  - Gump pour ajouter des fonds et des employes (accessible par les gms)
     *  - Gump pour gerer son argent et le retirer
     *  - Gump pour la geopol
     *  - - Ajouter une tresorerie qui recoit des fonds automatiquement 
     *  - - Set up du owner
     *  - - Batisseurs peuvent retirer des fonds pour une construction
     *  - - Log pour les modifications faites.
     *  S'assurer que les joueurs ne voient que les noms qu'ils connaissent.
     */

    public class Tresorier : Mobile
    {
        
        private Mobile m_Gestionnaire; // Joueur qui controle la tresorerie
        private Terre m_Terre; // null si pas lie a une terre 
        private string m_Etablissement; // Nom de la tresorerie
        private string m_Description; // Description dans le menu geopol
        private int m_Fonds; // Total des fonds accumules
        
        private Dictionary<Mobile, Employe> m_Employes; //Liste d'employes a payer
        private Timer m_Paiement; // Timer pour effectuer un paiement


        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Gestionnaire { get { return m_Gestionnaire; } set { m_Gestionnaire = value; } }
        public Terre Terre { get { return m_Terre; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public string Etablissement { get { return m_Etablissement; } set { m_Etablissement = value; } }
        [CommandProperty(AccessLevel.GameMaster)]
        public string Description { get { return m_Description; } set { m_Description = value; } }
        [CommandProperty(AccessLevel.GameMaster, true)]
        public int Fonds
        {
            get
            {
                if (m_Terre == null)
                    return m_Fonds;
                return m_Terre.Fonds;
            }
            set
            {
                if (m_Terre == null)
                    m_Fonds = value;
                else
                    m_Terre.Fonds = value;
            }
        }
        
        [CommandProperty(AccessLevel.GameMaster, true)]
        public Dictionary<Mobile, Employe> Employes { get { return m_Employes; } set { m_Employes = value; } }

        public Tresorier(string description, Terre terre)
        {
            m_Description = description;
            m_Terre = terre;
            m_Fonds = 0;
            m_Etablissement = "";
            m_Employes = new Dictionary<Mobile, Employe>();
        }

        public Tresorier(string etablissement, Mobile gestionnaire)
        {
            m_Etablissement = etablissement;
            m_Gestionnaire = gestionnaire;
            m_Fonds = 0;
            m_Employes = new Dictionary<Mobile, Employe>();
        }

        public void AddEmploye(Mobile employe, string titre, int paie)
        {
            Employe e;
            if (m_Employes.TryGetValue(employe, out e))
            {
                e.Paie = paie;
                e.Titre = titre;
                e.Removed = false;
            }
            else
            {
                m_Employes.Add(employe, new Employe(employe, titre, paie));
            }
        }

        public void RemoveEmploye(Mobile employe)
        {
            Employe e;
            if (!m_Employes.TryGetValue(employe, out e))
                return;
            if (e.Total > 0)
                e.Removed = true;
            else
                m_Employes.Remove(employe);
        }

        public void OnPaiementEvent(object source, ElapsedEventArgs e)
        {
            foreach (Employe employe in m_Employes.Values)
            {
                if (employe.Nom.Deleted)
                {
                    Fonds += employe.Total; // Si le perso a ete delete, l'etablissement reprend l'argent non reclame
                    employe.Total = 0;
                    RemoveEmploye(employe.Nom);
                    continue;
                }
                if (Fonds < employe.Paie)
                {
                    //Ajouter message pour employe et gestionnaire indiquant l'absence de fonds pour le paiement
                    continue;
                }
                if (employe.Removed)
                    continue;
                employe.Total += employe.Paie;
                Fonds -= employe.Paie;
            }
        }

        public void RetraitEmploye(Mobile employe, int montant)
        {
            Employe e;
            if (!m_Employes.TryGetValue(employe, out e))
                return;
            if (e.Total < montant)
            {
                PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, 
                    Etablissement + " ne vous doit que " + e.Total + ".", employe.NetState);
                return;
            }
            if (montant < 5000)
            { // Va peut-etre failer si le sac ne peut contenir un tel poids.
                employe.Backpack.DropItem(new Gold(montant));
            }
            else
            {
                employe.Backpack.DropItem(new BankCheck(montant));
            }
            e.Total -= montant;

            if (e.Removed && (e.Total == 0))
                RemoveEmploye(employe);
                
        }

        public void AjoutFonds(Mobile from, int montant)
        {
            Gold[] gold;
            BankCheck[] checks;

            gold = (Gold[]) from.Backpack.FindItemsByType(typeof(Gold));
            checks = (BankCheck[]) from.Backpack.FindItemsByType(typeof(BankCheck));

            int totalJoueur = 0;
            for (int i = 0; i < checks.Length; i++)
            {
                totalJoueur += checks[i].Worth;
                if (totalJoueur >= montant)
                {
                    int reste = totalJoueur - montant;
                    if (reste == 0) {}
                    else if (reste < 5000)
                    {
                        from.Backpack.DropItem(new Gold(reste));
                    }
                    else
                    {
                        from.Backpack.DropItem(new BankCheck(reste));
                    }
                    Fonds += montant;
                    for (int j = 0; j < i; j++)
                    {
                        checks[j].Delete();
                    }
                    PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, 
                        "Vous avez ajouté " + montant + " aux fonds.", from.NetState);
                    return;
                }
            }
            for (int i = 0; i < gold.Length; i++)
            {
                totalJoueur += gold[i].Amount;
                if (totalJoueur >= montant)
                {
                    int reste = totalJoueur - montant;
                    if (reste == 0) { }
                    else
                    {
                        from.Backpack.DropItem(new Gold(reste));
                    }
                    for (int j = 0; j < checks.Length; j++)
                    {
                        checks[j].Delete();
                    }
                    for (int j = 0; j < i; j++)
                    {
                        gold[j].Delete();
                    }
                    PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, 
                        "Vous avez ajouté " + montant + " aux fonds.", from.NetState);
                    return;
                }
            }
            PrivateOverheadMessage(MessageType.Regular, 0x3B2, false, 
                "Vous n'avez pas " + montant + "pièces sur vous.", from.NetState);   
        }

        
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            writer.Write((Mobile)m_Gestionnaire);
            writer.Write((string)m_Etablissement);
            writer.Write((string)m_Description);
            writer.Write((int)m_Fonds);
            
            writer.Write((int)m_Employes.Count);
            foreach (Employe e in m_Employes.Values)
            {
                e.Serialize(writer);
            }
            
            //new Timer(
            //m_Paiement.
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Gestionnaire = reader.ReadMobile();
            m_Etablissement = reader.ReadString();
            m_Description = reader.ReadString();
            m_Fonds = reader.ReadInt();
            
            int count = reader.ReadInt();
            m_Employes = new Dictionary<Mobile, Employe>();
            for (int i = 0; i < count; i++)
            {
                Employe e = new Employe(reader);
                m_Employes.Add(e.Nom, e);
            }
        }
    }
}
