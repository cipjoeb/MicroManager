using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Interfaces;
using Library;

namespace MicroManager.ViewModels
{
    class UserSettingsDesignTimeViewModel : IUserSettingsViewModel
    {
        public Settings Settings { get; set; }
        public List<string> Themes { get; private set; }
        public ICommand CloseCommand { get; set; }
        public string Theme { get; set; }

        public UserSettingsDesignTimeViewModel()
        {
            Themes = new List<string> {"Hacker", "Violent"};
            CloseCommand = new RelayCommand(() => { });
            Theme = "Hacker";
        }
    }
}
