
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Guilds;
using Server.Multis;
using Server.Regions;
using Server.Mobiles;
using Server.Targeting;
using Server.Engines.PartySystem;
using Server.Misc;
using System.Collections.Generic;
using Server.Spells.Fifth;

namespace Server
{
	public class DefensiveSpell
	{
		public static void Nullify( Mobile from )
		{
			if ( !from.CanBeginAction( typeof( DefensiveSpell ) ) )
				new InternalTimer( from ).Start();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;

			public InternalTimer( Mobile m ) : base( TimeSpan.FromMinutes( 1.0 ) )
			{
				m_Mobile = m;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				m_Mobile.EndAction( typeof( DefensiveSpell ) );
			}
		}
    }

    public class DefensiveAptitudeSpell
    {
        public static void Nullify(Mobile from)
        {
            if (!from.CanBeginAction(typeof(DefensiveAptitudeSpell)))
                new InternalTimer(from).Start();
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Mobile;

            public InternalTimer(Mobile m) : base(TimeSpan.FromMinutes(1.0))
            {
                m_Mobile = m;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                m_Mobile.EndAction(typeof(DefensiveAptitudeSpell));
            }
        }
    }
}

namespace Server.Spells
{
	public enum TravelCheckType
	{
		RecallFrom,
		RecallTo,
		GateFrom,
		GateTo,
		Mark,
		TeleportFrom,
		TeleportTo
	}

	public class SpellHelper
	{
		private static TimeSpan AosDamageDelay = TimeSpan.FromSeconds( 1.0 );
		private static TimeSpan OldDamageDelay = TimeSpan.FromSeconds( 0.5 );

		public static TimeSpan GetDamageDelayForSpell( Spell sp )
		{
			if ( !sp.DelayedDamage )
				return TimeSpan.Zero;

			return OldDamageDelay;
		}

