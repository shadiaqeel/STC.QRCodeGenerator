using System;
using System.Configuration;
using System.IO;

namespace STC.QRCodeGenerator.Tool
{
    static class AppConfig
    {
        public static string BackgroundImage
        {
            get
            {
                var file = GetAppSetting("BackgroundImage", @$"{AppContext.BaseDirectory}files\Stc_background.jpg");
                if (!File.Exists(file))
                    return string.Empty;
                return file;
            }
        }
        public static string DestinationPath
        {
            get
            {
                var dir = GetAppSetting("DestinationPath", @$"{AppContext.BaseDirectory}output");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }

        public static string ColumnName => GetAppSetting("ColumnName", "Desk");

        public static int HeightQRCode => GetAppSetting("HeightQRCode",220);
        public static int WidthQRCode => GetAppSetting("WidthQRCode", 230);

        private static T GetAppSetting<T>(string key, T defaultValue)
        {
            try
            {
                object value = ConfigurationManager.AppSettings[key];

                if (value == null && typeof(T) == typeof(string))
                    return defaultValue;

                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch { return defaultValue; }

        }
    }
}
