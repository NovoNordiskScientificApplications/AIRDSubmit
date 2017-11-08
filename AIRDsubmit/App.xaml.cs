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
        public string this[string key]
        {
            get { return ConfigurationManager.AppSettings[key] ?? Resources.ResourceManager.GetString(key); }
            set
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                    settings.Add(key, value);
                else
                    settings[key].Value = value;
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
        }
    }
}
