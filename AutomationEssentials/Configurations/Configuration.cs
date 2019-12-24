using System.IO;
using System.Reflection;

namespace AutomationEssentials.Configurations
{
    public class Configuration
    {

        public object DesiredCapabilities;
        public object DriverServices;
        public static double PageLoadTimeout = 20000;        
        public string DRIVER_EXE_FOLDER
        {
            get
            {
                return Path.GetFullPath(Path.Combine(Path.GetFullPath(Assembly.GetExecutingAssembly().Location), @"..\..\..\DriverExecutables"));
            }
        }

    }
}
