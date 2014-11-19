using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Engines.Races
{
    public enum RaceSecrete { Aucun, Aasimar, Tieffelin }

    public abstract class Humain : Race
    {
        private RaceSecrete raceSecrete;
        private int hueSecrete;

        public override bool isAasimaar
        {
            get { return raceSecrete == RaceSecrete.Aasimar; }
        }

        public override bool isTieffelin
        {
            get { return raceSecrete == RaceSecrete.Tieffelin; }
        }

        public override bool Transformed
        {
            get;
            set;
        }

        public Humain(int hue)
            : base(hue)
        {
            raceSecrete = RaceSecrete.Aucun;
        }

        public Humain(RaceSecrete r, int regHue, int secHue) : base(regHue)
        {
            raceSecrete = r;
            hueSecrete = secHue;
        }

        public Humain(GenericReader reader) : base(reader)
        {
            int version = reader.ReadInt();

            raceSecrete = (RaceSecrete)reader.ReadInt();
            hueSecrete = reader.ReadInt();
            Transformed = reader.ReadBool();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            
            writer.Write(0); //version

            writer.Write((int)raceSecrete);
            writer.Write(hueSecrete);
            writer.Write(Transformed);
        }

        public override void Transformer(PlayerMobile from)
        {
            if(raceSecrete == RaceSecrete.Aucun || Transformed == true)
                return;

            Race.SupprimerSkin(from);

            if (raceSecrete == RaceSecrete.Tieffelin)
            {
                if (from.FindItemOnLayer(Layer.Cloak) != null)
                    from.AddToBackpack(from.FindItemOnLayer(Layer.Cloak));

                from.AddItem(new AilesTieffelin());
                from.AddItem(new CorpsTieffelin());

                if (from.FindItemOnLayer(Layer.Helm) != null)
                    from.AddToBackpack(from.FindItemOnLayer(Layer.Helm));

                from.AddItem(new CornesTieffelin());
            }
            else
            {
                from.AddItem(new CorpsAasimar());
            }
            from.Hue = hueSecrete;
            from.Identities.Transformer();
            Transformed = true;
       }

        public override void Detransformer(PlayerMobile from)
        {
            if (raceSecrete == RaceSecrete.Aucun || Transformed == false)
                return;

            if (raceSecrete == RaceSecrete.Tieffelin)
            {
                if (from.FindItemOnLayer(Layer.Cloak) is AilesTieffelin)
                    from.FindItemOnLayer(Layer.Cloak).Delete();
                if (from.FindItemOnLayer(Layer.Shirt) is CorpsTieffelin)
                    from.FindItemOnLayer(Layer.Shirt).Delete();
                if (from.FindItemOnLayer(Layer.Helm) is CornesTieffelin)
                    from.FindItemOnLayer(Layer.Helm).Delete();
            }
            else
            {
                if (from.FindItemOnLayer(Layer.Shirt) is CorpsAasimar)
                    from.FindItemOnLayer(Layer.Shirt).Delete();
            }

            from.Hue = Hue;
            from.Identities.Detransformer();
            from.Race.Transformed = false;
        }
    }

    public class TransformerEntry : ContextMenuEntry
    {
        private PlayerMobile from;

        public TransformerEntry(PlayerMobile f)
            : base(6285)
        {
            from = f;
        }

        public override void OnClick()
        {
            from.Race.Transformer(from);
        }
    }

    public class DetransformerEntry : ContextMenuEntry
    {
        private PlayerMobile from;

        public DetransformerEntry(PlayerMobile f)
            : base(6285)
        {
            from = f;
        }

        public override void OnClick()
        {
            from.Race.Detransformer(from);
        }
    }
}
