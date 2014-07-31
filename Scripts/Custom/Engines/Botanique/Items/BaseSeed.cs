using System;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Items
{
	public abstract class BaseSeed : Item
    {
        public class AddBowlEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private BaseSeed m_Seed;

            public AddBowlEntry(Mobile from, BaseSeed seed)
                : base(6054, 1)
            {
                m_From = from;
                m_Seed = seed;
            }

            public override void OnClick()
            {
                if (m_Seed.Deleted || !m_Seed.Movable || !m_From.CheckAlive())
                    return;

                m_From.SendMessage("Choisissez un pot (Botanique) ou le sol (Agriculture).");
                m_From.BeginTarget(1, true, TargetFlags.None, new TargetCallback(m_Seed.ChooseTarget_OnTarget));
            }
        }

        public abstract PlantType PlantType { get; }
        public abstract string SeedName { get; }

        public BaseSeed() : base(13066)
        {
            Name = "Graine";
            Weight = 0.1;
            Hue = 2017;
        }

        public BaseSeed(Serial serial) : base(serial)
		{
        }

        public abstract BasePlant GetPlant();

        public override void OnSingleClick(Mobile from)
        {
            base.OnSingleClick(from);

            if (from is TMobile)
            {
                TMobile m = (TMobile)from;

                if (SeedName != null && SeedName != "" && m.GetAptitudeValue(Aptitude.Botanique) > 0)
                    LabelTo(m, String.Format("[{0}]", SeedName));
            }
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (from.Alive)
                list.Add(new AddBowlEntry(from, this));
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);

            if (from is TMobile)
            {
                TMobile m = (TMobile)from;

                m.SendMessage("Choisissez un pot (Botanique) ou le sol (Agriculture).");
                m.BeginTarget(1, true, TargetFlags.None, new TargetCallback(this.ChooseTarget_OnTarget));
            }
        }

        public void ChooseTarget_OnTarget(Mobile from, object targeted)
        {
            if (Deleted || !from.CheckAlive())
                return;

            if (targeted is BaseBowl)
            {
                BaseBowl bowl = targeted as BaseBowl;

                if (bowl.IsEmpty)
                {
                    from.SendMessage("Le pot est vide.");
                }
                else if (bowl.HasPlant)
                {
                    from.SendMessage("Il y a déja une graine dans ce pot.");
                }
                else
                {
                    if (this.PlantType == PlantType.None)
                    {
                        from.SendMessage("Cette graine n'est pas valide.");
                    }
                    else
                    {
                        bowl.AddSeed(this);
                        from.SendMessage("Vous plantez la graine dans le pot.");
                    }
                }
                return;
            }
            if (targeted is StaticTarget)
            {
                from.SendMessage("Vous devez pointez vers de la terre !");
            }
            else if (targeted is LandTarget)
            {
                LandTarget point = (LandTarget)targeted;

                //Terre Fertile
                if ((point.TileID > 8) && (point.TileID < 22))
                {
                    /*m_seed.Name = m_seed.Nom;
                    m_seed.Planted = true;
                    m_seed.Owner = from;
                    m_seed.ItemID = m_seed.ArtID;
                    m_seed.Dirt = false;
                    int seconds = 172800 - (from.Skills.Agriculture.Fixed * 800);
                    TimeSpan duration = TimeSpan.FromSeconds(seconds);
                    m_seed.m_evoTimer = new AgriEvoTimer(from, m_seed, duration, duration);
                    m_seed.m_evoTimer.Start();
                    m_seed.m_waterTimer = new AgriWaterTimer(from, m_seed, TimeSpan.FromHours(6), TimeSpan.FromHours(6));
                    m_seed.m_waterTimer.Start();
                    m_seed.MoveToWorld(point.Location);
                    m_seed.Movable = false;*/
                }
                //Dirt
                else if ((point.TileID > 112) && (point.TileID < 141))
                {
                    /*m_seed.Name = m_seed.Nom;
                    m_seed.Planted = true;
                    m_seed.Owner = from;
                    m_seed.ItemID = m_seed.ArtID;
                    m_seed.Dirt = true;
                    int seconds = 172800 - (from.Skills.Agriculture.Fixed * 800);
                    TimeSpan duration = TimeSpan.FromSeconds(seconds);
                    m_seed.m_evoTimer = new AgriEvoTimer(from, m_seed, duration, duration);
                    m_seed.m_evoTimer.Start();
                    m_seed.m_waterTimer = new AgriWaterTimer(from, m_seed, TimeSpan.FromHours(6), TimeSpan.FromHours(6));
                    m_seed.m_waterTimer.Start();
                    m_seed.MoveToWorld(point.Location);
                    m_seed.Movable = false;*/
                }
                else
                {
                    from.SendMessage("Vous devez pointez vers de la terre !");
                }
            }
            else if (targeted is Mobile)
            {
                from.SendMessage("Vous devez pointez vers de la terre !");
            }
            else if (targeted is Item)
            {
                from.SendMessage("Vous devez pointez vers de la terre !");
            }
            else
            {
                from.SendMessage("Vous devez choisir un pot ou le sol.");
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            Name = "graine";
            Weight = 0.1;
        }
    }

    public class GuiSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Gui; } }
        public override string SeedName { get { return "Gui"; } }

        [Constructable]
        public GuiSeed() : base()
        {
        }

        public GuiSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new GuiPlante();
        }
    }

    public class InuleSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Inule; } }
        public override string SeedName { get { return "L'Inule"; } }

        [Constructable]
        public InuleSeed() : base()
        {
        }

        public InuleSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new InulePlante();
        }
    }

    public class BenoiteSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Benoite; } }
        public override string SeedName { get { return "Benoite"; } }

        [Constructable]
        public BenoiteSeed() : base()
        {
        }

        public BenoiteSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new BenoitePlante();
        }
    }

    public class SolidagoSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Solidago; } }
        public override string SeedName { get { return "Solidago"; } }

        [Constructable]
        public SolidagoSeed() : base()
        {
        }

        public SolidagoSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new SolidagoPlante();
        }
    }

    public class GomphrenaSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Gomphrena; } }
        public override string SeedName { get { return "Gomphrena"; } }

        [Constructable]
        public GomphrenaSeed() : base()
        {
        }

        public GomphrenaSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new GomphrenaPlante();
        }
    }

    public class LavatereSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Lavatere; } }
        public override string SeedName { get { return "Lavatere"; } }

        [Constructable]
        public LavatereSeed() : base()
        {
        }

        public LavatereSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new LavaterePlante();
        }
    }

    public class PassifloreSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Passiflore; } }
        public override string SeedName { get { return "Passiflore"; } }

        [Constructable]
        public PassifloreSeed() : base()
        {
        }

        public PassifloreSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new PassiflorePlante();
        }
    }

    public class MillepertuisSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Millepertuis; } }
        public override string SeedName { get { return "Millepertuis"; } }

        [Constructable]
        public MillepertuisSeed() : base()
        {
        }

        public MillepertuisSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new MillepertuisPlante();
        }
    }

    public class ArtichautSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Artichaut; } }
        public override string SeedName { get { return "Artichaut"; } }

        [Constructable]
        public ArtichautSeed() : base()
        {
        }

        public ArtichautSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new ArtichautPlante();
        }
    }

    public class ImmortelleSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Immortelle; } }
        public override string SeedName { get { return "Immortelle à bractées"; } }

        [Constructable]
        public ImmortelleSeed() : base()
        {
        }

        public ImmortelleSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new ImmortellePlante();
        }
    }

    public class MelaleucaSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Melaleuca; } }
        public override string SeedName { get { return "Melaleuca"; } }

        [Constructable]
        public MelaleucaSeed() : base()
        {
        }

        public MelaleucaSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new MelaleucaPlante();
        }
    }

    public class BourracheSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Bourrache; } }
        public override string SeedName { get { return "Bourrache"; } }

        [Constructable]
        public BourracheSeed() : base()
        {
        }

        public BourracheSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new BourrachePlante();
        }
    }

    public class KalmiaSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Kalmia; } }
        public override string SeedName { get { return "Kalmia"; } }

        [Constructable]
        public KalmiaSeed() : base()
        {
        }

        public KalmiaSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new KalmiaPlante();
        }
    }

    public class PaqueretteSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Paquerette; } }
        public override string SeedName { get { return "Paquerette"; } }

        [Constructable]
        public PaqueretteSeed() : base()
        {
        }

        public PaqueretteSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new PaquerettePlante();
        }
    }

    public class AsphodelineSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Asphodeline; } }
        public override string SeedName { get { return "Asphodeline"; } }

        [Constructable]
        public AsphodelineSeed() : base()
        {
        }

        public AsphodelineSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new AsphodelinePlante();
        }
    }

    public class AirelleSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Airelle; } }
        public override string SeedName { get { return "Airelle Rouge"; } }

        [Constructable]
        public AirelleSeed() : base()
        {
        }

        public AirelleSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new AirellePlante();
        }
    }

    public class LiseronSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Liseron; } }
        public override string SeedName { get { return "Liseron"; } }

        [Constructable]
        public LiseronSeed()
            : base()
        {
        }

        public LiseronSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new LiseronPlante();
        }
    }

    public class AgastacheSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Agastache; } }
        public override string SeedName { get { return "Agastache"; } }

        [Constructable]
        public AgastacheSeed()
            : base()
        {
        }

        public AgastacheSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new AgastachePlante();
        }
    }

    public class ChicoreSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Chicore; } }
        public override string SeedName { get { return "Chicorée"; } }

        [Constructable]
        public ChicoreSeed()
            : base()
        {
        }

        public ChicoreSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new ChicorePlante();
        }
    }

    public class AchilleeSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Achillee; } }
        public override string SeedName { get { return "Achillée"; } }

        [Constructable]
        public AchilleeSeed()
            : base()
        {
        }

        public AchilleeSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new AchilleePlante();
        }
    }

    public class CisteSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Ciste; } }
        public override string SeedName { get { return "Ciste"; } }

        [Constructable]
        public CisteSeed()
            : base()
        {
        }

        public CisteSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new CistePlante();
        }
    }

    public class AconitSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Aconit; } }
        public override string SeedName { get { return "Aconit"; } }

        [Constructable]
        public AconitSeed()
            : base()
        {
        }

        public AconitSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new AconitPlante();
        }
    }

    public class AdonisSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Adonis; } }
        public override string SeedName { get { return "Adonis"; } }

        [Constructable]
        public AdonisSeed()
            : base()
        {
        }

        public AdonisSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new AdonisPlante();
        }
    }

    public class BuplevreSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Buplevre; } }
        public override string SeedName { get { return "Buplèvre"; } }

        [Constructable]
        public BuplevreSeed()
            : base()
        {
        }

        public BuplevreSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new BuplevrePlante();
        }
    }

    public class SouciSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Souci; } }
        public override string SeedName { get { return "Souci"; } }

        [Constructable]
        public SouciSeed()
            : base()
        {
        }

        public SouciSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new SouciPlante();
        }
    }

    public class SaugeSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Sauge; } }
        public override string SeedName { get { return "Sauge"; } }

        [Constructable]
        public SaugeSeed()
            : base()
        {
        }

        public SaugeSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new SaugePlante();
        }
    }

    public class ZanthoxylumSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Zanthoxylum; } }
        public override string SeedName { get { return "Zanthoxylum"; } }

        [Constructable]
        public ZanthoxylumSeed()
            : base()
        {
        }

        public ZanthoxylumSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new ZanthoxylumPlante();
        }
    }

    public class NielleSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Nielle; } }
        public override string SeedName { get { return "Nielle"; } }

        [Constructable]
        public NielleSeed()
            : base()
        {
        }

        public NielleSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new NiellePlante();
        }
    }

    public class BetoineSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Betoine; } }
        public override string SeedName { get { return "Bétoine"; } }

        [Constructable]
        public BetoineSeed()
            : base()
        {
        }

        public BetoineSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new BetoinePlante();
        }
    }

    public class TanaisieSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Tanaisie; } }
        public override string SeedName { get { return "Tanaisie"; } }

        [Constructable]
        public TanaisieSeed()
            : base()
        {
        }

        public TanaisieSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new TanaisiePlante();
        }
    }

    public class LinSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Lin; } }
        public override string SeedName { get { return "Lin"; } }

        [Constructable]
        public LinSeed()
            : base()
        {
        }

        public LinSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new LinPlante();
        }
    }

    public class CotonSeed : BaseSeed
    {
        public override PlantType PlantType { get { return PlantType.Coton; } }
        public override string SeedName { get { return "Coton"; } }

        [Constructable]
        public CotonSeed()
            : base()
        {
        }

        public CotonSeed(Serial serial)
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

        public override BasePlant GetPlant()
        {
            return new CotonPlante();
        }
    }
}