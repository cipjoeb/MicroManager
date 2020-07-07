using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace Library
{
    public class FileHelper
    {
        public static string GetPath()
        {
            return string.Format("{0}\\MicroManager", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
        }

        public static bool WriteFile(List<string> lines, string fileName)
        {
            var theFile = string.Format("{0}\\{1}", GetPath(), fileName);
            if (File.Exists(theFile))
                File.Delete(theFile);
            File.WriteAllLines(theFile, lines);
            return true;
        }

        public static Settings LoadSettings()
        {
            CheckDirectory();
            var theFile = string.Format("{0}\\Settings.txt", GetPath());
            if (!File.Exists(theFile)) return null;
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<Settings>(File.ReadAllText(theFile));
        }

        public static bool SaveSettings(Settings settings)
        {
            CheckDirectory();
            var theFile = string.Format("{0}\\Settings.txt", GetPath());
            var serializer = new JavaScriptSerializer();
            File.WriteAllText(theFile, serializer.Serialize(settings));
            return true;
        }

        public static bool WriteFile(string text, string fileName)
        {
            var theFile = string.Format("{0}\\{1}", GetPath(), fileName);
            File.WriteAllText(theFile, text);
            return true;
        }

        public bool WriteEntries(ICollection<TimeEntry> entries)
        {
            CheckDirectory();
            var theFile = GetFileName();
            if (File.Exists(theFile)) File.Delete(theFile);    
            var serializer = new JavaScriptSerializer();
            var strings = entries.Select(serializer.Serialize).ToList();
            File.WriteAllLines(theFile, strings);
            return true;
        }

        public List<TimeEntry> GetEntries(string fileName = null)
        {
            CheckDirectory();
            var theFile = string.IsNullOrWhiteSpace(fileName) ? GetFileName() : fileName;
            if (!File.Exists(theFile)) return null;
            var lines = File.ReadAllLines(theFile);
            var serializer = new JavaScriptSerializer();
            var theList = lines.Select(serializer.Deserialize<TimeEntry>).ToList();
            foreach (var entry in theList)
            {
                entry.Start = entry.Start.ToLocalTime();
                entry.Stop = entry.Stop.ToLocalTime();
            }
            return theList;
        }

        private static string GetFileName()
        {
            return string.Format("{0}\\{1}.txt", GetPath(), DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private static void CheckDirectory()
        {
            var path = GetPath();
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }
}
