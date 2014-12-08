using System;
using Server;
using Server.Gumps;
using Server.Targeting;
using Server.Mobiles;
using Server.Prompts;
using Server.Engines;
using System.Collections;
using Server.Commandes.Temrael;

namespace Server.Items
{
    [Flipable(0x1ED4, 0x1ED7)]
    public class BoiteAuLettreComponent : AddonComponent
    {
        private static ArrayList m_InstancesList;

        private bool m_Commerce = false,
                     owned = false,
                     m_ShowOwnerName = false;
        private Mobile owner = null;
        private BaseDoor m_Doors1 = null,
                         m_Doors2 = null;
        private string m_OwnerName = "A vendre";
        private int m_SellPrice = 1000;

        private Mobile[] m_CoProprio = new Mobile[]
                        {
                          null,
                          null,
                          null
                        };

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
            get { return m_Doors1; }
            set { m_Doors1 = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public BaseDoor Porte2
        {
            get { return m_Doors2; }
            set { m_Doors2 = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int PrixVente
        {
            get { return m_SellPrice; }
            set { m_SellPrice = value; }
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
            get { return owner; }
            set { if (owner == null) NomProprio = "A vendre"; owner = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public bool IsCommerce
        {
            get { return m_Commerce; }
            set { m_Commerce = value; }
        }

        public BoiteAuLettreComponent(int dir)
            : base(0x1ED4)
        {
            if (dir == 1)
                ItemID = 0x1ED7;
            SetName();
            Proprio = null;
            m_InstancesList.Add(this);
        }

        public override void Delete()
        {
            m_InstancesList.Remove(this);
            base.Delete();
        }

        private void SetName()
        {
            Name = "Batiment";
        }

        public BoiteAuLettreComponent(Serial serial)
            : base(serial)
        {
            Proprio = null;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            for (int i = 0; i < CoProprio.Length; i++)
                writer.Write((Mobile)CoProprio[i]);
            writer.Write((string)m_OwnerName);
            writer.Write((int)m_SellPrice);
            writer.Write((BaseDoor)m_Doors2);
            writer.Write((BaseDoor)m_Doors1);
            writer.Write((Mobile)owner);
            writer.Write((bool)owned);
            writer.Write((bool)m_Commerce);
            writer.Write((bool)m_ShowOwnerName);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            for (int i = 0; i < CoProprio.Length; i++)
                CoProprio[i] = reader.ReadMobile();
            m_OwnerName = reader.ReadString();
            m_SellPrice = reader.ReadInt();
            m_Doors2 = (BaseDoor)reader.ReadItem();
            m_Doors1 = (BaseDoor)reader.ReadItem();
            owner = reader.ReadMobile();
            owned = reader.ReadBool();
            m_Commerce = reader.ReadBool();
            m_ShowOwnerName = reader.ReadBool();

            m_InstancesList.Add(this); // Permettrait d'ajouter les items existants à la Deserialization à la place de saver les instances... ça fonctionnerait ?
        }

        public void Acheter(Mobile from)
        {
            if (from is PlayerMobile)
            {
                PlayerMobile rpm = (PlayerMobile)from;
                if (!Banker.Withdraw(from, this.PrixVente))
                    from.SendMessage("Vous n'avez pas assez d'argent sur votre compte.");
                else
                {
                    from.SendMessage("Vous avez acheté le batiment.");
                    Proprio = from;
                    owned = true;
                    from.SendMessage("Sous quel nom voulez-vous l'enregistrer ?");
                    from.Prompt = new OwnerNamePrompt(this);
                }
            }
        }

        public void Disown()
        {
            if (Proprio != null)
                Proprio.SendMessage("Vous ne possédez plus votre maison.");

            foreach(Mobile m in CoProprio)
                if (m != null)
                    m.SendMessage("Vous ne possédez plus votre maison.");

            Proprio = null;
            CoProprio = new Mobile[] { null, null, null };
            owned = false;

            Porte1.KeyValue = 0;
            Porte2.KeyValue = 0;

            Porte1.Locked = true;
            Porte2.Locked = true;
        }

        public static void WeeklyPay()
        {
            foreach(BoiteAuLettreComponent item in m_InstancesList)
            {
                if (item != null)
                {
                    if (!Banker.Withdraw(item.owner, item.PrixVente))
                    {
                        item.owner.SendMessage("Vous n'avez pas assez d'argent sur votre compte, votre maison a été mise en vente !");
                        item.Disown();
                    }
                    else
                    {
                        item.owner.SendMessage("Un paiement de " + item.PrixVente + " a été fait pour votre maison.");
                    }
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

            AddLabel(80, upmargin + num * 20, 0x00, string.Format("Prix : {0}", item.PrixVente)); num++;

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
                        AddLabelCropped(91, upmargin + num * 20 + 1, 180, 21, 0, m_item.CoProprio[i].GetNameUseBy(rpm)); // rpm.FindName(m_item.CoProprio[i].Serial.Value));
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
                        m_item.Acheter(m_from);
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