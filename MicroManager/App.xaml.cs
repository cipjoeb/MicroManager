using System;
using System.Windows;
using Library;

namespace MicroManager
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var settings = Settings.Instance;
            ChangeTheme(settings.Theme);
        }

        public void ChangeTheme(string themeName)
        {
            var uri = new Uri(string.Format("/MicroManager;component/Theme/{0}.xaml", themeName), UriKind.Relative);
            var resourceDict = LoadComponent(uri) as ResourceDictionary;
            Current.Resources.MergedDictionaries.Clear();
            Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
