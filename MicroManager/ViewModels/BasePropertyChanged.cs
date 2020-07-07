using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MicroManager.ViewModels
{
    public class BasePropertyChanged : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void PropertiesChanged(List<string> propertyNames)
        {
            propertyNames.ForEach(OnPropertyChanged);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
