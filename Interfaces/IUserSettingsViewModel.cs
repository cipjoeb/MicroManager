using System;
using System.Collections.Generic;
using System.Windows.Input;
using Library;

namespace Interfaces
{
    public interface IUserSettingsViewModel
    {
        Settings Settings { get; set; }
        List<string> Themes { get; }
        ICommand CloseCommand { get; set; }
        string Theme { get; set; }
    }
}