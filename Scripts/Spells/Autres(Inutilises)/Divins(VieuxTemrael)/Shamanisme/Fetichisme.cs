using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Commands;

namespace Server.Spells
{
	public class FetichismeSpell : ReligiousSpell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly SpellInfo m_Info = new SpellInfo(
                "Fétichisme", "Desi Haga Impa",
				SpellCircle.Seventh,
				212,
				9041
            );

        public FetichismeSpell(Mobile Target, Item scroll)
            : base(Target, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (m.Blessed)
            {
                Caster.SendMessage("Vous ne pouvez pas copier des créatures invulnérables !");
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                ToogleFetichisme(this, Caster, m); 

                m.FixedParticles(0x374A, 10, 15, 5013, EffectLayer.Waist);
                m.PlaySound(0x1F1);
            }

            FinishSequence();
        }

        public static void ToogleFetichisme(Spell spell, Mobile Caster, Mobile from)
        {
            TimeSpan duration = spell.GetDurationForSpell(1);

            SpellHelper.Summon(new Fetichisme(from), Caster, 0x217, duration, false, false);
        }

		private class InternalTarget : Target
		{
            private FetichismeSpell m_Owner;

            public InternalTarget(FetichismeSpell owner)
                : base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					m_Owner.Target( (Mobile)o );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}

namespace Server.Mobiles
{
    [CorpseName("un corps de copie")]
    public class Fetichisme : BaseCreature
    {
        public override bool DeleteCorpseOnDeath { get { return Summoned; } }

        public static Layer[] ItemLayers = {Layer.FirstValid, Layer.TwoHanded, Layer.Shoes, Layer.Pants,
			Layer.Shirt, Layer.Helm, Layer.Gloves, Layer.Ring, Layer.Neck, Layer.Hair,
			Layer.Waist, Layer.InnerTorso, Layer.Bracelet, Layer.FacialHair, Layer.MiddleTorso,
			Layer.Earrings, Layer.Arms, Layer.Cloak, Layer.OuterTorso, Layer.OuterLegs, Layer.Mount };

        [Constructable]
        public Fetichisme(Mobile Target)
            : base(AIType.AI_Animal, FightMode.None, 10, 1, 0.1, 0.1)
        {
            Name = Target.Name;
            Hue = Target.Hue;

            Body = Target.Body;

            SetStr(Target.Str);
            SetDex(Target.Dex);
            SetInt(Target.Int);

            SetHits(Target.HitsMax);
            Hits = Target.Hits;
            Mana = Target.Mana;
            Stam = Target.Stam;

            if (Target.Weapon != null)
            {
                BaseWeapon weapon = (BaseWeapon)Target.Weapon;
                SetDamage(weapon.MinDamage - 5, weapon.MaxDamage + 5);
            }
            else
            {
                SetDamage(10, 30);
            }

            //SetSkill(SkillName.EvalInt, Target.Skills[SkillName.EvalInt].Value);
            SetSkill(SkillName.ArtMagique, Target.Skills[SkillName.ArtMagique].Value);
            //SetSkill(SkillName.MagicResist, Target.Skills[SkillName.MagicResist].Value);
            SetSkill(SkillName.Tactiques, Target.Skills[SkillName.Tactiques].Value);
            SetSkill(SkillName.Anatomie, Target.Skills[SkillName.Anatomie].Value);
            //SetSkill(SkillName.Swords, Target.Skills[SkillName.Swords].Value);
            //SetSkill(SkillName.Macing, Target.Skills[SkillName.Macing].Value);
            //SetSkill(SkillName.Archery, Target.Skills[SkillName.Archery].Value);
            //SetSkill(SkillName.Fencing, Target.Skills[SkillName.Fencing].Value);


            VirtualArmor = Target.VirtualArmor;
            ControlSlots = 1;

            ArrayList PossessItems = new ArrayList(Target.Items);
            try
            {
                for (int i = 0; i < PossessItems.Count; i++)
                {
                    Item item = (Item)PossessItems[i];
                    if (Array.IndexOf(ItemLayers, item.Layer) != -1)
                    {
                        Item itemb = Dupe.DupeItem(Target, item, false);

                        if (itemb != null)
                            this.EquipItem(itemb);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Possess: MoveItems Exception: {0}", e.Message);
            }

            FocusMob = Target;
            Combatant = Target;
        }

        public override void GenerateLoot()
        {
        }

        public Fetichisme(Serial serial)
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