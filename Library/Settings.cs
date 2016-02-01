using System;
using System.Collections.Generic;

namespace Library
{
    public class Settings
    {
        public string Theme { get; set; }
        private readonly List<string> _availableThemes = new List<string> {"Hacker", "Violent"}; 

        public List<string> AvailableThemes
        {
            get { return _availableThemes; }
        }

        private static Settings _instance;

        [Obsolete("DO NOT USE - Constructor is only for serialization.")]
        public Settings()
        {
            
        }

        public static Settings Instance
        {
            get { return _instance ?? (_instance = FileHelper.LoadSettings() ?? new Settings { Theme = "Hacker" }); }
        }
    }
}
