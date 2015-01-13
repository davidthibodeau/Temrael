using System;
using Server.Regions;

namespace Server.Items
{
	[FlipableAttribute( 0xFAF, 0xFB0 )]
	[Server.Engines.Craft.Anvil]
    public class Anvil : Item
	{
		[Constructable]
		public Anvil() : base( 0xFAF )
		{
			Movable = false;
		}

		public Anvil( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            if (version == 0)
            {
                if (this.RootParent != null)
                {
                    if (this.RootParent.GetType() == typeof(Mobile))
                    {
                        ((Mobile)RootParent).AddToBackpack(new AnvilDeed());
                        Delete();
                    }
                    else
                    {
                        Movable = false;
                        CanBeAltered = false;
                    }
                }
                else
                {
                    Movable = false;
                    CanBeAltered = false;
                }
            }
		}
	}
    [FlipableAttribute(0xFAF, 0xFB0)]
    [Server.Engines.Craft.Anvil]
    public class AnvilAddon : BaseAddon
    {
        [Constructable]
        public AnvilAddon()
            : base(0xFAF)
        {
            Movable = false;
            CanBeAltered = false;
        }

        public AnvilAddon(Serial serial)
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
    public class AnvilDeed : BaseAddonDeed
    {

        public override BaseAddon Addon
        {
            get
            {
                if (Region.Find(Location, Map.Felucca) is VilleHurlevent)
                {
                    return new AnvilAddon();
                }
                else
                {
                    return null;
                }
            }
        }

        [Constructable]
        public AnvilDeed()
        {
            Name = "Enclume";
        }

        public AnvilDeed(Serial serial)
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

	[Server.Engines.Craft.Forge]
	public class Forge : Item
	{
		[Constructable]
		public Forge() : base( 0xFB1 )
		{
			Movable = false;
		}

		public Forge( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            if (version == 0)
            {
                if (this.RootParent != null)
                {
                    if (this.RootParent.GetType() == typeof(Mobile))
                    {
                        ((Mobile)RootParent).AddToBackpack(new ForgeDeed());
                        Delete();
                    }
                    else
                    {
                        Movable = false;
                        CanBeAltered = false;
                    }
                }
                else
                {
                    Movable = false;
                    CanBeAltered = false;
                }
            }
		}
	}
    [Server.Engines.Craft.Forge]
    public class ForgeAddon : BaseAddon
    {
        [Constructable]
        public ForgeAddon()
            : base(0xFB1)
        {
            CanBeAltered = false;
            Movable = false;
        }

        public ForgeAddon(Serial serial)
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

            if (version == 0)
            {
                Movable = false;
                CanBeAltered = false;
            }
        }
    }
    public class ForgeDeed : BaseAddonDeed
    {

        public override BaseAddon Addon
        {
            get
            {
                if (Region.Find(Location, Map.Felucca) is VilleHurlevent)
                {
                    return new ForgeAddon();
                }
                else
                {
                    return null;
                }
            }
        }

        [Constructable]
        public ForgeDeed()
        {
            Name = "Forge";
        }

        public ForgeDeed(Serial serial)
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