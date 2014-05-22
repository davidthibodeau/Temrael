using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Misc;

namespace Server
{

}

namespace Server.Items
{
	public class Calendrier : Item
	{
		[Constructable]
		public Calendrier() : base( 5359 )
		{
			Name = "calendrier";
			Weight = 1.0;
        }

        public override void OnDoubleClick(Mobile from)
        {
            int year;
            int month;
            int day;

            Time.GetDate(out year, out month, out day);

            LabelTo(from, String.Format("{0} {1} de l'annee du seigneur {2}", day, Time.Months[month - 1].Month, year));
        }

        public Calendrier(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}