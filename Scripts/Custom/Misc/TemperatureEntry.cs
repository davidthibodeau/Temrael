using System;

namespace Server.Misc
{
    public class TemperatureEntry
    {
        public static Temperature[] GetEntry(Season season, TimeOfDay timeOfDay)
        {
            Temperature[] entry = null;

            switch (season)
            {
                case Season.Spring:
                    {
                        switch (timeOfDay)
                        {
                            case TimeOfDay.Night: entry = m_SpringNight; break;
                            case TimeOfDay.ScaleToDay: entry = m_SpringScaleToDay; break;
                            case TimeOfDay.Day: entry = m_SpringDay; break;
                            case TimeOfDay.ScaleToNight: entry = m_SpringScaleToNight; break;
                        }

                        break;
                    }
                case Season.Summer:
                    {
                        switch (timeOfDay)
                        {
                            case TimeOfDay.Night: entry = m_SummerNight; break;
                            case TimeOfDay.ScaleToDay: entry = m_SummerScaleToDay; break;
                            case TimeOfDay.Day: entry = m_SummerDay; break;
                            case TimeOfDay.ScaleToNight: entry = m_SummerScaleToNight; break;
                        }

                        break;
                    }
                case Season.Automn:
                    {
                        switch (timeOfDay)
                        {
                            case TimeOfDay.Night: entry = m_AutomnNight; break;
                            case TimeOfDay.ScaleToDay: entry = m_AutomnScaleToDay; break;
                            case TimeOfDay.Day: entry = m_AutomnDay; break;
                            case TimeOfDay.ScaleToNight: entry = m_AutomnScaleToNight; break;
                        }

                        break;
                    }
                case Season.Winter:
                    {
                        switch (timeOfDay)
                        {
                            case TimeOfDay.Night: entry = m_WinterNight; break;
                            case TimeOfDay.ScaleToDay: entry = m_WinterScaleToDay; break;
                            case TimeOfDay.Day: entry = m_WinterDay; break;
                            case TimeOfDay.ScaleToNight: entry = m_WinterScaleToNight; break;
                        }

                        break;
                    }
                /*case Season.Abyss:
                    {
                        switch (timeOfDay)
                        {
                            case TimeOfDay.Night: entry = m_AbyssNight; break;
                            case TimeOfDay.ScaleToDay: entry = m_AbyssScaleToDay; break;
                            case TimeOfDay.Day: entry = m_AbyssDay; break;
                            case TimeOfDay.ScaleToNight: entry = m_AbyssScaleToNight; break;
                        }

                        break;
                    }*/
            }

            return entry;
        }

        #region Spring
        private static Temperature[] m_SpringNight = new Temperature[]
            {
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Confortable,
                Temperature.Confortable
            };

        private static Temperature[] m_SpringScaleToDay = new Temperature[]
            {
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Confortable
            };

        private static Temperature[] m_SpringDay = new Temperature[]
            {
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Chaud
            };

        private static Temperature[] m_SpringScaleToNight = new Temperature[]
            {
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Confortable
            };
        #endregion

        #region Summer
        private static Temperature[] m_SummerNight = new Temperature[]
            {
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Chaud,
                Temperature.Chaud,
                Temperature.Chaud,
                Temperature.Torride
            };

        private static Temperature[] m_SummerScaleToDay = new Temperature[]
            {
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Chaud,
                Temperature.Chaud,
                Temperature.Chaud,
                Temperature.Torride,
                Temperature.Torride
            };

        private static Temperature[] m_SummerDay = new Temperature[]
            {
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Chaud,
                Temperature.Chaud,
                Temperature.Chaud,
                Temperature.Torride,
                Temperature.Torride,
                Temperature.Brûlant
            };

        private static Temperature[] m_SummerScaleToNight = new Temperature[]
            {
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Chaud,
                Temperature.Chaud,
                Temperature.Chaud,
                Temperature.Torride,
                Temperature.Torride
            };
        #endregion

        #region Automn
        private static Temperature[] m_AutomnNight = new Temperature[]
            {
                Temperature.Hivernal,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Confortable
            };

        private static Temperature[] m_AutomnScaleToDay = new Temperature[]
            {
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Confortable,
                Temperature.Confortable
            };

        private static Temperature[] m_AutomnDay = new Temperature[]
            {
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Confortable,
                Temperature.Confortable,
                Temperature.Confortable
            };

        private static Temperature[] m_AutomnScaleToNight = new Temperature[]
            {
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Confortable,
                Temperature.Confortable
            };
        #endregion

        #region Winter
        private static Temperature[] m_WinterNight = new Temperature[]
            {
                Temperature.Glacial,
                Temperature.Glacial,
                Temperature.Glacial,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Froid
            };

        private static Temperature[] m_WinterScaleToDay = new Temperature[]
            {
                Temperature.Glacial,
                Temperature.Glacial,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Froid,
                Temperature.Froid
            };

        private static Temperature[] m_WinterDay = new Temperature[]
            {
                Temperature.Glacial,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid
            };

        private static Temperature[] m_WinterScaleToNight = new Temperature[]
            {
                Temperature.Glacial,
                Temperature.Glacial,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Froid,
                Temperature.Froid
            };
        #endregion

        #region Abyss
        private static Temperature[] m_AbyssNight = new Temperature[]
            {
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais
            };

        private static Temperature[] m_AbyssScaleToDay = new Temperature[]
            {
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais
            };

        private static Temperature[] m_AbyssDay = new Temperature[]
            {
                Temperature.Hivernal,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais,
                Temperature.Frais
            };

        private static Temperature[] m_AbyssScaleToNight = new Temperature[]
            {
                Temperature.Hivernal,
                Temperature.Hivernal,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Froid,
                Temperature.Frais,
                Temperature.Frais
            };
        #endregion
    }
}