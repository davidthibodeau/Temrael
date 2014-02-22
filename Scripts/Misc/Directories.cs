using System;
using System.IO;

namespace Server.Misc
{
    public class Directories
    {
        public static readonly string saves = Path.Combine(Core.BaseDirectory, "Saves");
        public static readonly string backups = Path.Combine(Core.BaseDirectory, "Backups");
        public static readonly string logs = Path.Combine(backups, "Logs");
        public static readonly string errors = Path.Combine(backups, "Errors");
        public static readonly string docs = Path.Combine(backups, "Docs");
        public static readonly string bsaves = Path.Combine(backups, "Saves");

        public static string Today { get { return FormatDay(DateTime.Now); } }

        public static string Now { get { return FormatTime(DateTime.Now); } }

        public static void Configure()
        {
            EnsureDirectory(backups);
            EnsureDirectory(logs);
            EnsureDirectory(errors);
            EnsureDirectory(docs);
            EnsureDirectory(bsaves);
        }

        public static void EnsureDirectory( string path )
		{
			if( !Directory.Exists( path ) )
				Directory.CreateDirectory( path );
		}

        public static string AppendPath(string path, string toAppend)
        {
            path = Path.Combine(path, toAppend);
            EnsureDirectory(path);
            return path;
        }

        public static string FormatDay(DateTime timestamp)
        {
            return String.Format("{0:D4}-{1:D2}-{2:D2},{3}", timestamp.Year, timestamp.Month, timestamp.Day, timestamp.DayOfWeek);
        }

        public static string FormatTime(DateTime timestamp)
        {
            return String.Format( "{0:D4}.{1:D2}.{2:D2}-{3:D2}.{4:D2}.{5:D2}",
					timestamp.Year, timestamp.Month, timestamp.Day,	timestamp.Hour,	timestamp.Minute, timestamp.Second);
        }
    }
}
