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
    }
}
