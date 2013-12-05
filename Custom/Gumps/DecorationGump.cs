using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Gumps
{
    public enum DecoDirection
    {
        NorthWest,
        North,
        NorthEast,
        East,
        West,
        SouthWest,
        South,
        SouthEast
    }

    class DecorationGump : Gump
    {
        private Mobile m_From;

        public DecorationGump(Mobile from) : base(0, 0)
        {
            m_From = from;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            //Backgound
            AddImage(100, 100, 5011);

            //Nudge
            AddButton(160, 235, 5600, 5604, 1, GumpButtonType.Reply, 0);
            AddButton(300, 235, 5602, 5606, 2, GumpButtonType.Reply, 0);

            //Fleches
            AddButton(216, 180, 4500, 4500, 3, GumpButtonType.Reply, 0);
            AddButton(245, 185, 4501, 4501, 4, GumpButtonType.Reply, 0);
            AddButton(245, 215, 4502, 4502, 5, GumpButtonType.Reply, 0);
            AddButton(240, 245, 4503, 4503, 6, GumpButtonType.Reply, 0);
            AddButton(216, 250, 4504, 4504, 7, GumpButtonType.Reply, 0);
            AddButton(187, 245, 4505, 4505, 8, GumpButtonType.Reply, 0);
            AddButton(182, 215, 4506, 4506, 9, GumpButtonType.Reply, 0);
            AddButton(187, 185, 4507, 4507, 10, GumpButtonType.Reply, 0);

            //Flip
            //AddButton(216, 180, 4008, 4008, 13, GumpButtonType.Reply, 0);

            //Lock
            AddButton(227, 162, 4020, 4022, 11, GumpButtonType.Reply, 0);
            AddButton(227, 312, 4017, 4019, 12, GumpButtonType.Reply, 0);

            //Texte
            AddHtml(159, 250, 200, 20, "<h3><basefont color=#5A4A31>Up<basefont></h3>", false, false);
            AddHtml(292, 250, 200, 20, "<h3><basefont color=#5A4A31>Down<basefont></h3>", false, false);

            AddHtml(220, 141, 200, 20, "<h3><basefont color=#5A4A31>Barrer<basefont></h3>", false, false);
            AddHtml(216, 293, 200, 20, "<h3><basefont color=#5A4A31>Debarrer<basefont></h3>", false, false);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    from.Target = new NudgeUpTarget();
                    break;
                case 2:
                    from.Target = new NudgeDownTarget();
                    break;
                case 3:
                    from.Target = new DecoMoveTarget(DecoDirection.North);
                    break;
                case 4:
                    from.Target = new DecoMoveTarget(DecoDirection.NorthEast);
                    break;
                case 5:
                    from.Target = new DecoMoveTarget(DecoDirection.East);
                    break;
                case 6:
                    from.Target = new DecoMoveTarget(DecoDirection.SouthEast);
                    break;
                case 7:
                    from.Target = new DecoMoveTarget(DecoDirection.South);
                    break;
                case 8:
                    from.Target = new DecoMoveTarget(DecoDirection.SouthWest);
                    break;
                case 9:
                    from.Target = new DecoMoveTarget(DecoDirection.West);
                    break;
                case 10:
                    from.Target = new DecoMoveTarget(DecoDirection.NorthWest);
                    break;
                case 11:
                    from.Target = new DecoLockTarget();
                    break;
                case 12:
                    from.Target = new DecoUnLockTarget();
                    break;
                default: break;
            }
        }
    }
    public class NudgeUpTarget : Target
    {
        public NudgeUpTarget()
            : base(-1, false, TargetFlags.None)
        {

        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target != null)
            {
                if ((target is Item) && (!(target is BaseDoor)))
                {
                    Item item = (Item)target;

                    if ((from.GetDistanceToSqrt(item.Location) <= 1) && (from.InLOS(item)))
                    {
                        if (item.CanBeAltered)
                        {
                            Point3D point = item.Location;
                            point.Z += 1;

                            item.Location = point;
                        }
                        from.SendGump(new DecorationGump(from));
                    }
                    else
                    {
                        from.SendMessage("Ceci est hors de votre portée.");
                    }
                }
                else
                {
                    from.SendMessage("Vous pouvez seulement deplacer un objet !");
                    from.SendGump(new DecorationGump(from));
                }
            }
        }
    }
    public class NudgeDownTarget : Target
    {
        public NudgeDownTarget()
            : base(-1, false, TargetFlags.None)
        {

        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target != null)
            {
                if ((target is Item) && (!(target is BaseDoor)))
                {
                    Item item = (Item)target;

                    if ((from.GetDistanceToSqrt(item.Location) <= 1) && (from.InLOS(item)))
                    {
                        if (item.CanBeAltered)
                        {
                            Point3D point = item.Location;
                            point.Z -= 1;

                            item.Location = point;
                        }
                        from.SendGump(new DecorationGump(from));
                    }
                    else
                    {
                        from.SendMessage("Ceci est hors de votre portée.");
                    }
                }
                else
                {
                    from.SendMessage("Vous pouvez seulement deplacer un objet !");
                    from.SendGump(new DecorationGump(from));
                }
            }
        }
    }
    public class DecoLockTarget : Target
    {
        public DecoLockTarget()
            : base(-1, false, TargetFlags.None)
        {

        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target != null)
            {
                if ((target is Item) && (!(target is BaseDoor)))
                {
                    Item item = (Item)target;

                    if ((from.GetDistanceToSqrt(item.Location) <= 1) && (from.InLOS(item)))
                    {
                        if (item.CanBeAltered)
                        {
                            item.Movable = false;
                        }
                    }
                    else
                    {
                        from.SendMessage("Ceci est hors de votre portée.");
                    }

                    from.SendGump(new DecorationGump(from));
                }
                else
                {
                    from.SendMessage("Vous pouvez seulement barrer/debarrer un objet !");
                    from.SendGump(new DecorationGump(from));
                }
            }
        }
    }
    public class DecoUnLockTarget : Target
    {
        public DecoUnLockTarget()
            : base(-1, false, TargetFlags.None)
        {

        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target != null)
            {
                if ((target is Item) && (!(target is BaseDoor)))
                {
                    Item item = (Item)target;

                    if ((from.GetDistanceToSqrt(item.Location) <= 1) && (from.InLOS(item)))
                    {
                        if (item.CanBeAltered)
                        {
                            item.Movable = true;
                        }
                    }
                    else
                    {
                        from.SendMessage("Ceci est hors de votre portée.");
                    }

                    from.SendGump(new DecorationGump(from));
                }
                else
                {
                    from.SendMessage("Vous pouvez seulement barrer/debarrer un objet !");
                    from.SendGump(new DecorationGump(from));
                }
            }
        }
    }
    public class DecoMoveTarget : Target
    {
        DecoDirection dir;

        public DecoMoveTarget(DecoDirection direction)
            : base(-1, false, TargetFlags.None)
        {
            dir = direction;
        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target != null)
            {
                if ((target is Item) && (!(target is BaseDoor)))
                {
                    Item item = (Item)target;

                    if ((from.GetDistanceToSqrt(item.Location) <= 1) && (from.InLOS(item)))
                    {
                        if (item.CanBeAltered)
                        {
                            Point3D point = item.Location;

                            switch (dir)
                            {
                                case DecoDirection.North:
                                    point.X -= 1;
                                    point.Y -= 1;
                                    break;
                                case DecoDirection.South:
                                    point.X -= 1;
                                    point.Y -= 1;
                                    break;
                                case DecoDirection.East:
                                    point.X += 1;
                                    point.Y -= 1;
                                    break;
                                case DecoDirection.West:
                                    point.X -= 1;
                                    point.Y += 1;
                                    break;
                                case DecoDirection.NorthEast:
                                    point.Y -= 1;
                                    break;
                                case DecoDirection.NorthWest:
                                    point.X -= 1;
                                    break;
                                case DecoDirection.SouthEast:
                                    point.X += 1;
                                    break;
                                case DecoDirection.SouthWest:
                                    point.Y += 1;
                                    break;
                            }
                            point.Z -= 1;

                            item.Location = point;
                        }
                    }
                    else
                    {
                        from.SendMessage("Ceci est hors de votre portée.");
                    }

                    from.SendGump(new DecorationGump(from));
                }
                else
                {
                    from.SendMessage("Vous pouvez seulement deplacer un objet !");
                    from.SendGump(new DecorationGump(from));
                }
            }
        }
    }
}
