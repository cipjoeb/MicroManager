using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Interfaces;
using Library;
using PropertyChanged;

namespace MicroManager.ViewModels
{
    [ImplementPropertyChanged]
    public class MainWindowViewModel : IMainWindowViewModel
    {
        public ICommand ClockInCommand { get; set; }
        public ICommand ClockOutCommand { get; set; }
        public ICommand ChangeTaskCommand { get; set; }
        public ICommand ReportsCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }
        public Settings Settings { get; set; }
        public string Description { get; set; }
        public ObservableCollection<TimeEntry> TimeEntries { get; set; }
        public string TotalElapsed { get; set; }

        private TimeEntry _entry;
        private readonly FileHelper _fileHelper;

        public MainWindowViewModel()
        {
            Settings = Settings.Instance;
            _fileHelper = new FileHelper();
            ClockInCommand = new RelayCommand(ClockIn);
            ReportsCommand = new RelayCommand(Reports);
            SettingsCommand = new RelayCommand(ShowSettings);
            TimeEntries = new ObservableCollection<TimeEntry>();
            new Thread(() =>
            {
                var entries = _fileHelper.GetEntries();
                if (entries != null)
                    entries.ForEach(e => TimeEntries.Add(e));
                SetElapsed();
            }){IsBackground = true}.Start();
        }

        private static void ShowSettings()
        {
            var dlg = new UserSettings();
            dlg.ShowDialog();
        }

        private static void Reports()
        {
            var dlg = new ReportsWindow();
            dlg.ShowDialog();
        }

        public void Save()
        {
            if(ClockInCommand == null)
                ClockOut();
            _fileHelper.WriteEntries(TimeEntries);
        }

        private void ClockIn()
        {
            ClockInCommand = null;
            _entry = new TimeEntry
            {
                Start = DateTime.Now,
                Description = Description
            };
            ChangeTaskCommand = new RelayCommand(ChangeTask);
            ClockOutCommand = new RelayCommand(ClockOut);
        }

        private void ClockOut()
        {
            ClockOutCommand = null;
            ChangeTaskCommand = null;
            ClockInCommand = new RelayCommand(ClockIn);
            _entry.Stop = DateTime.Now;
            TimeEntries.Add(_entry);
            SetElapsed();
            _entry = null;
        }

        private void ChangeTask()
        {
            ClockOut();
            ClockIn();
        }

        private void SetElapsed()
        {
            var ts = new TimeSpan(0, 0, 0, 0);
            ts = TimeEntries.Aggregate(ts, (current, e) => current.Add(e.Elapsed));
            TotalElapsed =  string.Format("{0} Hours {1} Minutes {2} Seconds", ts.Hours, ts.Minutes, ts.Seconds);
        }
    }
}
