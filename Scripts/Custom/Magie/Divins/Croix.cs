using System;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Gumps;

namespace Server.Items
{
    [FlipableAttribute(0x2, 0x3, 0x4, 0x5)]
	public class Croix : Item
	{
		[Constructable]
        public Croix() : base(0x2)
		{
			Weight = 85.0;
            Name = "croix";
		}

        public Croix(Serial serial) : base(serial)
		{
		}

        public override void OnDoubleClick(Mobile from)
        {
            TMobile m = from as TMobile;

            if (m != null)
            {
                if (!m.CanSee(this) || !m.InRange(Location, 4))
                {
                    m.SendLocalizedMessage(500446); // That is too far away.
                }
                else if (m.Dieux == Dieux.Aucune)
                {
                    m.SendMessage("Vous devez voir un pretre de la religion pour pouvoir convertir a celle-ci.");
                }
                else if (m.GetAptitudeValue(Aptitude.GraceDivine) <= 0)
                {
                    m.SendMessage("Vous devez avoir au moins un point de Grace Divine pour user la croix.");
                }
                else if (m.IsPraying)
                {
                    m.SendMessage("Vous êtes déjà en train de prier.");
                }
                else
                {
                    m.CloseGump(typeof(Religion.ReligionGump));
                    m.CloseGump(typeof(Religion.PriereGump));

                    if (this is Croix && (!m.CanSee(this) || !m.InRange(this.Location, 4)))
                        m.SendGump(new Religion.ReligionGump(m, 0));
                }
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}