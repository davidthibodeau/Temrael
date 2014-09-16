using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 7971, 7971 )]
	public class VisionDivineScroll : SpellScroll
	{
		[Constructable]
		public VisionDivineScroll() : this( 1 )
		{
		}

		[Constructable]
		public VisionDivineScroll( int amount ) : base( 1000, 7971, amount )
		{
			Name = "Vision divine";
            Hue = 1701;
		}

		public VisionDivineScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class PoingDeValeurScroll : SpellScroll
	{
		[Constructable]
		public PoingDeValeurScroll() : this( 1 )
		{
		}

		[Constructable]
		public PoingDeValeurScroll( int amount ) : base( 1001, 7971, amount )
		{
			Name = "Poing de valeur";
            Hue = 1446;
		}

		public PoingDeValeurScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class EssouflementScroll : SpellScroll
	{
		[Constructable]
		public EssouflementScroll() : this( 1 )
		{
		}

		[Constructable]
		public EssouflementScroll( int amount ) : base( 1002, 7971, amount )
		{
			Name = "Essouflement";
            Hue = 1328;
		}

		public EssouflementScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class LumiereDivineScroll : SpellScroll
	{
		[Constructable]
		public LumiereDivineScroll() : this( 1 )
		{
		}

		[Constructable]
		public LumiereDivineScroll( int amount ) : base( 1003, 7971, amount )
		{
			Name = "Lumière divine";
            Hue = 1201;
		}

		public LumiereDivineScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class GriffesScroll : SpellScroll
	{
		[Constructable]
		public GriffesScroll() : this( 1 )
		{
		}

		[Constructable]
		public GriffesScroll( int amount ) : base( 1004, 7971, amount )
		{
			Name = "Griffes";
            Hue = 1102;
		}

		public GriffesScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class ImbroglioScroll : SpellScroll
	{
		[Constructable]
		public ImbroglioScroll() : this( 1 )
		{
		}

		[Constructable]
		public ImbroglioScroll( int amount ) : base( 1005, 7971, amount )
		{
			Name = "Imbroglio";
            Hue = 1719;
		}

		public ImbroglioScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class RetablissementScroll : SpellScroll
	{
		[Constructable]
		public RetablissementScroll() : this( 1 )
		{
		}

		[Constructable]
		public RetablissementScroll( int amount ) : base( 1006, 7971, amount )
		{
			Name = "Rétablissement";
            Hue = 1701;
		}

		public RetablissementScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class RegenerationScroll : SpellScroll
	{
		[Constructable]
		public RegenerationScroll() : this( 1 )
		{
		}

		[Constructable]
		public RegenerationScroll( int amount ) : base( 1007, 7971, amount )
		{
			Name = "Régénération";
            Hue = 1446;
		}

		public RegenerationScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class BouclierScroll : SpellScroll
	{
		[Constructable]
		public BouclierScroll() : this( 1 )
		{
		}

		[Constructable]
		public BouclierScroll( int amount ) : base( 1008, 7971, amount )
		{
			Name = "Bouclier";
            Hue = 1201;
		}

		public BouclierScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class AmuletteScroll : SpellScroll
	{
		[Constructable]
		public AmuletteScroll() : this( 1 )
		{
		}

		[Constructable]
		public AmuletteScroll( int amount ) : base( 1009, 7971, amount )
		{
			Name = "Amulette";
            Hue = 1102;
		}

		public AmuletteScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class RefecteurScroll : SpellScroll
	{
		[Constructable]
		public RefecteurScroll() : this( 1 )
		{
		}

		[Constructable]
		public RefecteurScroll( int amount ) : base( 1010, 7971, amount )
		{
			Name = "Réfecteur";
            Hue = 1428;
		}

		public RefecteurScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class MiracleScroll : SpellScroll
	{
		[Constructable]
		public MiracleScroll() : this( 1 )
		{
		}

		[Constructable]
		public MiracleScroll( int amount ) : base( 1011, 7971, amount )
		{
			Name = "Miracle";
            Hue = 1237;
		}

		public MiracleScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class RepartitionScroll : SpellScroll
	{
		[Constructable]
		public RepartitionScroll() : this( 1 )
		{
		}

		[Constructable]
		public RepartitionScroll( int amount ) : base( 1012, 7971, amount )
		{
			Name = "Répartition";
            Hue = 1701;
		}

		public RepartitionScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class RenouvellementScroll : SpellScroll
	{
		[Constructable]
		public RenouvellementScroll() : this( 1 )
		{
		}

		[Constructable]
		public RenouvellementScroll( int amount ) : base( 1013, 7971, amount )
		{
			Name = "Renouvellement";
            Hue = 1328;
		}

		public RenouvellementScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class PurificationScroll : SpellScroll
	{
		[Constructable]
		public PurificationScroll() : this( 1 )
		{
		}

		[Constructable]
		public PurificationScroll( int amount ) : base( 1014, 7971, amount )
		{
			Name = "Purification";
            Hue = 1201;
		}

		public PurificationScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class PromptitudeScroll : SpellScroll
	{
		[Constructable]
		public PromptitudeScroll() : this( 1 )
		{
		}

		[Constructable]
		public PromptitudeScroll( int amount ) : base( 1015, 7971, amount )
		{
			Name = "Promptitude";
            Hue = 1719;
		}

		public PromptitudeScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class PassionScroll : SpellScroll
	{
		[Constructable]
		public PassionScroll() : this( 1 )
		{
		}

		[Constructable]
		public PassionScroll( int amount ) : base( 1016, 7971, amount )
		{
			Name = "Passion";
            Hue = 1428;
		}

		public PassionScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class RegenerescenceScroll : SpellScroll
	{
		[Constructable]
		public RegenerescenceScroll() : this( 1 )
		{
		}

		[Constructable]
		public RegenerescenceScroll( int amount ) : base( 1017, 7971, amount )
		{
			Name = "Régénérescence";
            Hue = 1237;
		}

		public RegenerescenceScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class HautePrecisionScroll : SpellScroll
	{
		[Constructable]
		public HautePrecisionScroll() : this( 1 )
		{
		}

		[Constructable]
		public HautePrecisionScroll( int amount ) : base( 1018, 7971, amount )
		{
			Name = "Haute précision";
            Hue = 1701;
		}

		public HautePrecisionScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class AgglomerationScroll : SpellScroll
	{
		[Constructable]
		public AgglomerationScroll() : this( 1 )
		{
		}

		[Constructable]
		public AgglomerationScroll( int amount ) : base( 1019, 7971, amount )
		{
			Name = "Agglomération";
            Hue = 1446;
		}

		public AgglomerationScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class RudesseScroll : SpellScroll
	{
		[Constructable]
		public RudesseScroll() : this( 1 )
		{
		}

		[Constructable]
		public RudesseScroll( int amount ) : base( 1020, 7971, amount )
		{
			Name = "Rudesse";
            Hue = 1201;
		}

		public RudesseScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class ConsecrationScroll : SpellScroll
	{
		[Constructable]
		public ConsecrationScroll() : this( 1 )
		{
		}

		[Constructable]
		public ConsecrationScroll( int amount ) : base( 1021, 7971, amount )
		{
			Name = "Consécration";
            Hue = 1102;
		}

		public ConsecrationScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class ConfessionScroll : SpellScroll
	{
		[Constructable]
		public ConfessionScroll() : this( 1 )
		{
		}

		[Constructable]
		public ConfessionScroll( int amount ) : base( 1022, 7971, amount )
		{
			Name = "Confession";
            Hue = 1719;
		}

		public ConfessionScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class ForceDeLaFoiScroll : SpellScroll
	{
		[Constructable]
		public ForceDeLaFoiScroll() : this( 1 )
		{
		}

		[Constructable]
		public ForceDeLaFoiScroll( int amount ) : base( 1023, 7971, amount )
		{
			Name = "Force de la foi";
            Hue = 1428;
		}

		public ForceDeLaFoiScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class FamineScroll : SpellScroll
	{
		[Constructable]
		public FamineScroll() : this( 1 )
		{
		}

		[Constructable]
		public FamineScroll( int amount ) : base( 1024, 7971, amount )
		{
			Name = "Famine";
            Hue = 1446;
		}

		public FamineScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class ErranceScroll : SpellScroll
	{
		[Constructable]
		public ErranceScroll() : this( 1 )
		{
		}

		[Constructable]
		public ErranceScroll( int amount ) : base( 1025, 7971, amount )
		{
			Name = "Errance";
            Hue = 1328;
		}

		public ErranceScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class BetesScroll : SpellScroll
	{
		[Constructable]
		public BetesScroll() : this( 1 )
		{
		}

		[Constructable]
		public BetesScroll( int amount ) : base( 1026, 7971, amount )
		{
			Name = "Bêtes";
            Hue = 1201;
		}

		public BetesScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class HypnoseScroll : SpellScroll
	{
		[Constructable]
		public HypnoseScroll() : this( 1 )
		{
		}

		[Constructable]
		public HypnoseScroll( int amount ) : base( 1027, 7971, amount )
		{
			Name = "Hypnose";
            Hue = 1102;
		}

		public HypnoseScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class FetichismeScroll : SpellScroll
	{
		[Constructable]
		public FetichismeScroll() : this( 1 )
		{
		}

		[Constructable]
		public FetichismeScroll( int amount ) : base( 1028, 7971, amount )
		{
			Name = "Fétichisme";
            Hue = 1428;
		}

		public FetichismeScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class VoodooScroll : SpellScroll
	{
		[Constructable]
		public VoodooScroll() : this( 1 )
		{
		}

		[Constructable]
		public VoodooScroll( int amount ) : base( 1029, 7971, amount )
		{
			Name = "Voodoo";
            Hue = 1237;
		}

		public VoodooScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class PiedAncreScroll : SpellScroll
	{
		[Constructable]
		public PiedAncreScroll() : this( 1 )
		{
		}

		[Constructable]
		public PiedAncreScroll( int amount ) : base( 1030, 7971, amount )
		{
			Name = "Pied ancré";
            Hue = 1701;
		}

		public PiedAncreScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class RobustesseScroll : SpellScroll
	{
		[Constructable]
		public RobustesseScroll() : this( 1 )
		{
		}

		[Constructable]
		public RobustesseScroll( int amount ) : base( 1031, 7971, amount )
		{
			Name = "Robustesse";
            Hue = 1446;
		}

		public RobustesseScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class SouplesseScroll : SpellScroll
	{
		[Constructable]
		public SouplesseScroll() : this( 1 )
		{
		}

		[Constructable]
		public SouplesseScroll( int amount ) : base( 1032, 7971, amount )
		{
			Name = "Souplesse";
            Hue = 1201;
		}

		public SouplesseScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class CorpsPurScroll : SpellScroll
	{
		[Constructable]
		public CorpsPurScroll() : this( 1 )
		{
		}

		[Constructable]
		public CorpsPurScroll( int amount ) : base( 1033, 7971, amount )
		{
			Name = "Corps pur";
            Hue = 1102;
		}

		public CorpsPurScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class EternelleJeunesseScroll : SpellScroll
	{
		[Constructable]
		public EternelleJeunesseScroll() : this( 1 )
		{
		}

		[Constructable]
		public EternelleJeunesseScroll( int amount ) : base( 1034, 7971, amount )
		{
			Name = "Éternelle jeunesse";
            Hue = 1428;
		}

		public EternelleJeunesseScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class ProuesseScroll : SpellScroll
	{
		[Constructable]
		public ProuesseScroll() : this( 1 )
		{
		}

		[Constructable]
		public ProuesseScroll( int amount ) : base( 1035, 7971, amount )
		{
			Name = "Prouesse";
            Hue = 1237;
		}

		public ProuesseScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class ConscienceScroll : SpellScroll
	{
		[Constructable]
		public ConscienceScroll() : this( 1 )
		{
		}

		[Constructable]
		public ConscienceScroll( int amount ) : base( 1036, 7971, amount )
		{
			Name = "Conscience";
            Hue = 1701;
		}

		public ConscienceScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class AppelDeLaNatureScroll : SpellScroll
	{
		[Constructable]
		public AppelDeLaNatureScroll() : this( 1 )
		{
		}

		[Constructable]
		public AppelDeLaNatureScroll( int amount ) : base( 1037, 7971, amount )
		{
			Name = "Appel de la nature";
            Hue = 1446;
		}

		public AppelDeLaNatureScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class AnimauxScroll : SpellScroll
	{
		[Constructable]
		public AnimauxScroll() : this( 1 )
		{
		}

		[Constructable]
		public AnimauxScroll( int amount ) : base( 1038, 7971, amount )
		{
			Name = "Animaux";
            Hue = 1201;
		}

		public AnimauxScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class InstinctCharnelScroll : SpellScroll
	{
		[Constructable]
		public InstinctCharnelScroll() : this( 1 )
		{
		}

		[Constructable]
		public InstinctCharnelScroll( int amount ) : base( 1039, 7971, amount )
		{
			Name = "Instinct charnel";
            Hue = 1102;
		}

		public InstinctCharnelScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class TransfertScroll : SpellScroll
	{
		[Constructable]
		public TransfertScroll() : this( 1 )
		{
		}

		[Constructable]
		public TransfertScroll( int amount ) : base( 1040, 7971, amount )
		{
			Name = "Transfert";
            Hue = 1428;
		}

		public TransfertScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class DominationScroll : SpellScroll
	{
		[Constructable]
		public DominationScroll() : this( 1 )
		{
		}

		[Constructable]
		public DominationScroll( int amount ) : base( 1041, 7971, amount )
		{
			Name = "Domination";
            Hue = 1237;
		}

		public DominationScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class PlumeScroll : SpellScroll
	{
		[Constructable]
		public PlumeScroll() : this( 1 )
		{
		}

		[Constructable]
		public PlumeScroll( int amount ) : base( 1042, 7971, amount )
		{
			Name = "Plume";
            Hue = 1446;
		}

		public PlumeScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class IntrinsequeScroll : SpellScroll
	{
		[Constructable]
		public IntrinsequeScroll() : this( 1 )
		{
		}

		[Constructable]
		public IntrinsequeScroll( int amount ) : base( 1043, 7971, amount )
		{
			Name = "Intrinsèque";
            Hue = 1328;
		}

		public IntrinsequeScroll( Serial serial ) : base( serial )
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

	/*[FlipableAttribute( 7971, 7971 )]
	public class VoileScroll : SpellScroll
	{
		[Constructable]
		public VoileScroll() : this( 1 )
		{
		}

		[Constructable]
		public VoileScroll( int amount ) : base( 1044, 7971, amount )
		{
			Name = "Voile";
            Hue = 1201;
		}

		public VoileScroll( Serial serial ) : base( serial )
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
	}*/

	[FlipableAttribute( 7971, 7971 )]
	public class EchoScroll : SpellScroll
	{
		[Constructable]
		public EchoScroll() : this( 1 )
		{
		}

		[Constructable]
		public EchoScroll( int amount ) : base( 1045, 7971, amount )
		{
			Name = "Écho";
            Hue = 1102;
		}

		public EchoScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class StupefactionScroll : SpellScroll
	{
		[Constructable]
		public StupefactionScroll() : this( 1 )
		{
		}

		[Constructable]
		public StupefactionScroll( int amount ) : base( 1046, 7971, amount )
		{
			Name = "Stupéfaction";
            Hue = 1428;
		}

		public StupefactionScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class DecheanceScroll : SpellScroll
	{
		[Constructable]
		public DecheanceScroll() : this( 1 )
		{
		}

		[Constructable]
		public DecheanceScroll( int amount ) : base( 1047, 7971, amount )
		{
			Name = "Déchéance";
            Hue = 1237;
		}

		public DecheanceScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class AuraDeFatigueScroll : SpellScroll
	{
		[Constructable]
		public AuraDeFatigueScroll() : this( 1 )
		{
		}

		[Constructable]
		public AuraDeFatigueScroll( int amount ) : base( 1048, 7971, amount )
		{
			Name = "Aura de fatigue";
            Hue = 1446;
		}

		public AuraDeFatigueScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class MortificationScroll : SpellScroll
	{
		[Constructable]
		public MortificationScroll() : this( 1 )
		{
		}

		[Constructable]
		public MortificationScroll( int amount ) : base( 1049, 7971, amount )
		{
			Name = "Mortification";
            Hue = 1328;
		}

		public MortificationScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class ExecrationScroll : SpellScroll
	{
		[Constructable]
		public ExecrationScroll() : this( 1 )
		{
		}

		[Constructable]
		public ExecrationScroll( int amount ) : base( 1050, 7971, amount )
		{
			Name = "Exécration";
            Hue = 1201;
		}

		public ExecrationScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class HalenePutrideScroll : SpellScroll
	{
		[Constructable]
		public HalenePutrideScroll() : this( 1 )
		{
		}

		[Constructable]
		public HalenePutrideScroll( int amount ) : base( 1051, 7971, amount )
		{
			Name = "Halène putride";
            Hue = 1102;
		}

		public HalenePutrideScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class HorreurScroll : SpellScroll
	{
		[Constructable]
		public HorreurScroll() : this( 1 )
		{
		}

		[Constructable]
		public HorreurScroll( int amount ) : base( 1052, 7971, amount )
		{
			Name = "Horreur";
            Hue = 1428;
		}

		public HorreurScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class PourrissementScroll : SpellScroll
	{
		[Constructable]
		public PourrissementScroll() : this( 1 )
		{
		}

		[Constructable]
		public PourrissementScroll( int amount ) : base( 1053, 7971, amount )
		{
			Name = "Pourrissement";
            Hue = 1237;
		}

		public PourrissementScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class CourageScroll : SpellScroll
	{
		[Constructable]
		public CourageScroll() : this( 1 )
		{
		}

		[Constructable]
		public CourageScroll( int amount ) : base( 1054, 7971, amount )
		{
			Name = "Courage";
            Hue = 1446;
		}

		public CourageScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class SagesseScroll : SpellScroll
	{
		[Constructable]
		public SagesseScroll() : this( 1 )
		{
		}

		[Constructable]
		public SagesseScroll( int amount ) : base( 1055, 7971, amount )
		{
			Name = "Sagesse";
            Hue = 1328;
		}

		public SagesseScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class BerseckScroll : SpellScroll
	{
		[Constructable]
		public BerseckScroll() : this( 1 )
		{
		}

		[Constructable]
		public BerseckScroll( int amount ) : base( 1056, 7971, amount )
		{
			Name = "Berseck";
            Hue = 1201;
		}

		public BerseckScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class TranscendanceScroll : SpellScroll
	{
		[Constructable]
		public TranscendanceScroll() : this( 1 )
		{
		}

		[Constructable]
		public TranscendanceScroll( int amount ) : base( 1057, 7971, amount )
		{
			Name = "Transcendance";
            Hue = 1102;
		}

		public TranscendanceScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class SpiritualiteScroll : SpellScroll
	{
		[Constructable]
		public SpiritualiteScroll() : this( 1 )
		{
		}

		[Constructable]
		public SpiritualiteScroll( int amount ) : base( 1058, 7971, amount )
		{
			Name = "Spiritualité";
            Hue = 1428;
		}

		public SpiritualiteScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class SoifDuCombatScroll : SpellScroll
	{
		[Constructable]
		public SoifDuCombatScroll() : this( 1 )
		{
		}

		[Constructable]
		public SoifDuCombatScroll( int amount ) : base( 1059, 7971, amount )
		{
			Name = "Soif du combat";
            Hue = 1237;
		}

		public SoifDuCombatScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class SauvegardeScroll : SpellScroll
	{
		[Constructable]
		public SauvegardeScroll() : this( 1 )
		{
		}

		[Constructable]
		public SauvegardeScroll( int amount ) : base( 1060, 7971, amount )
		{
			Name = "Sauvegarde";
            Hue = 1446;
		}

		public SauvegardeScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class ExaltationScroll : SpellScroll
	{
		[Constructable]
		public ExaltationScroll() : this( 1 )
		{
		}

		[Constructable]
		public ExaltationScroll( int amount ) : base( 1061, 7971, amount )
		{
			Name = "Exaltation";
            Hue = 1328;
		}

		public ExaltationScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class LabyrintheScroll : SpellScroll
	{
		[Constructable]
		public LabyrintheScroll() : this( 1 )
		{
		}

		[Constructable]
		public LabyrintheScroll( int amount ) : base( 1062, 7971, amount )
		{
			Name = "Labyrinthe";
            Hue = 1201;
		}

		public LabyrintheScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class VisionReelleScroll : SpellScroll
	{
		[Constructable]
		public VisionReelleScroll() : this( 1 )
		{
		}

		[Constructable]
		public VisionReelleScroll( int amount ) : base( 1063, 7971, amount )
		{
			Name = "Vision réelle";
            Hue = 1102;
		}

		public VisionReelleScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class AppuiScroll : SpellScroll
	{
		[Constructable]
		public AppuiScroll() : this( 1 )
		{
		}

		[Constructable]
		public AppuiScroll( int amount ) : base( 1064, 7971, amount )
		{
			Name = "Appui";
            Hue = 1428;
		}

		public AppuiScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class PatronageScroll : SpellScroll
	{
		[Constructable]
		public PatronageScroll() : this( 1 )
		{
		}

		[Constructable]
		public PatronageScroll( int amount ) : base( 1065, 7971, amount )
		{
			Name = "Patronage";
            Hue = 1237;
		}

		public PatronageScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class TalismanScroll : SpellScroll
	{
		[Constructable]
		public TalismanScroll() : this( 1 )
		{
		}

		[Constructable]
		public TalismanScroll( int amount ) : base( 1066, 7971, amount )
		{
			Name = "Talisman";
            Hue = 1446;
		}

		public TalismanScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class BarilDeBiereScroll : SpellScroll
	{
		[Constructable]
		public BarilDeBiereScroll() : this( 1 )
		{
		}

		[Constructable]
		public BarilDeBiereScroll( int amount ) : base( 1067, 7971, amount )
		{
			Name = "Baril de bière";
            Hue = 1328;
		}

		public BarilDeBiereScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class PointDeParesseScroll : SpellScroll
	{
		[Constructable]
		public PointDeParesseScroll() : this( 1 )
		{
		}

		[Constructable]
		public PointDeParesseScroll( int amount ) : base( 1068, 7971, amount )
		{
			Name = "Point de paresse";
            Hue = 1201;
		}

		public PointDeParesseScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class SoutienScroll : SpellScroll
	{
		[Constructable]
		public SoutienScroll() : this( 1 )
		{
		}

		[Constructable]
		public SoutienScroll( int amount ) : base( 1069, 7971, amount )
		{
			Name = "Soutien";
            Hue = 1102;
		}

		public SoutienScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class DonDesRochersScroll : SpellScroll
	{
		[Constructable]
		public DonDesRochersScroll() : this( 1 )
		{
		}

		[Constructable]
		public DonDesRochersScroll( int amount ) : base( 1070, 7971, amount )
		{
			Name = "Don des rochers";
            Hue = 1428;
		}

		public DonDesRochersScroll( Serial serial ) : base( serial )
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

	[FlipableAttribute( 7971, 7971 )]
	public class CouvertureScroll : SpellScroll
	{
		[Constructable]
		public CouvertureScroll() : this( 1 )
		{
		}

		[Constructable]
		public CouvertureScroll( int amount ) : base( 1071, 7971, amount )
		{
			Name = "Couverture";
            Hue = 1237;
		}

		public CouvertureScroll( Serial serial ) : base( serial )
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