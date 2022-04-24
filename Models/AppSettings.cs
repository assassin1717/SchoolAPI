using Newtonsoft.Json;

namespace SchoolAPI.Models
{
    public class LogLevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }

        [JsonProperty("Microsoft.Hosting.Lifetime")]
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class Http
    {
        public string Url { get; set; }
    }

    public class EndPoints
    {
        public Http Http { get; set; }
    }

    public class Kestrel
    {
        public EndPoints EndPoints { get; set; }
    }

    public class Auth
    {
        public string Secret { get; set; }
    }

    public class AppConfigs
    {
        public Auth Auth { get; set; }
    }

    public class AppSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public Kestrel Kestrel { get; set; }
        public AppConfigs AppConfigs { get; set; }
    }
}
