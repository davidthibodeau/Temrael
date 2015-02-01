using System;
using Server.Network;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;
using System.Collections.Generic;
using Server.Gumps;

namespace Server.Items
{
    public abstract class BaseTeinture : Item
    {
        public virtual int Couleur { get { return 0; } }

        public override void OnDoubleClick(Mobile from)
        {
            //base.OnDoubleClick(from);

            from.SendMessage("Choisissez un bac de colorant pour appliquer la teinture.");
            from.BeginTarget(1, false, TargetFlags.None, new TargetCallback(this.ChooseTarget_OnTarget));
        }

        public BaseTeinture(int itemID) : base(itemID)
        {
        }

        public BaseTeinture(Serial s)
            : base(s)
        {
        }

        public void ChooseTarget_OnTarget(Mobile from, object targeted)
        {
            if (targeted is BaseArmor)
            {
                ((BaseArmor)targeted).Hue = Couleur;
                from.SendMessage("Teinture appliquée.");
                this.Delete();
            }
            else if (targeted is BaseWeapon)
            {
                ((BaseWeapon)targeted).Hue = Couleur;
                from.SendMessage("Teinture appliquée.");
                this.Delete();
            }
            else if (targeted is DyeTub)
            {
                ((DyeTub)targeted).Hue = Couleur;
                from.SendMessage("Teinture appliquée.");
                this.Delete();
            }
            else
            {
                from.SendMessage("Ceci n'est pas un bac de teinture.");
            }
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            list.Add(new EchantillonnerEntry(from, Couleur));
        }

        private class EchantillonnerEntry : ContextMenuEntry
        {
            private int couleur;
            private Mobile m_from;

            public EchantillonnerEntry(Mobile from, int hue)
                : base(6258)
            {
                m_from = from;
                couleur = hue;
            }

            public override void OnClick()
            {
                m_from.SendMessage("Choisissez l'objet sur lequel vous désirez voir l'échantillon");
                m_from.Target = new InternalTarget(couleur);
            }
        }

        private class InternalTarget : Target
        {
            private int couleur;

            public InternalTarget(int hue)
                : base(1, false, TargetFlags.None)
            {
                couleur = hue;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                Item item = targeted as Item;
                if (item == null)
                {
                    from.SendMessage("Vous devez choisir un objet");
                    return;
                }

                from.SendGump(new EchantillonGump(item, couleur));
            }
        }

        private class EchantillonGump : Gump
        {
            public EchantillonGump(Item target, int hue)
                : base(50, 50)
            {
                AddBackground(0, 0, 550, 380, 5054);
                AddItem(20, 300, target.ItemID, hue);
                AddBackground(20, 20, 250, 250, 0xa3c);
                AddBackground(270, 20, 250, 250, 0xa3c);
                AddLabel(295, 305, 0, "Montrer l'échantillon à quelqu'un");
                AddButton(490, 304, 4005, 4007, 1, GumpButtonType.Reply, 0);
                if (target.ItemData.Animation > 0)
                {
                    AddImage(30, 30, 0xC);
                    AddImage(30, 30, target.ItemData.Animation + 50000, hue);
                    AddImage(280, 30, 0xD);
                    AddImage(280, 30, target.ItemData.Animation + 60000, hue);
                }
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (info.ButtonID == 1)
                {
                    sender.Mobile.Target = new MontrerTarget(this);
                }
            }
        }

        private class MontrerTarget : Target
        {
            EchantillonGump m_Gump;

            public MontrerTarget(EchantillonGump gump)
                : base(12, false, TargetFlags.None)
            {
                m_Gump = gump;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                Mobile to = targeted as Mobile;
                from.SendGump(m_Gump);

                if (to == null)
                {
                    from.SendMessage("Vous devez choisir un joueur");
                    return;
                }

                to.SendGump(m_Gump);
                to.SendMessage("{0} vous montre cet échantillon.", from.GetNameUsedBy(to));
            }
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
