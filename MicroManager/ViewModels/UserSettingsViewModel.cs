using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Interfaces;
using Library;
using PropertyChanged;

namespace MicroManager.ViewModels
{
    [ImplementPropertyChanged]
    public class UserSettingsViewModel : IUserSettingsViewModel
    {
        public Settings Settings { get; set; }
        public string Theme
        {
            get { return Settings.Theme; }
            set
            {
                Settings.Theme = value;
                var app = (App) Application.Current;
                app.ChangeTheme(Settings.Theme);
                foreach (var window in app.Windows)
                {
                    ((Window)window).UpdateLayout();
                }
            }
        }

        public List<string> Themes { get { return Settings.Instance.AvailableThemes; } }
        public ICommand CloseCommand { get; set; }

        public UserSettingsViewModel()
        {
            Settings = Settings.Instance;
        }
    }
}
