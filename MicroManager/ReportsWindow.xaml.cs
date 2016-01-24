using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MicroManager.ViewModels;

namespace MicroManager
{
    public partial class ReportsWindow
    {
        public ReportsViewModel ViewModel { get; set; }

        public ReportsWindow()
        {
            InitializeComponent();
            ViewModel = new ReportsViewModel {CloseCommand = new RelayCommand(Close)};
            DataContext = ViewModel;
        }

        private void ReportsWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
