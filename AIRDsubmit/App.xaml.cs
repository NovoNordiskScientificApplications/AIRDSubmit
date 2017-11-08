using AIRDsubmit.Properties;
using System.Configuration;
using System.Windows;

namespace AIRDsubmit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SettingsManager Settings = new SettingsManager();
    }

    public class SettingsManager
    {
        public string this[string key] => ConfigurationManager.AppSettings[key] ?? Resources.ResourceManager.GetString(key);
    }
}
