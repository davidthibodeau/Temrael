/***************************************************************************
 *                                 Skills.cs
 *                            -------------------
 *   begin                : May 1, 2002
 *   copyright            : (C) The RunUO Software Team
 *   email                : info@runuo.com
 *
 *   $Id$
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Server.Network;

namespace Server
{
	public delegate TimeSpan SkillUseCallback( Mobile user );

	public enum SkillLock : byte
	{
		Up = 0,
		Down = 1,
		Locked = 2
	}

	public enum SkillName
	{
        // Combat
        Tactiques,
        Parer,
        ArmeTranchante,
        ArmeContondante,
        ArmePerforante,
        ArmeHaste,
        ArmeDistance,
        Equitation,
        CoupCritique,
        Soins,
        Penetration,
        Anatomie,
        ResistanceMagique,
        Concentration,
        ArmureNaturelle,

        // Magie
        ArtMagique,
        // 9 branches de magie
        // Ces branches sont temporaires pour faire fonctionner le code existant.
        Conjuration,
        Goetie,
        Miracles,
        Mysticisme,
        Restoration,
        Reve,
        Tenebrae,
        Musique,
        Destruction,
        ///////////////////////////
        Meditation,
        Inscription,
        MagieDeGuerre,
        
        // Roublardise
        Discretion,
        Infiltration,
        Pieges,
        Crochetage,
        Empoisonnement,
        Fouille,
        Vol,
        Dressage,
        Poursuite,
        Survie,
        Deguisement,
        Langues,
        Detection,

        // Artisanat
        Fignolage,
        Polissage,
        Excavation,
        Foresterie,
        Forge,
        Couture,
        Menuiserie,
        Cuisine,
        Alchimie
	}

    public enum SkillCategory 
    {
        Aucun,
        Artisanat,
        Combat,
        Magie,
        Roublardise
    }

	[PropertyObject]
	public class Skill
	{
		private Skills m_Owner;
		private SkillInfo m_Info;
		private ushort m_Base;
		private ushort m_Cap;
		private SkillLock m_Lock;

		public override string ToString()
		{
			return String.Format( "[{0}: {1}]", Name, Base );
		}

		public Skill( Skills owner, SkillInfo info, GenericReader reader )
		{
			m_Owner = owner;
			m_Info = info;

			int version = reader.ReadByte();

			switch ( version )
			{
				case 0:
				{
					m_Base = reader.ReadUShort();
					m_Cap = reader.ReadUShort();
					m_Lock = (SkillLock)reader.ReadByte();

					break;
				}
				case 0xFF:
				{
					m_Base = 0;
					m_Cap = 1000;
					m_Lock = SkillLock.Up;

					break;
				}
				default:
				{
					if ( (version & 0xC0) == 0x00 )
					{
						if ( (version & 0x1) != 0 )
							m_Base = reader.ReadUShort();

						if ( (version & 0x2) != 0 )
							m_Cap = reader.ReadUShort();
						else
							m_Cap = 1000;

						if ( (version & 0x4) != 0 )
							m_Lock = (SkillLock)reader.ReadByte();
					}

					break;
				}
			}

			if ( m_Lock < SkillLock.Up || m_Lock > SkillLock.Locked )
			{
				Console.WriteLine( "Bad skill lock -> {0}.{1}", owner.Owner, m_Lock );
				m_Lock = SkillLock.Up;
			}
		}

		public Skill( Skills owner, SkillInfo info, int baseValue, int cap, SkillLock skillLock )
		{
			m_Owner = owner;
			m_Info = info;
			m_Base = (ushort)baseValue;
			m_Cap = (ushort)cap;
			m_Lock = skillLock;
		}

		public void SetLockNoRelay( SkillLock skillLock )
		{
			if ( skillLock < SkillLock.Up || skillLock > SkillLock.Locked )
				return;

			m_Lock = skillLock;
		}

		public void Serialize( GenericWriter writer )
		{
			if ( m_Base == 0 && m_Cap == 1000 && m_Lock == SkillLock.Up )
			{
				writer.Write( (byte) 0xFF ); // default
			}
			else
			{
				int flags = 0x0;

				if ( m_Base != 0 )
					flags |= 0x1;

				if ( m_Cap != 1000 )
					flags |= 0x2;

				if ( m_Lock != SkillLock.Up )
					flags |= 0x4;

				writer.Write( (byte) flags ); // version

				if ( m_Base != 0 )
					writer.Write( (short) m_Base );

				if ( m_Cap != 1000 )
					writer.Write( (short) m_Cap );

				if ( m_Lock != SkillLock.Up )
					writer.Write( (byte) m_Lock );
			}
		}

		public Skills Owner
		{
			get
			{
				return m_Owner;
			}
		}

		public SkillName SkillName
		{
			get
			{
				return (SkillName)m_Info.SkillID;
			}
		}

		public int SkillID
		{
			get
			{
				return m_Info.SkillID;
			}
		}

		[CommandProperty( AccessLevel.Counselor )]
		public string Name
		{
			get
			{
				return m_Info.Name;
			}
		}

		public SkillInfo Info
		{
			get
			{
				return m_Info;
			}
		}

		[CommandProperty( AccessLevel.Counselor )]
		public SkillLock Lock
		{
			get
			{
				return m_Lock;
			}
		}

		public int BaseFixedPoint
		{
			get
			{
				return m_Base;
			}
			set
			{
				if ( value < 0 )
					value = 0;
				else if ( value >= 0x10000 )
					value = 0xFFFF;

				ushort sv = (ushort)value;

				int oldBase = m_Base;

				if ( m_Base != sv )
				{
					m_Owner.Total = (m_Owner.Total - m_Base) + sv;

					m_Base = sv;

					m_Owner.OnSkillChange( this );

					Mobile m = m_Owner.Owner;

					if ( m != null )
						m.OnSkillChange( SkillName, (double)oldBase / 10 );
				}
			}
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Batisseur )]
		public double Base
		{
			get
			{
				return ((double)m_Base / 10.0);
			}
			set
			{
				BaseFixedPoint = (int)(value * 10.0);
			}
		}

		public int CapFixedPoint
		{
			get
			{
				return m_Cap;
			}
			set
			{
				if ( value < 0 )
					value = 0;
				else if ( value >= 0x10000 )
					value = 0xFFFF;

				ushort sv = (ushort)value;

				if ( m_Cap != sv )
				{
					m_Cap = sv;

					m_Owner.OnSkillChange( this );
				}
			}
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Batisseur )]
		public double Cap
		{
			get
			{
				return ((double)m_Cap / 10.0);
			}
			set
			{
				CapFixedPoint = (int)(value * 10.0);
			}
		}

		private static bool m_UseStatMods;

		public static bool UseStatMods{ get{ return m_UseStatMods; } set{ m_UseStatMods = value; } }

		public int Fixed
		{
			get{ return (int)(Value * 10); }
		}

		[CommandProperty( AccessLevel.Counselor )]
		public double Value
		{
			get
			{
				//There has to be this distinction between the racial values and not to account for gaining skills and these skills aren't displayed nor Totaled up.
				double value = this.NonRacialValue;

				double raceBonus = m_Owner.Owner.RacialSkillBonus;

				if( raceBonus > value )
					value = raceBonus;

				return value;
			}
		}

		[CommandProperty( AccessLevel.Counselor )]
		public double NonRacialValue
		{
			get
			{
				double baseValue = Base;
				double inv = 100.0 - baseValue;

				if( inv < 0.0 ) inv = 0.0;

				inv /= 100.0;

				double statsOffset = ((m_UseStatMods ? m_Owner.Owner.Str : m_Owner.Owner.RawStr) * m_Info.StrScale) + ((m_UseStatMods ? m_Owner.Owner.Dex : m_Owner.Owner.RawDex) * m_Info.DexScale) + ((m_UseStatMods ? m_Owner.Owner.Int : m_Owner.Owner.RawInt) * m_Info.IntScale);
				double statTotal = m_Info.StatTotal * inv;

				statsOffset *= inv;

				if( statsOffset > statTotal )
					statsOffset = statTotal;

				double value = baseValue + statsOffset;

				m_Owner.Owner.ValidateSkillMods();

				List<SkillMod> mods = m_Owner.Owner.SkillMods;

				double bonusObey = 0.0, bonusNotObey = 0.0;

				for( int i = 0; i < mods.Count; ++i )
				{
					SkillMod mod = mods[i];

					if( mod.Skill == (SkillName)m_Info.SkillID )
					{
						if( mod.Relative )
						{
							if( mod.ObeyCap )
								bonusObey += mod.Value;
							else
								bonusNotObey += mod.Value;
						}
						else
						{
							bonusObey = 0.0;
							bonusNotObey = 0.0;
							value = mod.Value;
						}
					}
				}

				value += bonusNotObey;

				if( value < Cap )
				{
					value += bonusObey;

					if( value > Cap )
						value = Cap;
				}

				return value;
			}
		}

		public void Update()
		{
			m_Owner.OnSkillChange( this );
		}
	}

	public class SkillInfo
	{
		private SkillName m_Skill;
		private string m_Name;
		private double m_StrScale;
		private double m_DexScale;
		private double m_IntScale;
		private double m_StatTotal;
		private SkillUseCallback m_Callback;
		private double m_StrGain;
		private double m_DexGain;
		private double m_IntGain;
		private double m_GainFactor;
        private SkillCategory m_Category;


		public SkillInfo( SkillName skillID, string name, SkillCategory cat, double strScale, double dexScale, double intScale, SkillUseCallback callback, double strGain, double dexGain, double intGain, double gainFactor )
		{
			m_Name = name;
			m_Skill = skillID;
            m_Category = cat;
			m_StrScale = strScale / 100.0;
			m_DexScale = dexScale / 100.0;
			m_IntScale = intScale / 100.0;
			m_Callback = callback;
			m_StrGain = strGain;
			m_DexGain = dexGain;
			m_IntGain = intGain;
			m_GainFactor = gainFactor;

			m_StatTotal = strScale + dexScale + intScale;
		}

		public SkillUseCallback Callback
		{
			get
			{
				return m_Callback;
			}
			set
			{
				m_Callback = value;
			}
		}

		public int SkillID
		{
			get
			{
				return (int)m_Skill;
			}
		}

        public SkillName Skill
        {
            get { return m_Skill; }
        }

        public SkillCategory Category
        {
            get { return m_Category; }
        }

		public string Name
		{
			get
			{
				return m_Name;
			}
			set
			{
				m_Name = value;
			}
		}

		public double StrScale
		{
			get
			{
				return m_StrScale;
			}
			set
			{
				m_StrScale = value;
			}
		}

		public double DexScale
		{
			get
			{
				return m_DexScale;
			}
			set
			{
				m_DexScale = value;
			}
		}

		public double IntScale
		{
			get
			{
				return m_IntScale;
			}
			set
			{
				m_IntScale = value;
			}
		}

		public double StatTotal
		{
			get
			{
				return m_StatTotal;
			}
			set
			{
				m_StatTotal = value;
			}
		}

		public double StrGain
		{
			get
			{
				return m_StrGain;
			}
			set
			{
				m_StrGain = value;
			}
		}

		public double DexGain
		{
			get
			{
				return m_DexGain;
			}
			set
			{
				m_DexGain = value;
			}
		}

		public double IntGain
		{
			get
			{
				return m_IntGain;
			}
			set
			{
				m_IntGain = value;
			}
		}

		public double GainFactor
		{
			get
			{
				return m_GainFactor;
			}
			set
			{
				m_GainFactor = value;
			}
		}

        private static SkillInfo[] m_Table = new SkillInfo[]
			{

                new SkillInfo( SkillName.Alchimie,		  "Alchimie",		SkillCategory.Artisanat,	0.0,	5.0,	5.0,	null,	0.0,	0.5,	0.5,	1.0 ),
				new SkillInfo( SkillName.Fignolage, 	  "Fignolage",  	SkillCategory.Artisanat,    0.0,	0.0,	0.0,	null,	0.0,	0.0,	1.0,	1.0 ),
				new SkillInfo( SkillName.Forge,           "Forge",      	SkillCategory.Artisanat,	10.0,	0.0,	0.0,	null,	1.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( SkillName.Menuiserie,      "Menuiserie",		SkillCategory.Artisanat,	20.0,	5.0,	0.0,	null,	2.0,	0.5,	0.0,	1.0 ),
				new SkillInfo( SkillName.Cuisine,         "Cuisine",		SkillCategory.Artisanat,	0.0,	20.0,	30.0,	null,	0.0,	2.0,	3.0,	1.0 ),
				new SkillInfo( SkillName.Couture,         "Couture",		SkillCategory.Artisanat,	3.75,	16.25,	5.0,	null,	0.38,	1.63,	0.5,	1.0 ),
				new SkillInfo( SkillName.Foresterie,      "Foresterie",		SkillCategory.Artisanat,    20.0,	0.0,	0.0,	null,	2.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( SkillName.Excavation,      "Excavation",		SkillCategory.Artisanat,	20.0,	0.0,	0.0,	null,	2.0,	0.0,	0.0,	1.0 ),
                new SkillInfo( SkillName.Polissage,       "Polissage",		SkillCategory.Artisanat,	0.0,	0.0,	0.0,	null,	0.0,	1.0,	2.0,	1.0 ),

                new SkillInfo( SkillName.ArmeHaste,		  "Arme d'Haste",		SkillCategory.Combat,	0.0,	0.0,	0.0,	null,	0.15,	0.15,	0.7,	1.0 ),
				new SkillInfo( SkillName.Parer, 		  "Parer",				SkillCategory.Combat,	7.5,	2.5,	0.0,	null,	0.75,	0.25,	0.0,	1.0 ),
                new SkillInfo( SkillName.Equitation,      "Equitation",			SkillCategory.Combat, 	6.0,	16.0,	0.0,	null,	0.6,	1.6,	0.0,	1.0 ),
				new SkillInfo( SkillName.Soins,           "Soins",				SkillCategory.Combat,	6.0,	6.0,	8.0,	null,	0.6,	0.6,	0.8,	1.0 ),
				new SkillInfo( SkillName.Tactiques,       "Tactiques",			SkillCategory.Combat,  	0.0,	0.0,	0.0,	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( SkillName.ArmeDistance,    "Arme de Distance",	SkillCategory.Combat,  	2.5,	7.5,	0.0,	null,	0.25,	0.75,	0.0,	1.0 ),
				new SkillInfo( SkillName.ArmeTranchante,  "Armes Tranchantes",	SkillCategory.Combat,	7.5,	2.5,	0.0,	null,	0.75,	0.25,	0.0,	1.0 ),
				new SkillInfo( SkillName.ArmeContondante, "Armes Contondantes",	SkillCategory.Combat,	9.0,	1.0,	0.0,	null,	0.9,	0.1,	0.0,	1.0 ),
				new SkillInfo( SkillName.ArmePerforante,  "Armes Perforantes",	SkillCategory.Combat,	4.5,	5.5,	0.0,	null,	0.45,	0.55,	0.0,	1.0 ),
				new SkillInfo( SkillName.Anatomie,        "Anatomie",			SkillCategory.Combat,	9.0,	1.0,	0.0,	null,	0.0,	0.1,	1.0,	1.0 ),
				new SkillInfo( SkillName.Concentration,   "Concentration",		SkillCategory.Combat,	0.0,	0.0,	0.0,	null,	0.0,	0.0,	0.0,	1.0 ),
                new SkillInfo( SkillName.Penetration,     "Penetration",		SkillCategory.Combat,	0.0,	0.0,	0.0,	null,	0.0,	0.5,	0.0,	1.0 ),
                new SkillInfo( SkillName.CoupCritique,    "Coup Critique",		SkillCategory.Combat,	0.0,	0.0,	0.0,	null,	0.0,	0.0,	1.0,	1.0 ),
                new SkillInfo( SkillName.ResistanceMagique,"Résistance Magique",SkillCategory.Combat,	0.0,	0.0,	0.0,	null,	0.0,	0.0,	1.0,	1.0 ),
                new SkillInfo( SkillName.ArmureNaturelle, "Armure Naturelle",   SkillCategory.Combat,	0.0,	0.0,	0.0,	null,	0.0,	0.0,	1.0,	1.0 ),
                
				new SkillInfo( SkillName.Inscription,     "Inscription",		SkillCategory.Magie,	0.0,	2.0,	8.0,	null,	0.0,	0.2,	0.8,	1.0 ),
				new SkillInfo( SkillName.ArtMagique,      "Art de la Magie",	SkillCategory.Magie,   	0.0,	0.0,	15.0,	null,	0.0,	0.0,	1.5,	1.0 ),
                new SkillInfo( SkillName.Meditation,      "Meditation",			SkillCategory.Magie,   	0.0,	0.0,	15.0,	null,	0.0,	0.0,	1.5,	1.0 ),
                new SkillInfo( SkillName.MagieDeGuerre,   "Magie de Guerre",	SkillCategory.Magie,   	0.0,	0.0,	15.0,	null,	0.0,	0.0,	1.5,	1.0 ),
                new SkillInfo( SkillName.Destruction,     "Destruction",        SkillCategory.Magie,    0.0,    0.0,    15.0,   null,   0.0,    0.0,    1.5,    1.0 ),
                new SkillInfo( SkillName.Conjuration,     "Conjuration",        SkillCategory.Magie,    0.0,    0.0,    15.0,   null,   0.0,    0.0,    1.5,    1.0 ),
                new SkillInfo( SkillName.Goetie,          "Goetie",             SkillCategory.Magie,    0.0,    0.0,    15.0,   null,   0.0,    0.0,    1.5,    1.0 ),
                new SkillInfo( SkillName.Miracles,        "Miracles",           SkillCategory.Magie,    0.0,    0.0,    15.0,   null,   0.0,    0.0,    1.5,    1.0 ),
                new SkillInfo( SkillName.Mysticisme,      "Mysticisme",         SkillCategory.Magie,    0.0,    0.0,    15.0,   null,   0.0,    0.0,    1.5,    1.0 ),
                new SkillInfo( SkillName.Reve,            "Reve",               SkillCategory.Magie,    0.0,    0.0,    15.0,   null,   0.0,    0.0,    1.5,    1.0 ),
                new SkillInfo( SkillName.Restoration,     "Restoration",        SkillCategory.Magie,    0.0,    0.0,    15.0,   null,   0.0,    0.0,    1.5,    1.0 ),
                new SkillInfo( SkillName.Tenebrae,        "Tenebrae",           SkillCategory.Magie,    0.0,    0.0,    15.0,   null,   0.0,    0.0,    1.5,    1.0 ),
                new SkillInfo( SkillName.Musique,         "Musique",            SkillCategory.Magie,    0.0,    0.0,    15.0,   null,   0.0,    0.0,    1.5,    1.0 ),

                new SkillInfo( SkillName.Survie,          "Survie",	  			SkillCategory.Roublardise,	20.0,	15.0,	15.0, 	null,	2.0,	1.5,	1.5,	1.0 ),
				new SkillInfo( SkillName.Detection,       "Detection",			SkillCategory.Roublardise,	0.0,	0.0,	0.0,	null,	0.0,	0.4,	0.6,	1.0 ),
				new SkillInfo( SkillName.Discretion,      "Discretion",			SkillCategory.Roublardise,	0.0,	0.0,	0.0, 	null,	0.0,	0.8,	0.2,	1.0 ),
				new SkillInfo( SkillName.Crochetage,      "Crochetage",			SkillCategory.Roublardise,	0.0,	25.0,	0.0,	null,	0.0,	2.0,	0.0,	1.0 ),
				new SkillInfo( SkillName.Fouille,         "Fouille",			SkillCategory.Roublardise,	0.0,	25.0,	0.0,	null,	0.0,	2.5,	0.0,	1.0 ),
				new SkillInfo( SkillName.Empoisonnement,  "Empoisonnement",		SkillCategory.Roublardise,	0.0,	4.0,	16.0,	null,	0.0,	0.4,	1.6,	1.0 ),
				new SkillInfo( SkillName.Vol,             "Vol",				SkillCategory.Roublardise,	0.0,	10.0,	0.0,	null,	0.0,	1.0,	0.0,	1.0 ),
				new SkillInfo( SkillName.Dressage,        "Dressage",			SkillCategory.Roublardise,	14.0,	2.0,	4.0, 	null,	1.4,	0.2,	0.4,	1.0 ),
				new SkillInfo( SkillName.Poursuite,       "Poursuite",			SkillCategory.Roublardise,	0.0,	12.5,	12.5, 	null,	0.0,	1.25,	1.25,	1.0 ),
				new SkillInfo( SkillName.Infiltration,    "Infiltration",		SkillCategory.Roublardise,	0.0,	0.0,	0.0,	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( SkillName.Pieges,          "Maitrise des Pieges",SkillCategory.Roublardise,	0.0,	0.0,	0.0,	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( SkillName.Langues,         "Langues",			SkillCategory.Roublardise,	0.0,	0.0,	0.0,	null,	0.0,	0.0,	0.0,	1.0 ),
                new SkillInfo( SkillName.Deguisement,     "Deguisement",		SkillCategory.Roublardise,	0.0,	0.0,	0.0,	null,	0.0,	0.0,	0.0,	1.0 ),

			};

        private static bool tableIsSorted = false;

		public static SkillInfo[] Table
		{
			get
			{
                if (!tableIsSorted)
                {
                    Array.Sort(m_Table, new SkillComparer());
                    tableIsSorted = true;
                }
				return m_Table;
			}
			set
			{
				m_Table = value;
                tableIsSorted = false;
			}
		}

        private class SkillComparer : IComparer<SkillInfo>
        {
            public SkillComparer() { }

            public int Compare(SkillInfo x, SkillInfo y)
            {
                SkillName a = (SkillName)x.Skill;
                SkillName b = (SkillName)y.Skill;
                return a.CompareTo(b);
            }
        }

        private static SkillName[] m_CatTable = (SkillName[])Enum.GetValues(typeof(SkillName));

        private static bool catTableIsSorted = false;

        public static SkillName[] CatTable
        {
            get
            {
                if (!catTableIsSorted)
                {
                    Array.Sort(m_CatTable, new SkillCatComparer());
                    catTableIsSorted = true;
                }
                return m_CatTable;
            }
            set
            {
                m_CatTable = value;
                catTableIsSorted = false;
            }
        }

        private class SkillCatComparer : IComparer<SkillName>
        {
            public SkillCatComparer() { }

            public int Compare(SkillName x, SkillName y)
            {
                int a = (int)x;
                int b = (int)y;
                SkillInfo sa = Table[a];
                SkillInfo sb = Table[b];
                int result = sa.Category.CompareTo(sb.Category);
                return result == 0 ? sa.Name.CompareTo(sb.Name) : result;
            }
        }

        public static SkillName[] GetCategory(SkillCategory cat)
        {
            SkillName[] c = CatTable;
            List<SkillName> l = new List<SkillName>();
            foreach (SkillName sk in c)
            {
                if (Table[(int)sk].Category == cat)
                    l.Add(sk);
            }
            return l.ToArray();
        }
	}

	[PropertyObject]
	public class Skills : IEnumerable
	{
		private Mobile m_Owner;
		private Skill[] m_Skills;
		private int m_Total, m_Cap;
		private Skill m_Highest;

		#region Skill Getters & Setters
		[CommandProperty( AccessLevel.Counselor )]
		public Skill Alchimie{ get{ return this[SkillName.Alchimie]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArmeHaste{ get{ return this[SkillName.ArmeHaste]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill CoupCritique{ get{ return this[SkillName.CoupCritique]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Penetration{ get{ return this[SkillName.Penetration]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Anatomie{ get{ return this[SkillName.Anatomie]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Parer{ get{ return this[SkillName.Parer]; } set{} }

        //[CommandProperty( AccessLevel.Counselor )]
        //public Skill Illusion{ get{ return this[SkillName.Illusion]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Forge{ get{ return this[SkillName.Forge]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Equitation{ get{ return this[SkillName.Equitation]; } set{} }

        //Ce skill est a changer en changeant le systeme de magie.
        [CommandProperty(AccessLevel.Counselor)]
        public Skill Conjuration { get { return this[SkillName.Conjuration]; } set { } }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Survie{ get{ return this[SkillName.Survie]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Menuiserie{ get{ return this[SkillName.Menuiserie]; } set{} }

        //[CommandProperty( AccessLevel.Counselor )]
        //public Skill Destruction{ get{ return this[SkillName.Destruction]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Cuisine{ get{ return this[SkillName.Cuisine]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Detection{ get{ return this[SkillName.Detection]; } set{} }

        //Ce skill est a changer en changeant le systeme de magie.
        [CommandProperty(AccessLevel.Counselor)]
        public Skill Tenebrae { get { return this[SkillName.Tenebrae]; } set { } }

        //[CommandProperty( AccessLevel.Counselor )]
        //public Skill Restoration{ get{ return this[SkillName.Restoration]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Soins{ get{ return this[SkillName.Soins]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ResistanceMagique{ get{ return this[SkillName.ResistanceMagique]; } set{} }

        //[CommandProperty( AccessLevel.Counselor )]
        //public Skill Reve{ get{ return this[SkillName.Reve]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Meditation{ get{ return this[SkillName.Meditation]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Discretion{ get{ return this[SkillName.Discretion]; } set{} }

        //Ce skill est a changer en changeant le systeme de magie.
        [CommandProperty(AccessLevel.Counselor)]
        public Skill Goetie { get { return this[SkillName.Goetie]; } set { } }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Inscription{ get{ return this[SkillName.Inscription]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Crochetage{ get{ return this[SkillName.Crochetage]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArtMagique{ get{ return this[SkillName.ArtMagique]; } set{} }

        //[CommandProperty( AccessLevel.Counselor )]
        //public Skill Mysticisme{ get{ return this[SkillName.Mysticisme]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Tactiques{ get{ return this[SkillName.Tactiques]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Fouille{ get{ return this[SkillName.Fouille]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill MagieDeGuerre{ get{ return this[SkillName.MagieDeGuerre]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Empoisonnement{ get{ return this[SkillName.Empoisonnement]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArmeDistance{ get{ return this[SkillName.ArmeDistance]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Deguisement{ get{ return this[SkillName.Deguisement]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Vol{ get{ return this[SkillName.Vol]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Couture{ get{ return this[SkillName.Couture]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Dressage{ get{ return this[SkillName.Dressage]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Langues{ get{ return this[SkillName.Langues]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Fignolage{ get{ return this[SkillName.Fignolage]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Poursuite{ get{ return this[SkillName.Poursuite]; } set{} }

        //[CommandProperty( AccessLevel.Counselor )]
        //public Skill Miracles{ get{ return this[SkillName.Miracles]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArmeTranchante{ get{ return this[SkillName.ArmeTranchante]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArmeContondante{ get{ return this[SkillName.ArmeContondante]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArmePerforante{ get{ return this[SkillName.ArmePerforante]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Polissage{ get{ return this[SkillName.Polissage]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Foresterie{ get{ return this[SkillName.Foresterie]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Excavation{ get{ return this[SkillName.Excavation]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Concentration{ get{ return this[SkillName.Concentration]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Infiltration{ get{ return this[SkillName.Infiltration]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Pieges{ get{ return this[SkillName.Pieges]; } set{} }

		#endregion

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Batisseur )]
		public int Cap
		{
			get{ return m_Cap; } 
			set{ m_Cap = value; }
		}

        [CommandProperty( AccessLevel.Counselor, true)]
		public int Total
		{
			get{ return m_Total; }
			set{ m_Total = value; }
		}

		public Mobile Owner
		{
			get{ return m_Owner; }
		}

		public int Length
		{
			get{ return m_Skills.Length; }
		}

        public Skill this[SkillName name]
        {
            get { return this[(int)name]; }
        }



        public Skill this[int skillID]
        {
            get
            {
                if (skillID < 0 || skillID >= m_Skills.Length)
                    return null;

                Skill sk = m_Skills[skillID];

                if (sk == null)
                    m_Skills[skillID] = sk = new Skill(this, SkillInfo.Table[skillID], 0, 1000, SkillLock.Up);

                return sk;
            }
        }

		public override string ToString()
		{
			return "...";
		}

		public static bool UseSkill( Mobile from, SkillName name )
		{
			return UseSkill( from, (int)name );
		}

		public static bool UseSkill( Mobile from, int skillID )
		{
			if ( !from.CheckAlive() )
				return false;
			else if ( !from.Region.OnSkillUse( from, skillID ) )
				return false;
			else if ( !from.AllowSkillUse( (SkillName)skillID ) )
				return false;

			if ( skillID >= 0 && skillID < SkillInfo.Table.Length )
			{
				SkillInfo info = SkillInfo.Table[skillID];

				if ( info.Callback != null )
				{
					if (Core.TickCount - from.NextSkillTime >= 0 && from.Spell == null)
					{
						from.DisruptiveAction();

						from.NextSkillTime = Core.TickCount + (int)(info.Callback(from)).TotalMilliseconds;

						return true;
					}
					else
					{
						from.SendSkillMessage();
					}
				}
				else
				{
					from.SendLocalizedMessage( 500014 ); // That skill cannot be used directly.
				}
			}

			return false;
		}

		public Skill Highest
		{
			get
			{
				if ( m_Highest == null )
				{
					Skill highest = null;
					int value = int.MinValue;

					for ( int i = 0; i < m_Skills.Length; ++i )
					{
						Skill sk = m_Skills[i];

						if ( sk != null && sk.BaseFixedPoint > value )
						{
							value = sk.BaseFixedPoint;
							highest = sk;
						}
					}

					if ( highest == null && m_Skills.Length > 0 )
						highest = this[0];

					m_Highest = highest;
				}

				return m_Highest;
			}
		}

		public void Serialize( GenericWriter writer )
		{
			m_Total = 0;

			writer.Write( (int) 0 ); // version

			writer.Write( (int) m_Cap );
			writer.Write( (int) m_Skills.Length );

			for ( int i = 0; i < m_Skills.Length; ++i )
			{
				Skill sk = m_Skills[i];

				if ( sk == null )
				{
					writer.Write( (byte) 0xFF );
				}
				else
				{
					sk.Serialize( writer );
					m_Total += sk.BaseFixedPoint;
				}
			}
		}

		public Skills( Mobile owner )
		{
			m_Owner = owner;
			m_Cap = 7000;

			SkillInfo[] info = SkillInfo.Table;

			m_Skills = new Skill[info.Length];

            for (int i = 0; i < info.Length; ++i)
                m_Skills[i] = new Skill(this, info[i], 0, 1000, SkillLock.Up);
		}

        public Skills(Mobile owner, GenericReader reader)
        {
            m_Owner = owner;

            int version = reader.ReadInt();

            m_Cap = reader.ReadInt();

            SkillInfo[] info = SkillInfo.Table;

            m_Skills = new Skill[info.Length];

            int count = reader.ReadInt();
            if (count != info.Length)
                Console.WriteLine("Warning: SkillInfo.Table a size {0} alors que m_Skills a size {1}. Si vous n'avez pas ajouté de skill, il y a un probleme.",
                    info.Length, count);

            for (int i = 0; i < count; ++i)
            {
                if (i < info.Length)
                {
                    Skill sk = new Skill(this, info[i], reader);

                    if (sk.BaseFixedPoint != 0 || sk.CapFixedPoint != 1000 || sk.Lock != SkillLock.Up)
                    {
                        m_Skills[i] = sk;
                        m_Total += sk.BaseFixedPoint;
                    }
                }
                else
                {
                    new Skill(this, null, reader);
                }
            }



        }

		public void OnSkillChange( Skill skill )
		{
			if ( skill == m_Highest ) // could be downgrading the skill, force a recalc
				m_Highest = null;
			else if ( m_Highest != null && skill.BaseFixedPoint > m_Highest.BaseFixedPoint )
				m_Highest = skill;

			m_Owner.OnSkillInvalidated( skill );

			NetState ns = m_Owner.NetState;

			if ( ns != null )
				ns.Send( new SkillChange( skill ) );
		}

		public IEnumerator GetEnumerator()
		{
			return m_Skills.GetEnumerator();
		}
	}
}