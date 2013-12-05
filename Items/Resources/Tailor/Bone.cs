using System;
using Server.Items;

namespace Server.Items
{
    public abstract class BaseBone : Item
    {
        private CraftResource m_Resource;

        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource Resource
        {
            get { return m_Resource; }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write((int)m_Resource);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_Resource = (CraftResource)reader.ReadInt();
                        break;
                    }
                case 0:
                    {
                        break;
                    }
            }
        }

        public BaseBone(CraftResource resource)
            : this(resource, 1)
        {
        }

        public BaseBone(CraftResource resource, int amount)
            : base(0xF7E)
        {
            Stackable = true;
            Weight = 1.0;
            Amount = amount;
            Hue = CraftResources.GetHue(resource);

            m_Resource = resource;
        }

        public BaseBone(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1049064;
            }
        }

        public static string[] m_Material = new string[]
            {
                "Regulier",
                "Gobelin",
                "Reptilien",
                "Nordique",
                "Desertique",
                "Maritime",
                "Volcanique",
                "Geant",
                "Minotaure",
                "Ophidien",
                "Arachnide",
                "Magique",
                "Ancien",
                "Demon",
                "Dragon",
                "Balron",
                "Wyrm"
            };

        public virtual string GetMaterial()
        {
            string value = "aucun";

            try
            {
                value = m_Material[((int)m_Resource) - 401];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return value;
        }

        public override void OnSingleClick(Mobile from)
        {
            base.OnSingleClick(from);

            LabelTo(from, String.Format("{0}{1}{2}", "[", GetMaterial(), "]"));
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("<h3><basefont color=#FFFFFF>{3} {0}{1}{2}</h3></basefont>", "Os [", GetMaterial(), "]", Amount);
            /*if (Amount > 1)
                list.Add(1060532, String.Format("{3} {0}{1}{2}", "Os [", GetMaterial(), "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
            else
                list.Add(String.Format("{0}{1}{2}", "Os [", GetMaterial(), "]")); // ingots*/
        }
    }

    public class Bone : BaseBone
    {
        [Constructable]
        public Bone()
            : this(1)
        {
        }

        [Constructable]
        public Bone(int amount)
            : base(CraftResource.RegularBones, amount)
        {
            Name = "Os";
        }

        public Bone(Serial serial)
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

    public class GobelinBone : BaseBone
    {
        [Constructable]
        public GobelinBone()
            : this(1)
        {
        }

        [Constructable]
        public GobelinBone(int amount)
            : base(CraftResource.GobelinBones, amount)
        {
            Name = "Os Gobelin";
        }

        public GobelinBone(Serial serial)
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

    public class ReptilienBone : BaseBone
    {
        [Constructable]
        public ReptilienBone()
            : this(1)
        {
        }

        [Constructable]
        public ReptilienBone(int amount)
            : base(CraftResource.ReptilienBones, amount)
        {
            Name = "Os Reptilien";
        }

        public ReptilienBone(Serial serial)
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

    public class NordiqueBone : BaseBone
    {
        [Constructable]
        public NordiqueBone()
            : this(1)
        {
        }

        [Constructable]
        public NordiqueBone(int amount)
            : base(CraftResource.NordiqueBones, amount)
        {
            Name = "Os Nordique";
        }

        public NordiqueBone(Serial serial)
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

    public class DesertiqueBone : BaseBone
    {
        [Constructable]
        public DesertiqueBone()
            : this(1)
        {
        }

        [Constructable]
        public DesertiqueBone(int amount)
            : base(CraftResource.DesertiqueBones, amount)
        {
            Name = "Os Désertique";
        }

        public DesertiqueBone(Serial serial)
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

    public class MaritimeBone : BaseBone
    {
        [Constructable]
        public MaritimeBone()
            : this(1)
        {
        }

        [Constructable]
        public MaritimeBone(int amount)
            : base(CraftResource.MaritimeBones, amount)
        {
            Name = "Os Maritime";
        }

        public MaritimeBone(Serial serial)
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

    public class VolcaniqueBone : BaseBone
    {
        [Constructable]
        public VolcaniqueBone()
            : this(1)
        {
        }

        [Constructable]
        public VolcaniqueBone(int amount)
            : base(CraftResource.VolcaniqueBones, amount)
        {
            Name = "Os Volcanique";
        }

        public VolcaniqueBone(Serial serial)
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

    public class GeantBone : BaseBone
    {
        [Constructable]
        public GeantBone()
            : this(1)
        {
        }

        [Constructable]
        public GeantBone(int amount)
            : base(CraftResource.GeantBones, amount)
        {
            Name = "Os Géant";
        }

        public GeantBone(Serial serial)
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

    public class MinotaureBone : BaseBone
    {
        [Constructable]
        public MinotaureBone()
            : this(1)
        {
        }

        [Constructable]
        public MinotaureBone(int amount)
            : base(CraftResource.MinotaureBones, amount)
        {
            Name = "Os de Minotaure";
        }

        public MinotaureBone(Serial serial)
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

    public class OphidienBone : BaseBone
    {
        [Constructable]
        public OphidienBone()
            : this(1)
        {
        }

        [Constructable]
        public OphidienBone(int amount)
            : base(CraftResource.OphidienBones, amount)
        {
            Name = "Os Ophidien";
        }

        public OphidienBone(Serial serial)
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

    public class ArachnideBone : BaseBone
    {
        [Constructable]
        public ArachnideBone()
            : this(1)
        {
        }

        [Constructable]
        public ArachnideBone(int amount)
            : base(CraftResource.ArachnideBones, amount)
        {
            Name = "Os d'Arachnide";
        }

        public ArachnideBone(Serial serial)
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

    public class MagiqueBone : BaseBone
    {
        [Constructable]
        public MagiqueBone()
            : this(1)
        {
        }

        [Constructable]
        public MagiqueBone(int amount)
            : base(CraftResource.MagiqueBones, amount)
        {
            Name = "Os Magique";
        }

        public MagiqueBone(Serial serial)
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

    public class AncienBone : BaseBone
    {
        [Constructable]
        public AncienBone()
            : this(1)
        {
        }

        [Constructable]
        public AncienBone(int amount)
            : base(CraftResource.AncienBones, amount)
        {
            Name = "Os Ancien";
        }

        public AncienBone(Serial serial)
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

    public class DemonBone : BaseBone
    {
        [Constructable]
        public DemonBone()
            : this(1)
        {
        }

        [Constructable]
        public DemonBone(int amount)
            : base(CraftResource.DemonBones, amount)
        {
            Name = "Os Démoniaque";
        }

        public DemonBone(Serial serial)
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

    public class DragonBone : BaseBone
    {
        [Constructable]
        public DragonBone()
            : this(1)
        {
        }

        [Constructable]
        public DragonBone(int amount)
            : base(CraftResource.DragonBones, amount)
        {
            Name = "Os Dragonique";
        }

        public DragonBone(Serial serial)
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

    public class BalronBone : BaseBone
    {
        [Constructable]
        public BalronBone()
            : this(1)
        {
        }

        [Constructable]
        public BalronBone(int amount)
            : base(CraftResource.BalronBones, amount)
        {
            Name = "Os Balronique";
        }

        public BalronBone(Serial serial)
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

    public class WyrmBone : BaseBone
    {
        [Constructable]
        public WyrmBone()
            : this(1)
        {
        }

        [Constructable]
        public WyrmBone(int amount)
            : base(CraftResource.WyrmBones, amount)
        {
        }

        public WyrmBone(Serial serial)
            : base(serial)
        {
            Name = "Os Wyrmique";
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