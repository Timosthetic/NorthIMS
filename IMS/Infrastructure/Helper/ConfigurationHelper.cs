using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Helper
{
    /// <summary>
    /// 配置文件Appconfig操作
    /// </summary>
    public class ConfigurationHelper
    {
        private static  Logger<ConfigurationHelper> _logger;
        public ConfigurationHelper(Logger<ConfigurationHelper> logger)
        {
            _logger = logger;
        }

        public static Dictionary<string,string> ReadAllSettings()
        {
            Dictionary<string, string> value = new Dictionary<string, string>();
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count != 0)
                {
                    foreach (var key in appSettings.AllKeys)
                    {

                        value.Add(key, appSettings[key]);
                    }
                }
           
            }
            catch (ConfigurationErrorsException)
            {
                _logger.LogError("Error reading app settings");
            }
            return value;
        }

      public  static string ReadSetting(string key)
        {
            string result = "";
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                 result = appSettings[key] ?? "Not Found";
              
            }
            catch (ConfigurationErrorsException)
            {
                _logger.LogError("Error reading app settings");
            }
            return result.Trim();
        }

      public  static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                _logger.LogError("Error writing app settings");
            }
        }
    }
}
