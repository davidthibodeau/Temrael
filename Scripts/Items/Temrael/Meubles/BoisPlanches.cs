using System;

namespace Server.Items
{
    [Furniture]
    public class BlocBoisClair : BaseContainer
	{
		[Constructable]
        public BlocBoisClair()
            : base(0x0720)
		{
			Weight = 5.0;
            Name = "Bloc de bois clair";
		}

        public BlocBoisClair(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

		}
	}
}