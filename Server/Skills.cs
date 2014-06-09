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
		Alchimie = 0,
		ArmeHaste = 1,
		Agriculture = 2,
		Identification = 3,
		FabricationArt = 4,
		Parer = 5,
		Illusion = 6,
		Forge = 7,
		Equitation = 8,
		Conjuration = 9,
		Survie = 10,
		Menuiserie = 11,
		Destruction = 12,
		Cuisine = 13,
		Detection = 14,
		Tenebrea = 15,
		Restoration = 16,
		Soins = 17,
		Peche = 18,
		Reve = 19,
		Elevage = 20,
		Discretion = 21,
		Goetie = 22,
		Inscription = 23,
		Crochetage = 24,
		ArtMagique = 25,
		Mysticisme = 26,
		Tactiques = 27,
		Fouille = 28,
		Musique = 29,
		Empoisonner = 30,
		ArmeDistance = 31,
		Priere = 32,
		Vol = 33,
		Couture = 34,
		Dressage = 35,
		Degustation = 36,
		Bricolage = 37,
		Poursuite = 38,
		Miracles = 39,
		ArmeTranchante = 40,
		ArmeContondante = 41,
		ArmePerforante = 42,
		ArmePoing = 43,
		Foresterie = 44,
		Excavation = 45,
		Concentration = 46,
		Infiltration = 47,
		Pieges = 48,
		ConnaissanceLangue = 49,
		ConnaissanceNoblesse = 50,
		ConnaissanceNature = 51,
		ConnaissanceBestiaire = 52,
		ConnaissanceHistoire = 53,
		ConnaissanceReligion = 54,
		Mysticism = 55,
		Imbuing = 56,
		Throwing = 57
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

		[CommandProperty( AccessLevel.Counselor, AccessLevel.GameMaster )]
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

		[CommandProperty( AccessLevel.Counselor, AccessLevel.GameMaster )]
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
		private int m_SkillID;
		private string m_Name;
		private string m_Title;
		private double m_StrScale;
		private double m_DexScale;
		private double m_IntScale;
		private double m_StatTotal;
		private SkillUseCallback m_Callback;
		private double m_StrGain;
		private double m_DexGain;
		private double m_IntGain;
		private double m_GainFactor;

		public SkillInfo( int skillID, string name, double strScale, double dexScale, double intScale, string title, SkillUseCallback callback, double strGain, double dexGain, double intGain, double gainFactor )
		{
			m_Name = name;
			m_Title = title;
			m_SkillID = skillID;
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
				return m_SkillID;
			}
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

		public string Title
		{
			get
			{
				return m_Title;
			}
			set
			{
				m_Title = value;
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

		private static SkillInfo[] m_Table = new SkillInfo[58]
			{
				new SkillInfo(  0, "Alchimie",			0.0,	5.0,	5.0,	"Alchimiste",	null,	0.0,	0.5,	0.5,	1.0 ),
				new SkillInfo(  1, "Arme d'Haste",			0.0,	0.0,	0.0,	"Hallebardier",	null,	0.15,	0.15,	0.7,	1.0 ),
				new SkillInfo(  2, "Agriculture",		0.0,	0.0,	0.0,	"Fermier",	null,	0.0,	0.0,	1.0,	1.0 ),
				new SkillInfo(  3, "Identification",	0.0,	0.0,	0.0,	"Marchand",	null,	0.0,	0.0,	1.0,	1.0 ),
				new SkillInfo(  4, "Fabrication d'Art",			0.0,	0.0,	0.0,	"Artiste",	null,	0.75,	0.15,	0.1,	1.0 ),
				new SkillInfo(  5, "Parer",			7.5,	2.5,	0.0,	"Protecteur",	null,	0.75,	0.25,	0.0,	1.0 ),
				new SkillInfo(  6, "Illusion",			0.0,	0.0,	0.0,	"Illusioniste",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo(  7, "Forge",		10.0,	0.0,	0.0,	"Forgeron",	null,	1.0,	0.0,	0.0,	1.0 ),
				new SkillInfo(  8, "Equitation",	6.0,	16.0,	0.0,	"Cavalier",	null,	0.6,	1.6,	0.0,	1.0 ),
				new SkillInfo(  9, "Conjuration",		0.0,	0.0,	0.0,	"Conjurateur",		null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 10, "Survie",			20.0,	15.0,	15.0,	"Aventurier",	null,	2.0,	1.5,	1.5,	1.0 ),
				new SkillInfo( 11, "Menuiserie",			20.0,	5.0,	0.0,	"Menuisier",	null,	2.0,	0.5,	0.0,	1.0 ),
				new SkillInfo( 12, "Destruction",		0.0,	7.5,	7.5,	"Mage de Bataille",	null,	0.0,	0.75,	0.75,	1.0 ),
				new SkillInfo( 13, "Cuisine",			0.0,	20.0,	30.0,	"Cuisinier",		null,	0.0,	2.0,	3.0,	1.0 ),
				new SkillInfo( 14, "Detection",		0.0,	0.0,	0.0,	"Gardien",	null,	0.0,	0.4,	0.6,	1.0 ),
				new SkillInfo( 15, "Tenebrea",		0.0,	2.5,	2.5,	"Sorcier",		null,	0.0,	0.25,	0.25,	1.0 ),
				new SkillInfo( 16, "Restoration",	0.0,	0.0,	0.0,	"Thaumaturge",	null,	0.0,	0.0,	1.0,	1.0 ),
				new SkillInfo( 17, "Soins",			6.0,	6.0,	8.0,	"Soigneur",	null,	0.6,	0.6,	0.8,	1.0 ),
				new SkillInfo( 18, "Peche",			0.0,	0.0,	0.0,	"Pecheur",	null,	0.5,	0.5,	0.0,	1.0 ),
				new SkillInfo( 19, "Reve",	0.0,	0.0,	0.0,	"Illusioniste",	null,	0.0,	0.2,	0.8,	1.0 ),
				new SkillInfo( 20, "Elevage",			16.25,	6.25,	2.5,	"Eleveur",	null,	1.625,	0.625,	0.25,	1.0 ),
				new SkillInfo( 21, "Discretion",			0.0,	0.0,	0.0,	"Vagabond",	null,	0.0,	0.8,	0.2,	1.0 ),
				new SkillInfo( 22, "Goetie",		0.0,	4.5,	0.5,	"Necromancien",		null,	0.0,	0.45,	0.05,	1.0 ),
				new SkillInfo( 23, "Inscription",		0.0,	2.0,	8.0,	"Scribe",	null,	0.0,	0.2,	0.8,	1.0 ),
				new SkillInfo( 24, "Crochetage",		0.0,	25.0,	0.0,	"Filou",	null,	0.0,	2.0,	0.0,	1.0 ),
				new SkillInfo( 25, "Art de la Magie",			0.0,	0.0,	15.0,	"Mage",		null,	0.0,	0.0,	1.5,	1.0 ),
				new SkillInfo( 26, "Mysticisme",		0.0,	0.0,	0.0,	"Magicien",		null,	0.25,	0.25,	0.5,	1.0 ),
				new SkillInfo( 27, "Tactiques",			0.0,	0.0,	0.0,	"Stratege",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 28, "Fouille",			0.0,	25.0,	0.0,	"Brigand",	null,	0.0,	2.5,	0.0,	1.0 ),
				new SkillInfo( 29, "Musique",		0.0,	0.0,	0.0,	"Barde",		null,	0.0,	0.8,	0.2,	1.0 ),
				new SkillInfo( 30, "Empoisonner",			0.0,	4.0,	16.0,	"Assassin",	null,	0.0,	0.4,	1.6,	1.0 ),
				new SkillInfo( 31, "Arme de Distance",			2.5,	7.5,	0.0,	"Archer",	null,	0.25,	0.75,	0.0,	1.0 ),
				new SkillInfo( 32, "Priere",		0.0,	0.0,	0.0,	"Moine",	null,	0.0,	0.0,	1.0,	1.0 ),
				new SkillInfo( 33, "Vol",			0.0,	10.0,	0.0,	"Voleur",	null,	0.0,	1.0,	0.0,	1.0 ),
				new SkillInfo( 34, "Couture",			3.75,	16.25,	5.0,	"Couturier",	null,	0.38,	1.63,	0.5,	1.0 ),
				new SkillInfo( 35, "Dressage",		14.0,	2.0,	4.0,	"Dresseur",	null,	1.4,	0.2,	0.4,	1.0 ),
				new SkillInfo( 36, "Degustation",	0.0,	0.0,	0.0,	"Gouteur",		null,	0.2,	0.0,	0.8,	1.0 ),
				new SkillInfo( 37, "Bricolage",			5.0,	2.0,	3.0,	"Inventeur",	null,	0.5,	0.2,	0.3,	1.0 ),
				new SkillInfo( 38, "Poursuite",			0.0,	12.5,	12.5,	"Rodeur",	null,	0.0,	1.25,	1.25,	1.0 ),
				new SkillInfo( 39, "Miracles",		8.0,	4.0,	8.0,	"Pretre",	null,	0.8,	0.4,	0.8,	1.0 ),
				new SkillInfo( 40, "Armes Tranchantes",		7.5,	2.5,	0.0,	"Chevalier",	null,	0.75,	0.25,	0.0,	1.0 ),
				new SkillInfo( 41, "Armes Contondantes",		9.0,	1.0,	0.0,	"Fantassin",	null,	0.9,	0.1,	0.0,	1.0 ),
				new SkillInfo( 42, "Armes Perforantes",			4.5,	5.5,	0.0,	"Duelliste",	null,	0.45,	0.55,	0.0,	1.0 ),
				new SkillInfo( 43, "Armes de Poings",			9.0,	1.0,	0.0,	"Spadassin",	null,	0.9,	0.1,	0.0,	1.0 ),
				new SkillInfo( 44, "Foresterie",		20.0,	0.0,	0.0,	"Paysan",	null,	2.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 45, "Excavation",			20.0,	0.0,	0.0,	"Ouvrier",	null,	2.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 46, "Concentration",		0.0,	0.0,	0.0,	"Mage",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 47, "Infiltration",			0.0,	0.0,	0.0,	"Rogue",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 48, "Maitrise des Pieges",		0.0,	0.0,	0.0,	"Roublard",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 49, "Connaissance des Langues",		0.0,	0.0,	0.0,	"Erudit",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 50, "Connaissance de la Noblesse",			0.0,	0.0,	0.0,	"Erudit",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 51, "Connaissance de la Nature",			0.0,	0.0,	0.0,	"Erudit",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 52, "Connaissance du Bestiaire",			0.0,	0.0,	0.0,	"Erudit",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 53, "Connaissance de l'Histoire",			0.0,	0.0,	0.0,	"Erudit",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 54, "Connaissance de la Religion",		0.0,	0.0,	0.0,	"Erudit",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 55, "Mysticism",			0.0,	0.0,	0.0,	"Mystic",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 56, "Imbuing",			0.0,	0.0,	0.0,	"Artificer",	null,	0.0,	0.0,	0.0,	1.0 ),
				new SkillInfo( 57, "Throwing",			0.0,	0.0,	0.0,	"Bladeweaver",	null,	0.0,	0.0,	0.0,	1.0 ),
			};

		public static SkillInfo[] Table
		{
			get
			{
				return m_Table;
			}
			set
			{
				m_Table = value;
			}
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
		public Skill Agriculture{ get{ return this[SkillName.Agriculture]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Identification{ get{ return this[SkillName.Identification]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill FabricationArt{ get{ return this[SkillName.FabricationArt]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Parer{ get{ return this[SkillName.Parer]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Illusion{ get{ return this[SkillName.Illusion]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Forge{ get{ return this[SkillName.Forge]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Equitation{ get{ return this[SkillName.Equitation]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Conjuration{ get{ return this[SkillName.Conjuration]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Survie{ get{ return this[SkillName.Survie]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Menuiserie{ get{ return this[SkillName.Menuiserie]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Destruction{ get{ return this[SkillName.Destruction]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Cuisine{ get{ return this[SkillName.Cuisine]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Detection{ get{ return this[SkillName.Detection]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Tenebrea{ get{ return this[SkillName.Tenebrea]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Restoration{ get{ return this[SkillName.Restoration]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Soins{ get{ return this[SkillName.Soins]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Peche{ get{ return this[SkillName.Peche]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Reve{ get{ return this[SkillName.Reve]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Elevage{ get{ return this[SkillName.Elevage]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Discretion{ get{ return this[SkillName.Discretion]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Goetie{ get{ return this[SkillName.Goetie]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Inscription{ get{ return this[SkillName.Inscription]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Crochetage{ get{ return this[SkillName.Crochetage]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArtMagique{ get{ return this[SkillName.ArtMagique]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Mysticisme{ get{ return this[SkillName.Mysticisme]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Tactiques{ get{ return this[SkillName.Tactiques]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Fouille{ get{ return this[SkillName.Fouille]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Musique{ get{ return this[SkillName.Musique]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Empoisonner{ get{ return this[SkillName.Empoisonner]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArmeDistance{ get{ return this[SkillName.ArmeDistance]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Priere{ get{ return this[SkillName.Priere]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Vol{ get{ return this[SkillName.Vol]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Couture{ get{ return this[SkillName.Couture]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Dressage{ get{ return this[SkillName.Dressage]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Degustation{ get{ return this[SkillName.Degustation]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Bricolage{ get{ return this[SkillName.Bricolage]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Poursuite{ get{ return this[SkillName.Poursuite]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Miracles{ get{ return this[SkillName.Miracles]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArmeTranchante{ get{ return this[SkillName.ArmeTranchante]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArmeContondante{ get{ return this[SkillName.ArmeContondante]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArmePerforante{ get{ return this[SkillName.ArmePerforante]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ArmePoing{ get{ return this[SkillName.ArmePoing]; } set{} }

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

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ConnaissanceLangue{ get{ return this[SkillName.ConnaissanceLangue]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ConnaissanceNoblesse{ get{ return this[SkillName.ConnaissanceNoblesse]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ConnaissanceNature{ get{ return this[SkillName.ConnaissanceNature]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ConnaissanceBestiaire{ get{ return this[SkillName.ConnaissanceBestiaire]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ConnaissanceHistoire{ get{ return this[SkillName.ConnaissanceHistoire]; } set{} }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill ConnaissanceReligion { get { return this[SkillName.ConnaissanceReligion]; } set { } }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Mysticism { get { return this[SkillName.Mysticism]; } set { } }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Imbuing { get { return this[SkillName.Imbuing]; } set { } }

		[CommandProperty( AccessLevel.Counselor )]
		public Skill Throwing { get { return this[SkillName.Throwing]; } set { } }

		#endregion

		[CommandProperty( AccessLevel.Counselor, AccessLevel.GameMaster )]
		public int Cap
		{
			get{ return m_Cap; } 
			set{ m_Cap = value; }
		}

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
			get{ return this[(int)name]; }
		}

		public Skill this[int skillID]
		{
			get
			{
				if ( skillID < 0 || skillID >= m_Skills.Length )
					return null;

				Skill sk = m_Skills[skillID];

				if ( sk == null )
					m_Skills[skillID] = sk = new Skill( this, SkillInfo.Table[skillID], 0, 1000, SkillLock.Up );

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

			writer.Write( (int) 3 ); // version

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

			//for ( int i = 0; i < info.Length; ++i )
			//	m_Skills[i] = new Skill( this, info[i], 0, 1000, SkillLock.Up );
		}

		public Skills( Mobile owner, GenericReader reader )
		{
			m_Owner = owner;

			int version = reader.ReadInt();

			switch ( version )
			{
				case 3:
				case 2:
				{
					m_Cap = reader.ReadInt();

					goto case 1;
				}
				case 1:
				{
					if ( version < 2 )
						m_Cap = 7000;

					if ( version < 3 )
						/*m_Total =*/ reader.ReadInt();

					SkillInfo[] info = SkillInfo.Table;

					m_Skills = new Skill[info.Length];

					int count = reader.ReadInt();

					for ( int i = 0; i < count; ++i )
					{
						if ( i < info.Length )
						{
							Skill sk = new Skill( this, info[i], reader );

							if ( sk.BaseFixedPoint != 0 || sk.CapFixedPoint != 1000 || sk.Lock != SkillLock.Up )
							{
								m_Skills[i] = sk;
								m_Total += sk.BaseFixedPoint;
							}
						}
						else
						{
							new Skill( this, null, reader );
						}
					}

					//for ( int i = count; i < info.Length; ++i )
					//	m_Skills[i] = new Skill( this, info[i], 0, 1000, SkillLock.Up );

					break;
				}
				case 0:
				{
					reader.ReadInt();

					goto case 1;
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