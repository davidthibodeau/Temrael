using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Races
{
    public class AucuneRace : Race
    {
        public AucuneRace() : base (0)
        {

        }

        public AucuneRace(GenericReader reader)
            : base(reader)
        {
        }

        public static int RaceId
        {
            get { return -1; }
        }

        public override int Id
        {
            get { return RaceId; }
        }

        public override string Name
        {
            get { return "Aucune"; }
        }

        public override string NameF
        {
            get { return "Aucune"; }
        }

        public override Type Skin
        {
            get { return null; }
        }

        public override string Description
        {
            get { return ""; }
        }

        public override int Image
        {
            get { return -1; }
        }

        public override int Tooltip
        {
            get { return -1; }
        }

        public override bool isTieffelin
        {
            get { return false; }
        }

        public override bool isAasimaar
        {
            get { return false; }
        }

        public override bool Transformed
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }
}
