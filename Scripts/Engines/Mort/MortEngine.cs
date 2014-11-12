using Server.Items;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Mort
{

    [PropertyObject]
    public class MortEngine
    {
        private PlayerMobile mobile;

        public List<ContratAssassinat> m_contratListe = new List<ContratAssassinat>();
        private Container m_Corps;
        private bool m_RisqueDeMort;
        private Timer m_TimerEvanouie;
        private Timer m_TimerMort;
        private Point3D m_EndroitMort;
        private bool m_Mort;
        private MortState m_MortState;
        private MortEvo m_MortEvo;
        private bool m_Achever = false;
        
        private bool m_Suicide;
        private DateTime m_AmeLastFed;
        private bool m_MortVivant;

        private Timer m_MortVivantTimer;
        private DateTime m_lastAchever;
        private DateTime m_lastAssassinat;


        public Container Corps
        {
            get { return m_Corps; }
            set { m_Corps = value; }
        }

        public List<ContratAssassinat> ContratListe
        {
            get { return m_contratListe; }
            set { m_contratListe = value; }
        }

        //[CommandProperty(AccessLevel.GameMaster)]
        public bool RisqueDeMort
        {
            get { return m_RisqueDeMort; }
            set { m_RisqueDeMort = value; }
        }

        public Timer TimerEvanouie
        {
            get { return m_TimerEvanouie; }
            set { m_TimerEvanouie = value; }
        }

        public Timer TimerMort
        {
            get { return m_TimerMort; }
            set { m_TimerMort = value; }
        }

        public Point3D EndroitMort
        {
            get { return m_EndroitMort; }
            set { m_EndroitMort = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool Mort
        {
            get { return m_Mort; }
            set { m_Mort = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool MortVivant
        {
            get { return m_MortVivant; }
            set { m_MortVivant = value; }
        }

        [CommandProperty(AccessLevel.Coordinateur)]
        public MortState MortCurrentState
        {
            get { return m_MortState; }
            set { m_MortState = value; }
        }

        [CommandProperty(AccessLevel.Coordinateur)]
        public MortEvo MortEvo
        {
            get { return m_MortEvo; }
            set { m_MortEvo = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool Suicide
        {
            get { return m_Suicide; }
            set { m_Suicide = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime AmeLastFed
        {
            get { return m_AmeLastFed; }
            set { m_AmeLastFed = value; }
        }

        public Timer MortVivantTimer
        {
            get { return m_MortVivantTimer; }
            set { m_MortVivantTimer = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime LastAchever
        {
            get { return m_lastAchever; }
            set { m_lastAchever = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime LastAssassinat
        {
            get { return m_lastAssassinat; }
            set { m_lastAssassinat = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool Achever { get { return m_Achever; } set { m_Achever = value; } }

        public void OnDeath(Container c)
        {
            if (m_TimerEvanouie != null)
            {
                m_TimerEvanouie.Stop();
                m_TimerEvanouie = null;
            }

            if (m_TimerMort != null)
            {
                m_TimerMort.Stop();
                m_TimerMort = null;
            }

            m_EndroitMort = mobile.Location;

            if (m_Suicide && mobile.Region.Name != "Jail")
                m_RisqueDeMort = true;
        }

        public void OnAmeEating()
        {
            m_AmeLastFed = DateTime.Now;
            if ((m_MortEvo == MortEvo.Decomposition) || (m_MortEvo == MortEvo.Zombie) || (m_MortEvo == MortEvo.Squelette))
            {
                m_MortEvo = MortEvo.Aucune;

                if (mobile.FindItemOnLayer(Layer.Shirt) is MortRaceGump)
                {
                    mobile.FindItemOnLayer(Layer.Shirt).Delete();
                }
            }
        }

        public override string ToString()
        {
            return "...";
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(m_Achever);
            writer.Write(m_Suicide);
            writer.Write((DateTime)m_lastAchever);
            writer.Write((DateTime)m_lastAssassinat);

            writer.Write((Container)m_Corps);
            writer.Write(m_RisqueDeMort);
            writer.Write(m_EndroitMort);
            writer.Write(m_Mort);

            writer.Write((int)m_MortState);
            writer.Write((int)m_MortEvo);

            writer.Write((DateTime)m_AmeLastFed);
            writer.Write((bool)m_MortVivant);
        }

        public MortEngine(PlayerMobile m)
        {
            mobile = m;
            m_contratListe = new List<ContratAssassinat>();
        }

        public MortEngine(PlayerMobile m, GenericReader reader)
        {
            mobile = m;
            m_Achever = reader.ReadBool();
            m_Suicide = reader.ReadBool();
            m_lastAchever = reader.ReadDateTime();
            m_lastAssassinat = reader.ReadDateTime();
            m_Corps = (Container)reader.ReadItem();
            m_RisqueDeMort = reader.ReadBool();
            m_EndroitMort = reader.ReadPoint3D();
            m_Mort = reader.ReadBool();

            m_MortState = (MortState)reader.ReadInt();
            m_MortEvo = (MortEvo)reader.ReadInt();

            m_AmeLastFed = reader.ReadDateTime();
            m_MortVivant = reader.ReadBool();

            if (!mobile.Alive && !m_Mort)
            {
                m_RisqueDeMort = false;

                EvanouieTimer timer = new EvanouieTimer(mobile, m_Corps, (int)mobile.Direction, this.RisqueDeMort);
                m_TimerEvanouie = timer;
                timer.Start();
            }

            if (m_RisqueDeMort)
            {
                RisqueDeMortTimer timer = new RisqueDeMortTimer(mobile);
                m_TimerMort = timer;
                timer.Start();
            }

            if (m_MortVivant)
            {
                MortVivantEvoTimer timer = new MortVivantEvoTimer(mobile);
                m_MortVivantTimer = timer;
                timer.Start();
            }
        }
    }
}
