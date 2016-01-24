using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        public ICommand GoOnBreakCommand { get; set; }
        public ICommand BackToWorkCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public string Description { get; set; }
        public ObservableCollection<TimeEntry> TimeEntries { get; set; }
        public string TotalElapsed { get; set; }

        private TimeEntry _entry;
        private readonly FileHelper _fileHelper;

        public MainWindowViewModel()
        {
            _fileHelper = new FileHelper();
            ClockInCommand = new RelayCommand(ClockIn);
            TimeEntries = new ObservableCollection<TimeEntry>();
            var entries = _fileHelper.GetEntries();
            if (entries != null)
                entries.ForEach(e => TimeEntries.Add(e));
            SetElapsed();
        }

        public void Save()
        {
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
            ClockOutCommand = new RelayCommand(ClockOut);
        }

        private void ClockOut()
        {
            ClockOutCommand = null;
            ClockInCommand = new RelayCommand(ClockIn);
            _entry.Stop = DateTime.Now;
            TimeEntries.Add(_entry);
            SetElapsed();
            _entry = null;
        }

        private void SetElapsed()
        {
            var ts = new TimeSpan(0, 0, 0, 0);
            ts = TimeEntries.Aggregate(ts, (current, e) => current.Add(e.Elapsed));
            TotalElapsed =  string.Format("{0} Hours {1} Minutes {2} Seconds", ts.Hours, ts.Minutes, ts.Seconds);
        }
    }
}