        public static void Heal(Mobile from, int amount, bool message)
        {
            int toheal = amount;

            if (RegenerescenceSpell.m_RegenerescenceTable.Contains(from))
            {
                toheal = (int)(toheal * (double)RegenerescenceSpell.m_RegenerescenceTable[from]);

                from.FixedParticles(14217, 10, 20, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                from.PlaySound(508);
            }

            from.Heal(toheal);
        }

        public static void Heal(Mobile from, int amount, bool message, bool miracle)
        {
            int toheal = amount;

            toheal = (int)(toheal * (double)RegenerescenceSpell.m_RegenerescenceTable[from]);

            if (miracle)
            {
                ReligiousSpell.MiracleEffet(from, from, 14217, 10, 20, 5013, 0, 0, EffectLayer.CenterFeet);
            }
            else
            {
                from.FixedParticles(14217, 10, 20, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
            }
            from.PlaySound(508);

            from.Heal(toheal);
        }

		public static bool CheckMulti( Point3D p, Map map )
		{
			return CheckMulti( p, map, true );
		}

		public static bool CheckMulti( Point3D p, Map map, bool houses )
		{
			if ( map == null || map == Map.Internal )
				return false;

			Sector sector = map.GetSector( p.X, p.Y );

			for ( int i = 0; i < sector.Multis.Count; ++i )
			{
				BaseMulti multi = (BaseMulti)sector.Multis[i];

				if ( multi is BaseHouse )
				{
					if ( houses && ((BaseHouse)multi).IsInside( p, 16 ) )
						return true;
				}
				else if ( multi.Contains( p ) )
				{
					return true;
				}
			}

			return false;
		}

        public static int GetTotalMobilesInRange(Mobile from, int range)
        {
            int total = 0;

            foreach (Mobile m in from.GetMobilesInRange(range))
            {
                if (m != null && m.Alive && !m.Deleted)
                    total++;
            }

            return total;
        }

        public static int GetTotalCreaturesInRange(Mobile from, int range)
        {
            int total = 0;

            foreach (Mobile m in from.GetMobilesInRange(range))
            {
                if (m != null && m.Alive && !m.Deleted && m is BaseCreature)
                    total++;
            }

            return total;
        }

        public static int GetRangeToMobile(Mobile from, Mobile m, int min, int max )
        {
            if (from == null || m == null || from.Deleted || m.Deleted || !from.CanSee(m))
                return max;

            for (int i = min; i <= min; i++)
            {
                if (from.InRange(m, i))
                    return i;
            }

            return max;
        }

        public static void Turn(Mobile from, object to)
		{
			IPoint3D target = to as IPoint3D;

			if ( target == null )
				return;

			if ( target is Item )
			{
				Item item = (Item)target;

				if ( item.RootParent != from )
					from.Direction = from.GetDirectionTo( item.GetWorldLocation() );
			}
			else if ( from != target )
			{
				from.Direction = from.GetDirectionTo( target );
			}
		}

		private static TimeSpan CombatHeatDelay = TimeSpan.FromSeconds( 30.0 );
		private static bool RestrictTravelCombat = true;

		public static bool CheckCombat( Mobile m )
		{
			if ( !RestrictTravelCombat )
				return false;

			for ( int i = 0; i < m.Aggressed.Count; ++i )
			{
				AggressorInfo info = (AggressorInfo)m.Aggressed[i];

				if ( info.Defender.Player && (DateTime.Now - info.LastCombatTime) < CombatHeatDelay )
					return true;
			}

			return false;
        }

        public static bool AdjustField(ref Point3D p, Map map, int height, bool mobsBlock)
        {
            if (map == null)
                return false;

            for (int offset = 0; offset < 10; ++offset)
            {
                Point3D loc = new Point3D(p.X, p.Y, p.Z - offset);

                if (CanFit(map, p.X, p.Y, p.Z - offset, height, true, mobsBlock))
                {
                    p = loc;
                    return true;
                }
            }

            for (int offset = 0; offset < 10; ++offset)
            {
                Point3D loc = new Point3D(p.X, p.Y, p.Z + offset);

                if (CanFit(map, p.X, p.Y, p.Z + offset, height, true, mobsBlock))
                {
                    p = loc;
                    return true;
                }
            }

            return false;
        }

        public static bool CanFit(Map map, int x, int y, int z, int height, bool checkBlocksFit, bool checkMobiles)
        {
            if (map == Map.Internal)
                return false;

            if (x < 0 || y < 0 || x >= map.Width || y >= map.Height)
                return false;

            bool hasSurface = false;

            LandTile lt = map.Tiles.GetLandTile(x, y);
            int lowZ = 0, avgZ = 0, topZ = 0;

            GetAverageZ(map, x, y, ref lowZ, ref avgZ, ref topZ);
            TileFlag landFlags = TileData.LandTable[lt.ID & 0x3FFF].Flags;

            if ((landFlags & TileFlag.Impassable) != 0 && map.Tiles.GetLandTile(x, y).Z > z && (z + height) > lowZ)
                return false;
            else if ((landFlags & TileFlag.Impassable) == 0 && z == avgZ && !lt.Ignored)
                hasSurface = true;

            StaticTile[] staticTiles = map.Tiles.GetStaticTiles(x, y, true);

            bool surface, impassable;

            for (int i = 0; i < staticTiles.Length; ++i)
            {
                ItemData id = TileData.ItemTable[staticTiles[i].ID & 0x3FFF];
                surface = id.Surface;
                impassable = id.Impassable;

                if ((staticTiles[i].Z + id.CalcHeight) > z + 10 && (z - 10 + height) > staticTiles[i].Z)
                    return false;
                else if (surface && !impassable && z == (staticTiles[i].Z + id.CalcHeight))
                    hasSurface = true;
            }

            Sector sector = map.GetSector(x, y);
            System.Collections.Generic.List<Mobile> mobs = sector.Mobiles;

            if (checkMobiles)
            {
                for (int i = 0; i < mobs.Count; ++i)
                {
                    Mobile m = (Mobile)mobs[i];

                    if (m.Location.X == x && m.Location.Y == y)
                        if ((m.Z + 16) > z && (z + height) > m.Z)
                            return false;
                }
            }

            return hasSurface;
        }

        public static void GetAverageZ(Map map, int x, int y, ref int z, ref int avg, ref int top)
        {
            int zTop = map.Tiles.GetLandTile(x, y).Z;
            int zLeft = map.Tiles.GetLandTile(x, y + 1).Z;
            int zRight = map.Tiles.GetLandTile(x + 1, y).Z;
            int zBottom = map.Tiles.GetLandTile(x + 1, y + 1).Z;

            z = zTop;
            if (zLeft < z)
                z = zLeft;
            if (zRight < z)
                z = zRight;
            if (zBottom < z)
                z = zBottom;

            top = zTop;
            if (zLeft > top)
                top = zLeft;
            if (zRight > top)
                top = zRight;
            if (zBottom > top)
                top = zBottom;

            if (Math.Abs(zTop - zBottom) > Math.Abs(zLeft - zRight))
                avg = (int)Math.Floor((zLeft + zRight) / 2.0);
            else
                avg = (int)Math.Floor((zTop + zBottom) / 2.0);
        }

		public static void GetSurfaceTop( ref IPoint3D p )
		{
			if ( p is Item )
			{
				p = ((Item)p).GetSurfaceTop();
			}
			else if ( p is StaticTarget )
			{
				StaticTarget t = (StaticTarget)p;
				int z = t.Z;

				if ( (t.Flags & TileFlag.Surface) == 0 )
					z -= TileData.ItemTable[t.ItemID & 0x3FFF].CalcHeight;

				p = new Point3D( t.X, t.Y, z );
			}
		}

		public static bool AddStatOffset( Mobile m, StatType type, int offset, TimeSpan duration )
		{
			if ( offset > 0 )
				return AddStatBonus( m, m, type, offset, duration );
			else if ( offset < 0 )
				return AddStatCurse( m, m, type, -offset, duration );

			return true;
		}

		public static bool AddStatBonus( Mobile caster, Mobile target, StatType type )
		{
			return AddStatBonus( caster, target, type, GetOffset( caster, target, type, false ), GetDuration( caster, target ) );
		}

        public static bool AddStatBonus(Mobile caster, Mobile target, StatType type, TimeSpan duration)
        {
            return AddStatBonus(caster, target, type, GetOffset(caster, target, type, false), duration);
        }

		public static bool AddStatBonus( Mobile caster, Mobile target, StatType type, int bonus, TimeSpan duration )
		{
			int offset = bonus;
			string name = String.Format( "Bénédiction : {0}", type );

			StatMod mod = target.GetStatMod( name );

			if ( mod != null && mod.Offset < 0 )
			{
				target.AddStatMod( new StatMod( type, name, mod.Offset + offset, duration ) );
				return true;
			}
			else if ( mod == null || mod.Offset < offset )
			{
				target.AddStatMod( new StatMod( type, name, offset, duration ) );
				return true;
			}

			return false;
		}

		public static bool AddStatCurse( Mobile caster, Mobile target, StatType type )
		{
			return AddStatCurse( caster, target, type, GetOffset( caster, target, type, true ), GetDuration( caster, target ) );
		}

        public static bool AddStatCurse(Mobile caster, Mobile target, StatType type, TimeSpan duration)
        {
            return AddStatCurse(caster, target, type, GetOffset(caster, target, type, true), duration);
        }

		public static bool AddStatCurse( Mobile caster, Mobile target, StatType type, int curse, TimeSpan duration )
		{
			int offset = -curse;
			string name = String.Format( "Malédiction : {0}", type );

			StatMod mod = target.GetStatMod( name );

			if ( mod != null && mod.Offset > 0 )
			{
				target.AddStatMod( new StatMod( type, name, mod.Offset + offset, duration ) );
				return true;
			}
			else if ( mod == null || mod.Offset > offset )
			{
				target.AddStatMod( new StatMod( type, name, offset, duration ) );
				return true;
			}

			return false;
		}

		public static TimeSpan GetDuration( Mobile caster, Mobile target )
        {
            double value = caster.Skills[SkillName.ArtMagique].Value * 5.4;

            if (caster is TMobile)
            {
                TMobile pm = caster as TMobile;

                if (pm != null)
                {
                    if (pm.GetAptitudeValue(NAptitude.Spiritisme) > 0)
                        value *= 1 + (pm.GetAptitudeValue(NAptitude.Spiritisme) * 0.05);
                }
            }

            return TimeSpan.FromSeconds(value);
		}

        public static double AdjustValue(Mobile caster, double value, NAptitude aptitude)
        {
            return AdjustValue(caster, value, aptitude, false);
        }

        public static double AdjustValue(Mobile caster, double value, NAptitude aptitude, bool rayon)
        {
            TMobile m = caster as TMobile;

            if (m != null)
            {
                switch (aptitude)
                {
                    case NAptitude.Sorcellerie:
                        value *= (m.GetAptitudeValue(NAptitude.Sorcellerie) * 0.04) + 1; break; //0.06
                    //case NAptitude.Sorcellerie:
                    //    value *= (m.GetAptitudeValue(NAptitude.Sorcellerie) * 0.04) + 1; break; //0.06
                    case NAptitude.Spiritisme:
                        value *= (m.GetAptitudeValue(NAptitude.Spiritisme) * 0.05) + 1; break; //0.10
                    case NAptitude.FaveurDivine:
                        value *= (m.GetAptitudeValue(NAptitude.GraceDivine) * 0.04) + 1; break; //0.04
                    //case NAptitude.ConnaissancesAccrues:
                    //    value *= 1 - (m.GetAptitudeValue(NAptitude.ConnaissancesAccrues) * 0.04); break; //0.05
                    //case NAptitude.BonusDivin:
                    //    value *= 1 - (m.GetAptitudeValue(NAptitude.BonusDivin) * 0.03); break; //0.04
                }
            }

            if (rayon)
            {
                if (RudesseSpell.m_RudesseTable.Contains(caster))
                {
                    value *= (double)RudesseSpell.m_RudesseTable[caster];
                    caster.FixedParticles(14138, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    caster.PlaySound(521);
                }
            }

            return value;
        }

		private static bool m_DisableSkillCheck;

		public static bool DisableSkillCheck
		{
			get{ return m_DisableSkillCheck; }
			set{ m_DisableSkillCheck = value; }
		}

		public static int GetOffset( Mobile caster, Mobile target, StatType type, bool curse )
        {
            double value = 1 + (caster.Skills[SkillName.ArtMagique].Value + caster.Skills[SkillName.Mysticisme].Value) * 0.3;

            if (curse)
            {
                double mr = target.Skills[SkillName.Concentration].Value;
                value *= 1 - (mr * 0.005);
            }

            TMobile pm = caster as TMobile;

            if (pm != null)
            {
                if (curse)
                    value *= (pm.GetAptitudeValue(NAptitude.Sorcellerie) * 0.02) + 1;
                else
                    value *= (pm.GetAptitudeValue(NAptitude.Sorcellerie) * 0.03) + 1;
            }

            return (int)value;
		}

		public static Guild GetGuildFor( Mobile m )
		{
			Guild g = m.Guild as Guild;

			if ( g == null && m is BaseCreature )
			{
				BaseCreature c = (BaseCreature)m;
				m = c.ControlMaster;

				if ( m != null )
					g = m.Guild as Guild;

				if ( g == null )
				{
					m = c.SummonMaster;

					if ( m != null )
						g = m.Guild as Guild;
				}
			}

			return g;
		}

        public static bool ValidIndirectTarget(Mobile from, Mobile to)
        {
            return ValidIndirectTarget( from, to, false );
        }

		public static bool ValidIndirectTarget( Mobile from, Mobile to, bool hithidden )
		{
			if ( from == to )
				return true;

			if ( (!from.CanSee(to) && !hithidden) || to.AccessLevel > from.AccessLevel )
				return false;

			if ( to is BaseCreature )
			{
				BaseCreature c = (BaseCreature)to;

				if ( c.Controlled || c.Summoned )
				{
					if ( c.ControlMaster == from || c.SummonMaster == from )
						return false;
				}
			}

			if ( from is BaseCreature )
			{
				BaseCreature c = (BaseCreature)from;

				if ( c.Controlled || c.Summoned )
				{
					if ( c.ControlMaster == to || c.SummonMaster == to )
						return false;
				}
			}

			return true;
		}

		private static int[] m_Offsets = new int[]
			{
				-1, -1,
				-1,  0,
				-1,  1,
				0, -1,
				0,  1,
				1, -1,
				1,  0,
				1,  1
			};

		public static void Summon( BaseCreature creature, Mobile caster, int sound, TimeSpan duration, bool scaleDuration, bool scaleStats )
        {
            Map map = caster.Map;

            if (map == null)
                return;

            if (caster.Followers + creature.ControlSlots > caster.FollowersMax)
            {
                caster.SendMessage("Vous ne pouvez pas controller plus de familiers.");
                return;
            }

            if (scaleDuration)
            {
                TMobile pm = caster as TMobile;

                if (pm != null)
                {
                    /* Bonus (Magie Prolongée) */
                    double scale = (pm.GetAptitudeValue(NAptitude.Spiritisme) * 0.04) + 1;
                    duration = TimeSpan.FromSeconds(duration.TotalSeconds * scale);
                }
            }

            if (scaleStats)
            {
                TMobile pm = caster as TMobile;

                if (pm != null)
                {
                    double scale = (pm.GetAptitudeValue(NAptitude.Sorcellerie) * 0.03) + 1;

                    creature.RawStr = (int)(creature.RawStr * scale);
                    creature.Hits = creature.HitsMax;

                    creature.RawDex = (int)(creature.RawDex * scale);
                    creature.Stam = creature.StamMax;

                    creature.RawInt = (int)(creature.RawInt * scale);
                    creature.Mana = creature.ManaMax;

                    creature.DamageMin = (int)(creature.DamageMin * scale);
                    creature.DamageMax = (int)(creature.DamageMax * scale);
                }
            }

            int offset = Utility.Random(8) * 2;

            for (int i = 0; i < m_Offsets.Length; i += 2)
            {
                int x = caster.X + m_Offsets[(offset + i) % m_Offsets.Length];
                int y = caster.Y + m_Offsets[(offset + i + 1) % m_Offsets.Length];

                if (map.CanSpawnMobile(x, y, caster.Z))
                {
                    BaseCreature.Summon(creature, caster, new Point3D(x, y, caster.Z), sound, duration);
                    return;
                }
                else
                {
                    int z = map.GetAverageZ(x, y);

                    if (map.CanSpawnMobile(x, y, z))
                    {
                        BaseCreature.Summon(creature, caster, new Point3D(x, y, z), sound, duration);
                        return;
                    }
                }
            }

            creature.Delete();
            caster.SendLocalizedMessage(501942); // That location is blocked.
		}

        private delegate bool TravelValidator(Map map, Point3D loc);

        private static TravelValidator[] m_Validators = new TravelValidator[]
			{
				new TravelValidator( IsPlace01 ),
				new TravelValidator( IsPlace02 ),
				new TravelValidator( IsPlace03 ),
				new TravelValidator( IsPlace04 ),
				new TravelValidator( IsPlace05 ),
			};

		private static bool[,] m_Rules = new bool[,]
			{
					/*T2A(Fel)		Ilshenar		Wind(Tram),	Wind(Fel),	Dungeons(Fel),	Solen(Tram),	Solen(Fel), CrystalCave(Malas),	Gauntlet(Malas),	Gauntlet(Ferry),	Stronghold */
/* Recall From */	{ false,		true,			true,		false,		false,			true,			false,		false,				false,				false,				true },
/* Recall To */		{ false,		false,			false,		false,		false,			false,			false,		false,				false,				false,				false },
/* Gate From */		{ false,		false,			false,		false,		false,			false,			false,		false,				false,				false,				false },
/* Gate To */		{ false,		false,			false,		false,		false,			false,			false,		false,				false,				false,				false },
/* Mark In */		{ false,		false,			false,		false,		false,			false,			false,		false,				false,				false,				false },
/* Tele From */		{ true,			true,			true,		true,		true,			true,			true,		false,				true,				true,				false },
/* Tele To */		{ true,			true,			true,		true,		true,			true,			true,		false,				true,				false,				false },
			};

		public static bool CheckTravel( Mobile caster, TravelCheckType type )
        {
            /*if ( CheckTravel( caster, caster.Map, caster.Location, type ) )
                return true;

            SendInvalidMessage( caster, type );
            return false;*/

            return CheckTravel(caster, caster.Map, caster.Location, type);
		}

		public static void SendInvalidMessage( Mobile caster, TravelCheckType type )
		{
			if ( type == TravelCheckType.RecallTo || type == TravelCheckType.GateTo )
				caster.SendLocalizedMessage( 1019004 ); // You are not allowed to travel there.
			else if ( type == TravelCheckType.TeleportTo )
				caster.SendLocalizedMessage( 501035 ); // You cannot teleport from here to the destination.
			else
				caster.SendLocalizedMessage( 501802 ); // Thy spell doth not appear to work...
		}

		public static bool CheckTravel( Map map, Point3D loc, TravelCheckType type )
		{
			return CheckTravel( null, map, loc, type );
		}

		private static Mobile m_TravelCaster;
		private static TravelCheckType m_TravelType;

		public static bool CheckTravel( Mobile caster, Map map, Point3D loc, TravelCheckType type )
		{
			if ( IsInvalid( map, loc ) ) // null, internal, out of bounds
			{
				if ( caster != null )
					SendInvalidMessage( caster, type );

				return false;
			}

			m_TravelCaster = caster;
			m_TravelType = type;

			int v = (int)type;
			bool isValid = true;

			for ( int i = 0; isValid && i < m_Validators.Length; ++i )
				isValid = ( m_Rules[v, i] || !m_Validators[i]( map, loc ) );

			if ( !isValid && caster != null )
				SendInvalidMessage( caster, type );

			return isValid;
        }

        public static bool IsPlace01(Map map, Point3D loc)
        {
            int x = loc.X, y = loc.Y;

            return (map == Map.Felucca && x >= 1318 && y >= 2826 && x <= 1335 && y <= 2844);
        }

        public static bool IsPlace02(Map map, Point3D loc)
        {
            int x = loc.X, y = loc.Y;

            return (map == Map.Felucca && x >= 2423 && y >= 1979 && x <= 2445 && y <= 2002);
        }

        public static bool IsPlace03(Map map, Point3D loc)
        {
            int x = loc.X, y = loc.Y;

            return (map == Map.Felucca && x >= 1870 && y >= 688 && x <= 1884 && y <= 702);
        }

        public static bool IsPlace04(Map map, Point3D loc)
        {
            int x = loc.X, y = loc.Y;

            return (map == Map.Felucca && x >= 957 && y >= 550 && x <= 975 && y <= 570);
        }

        public static bool IsPlace05(Map map, Point3D loc)
        {
            int x = loc.X, y = loc.Y;

            return (map == Map.Felucca && x >= 2846 && y >= 1309 && x <= 2881 && y <= 1326);
        }

		public static bool IsInvalid( Map map, Point3D loc )
		{
			if ( map == null || map == Map.Internal )
				return true;

			int x = loc.X, y = loc.Y;

			return ( x < 0 || y < 0 || x >= map.Width || y >= map.Height );
		}

		//towns
		public static bool IsTown( IPoint3D loc, Mobile caster )
		{
			if ( loc is Item )
				loc = ((Item)loc).GetWorldLocation();

			return IsTown( new Point3D( loc ), caster );
		}

		public static bool IsTown( Point3D loc, Mobile caster )
		{
			return false;
		}

		public static bool CheckTown( IPoint3D loc, Mobile caster )
		{
			if ( loc is Item )
				loc = ((Item)loc).GetWorldLocation();

			return CheckTown( new Point3D( loc ), caster );
		}

		public static bool CheckTown( Point3D loc, Mobile caster )
		{
			if ( IsTown( loc, caster ) )
			{
				caster.SendLocalizedMessage( 500946 ); // You cannot cast this in town!
				return false;
			}

			return true;
		}

		//magic reflection
		public static void CheckReflect( int circle, Mobile caster, ref Mobile target )
		{
			CheckReflect( circle, ref caster, ref target );
		}

        public static void CheckReflect(int circle, ref Mobile caster, ref Mobile target)
        {
            if (ReflectionSpell.Registry.Contains(target))
            {
                int chance = (int)ReflectionSpell.Registry[target] - (int)(circle * 1.5);

                if (Utility.Random(0, 100) < chance)
                {
                    target.FixedEffect(0x37B9, 10, 5);

                    Mobile temp = caster;
                    caster = target;
                    target = temp;
                }
            }
        }

		public static void Damage( Spell spell, Mobile target, double damage )
		{
			TimeSpan ts = GetDamageDelayForSpell( spell );

			Damage( ts, target, spell.Caster, damage );
		}

		public static void Damage( TimeSpan delay, Mobile target, double damage )
		{
			Damage( delay, target, null, damage );
		}

		public static void Damage( TimeSpan delay, Mobile target, Mobile from, double damage )
		{
			int iDamage = (int) damage;

			if ( delay == TimeSpan.Zero )
			{
				if ( from is BaseCreature )
					((BaseCreature)from).AlterSpellDamageTo( target, ref iDamage );

				if ( target is BaseCreature )
					((BaseCreature)target).AlterSpellDamageFrom( from, ref iDamage );

				target.Damage( iDamage, from );
			}
			else
			{
				new SpellDamageTimer( target, from, iDamage, delay ).Start();
			}

			if ( target is BaseCreature && from != null && delay == TimeSpan.Zero )
				((BaseCreature)target).OnDamagedBySpell( from );
		}

		public static void Damage( Spell spell, Mobile target, double damage, int phys, int fire, int cold, int pois, int nrgy )
		{
			TimeSpan ts = GetDamageDelayForSpell( spell );

			Damage( ts, target, spell.Caster, damage, phys, fire, cold, pois, nrgy );
		}

		public static void Damage( Spell spell, Mobile target, double damage, int phys, int fire, int cold, int pois, int nrgy, DFAlgorithm dfa )
		{
			TimeSpan ts = GetDamageDelayForSpell( spell );

			Damage( ts, target, spell.Caster, damage, phys, fire, cold, pois, nrgy, dfa );
		}

		public static void Damage( TimeSpan delay, Mobile target, double damage, int phys, int fire, int cold, int pois, int nrgy )
		{
			Damage( delay, target, null, damage, phys, fire, cold, pois, nrgy );
		}

		public static void Damage( TimeSpan delay, Mobile target, Mobile from, double damage, int phys, int fire, int cold, int pois, int nrgy )
		{
			Damage( delay, target, from, damage, phys, fire, cold, pois, nrgy, DFAlgorithm.Standard );
		}


		public static void Damage( TimeSpan delay, Mobile target, Mobile from, double damage, int phys, int fire, int cold, int pois, int nrgy, DFAlgorithm dfa )
		{
			int iDamage = (int) damage;

			if ( delay == TimeSpan.Zero )
			{
				if ( from is BaseCreature )
					((BaseCreature)from).AlterSpellDamageTo( target, ref iDamage );

				if ( target is BaseCreature )
					((BaseCreature)target).AlterSpellDamageFrom( from, ref iDamage );

				WeightOverloading.DFA = dfa;
				AOS.Damage( target, from, iDamage, phys, fire, cold, pois, nrgy );
				WeightOverloading.DFA = DFAlgorithm.Standard;
			}
			else
			{
				new SpellDamageTimerAOS( target, from, iDamage, phys, fire, cold, pois, nrgy, delay, dfa ).Start();
			}

			if ( target is BaseCreature && from != null && delay == TimeSpan.Zero )
				((BaseCreature)target).OnDamagedBySpell( from );
		}

		private class SpellDamageTimer : Timer
		{
			private Mobile m_Target, m_From;
			private int m_Damage;

			public SpellDamageTimer( Mobile target, Mobile from, int damage, TimeSpan delay ) : base( delay )
			{
				m_Target = target;
				m_From = from;
				m_Damage = damage;

				Priority = TimerPriority.TwentyFiveMS;
			}

			protected override void OnTick()
			{
				if ( m_From is BaseCreature )
					((BaseCreature)m_From).AlterSpellDamageTo( m_Target, ref m_Damage );

				if ( m_Target is BaseCreature )
					((BaseCreature)m_Target).AlterSpellDamageFrom( m_From, ref m_Damage );

				m_Target.Damage( m_Damage );
			}
		}

		private class SpellDamageTimerAOS : Timer
		{
			private Mobile m_Target, m_From;
			private int m_Damage;
			private int m_Phys, m_Fire, m_Cold, m_Pois, m_Nrgy;
			private DFAlgorithm m_DFA;

			public SpellDamageTimerAOS( Mobile target, Mobile from, int damage, int phys, int fire, int cold, int pois, int nrgy, TimeSpan delay, DFAlgorithm dfa ) : base( delay )
			{
				m_Target = target;
				m_From = from;
				m_Damage = damage;
				m_Phys = phys;
				m_Fire = fire;
				m_Cold = cold;
				m_Pois = pois;
				m_Nrgy = nrgy;
				m_DFA = dfa;

				Priority = TimerPriority.TwentyFiveMS;
			}

			protected override void OnTick()
			{
				if ( m_From is BaseCreature && m_Target != null )
					((BaseCreature)m_From).AlterSpellDamageTo( m_Target, ref m_Damage );

				if ( m_Target is BaseCreature && m_From != null )
					((BaseCreature)m_Target).AlterSpellDamageFrom( m_From, ref m_Damage );

				WeightOverloading.DFA = m_DFA;
				AOS.Damage( m_Target, m_From, m_Damage, m_Phys, m_Fire, m_Cold, m_Pois, m_Nrgy );
				WeightOverloading.DFA = DFAlgorithm.Standard;

				if ( m_Target is BaseCreature && m_From != null )
					((BaseCreature)m_Target).OnDamagedBySpell( m_From );
			}
		}
	}
    public class TransformationSpellHelper
    {
        #region Context Stuff
        private static Dictionary<Mobile, TransformContext> m_Table = new Dictionary<Mobile, TransformContext>();

        public static void AddContext(Mobile m, TransformContext context)
        {
            m_Table[m] = context;
        }

        public static void RemoveContext(Mobile m, bool resetGraphics)
        {
            TransformContext context = GetContext(m);

            if (context != null)
                RemoveContext(m, context, resetGraphics);
        }

        public static void RemoveContext(Mobile m, TransformContext context, bool resetGraphics)
        {
            if (m_Table.ContainsKey(m))
            {
                m_Table.Remove(m);

                List<ResistanceMod> mods = context.Mods;

                for (int i = 0; i < mods.Count; ++i)
                    m.RemoveResistanceMod(mods[i]);

                if (resetGraphics)
                {
                    m.HueMod = -1;
                    m.BodyMod = 0;
                }

                context.Timer.Stop();
                context.Spell.RemoveEffect(m);
            }
        }

        public static TransformContext GetContext(Mobile m)
        {
            TransformContext context = null;

            m_Table.TryGetValue(m, out context);

            return context;
        }

        public static bool UnderTransformation(Mobile m)
        {
            return (GetContext(m) != null);
        }

        public static bool UnderTransformation(Mobile m, Type type)
        {
            TransformContext context = GetContext(m);

            return (context != null && context.Type == type);
        }
        #endregion

        public static bool CheckCast(Mobile caster, Spell spell)
        {
            if (Factions.Sigil.ExistsOn(caster))
            {
                caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
                return false;
            }
            /*else if (!caster.CanBeginAction(typeof(PolymorphSpell)))
            {
                caster.SendLocalizedMessage(1061628); // You can't do that while polymorphed.
                return false;
            }
            else if (AnimalForm.UnderTransformation(caster))
            {
                caster.SendLocalizedMessage(1061091); // You cannot cast that spell in this form.
                return false;
            }*/

            return true;
        }

        public static bool OnCast(Mobile caster, Spell spell)
        {
            ITransformationSpell transformSpell = spell as ITransformationSpell;

            if (transformSpell == null)
                return false;

            if (Factions.Sigil.ExistsOn(caster))
            {
                caster.SendLocalizedMessage(1061632); // You can't do that while carrying the sigil.
            }
            /*else if (!caster.CanBeginAction(typeof(PolymorphSpell)))
            {
                caster.SendLocalizedMessage(1061628); // You can't do that while polymorphed.
            }*/
            else if (DisguiseTimers.IsDisguised(caster))
            {
                caster.SendLocalizedMessage(1061631); // You can't do that while disguised.
                return false;
            }
            /*else if (AnimalForm.UnderTransformation(caster))
            {
                caster.SendLocalizedMessage(1061091); // You cannot cast that spell in this form.
            }*/
            else if (!caster.CanBeginAction(typeof(IncognitoSpell)) || (caster.IsBodyMod && GetContext(caster) == null))
            {
                spell.DoFizzle();
            }
            else if (spell.CheckSequence())
            {
                TransformContext context = GetContext(caster);
                Type ourType = spell.GetType();

                bool wasTransformed = (context != null);
                bool ourTransform = (wasTransformed && context.Type == ourType);

                if (wasTransformed)
                {
                    RemoveContext(caster, context, ourTransform);

                    if (ourTransform)
                    {
                        caster.PlaySound(0xFA);
                        caster.FixedParticles(0x3728, 1, 13, 5042, EffectLayer.Waist);
                    }
                }

                if (!ourTransform)
                {
                    List<ResistanceMod> mods = new List<ResistanceMod>();

                    if (transformSpell.PhysResistOffset != 0)
                        mods.Add(new ResistanceMod(ResistanceType.Physical, transformSpell.PhysResistOffset));

                    if (transformSpell.FireResistOffset != 0)
                        mods.Add(new ResistanceMod(ResistanceType.Contondant, transformSpell.FireResistOffset));

                    if (transformSpell.ColdResistOffset != 0)
                        mods.Add(new ResistanceMod(ResistanceType.Tranchant, transformSpell.ColdResistOffset));

                    if (transformSpell.PoisResistOffset != 0)
                        mods.Add(new ResistanceMod(ResistanceType.Perforant, transformSpell.PoisResistOffset));

                    if (transformSpell.NrgyResistOffset != 0)
                        mods.Add(new ResistanceMod(ResistanceType.Magie, transformSpell.NrgyResistOffset));

                    if (!((Body)transformSpell.Body).IsHuman)
                    {
                        Mobiles.IMount mt = caster.Mount;

                        if (mt != null)
                            mt.Rider = null;
                    }

                    caster.BodyMod = transformSpell.Body;
                    caster.HueMod = transformSpell.Hue;

                    for (int i = 0; i < mods.Count; ++i)
                        caster.AddResistanceMod(mods[i]);

                    transformSpell.DoEffect(caster);

                    Timer timer = new TransformTimer(caster, transformSpell);
                    timer.Start();

                    AddContext(caster, new TransformContext(timer, mods, ourType, transformSpell));
                    return true;
                }
            }

            return false;
        }
    }

    public interface ITransformationSpell
    {
        int Body { get; }
        int Hue { get; }

        int PhysResistOffset { get; }
        int FireResistOffset { get; }
        int ColdResistOffset { get; }
        int PoisResistOffset { get; }
        int NrgyResistOffset { get; }

        double TickRate { get; }
        void OnTick(Mobile m);

        void DoEffect(Mobile m);
        void RemoveEffect(Mobile m);
    }


    public class TransformContext
    {
        private Timer m_Timer;
        private List<ResistanceMod> m_Mods;
        private Type m_Type;
        private ITransformationSpell m_Spell;

        public Timer Timer { get { return m_Timer; } }
        public List<ResistanceMod> Mods { get { return m_Mods; } }
        public Type Type { get { return m_Type; } }
        public ITransformationSpell Spell { get { return m_Spell; } }

        public TransformContext(Timer timer, List<ResistanceMod> mods, Type type, ITransformationSpell spell)
        {
            m_Timer = timer;
            m_Mods = mods;
            m_Type = type;
            m_Spell = spell;
        }
    }

    public class TransformTimer : Timer
    {
        private Mobile m_Mobile;
        private ITransformationSpell m_Spell;

        public TransformTimer(Mobile from, ITransformationSpell spell)
            : base(TimeSpan.FromSeconds(spell.TickRate), TimeSpan.FromSeconds(spell.TickRate))
        {
            m_Mobile = from;
            m_Spell = spell;

            Priority = TimerPriority.TwoFiftyMS;
        }

        protected override void OnTick()
        {
            if (m_Mobile.Deleted || !m_Mobile.Alive || m_Mobile.Body != m_Spell.Body || m_Mobile.Hue != m_Spell.Hue)
            {
                TransformationSpellHelper.RemoveContext(m_Mobile, true);
                Stop();
            }
            else
            {
                m_Spell.OnTick(m_Mobile);
            }
        }
    }
}