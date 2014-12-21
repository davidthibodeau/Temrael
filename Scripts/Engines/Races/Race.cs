using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Races
{
    [PropertyObject]
	public abstract class Race
    {
        public abstract int Id { get; }

        public abstract int[] HueGumps { get; }

        [CommandProperty(AccessLevel.Batisseur)]
        public virtual string Name { get { return ""; } }
        public abstract string NameF { get; }

        public abstract Type Skin { get; }

        public abstract string Description { get; }
        public abstract int Image { get; }
        public abstract int Tooltip { get; }

        private int hue;

        [CommandProperty(AccessLevel.Batisseur)]
        public int Hue { get { return hue; } }

        public abstract bool isTieffelin { get; }

        public abstract bool isAasimaar { get; }

        public abstract bool Transformed { get; set; }

        public virtual void Transformer(PlayerMobile from)
        {
        }

        public virtual void Detransformer(PlayerMobile from)
        {
        }

        public Race(int h)
        {
            hue = h;
        }

        public Race(GenericReader reader)
        {
            int version = reader.ReadInt();

            hue = reader.ReadInt();
        }

        public virtual void Serialize(GenericWriter writer)
        {
            writer.Write(0); //version

            writer.Write(hue);
        }

        public static void Configure()
        {
            Exception ex = new Exception("Race ids incorrects!");
            // Les races ids sont uniques. Ceci est une vérification de leur intégrité.
            if (Capiceen.RaceId != 1)
                throw ex;
            if (Nordique.RaceId != 2)
                throw ex;
            if (Nomade.RaceId != 3)
                throw ex;
            if (Alfar.RaceId != 4)
                throw ex;
            if (Elfe.RaceId != 5)
                throw ex;
            if (Orcish.RaceId != 6)
                throw ex;
            if (Nain.RaceId != 7)
                throw ex;
        }

        public static Race Deserialize(GenericReader reader)
        {
            int race = reader.ReadInt();

            if (race == Capiceen.RaceId)
                return new Capiceen(reader);
            if (race == Nordique.RaceId)
                return new Nordique(reader);
            if (race == Nomade.RaceId)
                return new Nomade(reader);
            if (race == Alfar.RaceId)
                return new Alfar(reader);
            if (race == Elfe.RaceId)
                return new Elfe(reader);
            if (race == Orcish.RaceId)
                return new Orcish(reader);
            if (race == Nain.RaceId)
                return new Nain(reader);

            if (race == AucuneRace.RaceId)
                return new AucuneRace(reader);

            throw new Exception(String.Format("Index de race invalide. Index: {0}", race));
        }

        public static void SerializeRace(Race race, GenericWriter writer)
        {
            if (race == null)
            {
                writer.Write(AucuneRace.RaceId);
                new AucuneRace().Serialize(writer);
            }
            else
            {
                writer.Write(race.Id);
                race.Serialize(writer);
            }
        }

        public static Race GetRaceInstance(int raceId)
        {
            switch (raceId)
            {
                case 1: return new Capiceen(0);
                case 2: return new Nordique(0);
                case 3: return new Nomade(0);
                case 4: return new Alfar(0);
                case 5: return new Elfe(0);
                case 6: return new Orcish(0);
                case 7: return new Nain(0);
                default: return null;
            }
        }

        public static void SupprimerSkin(Mobile m)
        {
            RaceSkin skin = m.FindItemOnLayer(Layer.Shirt) as RaceSkin;
            if (skin != null)
                skin.Delete();
        }

        public override string ToString()
        {
            return "...";
        }
    }
}