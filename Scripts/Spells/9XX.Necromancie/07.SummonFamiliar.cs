using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Spells
{
	public class SummonFamiliarSpell : NecromancerSpell
	{
        public static int m_SpellID { get { return 907; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_DureeCastCast = TimeSpan.FromSeconds(1);

		public static readonly SpellInfo m_Info = new SpellInfo(
				"Minion", "Kal Xen Bal",
				SpellCircle.Eighth,
				203,
				9031,
                s_ManaCost,
                s_DureeCastCast,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.BatWing,
				Reagent.GraveDust,
				Reagent.DaemonBlood
            );

		public SummonFamiliarSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		private static Hashtable m_Table = new Hashtable();

		public static Hashtable Table{ get{ return m_Table; } }

		public override bool CheckCast()
		{
			/*BaseCreature check = (BaseCreature)m_Table[Caster];

			if ( check != null && !check.Deleted )
			{
				Caster.SendLocalizedMessage( 1061605 ); // You already have a familiar.
				return false;
			}*/

			return base.CheckCast();
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				Caster.CloseGump( typeof( SummonFamiliarGump ) );
				Caster.SendGump( new SummonFamiliarGump( Caster, m_Entries ) );
			}

			FinishSequence();
		}

		private static SummonFamiliarEntry[] m_Entries = new SummonFamiliarEntry[]
			{
				/*new SummonFamiliarEntry( typeof( HordeMinionFamiliar ), 1060146,  30.0,  30.0 ), // Horde Minion
				new SummonFamiliarEntry( typeof( ShadowWispFamiliar ), 1060142,  50.0,  50.0 ), // Shadow Wisp
				new SummonFamiliarEntry( typeof( DarkWolfFamiliar ), 1060143,  60.0,  60.0 ), // Dark Wolf
				new SummonFamiliarEntry( typeof( DeathAdder ), 1060145,  70.0,  70.0 ), // Death Adder
				new SummonFamiliarEntry( typeof( VampireBatFamiliar ), 1060144, 80.0, 80.0 ),  // Vampire Bat */
                new SummonFamiliarEntry( typeof( Zombie ), "Zombie", 30.0, 30.0 ),
                new SummonFamiliarEntry( typeof( Skeleton ), "Squelette", 40.0, 40.0 ),
                new SummonFamiliarEntry( typeof( SkeletonArcher ), "Squelette Archer", 50.0, 50.0 ),
                new SummonFamiliarEntry( typeof( SkeletalKnight ), "Squelette Guerrier", 50.0, 50.0 ),
                new SummonFamiliarEntry( typeof( Ghoul ), "Ghoul", 60.0, 60.0 ),
                new SummonFamiliarEntry( typeof( Spectre ), "Spectre", 70.0, 70.0 ),
                new SummonFamiliarEntry( typeof( SkeletalMage ), "Squelette Mage", 80.0, 80.0 ),
                new SummonFamiliarEntry( typeof( Mummy ), "Momie", 90.0, 90.0 ),
                new SummonFamiliarEntry( typeof( Lich ), "Liche", 100.0, 100.0 ),
                new SummonFamiliarEntry( typeof( Reaper ), "Faucheur", 100.0, 100.0 ),
			};

		public static SummonFamiliarEntry[] Entries{ get{ return m_Entries; } }
	}

	public class SummonFamiliarEntry
	{
		private Type m_Type;
		private object m_Name;
		private double m_ReqNecromancy;
		private double m_ReqSpiritSpeak;

		public Type Type{ get{ return m_Type; } }
		public object Name{ get{ return m_Name; } }
		public double ReqNecromancy{ get{ return m_ReqNecromancy; } }
		public double ReqSpiritSpeak{ get{ return m_ReqSpiritSpeak; } }

		public SummonFamiliarEntry( Type type, object name, double reqNecromancy, double reqSpiritSpeak )
		{
			m_Type = type;
			m_Name = name;
			m_ReqNecromancy = reqNecromancy;
			m_ReqSpiritSpeak = reqSpiritSpeak;
		}
	}

	public class SummonFamiliarGump : Gump
	{
		private Mobile m_From;
		private SummonFamiliarEntry[] m_Entries;

		private const int  EnabledColor16 = 0x0F20;
		private const int DisabledColor16 = 0x262A;

		private const int  EnabledColor32 = 0x18CD00;
		private const int DisabledColor32 = 0x4A8B52;

		public SummonFamiliarGump( Mobile from, SummonFamiliarEntry[] entries ) : base( 200, 100 )
		{
			m_From = from;
			m_Entries = entries;

			AddPage( 0 );

			AddBackground( 10, 10, 250, 258, 9270 );
			AddAlphaRegion( 20, 20, 230, 248 );

			AddImage( 220, 20, 10464 );
			AddImage( 220, 72, 10464 );
			AddImage( 220, 124, 10464 );
            AddImage(220, 176, 10464);

			AddItem( 188, 16, 6883 );
			AddItem( 198, 258, 6881 );
			AddItem( 8, 15, 6882 );
			AddItem( 2, 258, 6880 );

			AddHtml( 30, 26, 200, 20, "Choisissez le familier...", false, false ); // Chose thy familiar...

            double necro = from.Skills[SkillName.ArtMagique].Base;
			double spirit = from.Skills[SkillName.Necromancie].Base;

			for ( int i = 0; i < entries.Length; ++i )
			{
				object name = entries[i].Name;

				bool enabled = ( necro >= entries[i].ReqNecromancy && spirit >= entries[i].ReqSpiritSpeak );

				AddButton( 27, 53 + (i * 21), 9702, 9703, i + 1, GumpButtonType.Reply, 0 );

				if ( name is int )
					AddHtmlLocalized( 50, 51 + (i * 21), 150, 20, (int)name, enabled ? EnabledColor16 : DisabledColor16, false, false );
				else if ( name is string )
					AddHtml( 50, 51 + (i * 21), 150, 20, String.Format( "<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", enabled ? EnabledColor32 : DisabledColor32, name ), false, false );
			}
		}

		private static Hashtable m_Table = new Hashtable();

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			int index = info.ButtonID - 1;

			if ( index >= 0 && index < m_Entries.Length )
			{
				SummonFamiliarEntry entry = m_Entries[index];

                double necro = m_From.Skills[SkillName.ArtMagique].Base;
				double spirit = m_From.Skills[SkillName.Necromancie].Base;

				//BaseCreature check = (BaseCreature)SummonFamiliarSpell.Table[m_From];

				/*if ( check != null && !check.Deleted )
				{
					m_From.SendLocalizedMessage( 1061605 ); // You already have a familiar.
				}*/
				if ( necro < entry.ReqNecromancy || spirit < entry.ReqSpiritSpeak )
				{
					// That familiar requires ~1_NECROMANCY~ Necromancy and ~2_SPIRIT~ Spirit Speak.
					m_From.SendLocalizedMessage( 1061606, String.Format( "{0:F1}\t{1:F1}", entry.ReqNecromancy, entry.ReqSpiritSpeak ) );

					m_From.CloseGump( typeof( SummonFamiliarGump ) );
					m_From.SendGump( new SummonFamiliarGump( m_From, SummonFamiliarSpell.Entries ) );
				}
				else if ( entry.Type == null )
				{
					m_From.SendMessage( "That familiar has not yet been defined." );

					m_From.CloseGump( typeof( SummonFamiliarGump ) );
					m_From.SendGump( new SummonFamiliarGump( m_From, SummonFamiliarSpell.Entries ) );
				}
				else
				{
					try
					{
						BaseCreature bc = (BaseCreature)Activator.CreateInstance( entry.Type );

						//bc.Skills.Concentration = m_From.Skills.Concentration;

                        if (m_From is TMobile)
                        {
                            TMobile tmob = (TMobile)m_From;

                            double duration = (2 * m_From.Skills.Necromancie.Fixed) / 5;

                            if (BaseCreature.Summon(bc, m_From, m_From.Location, -1, TimeSpan.FromMinutes(duration)))
                            {
                                m_From.FixedParticles(0x3728, 1, 10, 9910, EffectLayer.Head);
                                bc.PlaySound(bc.GetIdleSound());
                                SummonFamiliarSpell.Table[m_From] = bc;
                                /*if( m_From is TMobile )
                                    CombatManager.get().ConfigureCreature(bc, 
                                        Math.Max(1, ((TMobile)m_From).Niveau - 3 ));*/

                                //Console.WriteLine("{0} damage {1}:{2} speed:{3}", bc.Name, bc.DamageMin, bc.DamageMax, bc.AttackSpeed);
                            }
                        }
					}
					catch
					{
					}
				}
			}
			else
			{
				m_From.SendLocalizedMessage( 1061825 ); // You decide not to summon a familiar.
			}
		}
	}
}