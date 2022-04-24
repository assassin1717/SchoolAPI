using SchoolAPI.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace SchoolAPI.Helpers
{
    public static class Settings
    {
        public static string Secret = GetSecret();

        private static string GetSecret()
        {
            try
            {
                var appRunningPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var appSettingsPath = Path.Combine(appRunningPath, "appsettings.json");
                var fileData = File.ReadAllText(appSettingsPath);
                var json = JsonSerializer.Deserialize<AppSettings>(fileData);
                Console.WriteLine(json.AppConfigs.Auth.Secret);
                return json.AppConfigs.Auth.Secret;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Settings -> GetSecret -> " + ex.Message);
                return string.Empty;
            }
        }
    }
}
