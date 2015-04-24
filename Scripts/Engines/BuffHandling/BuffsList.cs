using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Items;

namespace Server.Engines.BuffHandling
{
    #region Potions à buff.


    public abstract class Buff : BaseBuff
    {

        public Buff(TimeSpan duration)
            : base(duration)
        {
        }
    }

    #endregion

    #region Potions à malus.





    #endregion

    #region Buffs
    //public class BuffForce : Buff
    //{
    //    public override MobileDelta mobileDelta
    //    {
    //        get
    //        {
    //            return MobileDelta.Stat;
    //        }
    //    }

    //    private int forceOffset;

    //    public BuffForce(int offset, TimeSpan duration) : base(duration)
    //    {
    //        forceOffset = offset;
    //    }

    //    public override void Effect(Mobile trg)
    //    {
    //        RetourGetOffset = forceOffset;
    //    }

    //    public override void RemoveEffect(Mobile trg)
    //    {
    //        RetourGetOffset = 0;
    //    }

    //    public override bool CompareNewEntry(Buff buff)
    //    {
    //        if (buff is BuffForce)
    //        {
    //            BuffForce buffForce = (BuffForce)buff;

    //            if (Math.Abs(buffForce.forceOffset) > Math.Abs(RetourGetOffset))
    //            {
    //                forceOffset = buffForce.forceOffset;
    //            }

    //            return true;
    //        }

    //        return false;
    //    }
    //}
    #endregion

    #region Debuffs

    #endregion
}
