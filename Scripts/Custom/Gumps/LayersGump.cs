using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Gumps
{
    class LayersGump : Gump
    {
        private Mobile m_From;

        public LayersGump(Mobile from) : base(0, 0)
        {
            m_From = from;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            //BG
            AddBackground(80, 72, 420, 397, 3600);
            AddBackground(90, 82, 400, 377, 9200);
            AddBackground(100, 92, 380, 350, 3500);

            //Dragons
            AddImage(39, 53, 10440);
            AddImage(459, 53, 10441);

            //Titre
            AddImage(125, 110, 95);
            AddImage(132, 119, 96);
            AddImage(268, 119, 96);
            AddImage(280, 119, 96);
            AddImage(455, 110, 97);

            AddHtml(260, 105, 200, 20, "<h1><basefont color=#025a>Layers<basefont></h1>", false, false);

            //Images
            AddButton(126, 130, 1209, 1210, 1, GumpButtonType.Reply, 0);
            AddHtml(150, 130, 200, 20, "<h3><basefont color=#5A4A31>Chausses<basefont></h3>", false, false);
            AddItem(223, 119, 5905);

            AddButton(126, 160, 1209, 1210, 2, GumpButtonType.Reply, 0);
            AddHtml(150, 160, 200, 20, "<h3><basefont color=#5A4A31>Pantalons<basefont></h3>", false, false);
            AddItem(223, 149, 10047);

            AddButton(126, 190, 1209, 1210, 3, GumpButtonType.Reply, 0);
            AddHtml(150, 190, 200, 20, "<h3><basefont color=#5A4A31>Torse<basefont></h3>", false, false);
            AddItem(223, 182, 10232);

            AddButton(126, 220, 1209, 1210, 4, GumpButtonType.Reply, 0);
            AddHtml(150, 220, 200, 20, "<h3><basefont color=#5A4A31>Tete<basefont></h3>", false, false);
            AddItem(223, 209, 10366);

            AddButton(126, 250, 1209, 1210, 5, GumpButtonType.Reply, 0);
            AddHtml(150, 250, 200, 20, "<h3><basefont color=#5A4A31>Mains<basefont></h3>", false, false);
            AddItem(223, 242, 5062);

            AddButton(126, 280, 1209, 1210, 6, GumpButtonType.Reply, 0);
            AddHtml(150, 280, 200, 20, "<h3><basefont color=#5A4A31>Bague<basefont></h3>", false, false);
            AddItem(223, 275, 4234);

            AddButton(126, 310, 1209, 1210, 7, GumpButtonType.Reply, 0);
            AddHtml(150, 310, 200, 20, "<h3><basefont color=#5A4A31>Talisman<basefont></h3>", false, false);
            AddItem(223, 296, 5219);

            AddButton(126, 340, 1209, 1210, 8, GumpButtonType.Reply, 0);
            AddHtml(150, 340, 200, 20, "<h3><basefont color=#5A4A31>Cou<basefont></h3>", false, false);
            AddItem(223, 330, 9865);

            AddButton(126, 370, 1209, 1210, 9, GumpButtonType.Reply, 0);
            AddHtml(150, 370, 200, 20, "<h3><basefont color=#5A4A31>Ceinture<basefont></h3>", false, false);
            AddItem(223, 369, 9823);

            AddButton(126, 400, 1209, 1210, 10, GumpButtonType.Reply, 0);
            AddHtml(150, 400, 200, 20, "<h3><basefont color=#5A4A31>Cuirasse<basefont></h3>", false, false);
            AddItem(223, 399, 10358);

            //Deuxieme Ranger
            AddButton(321, 130, 1209, 1210, 11, GumpButtonType.Reply, 0);
            AddHtml(345, 130, 200, 20, "<h3><basefont color=#5A4A31>Bras<basefont></h3>", false, false);
            AddItem(415, 119, 9862);

            AddButton(321, 160, 1209, 1210, 12, GumpButtonType.Reply, 0);
            AddHtml(345, 160, 200, 20, "<h3><basefont color=#5A4A31>Tunique<basefont></h3>", false, false);
            AddItem(415, 149, 10062);

            AddButton(321, 190, 1209, 1210, 13, GumpButtonType.Reply, 0);
            AddHtml(345, 190, 200, 20, "<h3><basefont color=#5A4A31>Oreille<basefont></h3>", false, false);
            AddItem(415, 190, 4231);

            AddButton(321, 220, 1209, 1210, 14, GumpButtonType.Reply, 0);
            AddHtml(345, 220, 200, 20, "<h3><basefont color=#5A4A31>Brassards<basefont></h3>", false, false);
            AddItem(415, 209, 10379);

            AddButton(321, 250, 1209, 1210, 15, GumpButtonType.Reply, 0);
            AddHtml(345, 250, 200, 20, "<h3><basefont color=#5A4A31>Cape<basefont></h3>", false, false);
            AddItem(415, 235, 10013);

            AddButton(321, 280, 1209, 1210, 16, GumpButtonType.Reply, 0);
            AddHtml(345, 280, 200, 20, "<h3><basefont color=#5A4A31>Robe<basefont></h3>", false, false);
            AddItem(415, 269, 10146);

            AddButton(321, 310, 1209, 1210, 17, GumpButtonType.Reply, 0);
            AddHtml(345, 310, 200, 20, "<h3><basefont color=#5A4A31>Jupe<basefont></h3>", false, false);
            AddItem(415, 299, 10051);

            AddButton(321, 340, 1209, 1210, 18, GumpButtonType.Reply, 0);
            AddHtml(345, 340, 200, 20, "<h3><basefont color=#5A4A31>Jambieres<basefont></h3>", false, false);
            AddItem(415, 339, 10374);

            AddButton(321, 370, 1209, 1210, 19, GumpButtonType.Reply, 0);
            AddHtml(345, 370, 200, 20, "<h3><basefont color=#5A4A31>Défaut<basefont></h3>", false, false);

            AddButton(321, 390, 1209, 1210, 20, GumpButtonType.Reply, 0);
            AddHtml(345, 390, 200, 20, "<h3><basefont color=#5A4A31>Layer Info<basefont></h3>", false, false);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    from.Target = new LayerChangeTarget(Layer.Shoes);
                    break;
                case 2:
                    from.Target = new LayerChangeTarget(Layer.Pants);
                    break;
                case 3:
                    from.Target = new LayerChangeTarget(Layer.Shirt);
                    break;
                case 4:
                    from.Target = new LayerChangeTarget(Layer.Helm);
                    break;
                case 5:
                    from.Target = new LayerChangeTarget(Layer.Gloves);
                    break;
                case 6:
                    from.Target = new LayerChangeTarget(Layer.Ring);
                    break;
                case 7:
                    from.Target = new LayerChangeTarget(Layer.Talisman);
                    break;
                case 8:
                    from.Target = new LayerChangeTarget(Layer.Neck);
                    break;
                case 9:
                    from.Target = new LayerChangeTarget(Layer.Waist);
                    break;
                case 10:
                    from.Target = new LayerChangeTarget(Layer.InnerTorso);
                    break;
                case 11:
                    from.Target = new LayerChangeTarget(Layer.Bracelet);
                    break;
                case 12:
                    from.Target = new LayerChangeTarget(Layer.MiddleTorso);
                    break;
                case 13:
                    from.Target = new LayerChangeTarget(Layer.Earrings);
                    break;
                case 14:
                    from.Target = new LayerChangeTarget(Layer.Arms);
                    break;
                case 15:
                    from.Target = new LayerChangeTarget(Layer.Cloak);
                    break;
                case 16:
                    from.Target = new LayerChangeTarget(Layer.OuterTorso);
                    break;
                case 17:
                    from.Target = new LayerChangeTarget(Layer.InnerLegs);
                    break;
                case 18:
                    from.Target = new LayerChangeTarget(Layer.OuterLegs);
                    break;
                case 19:
                    from.Target = new LayerResetTarget();
                    break;
                case 20:
                    from.Target = new LayerInfoTarget();
                    break;
                default: break;
            }
        }
    }
    public class LayerChangeTarget : Target
    {
        private Layer layer;

        public LayerChangeTarget(Layer layer)
            : base(-1, false, TargetFlags.None)
        {
            this.layer = layer;
        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target != null)
            {
                if (target is BaseClothing)
                {
                    BaseClothing cloth = (BaseClothing)target;
                    if (cloth.BaseLayer == Layer.Invalid)
                    {
                        cloth.BaseLayer = cloth.Layer;
                    }
                    cloth.Layer = this.layer;
                    from.SendGump(new LayersGump(from));
                }
                else
                {
                    from.SendMessage("Vous pouvez seulement changer le layer d'un vetement.");
                    from.SendGump(new LayersGump(from));
                }
            }
        }
    }
    public class LayerResetTarget : Target
    {
        public LayerResetTarget()
            : base(-1, false, TargetFlags.None)
        {

        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target != null)
            {
                if (target is BaseClothing)
                {
                    BaseClothing cloth = (BaseClothing)target;
                    if (cloth.BaseLayer != Layer.Invalid)
                    {
                        cloth.Layer = cloth.BaseLayer;
                        cloth.BaseLayer = Layer.Invalid;
                    }
                    else
                    {
                        from.SendMessage("Le vetement n'a pas change de layer !");
                        from.SendGump(new LayersGump(from));
                    }
                }
                else
                {
                    from.SendMessage("Vous pouvez seulement changer le layer d'un vetement.");
                    from.SendGump(new LayersGump(from));
                }
            }
        }
    }
    public class LayerInfoTarget : Target
    {
        public LayerInfoTarget()
            : base(-1, false, TargetFlags.None)
        {

        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target != null)
            {
                if (target is BaseClothing)
                {
                    if (((BaseClothing)target).BaseLayer != Layer.Invalid)
                        from.SendMessage("Layer de Base : " + ((BaseClothing)target).BaseLayer.ToString());
                    from.SendMessage("Layer Presentement : " + ((BaseClothing)target).Layer.ToString());
                    from.SendGump(new LayersGump(from));
                }
                else
                {
                    from.SendMessage("Vous pouvez seulement selectionner un vetement.");
                    from.SendGump(new LayersGump(from));
                }
            }
        }
    }
}
