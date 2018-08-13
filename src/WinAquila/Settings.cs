using System.ComponentModel;
using System.Configuration;
using System.Linq;

namespace WinAquila
{
    public class Settings
    {
        public const string SECTION_NAME = "aquila";

        [Bindable(true)]
        public string TrackerId { get; set; }

        [Bindable(true)]
        public string UserAgent { get; set; }

        public void Load()
        {
            System.Configuration.AppSettingsSection section = null;
            var configFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location), "aquila.config");
            if (System.IO.File.Exists(configFileName))
            {
                var map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = configFileName;
                var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                section = config.GetSection(SECTION_NAME) as System.Configuration.AppSettingsSection;
            }
            else
            {
                section = new System.Configuration.AppSettingsSection();
            }

            if (section.Settings.AllKeys.Contains("trackerId"))
            {
                TrackerId = section.Settings["trackerId"].Value;
            }
            else
            {
                TrackerId = "UA-XXXXX-Y";
            }
        }

        public void SaveSettings()
        {
            var configFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location), "aquila.config");
            var fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = configFileName
            };

            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var section = config.GetSection(SECTION_NAME) as System.Configuration.AppSettingsSection;
            if (section == null)
            {
                section = new System.Configuration.AppSettingsSection();
                config.Sections.Add(SECTION_NAME, section);
            }

            if (section.Settings.AllKeys.Contains("trackerId"))
            {
                section.Settings["trackerId"].Value = TrackerId;
            }
            else
            {
                section.Settings.Add("trackerId", TrackerId);
            }

            config.Save(ConfigurationSaveMode.Minimal);
        }
    }
}