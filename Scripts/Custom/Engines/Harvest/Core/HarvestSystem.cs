using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Engines.Harvest
{
    public abstract class HarvestSystem
    {
        #region clearbanks
        public static DateTime m_BankClear = DateTime.Now;
        #endregion

        private ArrayList m_Definitions;

        public ArrayList Definitions { get { return m_Definitions; } }

        public HarvestSystem()
        {
            m_Definitions = new ArrayList();
        }

        public virtual bool CheckTool(Mobile from, Item tool)
        {
            bool wornOut = (tool == null || tool.Deleted || (tool is IUsesRemaining && ((IUsesRemaining)tool).UsesRemaining <= 0));

            if (wornOut)
                from.SendLocalizedMessage(1044038); // You have worn out your tool!

            return !wornOut;
        }

        public virtual bool CheckHarvest(Mobile from, Item tool)
        {
            return CheckTool(from, tool);
        }

        public virtual bool CheckHarvest(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
        {
            return CheckTool(from, tool);
        }

        public virtual bool CheckRange(Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, bool timed)
        {
            bool inRange = (from.Map == map && from.InRange(loc, def.MaxRange));

            if (!inRange)
                def.SendMessageTo(from, timed ? def.TimedOutOfRangeMessage : def.OutOfRangeMessage);

            return inRange;
        }

        public virtual bool CheckResources(Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, bool timed, int tileID)
        {
            HarvestBank bank = def.GetBank(from, map, loc.X, loc.Y, tool, tileID);
            bool available = (bank != null && bank.Current >= def.MinConsumedPerHarvest);

            if (!available)
                def.SendMessageTo(from, timed ? def.DoubleHarvestMessage : def.NoResourcesMessage);

            return available;
        }

        public virtual void OnBadHarvestTarget(Mobile from, Item tool, object toHarvest)
        {
        }

        public virtual object GetLock(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
        {
            /* Here we prevent multiple harvesting.
             * 
             * Some options:
             *  - 'return tool;' : This will allow the player to harvest more than once concurrently, but only if they use multiple tools. This seems to be as OSI.
             *  - 'return GetType();' : This will disallow multiple harvesting of the same type. That is, we couldn't mine more than once concurrently, but we could be both mining and lumberjacking.
             *  - 'return typeof( HarvestSystem );' : This will completely restrict concurrent harvesting.
             */

            return tool;
        }

        public virtual void OnConcurrentHarvest(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
        {
        }

        public virtual void OnHarvestStarted(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
        {
        }

        public virtual bool BeginHarvesting(Mobile from, Item tool)
        {
            if (!CheckHarvest(from, tool))
                return false;

            from.Target = new HarvestTarget(tool, this);
            return true;
        }

        public virtual void FinishHarvesting(Mobile from, Item tool, HarvestDefinition def, object toHarvest, object locked)
        {
            from.EndAction(locked);

            if (!CheckHarvest(from, tool))
                return;

            int tileID;
            Map map;
            Point3D loc;

            if (tool.Parent != from && !(tool is FishingNet))
            {
                from.SendMessage("Vous devez avoir l'objet en main pour l'utiliser."); // That must be in your pack for you to use it.
                return;
            }
            else if (!GetHarvestDetails(from, tool, toHarvest, out tileID, out map, out loc))
            {
                OnBadHarvestTarget(from, tool, toHarvest);
                return;
            }
            else if (!def.Validate(tileID))
            {
                OnBadHarvestTarget(from, tool, toHarvest);
                return;
            }

            if (!CheckRange(from, tool, def, map, loc, true))
                return;
            else if (!CheckResources(from, tool, def, map, loc, true, tileID))
                return;
            else if (!CheckHarvest(from, tool, def, toHarvest))
                return;

            if (SpecialHarvest(from, tool, def, map, loc))
                return;

            HarvestBank bank = def.GetBank(from, map, loc.X, loc.Y, tool, tileID);

            if (bank == null)
            {
                def.SendMessageTo(from, def.FailMessage);
                return;
            }
            
            HarvestVein vein = bank.Vein;

            //if ( vein != null )
            //    vein = MutateVein( from, tool, def, bank, toHarvest, vein );

            if (vein == null)
            {
                def.SendMessageTo(from, def.FailMessage);
                return;
            }

            HarvestResource primary = vein.PrimaryResource;
            HarvestResource fallback = vein.FallbackResource;
            HarvestResource resource = MutateResource(from, tool, def, map, loc, vein, primary, fallback);

            double skillBase = from.Skills[def.Skill].Base;
            double skillValue = from.Skills[def.Skill].Value;

            Type type = null;

            from.CheckSkill(def.Skill, -20, 120);

            if (skillBase >= resource.ReqSkill && from.CheckSkill(def.Skill, resource.MinSkill - 25, resource.MaxSkill + 25))
            {
                if (from is TMobile)
                {
                    TMobile pm = (TMobile)from;

                    if (pm.CheckFatigue(10))
                    {
                        def.SendMessageTo(from, def.FailMessage);

                        OnHarvestFinished(from, tool, def, vein, bank, resource, toHarvest);
                        return;
                    }
                }

                type = GetResourceType(from, tool, def, map, loc, resource);

                if (type != null)
                    type = MutateType(type, from, tool, def, map, loc, resource);

                if (type != null)
                {
                    Item item = Construct(type, from);

                    if (item == null)
                    {
                        type = null;
                    }
                    else
                    {
                        /*if (def.Skill == SkillName.Peche && 0.015 > Utility.RandomDouble())
                        {
                            if (tool is LargeFishingPole)
                                item = Loot.RandomMidTreasureMap();
                            else if (tool is StrongFishingPole)
                                item = Loot.RandomMidTreasureMap();
                            else if (tool is LargeStrongFishingPole)
                                item = Loot.RandomHighTreasureMap();
                            else if (tool is FishingNet)
                                item = Loot.RandomLowTreasureMap();
                            else if (tool is Harpoon)
                                item = Loot.RandomLowTreasureMap();
                            else
                                item = Loot.RandomLowTreasureMap();

                            if (item.Amount != 1)
                                item.Amount = 1;

                            type = item.GetType();
                        }*/

                        if (item.Stackable /*&& !(item is BaseTreasureMapPart)*/)
                        {
                            int consumed = Utility.RandomMinMax(def.MinConsumedPerHarvest, def.MaxConsumedPerHarvest);
                            consumed += (int)(from.Skills[def.Skill].Value / 25);
                            
                            if (from is TMobile)
                            {
                                TMobile tmob = (TMobile)from;
                                Random rand = new Random();

                                if (def.Skill == SkillName.Foresterie)
                                {
                                    if (tmob.GetAptitudeValue(Aptitude.Forestier) * 5 > rand.Next(0, 100))
                                        consumed += tmob.GetAptitudeValue(Aptitude.Forestier) / 3;
                                }
                                else if (def.Skill == SkillName.Excavation)
                                {
                                    if (tmob.GetAptitudeValue(Aptitude.Mineur) * 5 > rand.Next(0, 100))
                                        consumed += tmob.GetAptitudeValue(Aptitude.Mineur) / 3;
                                }
                            }

                            consumed += Utility.RandomMinMax(-1, 1);

                            if (consumed > 10)
                                consumed = 10;

                            if (consumed < 1 /*|| (def.Skill == SkillName.Fishing && (tool is Harpoon || tool is LargeStrongFishingPole || tool is LargeFishingPole || tool is StrongFishingPole || tool is FishingPole))*/)
                                consumed = 1;

                            if (bank.Current < consumed)
                                consumed = bank.Current;

                            if (bank.Current >= consumed)
                                item.Amount = consumed;
                        }

                        //if (!(item is BaseTreasureMapPart))
                            bank.Consume(def, item.Amount, loc);

                        if (Give(from, item, def.PlaceAtFeetIfFull, loc))
                        {
                            SendSuccessTo(from, item, resource);
                        }
                        else
                        {
                            SendPackFullTo(from, item, def, resource);
                            item.Delete();
                        }

                        if (tool is IUsesRemaining)
                        {
                            IUsesRemaining toolWithUses = (IUsesRemaining)tool;

                            toolWithUses.ShowUsesRemaining = true;

                            if (toolWithUses.UsesRemaining > 0)
                                --toolWithUses.UsesRemaining;

                            if (toolWithUses.UsesRemaining < 1)
                            {
                                tool.Delete();
                                def.SendMessageTo(from, def.ToolBrokeMessage);
                            }
                        }
                    }
                }
            }

            if (type == null)
                def.SendMessageTo(from, def.FailMessage);

            OnHarvestFinished(from, tool, def, vein, bank, resource, toHarvest);
        }

        public virtual void OnHarvestFinished(Mobile from, Item tool, HarvestDefinition def, HarvestVein vein, HarvestBank bank, HarvestResource resource, object harvested)
        {
            if (from.Hidden)
                from.RevealingAction();
        }

        public virtual bool SpecialHarvest(Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc)
        {
            return false;
        }

        public virtual Item Construct(Type type, Mobile from)
        {
            try { return Activator.CreateInstance(type) as Item; }
            catch { return null; }
        }

        public virtual HarvestVein MutateVein(Mobile from, Item tool, HarvestDefinition def, HarvestBank bank, object toHarvest, HarvestVein vein)
        {
            return vein;
        }

        public virtual void SendSuccessTo(Mobile from, Item item, HarvestResource resource)
        {
            /*if (item is BaseTreasureMapPart)
                from.SendMessage("Vous trouvez un morceau de carte au trésor et le placez dans votre sac !");
            else
                resource.SendSuccessTo(from);*/
        }

        public virtual void SendPackFullTo(Mobile from, Item item, HarvestDefinition def, HarvestResource resource)
        {
            def.SendMessageTo(from, def.PackFullMessage);
        }

        public virtual bool Give(Mobile m, Item item, bool placeAtFeet)
        {
            if (m.PlaceInBackpack(item))
                return true;

            if (!placeAtFeet)
                return false;

            Map map = m.Map;

            if (map == null)
                return false;

            ArrayList atFeet = new ArrayList();

            foreach (Item obj in m.GetItemsInRange(0))
                atFeet.Add(obj);

            for (int i = 0; i < atFeet.Count; ++i)
            {
                Item check = (Item)atFeet[i];

                if (check.StackWith(m, item, false))
                    return true;
            }

            item.MoveToWorld(m.Location, map);
            return true;
        }

        public virtual bool Give(Mobile m, Item item, bool placeAtFeet, Point3D loc)
        {
            if (m.PlaceInBackpack(item))
                return true;

            if (!placeAtFeet)
                return false;

            Map map = m.Map;

            if (map == null)
                return false;

            ArrayList atFeet = new ArrayList();

            foreach (Item obj in m.GetItemsInRange(0))
                atFeet.Add(obj);

            for (int i = 0; i < atFeet.Count; ++i)
            {
                Item check = (Item)atFeet[i];

                if (check.StackWith(m, item, false))
                    return true;
            }

            item.MoveToWorld(m.Location, map);
            return true;
        }

        public virtual Type MutateType(Type type, Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, HarvestResource resource)
        {
            return type;
        }

        public virtual Type GetResourceType(Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, HarvestResource resource)
        {
            if (resource.Types.Length > 0)
                return resource.Types[Utility.Random(resource.Types.Length)];

            return null;
        }

        public virtual HarvestResource MutateResource(Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, HarvestVein vein, HarvestResource primary, HarvestResource fallback)
        {
            //if ( vein.ChanceToFallback > Utility.RandomDouble() )
            //    return fallback;

            //double skillValue = from.Skills[def.Skill].Value;

            //if ( fallback != null && (skillValue < primary.ReqSkill || skillValue < primary.MinSkill) )
            //    return fallback;

            return primary;
        }

        public virtual bool OnHarvesting(Mobile from, Item tool, HarvestDefinition def, object toHarvest, object locked, bool last)
        {
            if (!CheckHarvest(from, tool))
            {
                from.EndAction(locked);
                return false;
            }

            if (from.Frozen || from.Paralyzed || !from.Alive)
            {
                from.EndAction(locked);
                from.SendMessage("Assez dur de récolter lorsque vous ne pouvez pas bouger.");
                return false;
            }

            int tileID;
            Map map;
            Point3D loc;

            if (!GetHarvestDetails(from, tool, toHarvest, out tileID, out map, out loc))
            {
                from.EndAction(locked);
                OnBadHarvestTarget(from, tool, toHarvest);
                return false;
            }
            else if (!def.Validate(tileID))
            {
                from.EndAction(locked);
                OnBadHarvestTarget(from, tool, toHarvest);
                return false;
            }
            else if (!CheckRange(from, tool, def, map, loc, true))
            {
                from.EndAction(locked);
                return false;
            }
            else if (!CheckResources(from, tool, def, map, loc, true, tileID))
            {
                from.EndAction(locked);
                return false;
            }
            else if (!CheckHarvest(from, tool, def, toHarvest))
            {
                from.EndAction(locked);
                return false;
            }

            DoHarvestingEffect(from, tool, def, map, loc);

            new HarvestSoundTimer(from, tool, this, def, toHarvest, locked, last).Start();

            return !last;
        }

        public virtual void DoHarvestingSound(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
        {
            if (def.EffectSounds.Length > 0)
                from.PlaySound(Utility.RandomList(def.EffectSounds));
        }

        public virtual void DoHarvestingEffect(Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc)
        {
            from.Direction = from.GetDirectionTo(loc);

            if (!from.Mounted)
                from.Animate(Utility.RandomList(def.EffectActions), 5, 1, true, false, 0);
        }

        public virtual HarvestDefinition GetDefinition(int tileID)
        {
            HarvestDefinition def = null;

            for (int i = 0; def == null && i < m_Definitions.Count; ++i)
            {
                HarvestDefinition check = (HarvestDefinition)m_Definitions[i];

                if (check.Validate(tileID))
                    def = check;
            }

            return def;
        }

        public virtual void StartHarvesting(Mobile from, Item tool, object toHarvest)
        {
            if (!CheckHarvest(from, tool))
                return;

            int tileID;
            Map map;
            Point3D loc;

            if (!GetHarvestDetails(from, tool, toHarvest, out tileID, out map, out loc))
            {
                OnBadHarvestTarget(from, tool, toHarvest);
                return;
            }

            HarvestDefinition def = GetDefinition(tileID);

            if (def == null)
            {
                OnBadHarvestTarget(from, tool, toHarvest);
                return;
            }

            if (!CheckRange(from, tool, def, map, loc, false))
                return;

            if (def.Skill == SkillName.Foresterie)
            {
                HarvestBank bank = def.GetBank(from, map, loc.X, loc.Y, tool, tileID);

                if (bank != null && bank.Vein.PrimaryResource.ReqSkill > from.Skills[def.Skill].Value)
                {
                    from.SendMessage("Vous n'êtes pas assez compétent pour bûcher cet arbre.");
                    return;
                }
            }

            if (!CheckResources(from, tool, def, map, loc, false, tileID))
                return;

            if (!CheckHarvest(from, tool, def, toHarvest))
                return;

            object toLock = GetLock(from, tool, def, toHarvest);

            if (!from.BeginAction(toLock))
            {
                OnConcurrentHarvest(from, tool, def, toHarvest);
                return;
            }

            new HarvestTimer(from, tool, this, def, toHarvest, toLock).Start();
            OnHarvestStarted(from, tool, def, toHarvest);
        }

        public virtual bool GetHarvestDetails(Mobile from, Item tool, object toHarvest, out int tileID, out Map map, out Point3D loc)
        {
            if (toHarvest is Static && !((Static)toHarvest).Movable)
            {
                Static obj = (Static)toHarvest;

                tileID = (obj.ItemID & 0x3FFF) | 0x4000;
                map = obj.Map;
                loc = obj.GetWorldLocation();
            }
            else if (toHarvest is StaticTarget)
            {
                StaticTarget obj = (StaticTarget)toHarvest;

                tileID = (obj.ItemID & 0x3FFF) | 0x4000;
                map = from.Map;
                loc = obj.Location;
            }
            else if (toHarvest is LandTarget)
            {
                LandTarget obj = (LandTarget)toHarvest;

                tileID = obj.TileID & 0x3FFF;
                map = from.Map;
                loc = obj.Location;
            }
            else
            {
                tileID = 0;
                map = null;
                loc = Point3D.Zero;
                return false;
            }

            return (map != null && map != Map.Internal);
        }
    }
}

namespace Server
{
    public interface IChopable
    {
        void OnChop(Mobile from);
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class FurnitureAttribute : Attribute
    {
        public static bool Check(Item item)
        {
            return (item != null && item.GetType().IsDefined(typeof(FurnitureAttribute), false));
        }

        public FurnitureAttribute()
        {
        }
    }
}