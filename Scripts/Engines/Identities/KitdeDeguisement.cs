using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Spells;
using Server.Scripts.Commands;

namespace Server.Engines.Identities
{
    public class DeguisementKit : Item
    {
        [Constructable]
        public DeguisementKit()
            : base(0x1EBA)
        {
            Name = "Outils de déguisement";
            Weight = 1.0;
        }

        public DeguisementKit(Serial serial)
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

        public override void OnDoubleClick(Mobile m)
        {
            if (m is TMobile)
            {
                TMobile from = m as TMobile;

                if (!from.Alive)
                    return;

                if (!IsChildOf(from.Backpack))
                {
                    from.SendMessage("L'objet doit etre dans votre sac.");
                }
                else if (from.GetAptitudeValue(Aptitude.Deguisement) <= 0)
                {
                    from.SendMessage("Vous devez avoir au moins un point en deguisement !");
                }
                else if (from.Identities.CurrentIdentity == 13)
                {
                    from.SendMessage("Vous ne pouvez pas vous déguisez en forme Aasimar ou Tieffeline !");
                }
                /*else if (from.LastDeguisement.AddHours(3) > DateTime.Now && from.AccessLevel == AccessLevel.Player)
                {
                    from.SendMessage("Il est trop tot pour vous deguiser a nouveau !");
                }
                else if (from.Disguised)
                {
                    from.SendMessage("Vous etes deja deguise !");
                }*/
                else
                {
                    from.SendGump(new DeguisementGump(from));
                }
            }
        }
    }
}