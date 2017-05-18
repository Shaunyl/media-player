using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Resources;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

using Maths.Graphs;
using Shauni.Database;
using Shauni.Learning;
using Maths.Learning;
using Maths;

namespace Shauni
{
    public enum Space
    {
        None,
        Around,
        Left,
        Right
    }

    public enum Bracket
    {
        Round,
        Square,
        Brace
    }

    public static class Extensions
    {
        public static T[] MinMax<T>(this IEnumerable<T> input)
            where T : new()
        {
            return new T[2] { input.Min(), input.Max() };
        }

        public static Double Normalize(double input, double min, double max)
        {
            if (min == max)
                return 0.5;

            return (input - min) / (max - min);
        }

        public static int Normalize(int input, int min, int max)
        {
            return (input - min) / (max - min);
        }

        public static Byte[] ToByteArray(this String text)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(text);
        }

        public static bool Between(this int value, int left, int right)
        {
            return value >= left && value <= right;
        }

        public static bool Between(this double value, double left, double right)
        {
            return value >= left && value <= right;
        }

        /// <summary>
        /// Returns a string that contains the sequence of all original words splitted by the specified character passed to
        /// aggregated to the specified space pattern.
        /// </summary>
        public static String Halve(this char separator, Space space, params string[] words)
        {
            String sep = String.Empty;

            switch (space)
            {
                case Space.Around: sep = " " + separator + " "; break;
                case Space.Right: sep = separator + " "; break;
                case Space.Left: sep = " " + separator; break;
                default: sep = separator.ToString(); break;
            }

            return words.Aggregate("", (accumulator, word) => accumulator + word + sep).Trim()
               .TrimEnd(new char[] { separator });
        }
        /// <summary>
        /// Returns a string in the specified brackets.
        /// </summary>
        public static String InBrackets(this String instance, Bracket bracket = Bracket.Round)
        {
            switch (bracket)
            {
                case Bracket.Round: return "(" + instance + ")";
                case Bracket.Square: return "[" + instance + "]";
                default: return "{" + instance + "}";
            }
        }

        public static String ToProperCase(this String instance)
        {
            if (String.IsNullOrEmpty(instance))
                return instance;

            return instance.Trim()
               .Split(' ', '_')
               .Where(word => !String.IsNullOrEmpty(word))
               .Select(word => word.Length > 1 ?
                               word.Substring(0, word.FirstLetter()) + Char.ToUpper(word[word.FirstLetter()]) + word.Substring(word.FirstLetter() + 1).ToLower() :
                               word.ToUpper())
               .Aggregate("", (accumulator, word) => accumulator + word + ' ')
               .Trim();
        }

        public static int FirstLetter(this String input)
        {
            Match match = Regex.Match(input, @"[a-zA-Z]");
            return match.Success ? match.Index : 0;
        }
    }

    public static class Utility
    {
        public static T GetEnumValueFromString<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static T GetEnumValueFromDescription<T>(string description)
        {
            MemberInfo[] fis = typeof(T).GetFields();

            foreach (var fi in fis)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0 && attributes[0].Description == description)
                    return (T)Enum.Parse(typeof(T), fi.Name);
            }

            throw new Exception("Not found");
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static void Serialize(this object graph, String filename)
        {
            FileStream writeStream = new FileStream(filename, FileMode.Create);
            new BinaryFormatter().Serialize(writeStream, graph);
            writeStream.Close();
        }

        public static T Deserialize<T>(String filename)
            where T : class
        {
            FileStream readStream = new FileStream(filename, FileMode.Open);
            var readData = (T)new BinaryFormatter().Deserialize(readStream);
            readStream.Close();
            return readData;
        }

        public static String ParseDuration(int duration, string pattern1 = "")
        {
            return (duration / 60).ToString(pattern1) + ":" + (duration % 60).ToString("D2");
        }

        public static void LoadPlugins(Shauni.Forms.MainForm mainForm) //buggato e inutile!
        {
            foreach (Plugin.IPlugin plugin in Shauni.Database.SharedData.PluginManager(mainForm).Plugins.Values)
            {
                if (plugin.AtStartup)
                    plugin.Run();
            }
        }

        public static CultureInfo DetectLanguage(bool log)
        {
            CultureInfo culture = null;

            if (!Shauni.Properties.Settings.Default.AutoLangDetection)
            {
                culture = new CultureInfo(Shauni.Properties.Settings.Default.Language);
                if(log)
                    Shauni.Database.SharedData.Logger.Append("Auto language detection disabled.", 0);
            }
            else
            {
                culture = CultureInfo.CurrentCulture;
                if (log)
                    Shauni.Database.SharedData.Logger.Append("Auto language detection enabled.", 0);
            }

            return culture;
        }

        // get cultures for a specific resource info
        public static IEnumerable<CultureInfo> EnumSatelliteLanguages(string baseName)
        {
            if (baseName == null)
                throw new ArgumentNullException("baseName");

            ResourceManager manager = new ResourceManager(baseName, Assembly.GetExecutingAssembly());
            ResourceSet set = manager.GetResourceSet(CultureInfo.InvariantCulture, true, false);
            if (set != null)
                yield return CultureInfo.InvariantCulture;

            foreach (CultureInfo culture in EnumSatelliteLanguages())
            {
                set = manager.GetResourceSet(culture, true, false);
                if (set != null)
                    yield return culture;
            }
        }

        // determine what assemblies are available
        public static IEnumerable<CultureInfo> EnumSatelliteLanguages()
        {
            foreach (string directory in Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory))
            {
                string name = Path.GetFileNameWithoutExtension(directory); // resource dir don't have an extension...

                // format is XX-YY, we discard directories that can't match.
                // could/should be replaced by a regex but we still need to catch cultures errors...
                if (name.Length > 5)
                    continue;

                CultureInfo culture = null;
                try
                {
                    culture = CultureInfo.GetCultureInfo(name);
                }
                catch
                {
                    // not a good directory...
                    continue;
                }

                string resName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location) + ".resources.dll";

                if (File.Exists(Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, name), resName)))
                    yield return culture;
            }
        }
    }
}
