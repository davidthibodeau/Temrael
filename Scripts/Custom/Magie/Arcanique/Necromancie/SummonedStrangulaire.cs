using System;
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "a Strangulaire corpse" )]
	public class SummonedStrangulaire : BaseCreature
	{
	    public override double DispelDifficulty{ get{ return 80; } }
		public override double DispelFocus{ get{ return 40.0; } }
        public override bool DeleteCorpseOnDeath { get { return true; } }

		[Constructable]
		public SummonedStrangulaire () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "Un strangulaire";
            Body = 574;
            BaseSoundID = 0;

            Hue = 999999;

            SetStr(200, 225);
            SetDex(110, 120);
            SetInt(220, 240);

            SetHits(200, 225);

            SetDamage(25, 30);

            SetSkill(SkillName.Goetie, 83.1, 85.5);
            SetSkill(SkillName.ArtMagique, 83.0, 85.5);
            SetSkill(SkillName.Concentration, 73.1, 75.0);
            SetSkill(SkillName.Tactiques, 62.1, 64.0);
            SetSkill(SkillName.ArmePoing, 62.1, 64.0);
            SetSkill(SkillName.Destruction, 45.1, 50.0);

            VirtualArmor = 71;

            ControlSlots = 3;

            new InternalTimer(this).Start();
		}

		public SummonedStrangulaire( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

            new InternalTimer(this).Start();
		}

        public class InternalTimer : Timer
        {
            private SummonedStrangulaire m_Mobile;
            public InternalTimer(SummonedStrangulaire mobile)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1.5))
            {
                m_Mobile = mobile;
            }

            protected override void OnTick()
            {
                if (!m_Mobile.Alive || m_Mobile.Deleted)
                    Stop();
                else
                {
                    Map map = m_Mobile.Map;

                    if (map != null)
                    {
                        ArrayList targets = new ArrayList();

                        foreach (Mobile m in m_Mobile.GetMobilesInRange(2))
                        {
                            if (m_Mobile != m && SpellHelper.ValidIndirectTarget(m_Mobile, m) && m_Mobile.CanBeHarmful(m, false))
                                targets.Add(m);
                        }

                        if (targets.Count > 0)
                        {
                            for (int i = 0; i < targets.Count; ++i)
                            {
                                Mobile m = (Mobile)targets[i];

                                m_Mobile.DoHarmful(m);

                                int damage = 10;

                                AOS.Damage(m, m_Mobile, damage, 100, 0, 0, 0, 0);
                            }
                        }
                    }
                }
            }
        }
	}
}