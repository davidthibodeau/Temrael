using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("un corps de lumiere divine")]
    public class LumiereDivine : BaseCreature
    {
        [Constructable]
        public LumiereDivine()
            : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "une lumiere divine";
            Body = 58;
            BaseSoundID = 1136;

            SetStr(1, 1);
            SetDex(1, 1);
            SetInt(1, 1);

            SetHits(1, 1);

            SetDamage(1, 1);

            //SetSkill(SkillName.EvalInt, 83.1, 85.5);
            //SetSkill(SkillName.Magery, 83.0, 85.5);
            //SetSkill(SkillName.MagicResist, 20.1, 30.0);
            SetSkill(SkillName.Tactiques, 62.1, 64.0);
            SetSkill(SkillName.Anatomie, 62.1, 64.0);
            //SetSkill(SkillName.Anatomy, 45.1, 50.0);

            VirtualArmor = 0;

            AddItem(new LightSource());
        }

        public override int GetDeathSound()
        {
            return 1134;
        }

        public override void GenerateLoot()
        {
        }

        public override Poison PoisonImmune { get { return Poison.Lethal; } }

        public LumiereDivine(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}

namespace Server.Spells
{
    public class LumiereDivineSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static readonly SpellInfo m_Info = new SpellInfo(
                "Lumière divine", "Haga Kena",
                SpellCircle.Fourth,
                269,
                9032,
                false
            );

        public override bool Invocation { get { return true; } }

        public LumiereDivineSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override bool CheckCast()
        {
            if (!base.CheckCast())
                return false;

            if ((Caster.Followers + 1) > Caster.FollowersMax)
            {
                Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
                return false;
            }

            return true;
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                TimeSpan duration = GetDurationForSpell(30, 1.8);

                SpellHelper.Summon(new LumiereDivine(), Caster, 0x217, duration, false, false);
            }

            FinishSequence();
        }
    }
}