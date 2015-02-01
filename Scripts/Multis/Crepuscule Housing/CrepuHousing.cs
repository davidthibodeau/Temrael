using System;
using Server;
using Server.Gumps;
using Server.Targeting;
using Server.Mobiles;
using Server.Prompts;
using Server.Engines;
using System.Collections;
using Server.Commandes.Temrael;
using System.Collections.Generic;

namespace Server.Items
{
    [Flipable(0x1ED4, 0x1ED7)]
    public class BoiteAuLettreComponent : AddonComponent
    {
        private static ArrayList m_InstancesList;

        private bool m_Commerce = false;
        private bool m_Owned = false;
        private bool m_ShowOwnerName = false;

        private string m_OwnerName = "A vendre";
        private Mobile m_Proprio = null;
        private Mobile[] m_CoProprio = new Mobile[] { null, null, null };

        private BaseDoor m_Door1 = null;
        private BaseDoor m_Door2 = null;

        private int m_Price = 1000;

        private Point3D m_Point1;
        private Point3D m_Point2;
        private Container m_Container;
        private Point3D m_BootLocation;

        #region Propriétés
        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile[] CoProprio
        {
            get { return m_CoProprio; }
            set { m_CoProprio = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public string NomProprio
        {
            get { return m_OwnerName != null ? m_OwnerName.Replace("\"", "") : ""; }
            set { m_OwnerName = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public BaseDoor Porte1
        {
            get { return m_Door1; }
            set { m_Door1 = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public BaseDoor Porte2
        {
            get { return m_Door2; }
            set { m_Door2 = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int PrixLocation
        {
            get { return m_Price; }
            set { m_Price = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool MontrerProprio
        {
            get { return m_ShowOwnerName; }
            set { m_ShowOwnerName = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Mobile Proprio
        {
            get { return m_Proprio; }
            set { if (m_Proprio == null) NomProprio = "A vendre"; m_Proprio = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool IsCommerce
        {
            get { return m_Commerce; }
            set { m_Commerce = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Point3D RegionPoint1
        {
            get { return m_Point1; }
            set { m_Point1 = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Point3D RegionPoint2
        {
            get { return m_Point2; }
            set { m_Point2 = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Container DumpContainer
        {
            get { return m_Container; }
            set { m_Container = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public Point3D BootLocation
        {
            get { return m_BootLocation; }
            set { m_BootLocation = value; }
        }
        #endregion

        public BoiteAuLettreComponent(int dir)
            : base(0x1ED4)
        {
            if (dir == 1)
                ItemID = 0x1ED7;
            Name = "Batiment";

            Proprio = null;

            if (m_InstancesList == null)
                m_InstancesList = new ArrayList();

            m_InstancesList.Add(this);
        }

        public override void Delete()
        {
            if (m_InstancesList != null)
                m_InstancesList.Remove(this);

            base.Delete();
        }

        public BoiteAuLettreComponent(Serial serial)
            : base(serial)
        {
            Proprio = null;
        }

        // Enlève le montant d'or à payer pour la location au propriétaire, et leur enlève la maison si ils n'ont pas l'or.
        public static void WeeklyPay()
        {
            if (m_InstancesList != null)
            {
                if (m_InstancesList.Count > 0)
                {
                    foreach (BoiteAuLettreComponent item in m_InstancesList)
                    {
                        if (item != null && item.m_Owned && item.m_Proprio != null)
                        {
                            if (!Banker.Withdraw(item.m_Proprio, item.PrixLocation))
                            {
                                item.m_Proprio.SendMessage("Vous n'avez pas assez d'argent sur votre compte, votre maison a été mise en vente !");
                                item.Disown();
                            }
                            else
                            {
                                item.m_Proprio.SendMessage("Un paiement de " + item.PrixLocation + " a été fait pour votre maison.");
                            }
                        }
                    }
                }
            }
        }

        public void Louer(Mobile from)
        {
            if (!Banker.Withdraw(from, this.PrixLocation))
                from.SendMessage("Vous n'avez pas assez d'argent sur votre compte.");
            else
            {
                from.SendMessage("Vous louez le batiment.");
                Proprio = from;
                m_Owned = true;
                from.SendMessage("Sous quel nom voulez-vous l'enregistrer ?");
                from.Prompt = new OwnerNamePrompt(this);

                GenerateKey.GenerateNewKey(from, Porte1, 1);
                GenerateKey.GenerateNewKey(from, Porte2, 1);
            }
        }

        public void Disown()
        {
            if (Proprio != null)
            {
                Proprio.SendMessage("Vous ne possédez plus votre maison.");

                foreach (Mobile m in CoProprio)
                    if (m != null)
                        m.SendMessage("Vous ne possédez plus votre maison.");

                if (Porte1 != null)
                {
                    Porte1.KeyValue = 0;
                    Porte1.Locked = true;
                }
                if (Porte2 != null)
                {
                    Porte2.KeyValue = 0;
                    Porte2.Locked = true;
                }

                DumpItems();

                BootMobiles();

                Proprio = null;
                CoProprio = new Mobile[] { null, null, null };
                m_Owned = false;
            }
        }
        // Deux sous fonctions qui permettent de vider la zone de location, lorsque le proprio perd la maison.
        private void DumpItems()
        {
            if (m_Container != null)
            {
                WoodenBox b = new WoodenBox();
                b.MaxItems = int.MaxValue;
                b.Name = m_OwnerName;

                List<Item> toMove = new List<Item>();
                Rectangle2D rect = new Rectangle2D(RegionPoint1, RegionPoint2);
                IPooledEnumerable<Item> list = Map.Felucca.GetItemsInBounds(rect);

                foreach (Item i in list)
                {
                    if (i != null && !(i is BaseDoor))
                    {
                        toMove.Add(i);
                    }
                }
                list.Free();

                for (int i = 0; i < toMove.Count; ++i)
                {
                    b.DropItem(toMove[i]);
                    b.Movable = true;
                }

                // Seulement ouvrable par le owner, qui obtient une nouvelle clef à chaque fois.
                GenerateKey.GenerateNewKey(m_Proprio, b, 1);
                b.Locked = true;

                // Ajout de la boite lockée dans le container lié à la maison.
                m_Container.DropItem(b);
                b.CanBeAltered = false;
                b.Movable = false;
            }
        }
        private void BootMobiles()
        {
            if (m_BootLocation.X != 0 && m_BootLocation.Y != 0)
            {
                List<Mobile> toBoot = new List<Mobile>();

                Rectangle2D rect = new Rectangle2D(RegionPoint1, RegionPoint2);

                // Ajout des joueurs déconnectés à la liste de boot.
                Region regionDC = new Region("Loc", Map.Felucca, 0, rect);
                foreach (Mobile m in World.Mobiles.Values)
                {
                    if (m != null)
                    {
                        if (regionDC.Contains(m.LogoutLocation) && !m.IsConnected)
                        {
                            toBoot.Add(m);
                        }
                    }
                }

                // Ajout des joueurs connectés à la liste de boot.
                IPooledEnumerable<Mobile> list = Map.Felucca.GetMobilesInBounds(rect);
                foreach (Mobile m in list)
                {
                    if (m != null && !toBoot.Contains(m)) // Better be safe than sorry.
                    {
                        toBoot.Add(m);
                    }
                }
                list.Free();

                // Application du boot.
                for (int i = 0; i < toBoot.Count; ++i)
                {
                    Mobile m = toBoot[i];

                    m.Location = m_BootLocation;
                    m.LogoutLocation = m_BootLocation;
                }
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.CloseGump(typeof(InternalGump));
            from.SendGump(new InternalGump(from, this));
        }

        public void AddCoproprio(Mobile target, Mobile from)
        {
            for (int i = 0; i < CoProprio.Length; i++)
            {
                if (CoProprio[i] == null)
                {
                    CoProprio[i] = (Mobile)target;
                    return;
                }
            }
        }

        #region Serialize/Deserialize
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            for (int i = 0; i < CoProprio.Length; i++)
                writer.Write((Mobile)CoProprio[i]);
            writer.Write((string)m_OwnerName);
            writer.Write((int)m_Price);
            writer.Write((BaseDoor)m_Door2);
            writer.Write((BaseDoor)m_Door1);
            writer.Write((Mobile)m_Proprio);
            writer.Write((bool)m_Owned);
            writer.Write((bool)m_Commerce);
            writer.Write((bool)m_ShowOwnerName);

            writer.Write(m_Point1);
            writer.Write(m_Point2);
            writer.Write(m_Container);
            writer.Write(m_BootLocation);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            for (int i = 0; i < CoProprio.Length; i++)
                CoProprio[i] = reader.ReadMobile();
            m_OwnerName = reader.ReadString();
            m_Price = reader.ReadInt();
            m_Door2 = (BaseDoor)reader.ReadItem();
            m_Door1 = (BaseDoor)reader.ReadItem();
            m_Proprio = reader.ReadMobile();
            m_Owned = reader.ReadBool();
            m_Commerce = reader.ReadBool();
            m_ShowOwnerName = reader.ReadBool();

            if (version == 1)
            {
                m_Point1 = reader.ReadPoint3D();
                m_Point2 = reader.ReadPoint3D();
                m_Container = (LockableContainer)reader.ReadItem();
                m_BootLocation = reader.ReadPoint3D();
            }

            if (m_InstancesList == null)
                m_InstancesList = new ArrayList();

            m_InstancesList.Add(this); // Permettrait d'ajouter les items existants à la Deserialization à la place de saver les instances... ça fonctionnerait ?
        }
        #endregion
    }

    public class OwnerNamePrompt : Prompt
    {
        private BoiteAuLettreComponent m_Boite;

        public OwnerNamePrompt(BoiteAuLettreComponent boite)
        {
            m_Boite = boite;
        }

        public override void OnCancel(Mobile from)
        {
            from.SendMessage("Le nom du proprietaire n'a pas ete change.");
        }

        public override void OnResponse(Mobile from, string text)
        {
            string oldowner = m_Boite.NomProprio;
            m_Boite.NomProprio = Utility.FixHtml(text);
        }
    }

    ////////////////////////////
    // Gump Boite aux lettres //  
    ////////////////////////////
    public class InternalGump : Gump
    {
        Mobile m_from;
        BoiteAuLettreComponent m_item;

        public void AddButtonLabeled(int x, int y, int buttonID, string text)
        {
            AddButton(x, y - 1, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
            AddHtml(x + 35, y, 240, 20, "" + text + "", false, false);
        }
        public void AddButtonLabeledDel(int x, int y, int buttonID, string text)
        {
            AddButton(x, y - 1, 4017, 4019, buttonID, GumpButtonType.Reply, 0);
            AddHtml(x + 35, y, 240, 20, "" + text + "", false, false);
        }

        public InternalGump(Mobile from, BoiteAuLettreComponent item)
            : base(100, 100)
        {
            m_from = from;
            m_item = item;

            int upmargin = 90, num = 0;

            PlayerMobile rpm = (PlayerMobile)from;

            AddBackground(55, 60, 260, 320, 9200);
            AddLabel(120, 70, 0x26, "Gestion de la maison");

            AddLabel(80, upmargin + num * 20, 0x00, string.Format("Prix : {0}", item.PrixLocation)); num++;

            if (m_item.Proprio == null)
            {
                AddButtonLabeled(80, upmargin + num * 20, 1, "Acheter la maison"); num++;
            }
            else if (item.MontrerProprio )
            {
                AddLabel(80, upmargin + num * 20, 0x00, string.Format("Proprietaire : {0}", item.NomProprio)); num++;
                if (m_from == item.Proprio)
                {
                    AddButtonLabeled(80, upmargin + num * 20, 2, "Cacher votre nom"); num++;
                }
            }

            if (m_item.Proprio == from )
            {
                AddButtonLabeled(80, upmargin + num * 20, 3, "Changer votre nom"); num++;
            }

            num++;

            if (m_from == m_item.Proprio || m_from.AccessLevel > AccessLevel.Player || m_from == m_item.CoProprio[0] || m_from == m_item.CoProprio[1] || m_from == m_item.CoProprio[2])
            {
                if (m_item.Proprio == m_from)
                {
                    AddButtonLabeled(80, upmargin + num * 20, 4, "Ajouter Coproprietaire"); num++;
                }

                num++;

                for (int i = 0; i < 3; ++i)
                {
                    AddImageTiled(80, upmargin + num * 20, 182, 23, 0x52);
                    AddImageTiled(81, upmargin + num * 20 + 1, 180, 21, 0xBBC);
                    if (m_item.CoProprio[i] != null)
                    {
                        AddLabelCropped(91, upmargin + num * 20 + 1, 180, 21, 0, m_item.CoProprio[i].GetNameUsedBy(rpm)); // rpm.FindName(m_item.CoProprio[i].Serial.Value));
                        if (m_item.Proprio == m_from)
                            AddButtonLabeledDel(270, upmargin + num * 20, 5 + i, "");
                    }
                    num++;
                }

                num++;
                if (m_item.Proprio == m_from)
                    AddButtonLabeled(80, upmargin + num * 20, 8, "Transferer la propriete");

                num++;
                if (m_item.Proprio == m_from)
                    AddButtonLabeled(80, upmargin + num * 20, 9, "Créer une clef : porte 1.");

                num++;
                if (m_item.Proprio == m_from)
                    AddButtonLabeled(80, upmargin + num * 20, 10, "Créer une clef : porte 2.");

                num++;
                num++;
                if (m_item.Proprio == m_from)
                    AddButtonLabeled(80, upmargin + num * 20, 11, "Cesser de payer.");
            }
        }

        public override void OnResponse(Server.Network.NetState sender, RelayInfo info)
        {
            int val = info.ButtonID;

            switch (val)
            {
                default: break;
                case 1:
                    {
                        m_item.Louer(m_from);
                        break;
                    }
                case 2:
                    {
                        m_item.MontrerProprio = !m_item.MontrerProprio;
                        break;
                    }
                case 3:
                    {
                        m_from.SendMessage("Sous quel nom voulez-vous enregistrer le batiment ?");
                        m_from.Prompt = new OwnerNamePrompt(m_item);
                        break;
                    }
                case 4:
                    {
                        m_from.Target = new AddTargetCoproprio(m_item);
                        m_from.SendMessage("Qui desirez vous ajouter comme coproprietaire?");
                        break;
                    }
                case 5:
                    {
                        m_item.CoProprio[0] = null;
                        break;
                    }
                case 6:
                    {
                        m_item.CoProprio[1] = null;
                        break;
                    }
                case 7:
                    {
                        m_item.CoProprio[2] = null;
                        break;
                    }
                case 8:
                    {
                        m_from.Target = new AddTargetChangeProprio(m_item);
                        m_from.SendMessage("A qui voulez vous transferer la maison?");
                        break;
                    }
                case 9:
                    {
                        if (m_item.Porte1 != null)
                        {
                            if (!GenerateKey.GenerateKeyFor(m_from, m_item.Porte1, 1))
                            {
                                GenerateKey.GenerateNewKey(m_from, m_item.Porte1, 1);
                            }
                        }

                        break;
                    }
                case 10:
                    {
                        if (m_item.Porte2 != null)
                        {
                            if (! GenerateKey.GenerateKeyFor(m_from, m_item.Porte2, 1))
                            {
                                GenerateKey.GenerateNewKey(m_from, m_item.Porte2, 1);
                            }
                        }

                        break;
                    }
                case 11:
                    {
                        m_item.Disown();

                        break;
                    }
            }
        }
    }

    public class AddTargetCoproprio : Target
    {
        BoiteAuLettreComponent m_item;

        public AddTargetCoproprio(BoiteAuLettreComponent item)
            : base(3, false, TargetFlags.None)
        {
            m_item = item;
        }

        protected override void OnTarget(Mobile from, object targ)
        {
            if (targ is PlayerMobile)
            {
                Mobile target = (Mobile)targ;
                m_item.AddCoproprio(target, from);
            }
        }
    }

    public class AddTargetChangeProprio : Target
    {
        BoiteAuLettreComponent m_item;

        public AddTargetChangeProprio(BoiteAuLettreComponent item)
            : base(3, false, TargetFlags.None)
        {
            m_item = item;
        }

        protected override void OnTarget(Mobile from, object targ)
        {
            if (targ is PlayerMobile)
            {
                Mobile target = (Mobile)targ;
                m_item.Proprio = target;
                target.Prompt = new OwnerNamePrompt(m_item);
            }
        }
    }

    public class BoiteAuLettreAddon : BaseAddon
    {
        public int m_dir;

        [Constructable]
        public BoiteAuLettreAddon(int dir)
        {
            AddComponent(new BoiteAuLettreComponent(dir), 0, 0, 0);
            Name = "Boite aux lettres";
        }

        public BoiteAuLettreAddon(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class GestionMaisonSudDeed : BaseAddonDeed
    {

        public override BaseAddon Addon { get { return new BoiteAuLettreAddon(0); } }

        [Constructable]
        public GestionMaisonSudDeed()
        {
            Name = "Boite aux lettres Sud";
        }

        public GestionMaisonSudDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class GestionMaisonEstDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new BoiteAuLettreAddon(1); } }

        [Constructable]
        public GestionMaisonEstDeed()
        {
            Name = "Boite aux lettres Est";
        }

        public GestionMaisonEstDeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}