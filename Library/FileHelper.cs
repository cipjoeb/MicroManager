using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace Library
{
    public class FileHelper
    {
        private readonly string _path = string.Format("{0}\\MicroManager", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

        public bool WriteEntries(ObservableCollection<TimeEntry> entries)
        {
            CheckDirectory();
            var theFile = GetFileName();
            if (File.Exists(theFile)) File.Delete(theFile);    
            var serializer = new JavaScriptSerializer();
            var strings = entries.Select(serializer.Serialize).ToList();
            File.WriteAllLines(theFile, strings);
            return true;
        }

        public List<TimeEntry> GetEntries()
        {
            CheckDirectory();
            var theFile = GetFileName();
            if (!File.Exists(theFile)) return null;
            var lines = File.ReadAllLines(theFile);
            var serializer = new JavaScriptSerializer();
            return lines.Select(serializer.Deserialize<TimeEntry>).ToList();
        }

        private string GetFileName()
        {
            return string.Format("{0}\\{1}.txt", _path, DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private void CheckDirectory()
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
        }
    }
}
