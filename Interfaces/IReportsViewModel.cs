using System.Windows.Input;

namespace Interfaces
{
    public interface IReportsViewModel
    {
        ICommand ChooseFilesCommand { get; set; }
        ICommand PrintReportCommand { get; set; }
        ICommand CloseCommand { get; set; }
        string ReportText { get; set; }
    }
}