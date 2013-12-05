using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class BagOfingots : Bag 
	{ 
		[Constructable] 
		public BagOfingots() : this( 5000 ) 
		{ 
		} 

		[Constructable] 
		public BagOfingots( int amount ) 
		{ 
			DropItem( new CuivreIngot   ( amount ) ); 
			DropItem( new BronzeIngot   ( amount ) ); 
			DropItem( new AcierIngot   ( amount ) ); 
			DropItem( new ArgentIngot   ( amount ) ); 
			DropItem( new OrIngot   ( amount ) ); 
			DropItem( new MytherilIngot   ( amount ) ); 
			DropItem( new FerIngot   ( amount ) );
			DropItem( new Tongs() );
			DropItem( new TinkerTools() );

		} 

		public BagOfingots( Serial serial ) : base( serial ) 
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
