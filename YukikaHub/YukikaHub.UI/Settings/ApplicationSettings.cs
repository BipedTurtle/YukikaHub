using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukikaHub.UI.Settings
{
    public static class ApplicationSettings
    {
        public static event Action<ApplicationMode> ModeChanged;
        public static void RaiseModeChanged(ApplicationMode newMode)
        {
            ModeChanged?.Invoke(newMode);
        }
    } 

    public enum ApplicationMode
    {
        Developer,
        User
    }
}

