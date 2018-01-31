using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using SC.Common.Helpers;

namespace SC.Common
{
    public static class MainSettings
    {
        public const string DatabaseConnectionStringName = "DefaultConnection";

        public static readonly bool IsProductionMode = (ConfigurationHelper.GetValue<int>("IsProductionMode") == 1);

        public static readonly string UploadFolder = ConfigurationHelper.GetValue<string>("UploadFolder");

        public static readonly CultureInfo CoreDefaulCulture = new CultureInfo("EN-US");

        public static void SetupCulture()
        {
            Thread.CurrentThread.CurrentCulture = CoreDefaulCulture;
            Thread.CurrentThread.CurrentUICulture = CoreDefaulCulture;
        }

        public static string GetRoot()
        {
            var uri = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase);
            var directory = Path.GetDirectoryName(uri.LocalPath);

            return directory;
        }

    }
}
