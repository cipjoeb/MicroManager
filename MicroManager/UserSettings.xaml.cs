using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Interfaces;
using Library;
using MicroManager.ViewModels;

namespace MicroManager
{
    public partial class UserSettings
    {
        public IUserSettingsViewModel ViewModel { get; set; }
        public UserSettings()
        {
            InitializeComponent();
            ViewModel = new UserSettingsViewModel();
            DataContext = ViewModel;
            ViewModel.CloseCommand = new RelayCommand(() =>
            {
                FileHelper.SaveSettings(ViewModel.Settings);
                Close();
            });
        }

        private void UserSettings_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
