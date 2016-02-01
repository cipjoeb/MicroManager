using System.Windows.Input;
using Library;

namespace Interfaces
{
    public interface IReportsViewModel
    {
        ICommand ChooseFilesCommand { get; set; }
        ICommand PrintReportCommand { get; set; }
        ICommand CloseCommand { get; set; }
        Settings Settings { get; set; }
        string ReportText { get; set; }
    }
}