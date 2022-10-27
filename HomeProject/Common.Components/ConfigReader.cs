using System.Configuration;

namespace Common.Components
{
    public static class ConfigReader
    {
        public static string PetStore3BaseUrl => GetValueByKeyFromAppSettings("PetStore3BaseUrl");

        /// <summary>
        /// Get value by key from app.config
        /// </summary>
        /// <param name="key">Key to find</param>
        /// <returns>Value</returns>
        /// <exception cref="ArgumentNullException">Key don't exist in app.config</exception>
        private static string GetValueByKeyFromAppSettings(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(value))
            {
                var message = $"Key: {key} - don't exist in app.config.";
                throw new ArgumentNullException(value, message);
            }

            return value;
        }
    }
}