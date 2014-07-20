using System;
using Server.Targeting;
using Server.HuePickers;
using Server.Gumps;

namespace Server.Items
{
	public class Dyes : Item
	{
		[Constructable]
		public Dyes() : base( 0xFA9 )
		{
			Weight = 3.0;
		}

		public Dyes( Serial serial ) : base( serial )
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

			if ( Weight == 0.0 )
				Weight = 3.0;
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendLocalizedMessage( 500856 ); // Select the dye tub to use the dyes on.
			from.Target = new InternalTarget();
		}

        private class InternalTarget : Target
        {
            public InternalTarget()
                : base(1, false, TargetFlags.None)
            {
            }

            private static void SetTubHue(Mobile from, object state, int hue)
            {
                ((DyeTub)state).Hue = hue;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is DyeTub)
                {
                    DyeTub tub = (DyeTub)targeted;

                    if (tub.Redyable)
                    {
                        from.SendGump(new TeintureGump(from, TeintureTabs.Baies, tub));
                    }
                    else
                    {
                        from.SendMessage("That dye tub may not be redyed.");
                    }
                }
                else
                {
                    from.SendLocalizedMessage(500857); // Use this on a dye tub.
                }
            }
        }
	}
}