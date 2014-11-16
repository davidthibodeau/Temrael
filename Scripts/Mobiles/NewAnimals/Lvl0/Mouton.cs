using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("Cadavre de mouton")]
    public class Mouton : BaseCreature, ICarvable
    {
        private DateTime m_NextWoolTime;

        [CommandProperty(AccessLevel.Batisseur)]
        public DateTime NextWoolTime
        {
            get { return m_NextWoolTime; }
            set { m_NextWoolTime = value; Body = (DateTime.Now >= m_NextWoolTime) ? 0xCF : 0xDF; }
        }

        public void Carve(Mobile from, Item item)
        {
            if (DateTime.Now < m_NextWoolTime)
            {
                // Ce mouton n'est pas prêt à être tondu.
                PrivateOverheadMessage(MessageType.Regular, 0x3B2, 500449, from.NetState);
                return;
            }

            from.SendLocalizedMessage(500452); // Vous placez la laine dans votre sac.
            from.AddToBackpack(new Wool(Map == Map.Felucca ? 2 : 1));

            NextWoolTime = DateTime.Now + TimeSpan.FromHours(3.0); // TODO: Proper time delay
        }

        public override void OnThink()
        {
            base.OnThink();
            Body = (DateTime.Now >= m_NextWoolTime) ? 0xCF : 0xDF;
        }

        [Constructable]
        public Mouton()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Un mouton";
            Body = 0xCF;
            BaseSoundID = 0xD6;

            SetStr(19);
            SetDex(25);
            SetInt(5);

            SetHits(12);
            SetMana(0);

            SetDamage(1, 2);

            SetDamageType(ResistanceType.Physical, 0);

            SetResistance(ResistanceType.Physical, 0);

            SetSkill(SkillName.Concentration, 5.0);
            SetSkill(SkillName.Tactiques, 6.0);
            SetSkill(SkillName.Anatomie, 5.0);

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 5;
        }

        public override double AttackSpeed { get { return 2.5; } }
        public override int Meat { get { return 3; } }
        public override MeatType MeatType { get { return MeatType.LambLeg; } }
        public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public override int Wool { get { return (Body == 0xCF ? 3 : 0); } }

        public Mouton(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1);

            writer.WriteDeltaTime(m_NextWoolTime);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        NextWoolTime = reader.ReadDeltaTime();
                        break;
                    }
            }
        }
    }
}