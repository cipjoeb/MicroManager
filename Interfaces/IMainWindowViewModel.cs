using System.Collections.ObjectModel;
using System.Windows.Input;
using Library;

namespace Interfaces
{
    public interface IMainWindowViewModel
    {
        ICommand ClockInCommand { get; set; }
        ICommand ClockOutCommand { get; set; }
        ICommand ChangeTaskCommand { get; set; }
        ICommand CloseCommand { get; set; }
        string Description { get; set; }
        ObservableCollection<TimeEntry> TimeEntries { get; set; }
        string TotalElapsed { get; set; }
        void Save();
    }
}